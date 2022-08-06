using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Tests
{
    [TestFixture]
    public class TexasHoldemHandsTests
    {
        private static TexasHoldemHands _texasHoldemHands;

        [SetUp]
        public void SetUp()
        {
            _texasHoldemHands = new TexasHoldemHands();
        }

        private static IEnumerable<TestCaseData> getHandTypetestCases
        {
            get
            {
                yield return new TestCaseData(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }).Returns("nothing");
                yield return new TestCaseData("camelCasingTest").Returns("camel Casing Test");
            }
        }

        [TestCase(new[] { "8♠", "6♠" }, new[] { "7♠", "5♠", "9♠", "J♠", "10♠" }, ExpectedResult = new[] { "J", "10", "9", "8", "7" })]
        [TestCase(new[] { "J♣", "7♣" }, new[] { "6♣", "8♣", "5♣", "4♣", "3♣" }, ExpectedResult = new[] { "8", "7", "6", "5", "4" })]
        public string[] CheckForStraightFlushTestsReturnCombinationIfPlayerHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForStraightFlush(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new string[0])]
        public string[] CheckForStraightFlushTestsReturnEmptyArrayIfPlayerDontHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForStraightFlush(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "2♠", "3♦" }, new[] { "2♣", "2♥", "3♠", "3♥", "2♦" }, ExpectedResult = new[] { "2", "3" })]
        [TestCase(new[] { "A♠", "A♦" }, new[] { "A♣", "A♥", "K♠", "3♥", "2♦" }, ExpectedResult = new[] { "A", "K" })]
        [TestCase(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new string[0])]
        public string[] CheckForFourOfAKindReturnCombinationIfPlayerHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForFourOfAKind(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "4♠", "9♦" }, new[] { "J♣", "Q♥", "Q♠", "2♥", "Q♦" }, ExpectedResult = new[] { "Q", "J", "9" })]
        [TestCase(new[] { "Q♠", "A♦" }, new[] { "J♣", "Q♥", "4♠", "2♥", "Q♦" }, ExpectedResult = new[] { "Q", "A", "J" })]
        [TestCase(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new string[0])]
        public string[] CheckForThreeOfAKindReturnCombinationIfPlayerHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForThreeOfAKind(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "K♠", "Q♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new[] { "Q", "K", "J", "9" })]
        [TestCase(new[] { "A♠", "A♦" }, new[] { "J♣", "5♥", "4♠", "2♥", "Q♦" }, ExpectedResult = new[] { "A", "Q", "J", "5" })]
        [TestCase(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new string[0])]
        public string[] CheckForPairReturnCombinationIfPlayerHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForPair(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "A♠", "K♦" }, new[] { "J♥", "5♥", "10♥", "Q♥", "3♥" }, ExpectedResult = new[] { "Q", "J", "10", "5", "3" })]
        [TestCase(new[] { "8♠", "6♠" }, new[] { "7♠", "5♠", "9♠", "J♠", "10♠" }, ExpectedResult = new[] { "J", "10", "9", "8", "7" })]
        public string[] CheckForFlushReturnCombinationIfPlayerHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForFlush(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new string[0])]
        public string[] CheckForFlushReturnEmptyArrayIfPlayerDontHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForFlush(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "Q♠", "2♦" }, new[] { "J♣", "10♥", "9♥", "K♥", "3♦" }, ExpectedResult = new[] { "K", "Q", "J", "10", "9" })]
        [TestCase(new[] { "8♠", "6♠" }, new[] { "7♠", "5♠", "9♠", "J♠", "10♠" }, ExpectedResult = new[] { "J", "10", "9", "8", "7" })]
        public string[] CheckForStraightReturnCombinationIfPlayerHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForStraight(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new string[0])]
        public string[] CheckForStraightReturnEmptyArrayIfPlayerDontHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForStraight(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "A♠", "A♦" }, new[] { "K♣", "K♥", "A♥", "Q♥", "3♦" }, ExpectedResult = new[] { "A", "K" })]
        [TestCase(new[] { "A♠", "A♦" }, new[] { "K♣", "K♥", "A♥", "Q♥", "K♦" }, ExpectedResult = new[] { "A", "K" })]
        [TestCase(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new string[0])]
        public string[] CheckForFullHouseReturnCombinationIfPlayerHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForFullHouse(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "K♠", "J♦" }, new[] { "J♣", "K♥", "9♥", "2♥", "3♦" }, ExpectedResult = new[] { "K", "J", "9" })]
        [TestCase(new[] { "K♠", "J♦" }, new[] { "Q♣", "Q♥", "9♥", "2♥", "2♦" }, ExpectedResult = new[] { "Q", "2", "K" })]
        [TestCase(new[] { "K♠", "J♦" }, new[] { "J♣", "K♥", "9♥", "2♥", "2♦" }, ExpectedResult = new[] { "K", "J", "9" })]
        [TestCase(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new string[0])]

        public string[] CheckForTwoPairReturnCombinationIfPlayerHaveIt(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForTwoPairs(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase(new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" }, ExpectedResult = new[] { "A", "K", "Q", "J", "9" })]
        public string[] CheckForKickerReturnCombination(string[] hole, string[] community)
        {
            return _texasHoldemHands.CheckForKicker(hole, community).Select(x => x.Name).ToArray();
        }

        [TestCase("K♠", "K", 13, "♠")]
        [TestCase("2♦", "2", 2, "♦")]
        [TestCase("J♣", "J", 11, "♣")]
        [TestCase("A♥", "A", 14, "♥")]
        public void ToCardShouldConvertValidInput(string cardString, string cardValue, int expectedValue, string expectedSuit)
        {
            var result = _texasHoldemHands.ToCard(cardString);

            Assert.AreEqual(expectedValue, result.CardValue);
            Assert.AreEqual(cardValue, result.Name);
            Assert.AreEqual(expectedSuit, result.SuitSign);
        }

        [TestCase("nothing", new[] { "A", "K", "Q", "J", "9" }, new[] { "K♠", "A♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" })]
        [TestCase("pair", new[] { "Q", "K", "J", "9" }, new[] { "K♠", "Q♦" }, new[] { "J♣", "Q♥", "9♥", "2♥", "3♦" })]
        [TestCase("two pair", new[] { "K", "J", "9" }, new[] { "K♠", "J♦" }, new[] { "J♣", "K♥", "9♥", "2♥", "3♦" })]
        [TestCase("three-of-a-kind", new[] { "Q", "J", "9" }, new[] { "4♠", "9♦" }, new[] { "J♣", "Q♥", "Q♠", "2♥", "Q♦" })]
        [TestCase("straight", new[] { "K", "Q", "J", "10", "9" }, new[] { "Q♠", "2♦" }, new[] { "J♣", "10♥", "9♥", "K♥", "3♦" })]
        [TestCase("flush", new[] { "Q", "J", "10", "5", "3" }, new[] { "A♠", "K♦" }, new[] { "J♥", "5♥", "10♥", "Q♥", "3♥" })]
        [TestCase("full house", new[] { "A", "K" }, new[] { "A♠", "A♦" }, new[] { "K♣", "K♥", "A♥", "Q♥", "3♦" })]
        [TestCase("four-of-a-kind", new[] { "2", "3" }, new[] { "2♠", "3♦" }, new[] { "2♣", "2♥", "3♠", "3♥", "2♦" })]
        [TestCase("straight-flush", new[] { "J", "10", "9", "8", "7" }, new[] { "8♠", "6♠" }, new[] { "7♠", "5♠", "9♠", "J♠", "10♠" })]
        public void TestHand(string type, string[] ranks, string[] holeCards, string[] communityCards)
        {
            var result = _texasHoldemHands.Hand(holeCards, communityCards);

            Assert.AreEqual(type, result.type);
            Assert.AreEqual(ranks, result.ranks);
        }

    }
}
