/*
 * Texas Hold'em Hands: https://www.codewars.com/kata/524c74f855025e2495000262
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    public class TexasHoldemHands
    {

        public (string type, string[] ranks) Hand(string[] holeCards, string[] communityCards)
        {
            var KickerChecker = new CombinationChecker(HandType.Nothing, CheckForKicker, null);
            var PairChecker = new CombinationChecker(HandType.Pair, CheckForPair, KickerChecker);
            var TwoPairsChecker = new CombinationChecker(HandType.TwoPairs, CheckForTwoPairs, PairChecker);
            var ThreeOfAKindChecker = new CombinationChecker(HandType.ThreeOfAKind, CheckForThreeOfAKind, TwoPairsChecker);
            var StraightChecker = new CombinationChecker(HandType.Straight, CheckForStraight, ThreeOfAKindChecker);
            var FlushChecker = new CombinationChecker(HandType.Flush, CheckForFlush, StraightChecker);
            var FullHouseChecker = new CombinationChecker(HandType.FullHouse, CheckForFullHouse, FlushChecker);
            var FourOfAKindChecker = new CombinationChecker(HandType.FourOfAKind, CheckForFourOfAKind, FullHouseChecker);
            var StraightFlushChecker = new CombinationChecker(HandType.StraightFlush, CheckForStraightFlush, FourOfAKindChecker);

            return StraightFlushChecker.GetHandType(holeCards, communityCards);
        }

        public Card[] CheckForKicker(string[] holeCards, string[] communityCards)
        {
            var playableCards = holeCards.Concat(communityCards).Select(x => ToCard(x));

            return playableCards.OrderByDescending(x => x.CardValue).Take(5).ToArray();
        }

        public Card[] CheckForTwoPairs(string[] holeCards, string[] communityCards)
        {
            var playableCards = holeCards.Concat(communityCards).Select(x => ToCard(x));

            var pairGroups = playableCards.GroupBy(x => x.CardValue).Where(x => x.Count() == 2);

            if (pairGroups.Count() < 2)
            {
                return Array.Empty<Card>();
            }

            var twoPairCombination = pairGroups.OrderByDescending(x => x.Key).Take(2).Select(x => x.First());

            var twoPairsKicker = playableCards
                .Where(x => !twoPairCombination.Select(x => x.Name).Contains(x.Name))
                .OrderByDescending(x => x.CardValue)
                .First();

            return twoPairCombination.Append(twoPairsKicker).ToArray();
        }

        public Card[] CheckForFullHouse(string[] holeCards, string[] communityCards)
        {
            var playableCards = holeCards.Concat(communityCards).Select(x => ToCard(x));

            var threeOfAKindCards = CheckForThreeOfAKind(holeCards, communityCards);

            if (!threeOfAKindCards.Any())
            {
                return Array.Empty<Card>();
            }

            var restOfCards = playableCards.Where(x => x.Name != threeOfAKindCards.First().Name);

            if (restOfCards.GroupBy(x => x.Name).Where(x => x.Count() == 3).Any())
            {
                var anotherThreeOfAKindOccurrence = restOfCards.GroupBy(x => x.Name).OrderByDescending(x => x.Count()).First().ToArray();

                return new[] { threeOfAKindCards[0], anotherThreeOfAKindOccurrence[0] }.OrderByDescending(x => x.CardValue).ToArray();
            }

            var pairCards = CheckForPair(holeCards, communityCards);

            if (!pairCards.Any())
            {
                return Array.Empty<Card>();
            }

            return new[] { threeOfAKindCards[0], pairCards[0] };
        }

        public Card[] CheckForStraightFlush(string[] holeCards, string[] communityCards)
        {
            var playableCards = holeCards.Concat(communityCards).Select(x => ToCard(x));

            var flushCards = playableCards.GroupBy(x => x.SuitSign).Where(x => x.Count() >= 5);


            if (flushCards.Any())
            {
                return CheckForStraight(Array.Empty<string>(), flushCards.First().ToArray().Select(x => $"{x.Name}{x.SuitSign}").ToArray());
            }

            return Array.Empty<Card>();
        }

        public Card[] CheckForFourOfAKind(string[] holeCards, string[] communityCards)
        {
            return CheckForNOfAKind(holeCards, communityCards, 4);
        }

        public Card[] CheckForThreeOfAKind(string[] holeCards, string[] communityCards)
        {
            return CheckForNOfAKind(holeCards, communityCards, 3);
        }

        public Card[] CheckForPair(string[] holeCards, string[] communityCards)
        {
            return CheckForNOfAKind(holeCards, communityCards, 2);
        }

        private Card[] CheckForNOfAKind(string[] holeCards, string[] communityCards, int cardsInCombination)
        {
            var playableCards = holeCards.Concat(communityCards).Select(x => ToCard(x));

            var cardGroups = playableCards.GroupBy(x => x.CardValue);

            var nOfAKind = cardGroups.Where(x => x.Count() == cardsInCombination);

            if (!nOfAKind.Any())
            {
                return Array.Empty<Card>();
            }

            var NOfAKindCardsValue = nOfAKind.Select(x => x.First()).OrderByDescending(x => x.CardValue).First();

            int kikcerSize = 5 - cardsInCombination;

            var kicker = playableCards.Where(x => x.CardValue != NOfAKindCardsValue.CardValue).OrderByDescending(x => x.CardValue).Take(kikcerSize);

            return kicker.Prepend(NOfAKindCardsValue).ToArray();
        }

        public Card[] CheckForStraight(string[] holeCards, string[] communityCards)
        {
            var playableCards = communityCards.Concat(holeCards).Select(x => ToCard(x)).OrderByDescending(x => x.CardValue);

            var straightCards = new LinkedList<Card>();

            foreach (var card in playableCards)
            {
                if (straightCards.Count == 0 || straightCards.Last.Value.CardValue == card.CardValue + 1)
                {
                    straightCards.AddLast(card);

                    if (straightCards.Count == 5)
                    {
                        break;
                    }
                }
                else if (straightCards.Last.Value.CardValue > card.CardValue + 1)
                {
                    straightCards.Clear();
                    straightCards.AddLast(card);
                }
            }

            if (straightCards.Count != 5)
            {
                return Array.Empty<Card>();
            }

            return straightCards.ToArray();
        }

        public Card[] CheckForFlush(string[] holeCards, string[] communityCards)
        {
            var suitGroups = communityCards.Concat(holeCards).Select(x => ToCard(x)).GroupBy(x => x.SuitSign);

            IEnumerable<Card> flushCards = new List<Card>();

            foreach (var suitGroup in suitGroups)
            {
                if (suitGroup.Count() >= 5)
                {
                    flushCards = suitGroup.OrderByDescending(x => x.CardValue).Take(5).ToList();
                }
            }

            if (!flushCards.Any())
            {
                return Array.Empty<Card>();
            }

            return flushCards.ToArray();
        }

        public Card ToCard(string cardString)
        {
            string suitPart = cardString[^1].ToString();
            string valuePart = cardString.Replace(suitPart, "");

            return new Card(suitPart, valuePart);
        }
    }

    public class Card
    {
        private string _suit;
        private string _value;

        public Card(string suit, string value)
        {
            _suit = suit;
            _value = value;
        }

        public string Name => $"{_value}";
        public string SuitSign => $"{_suit}";
        public int CardValue => (_value) switch
        {
            "J" => 11,
            "Q" => 12,
            "K" => 13,
            "A" => 14,
            _ => Convert.ToInt32(_value)
        };
    }
    public static class HandType
    {
        public const string StraightFlush = "straight-flush";
        public const string FourOfAKind = "four-of-a-kind";
        public const string FullHouse = "full house";
        public const string Flush = "flush";
        public const string Straight = "straight";
        public const string ThreeOfAKind = "three-of-a-kind";
        public const string TwoPairs = "two pair";
        public const string Pair = "pair";
        public const string Nothing = "nothing";
    }

    public class CombinationChecker
    {
        public string HandType { get; set; }
        public Func<string[], string[], Card[]> CombinationCheck { get; set; }
        public CombinationChecker NextCombinationCheker { get; set; }

        public CombinationChecker(string handType, Func<string[], string[], Card[]> combinationCheck, CombinationChecker nextCombinationCheker)
        {
            HandType = handType;
            CombinationCheck = combinationCheck;
            NextCombinationCheker = nextCombinationCheker;
        }

        public (string type, string[] ranks) GetHandType(string[] holeCards, string[] communityCards)
        {
            var combination = CombinationCheck(holeCards, communityCards);

            if (!combination.Any())
            {
                return NextCombinationCheker.GetHandType(holeCards, communityCards);
            }

            return (HandType, combination.Select(x => x.Name).ToArray());
        }
    }
}
