using System;

namespace Codewars
{
    public class LetsPlayDarts
    {

        const double BULLS_EYE_RANGE = 6.35;
        const double BULL_RANGE = 15.9;
        const double TRIPLE_RING_INNER_RANGE = 99;
        const double TRIPLE_RING_OUTER_RANGE = 107;
        const double DOBULE_RING_INNER_RANGE = 162;
        const double DOUBLE_RING_OUTER_RANGE = 170;

        const string OUT_RESULT = "X";
        const string BULLS_EYE_RESULT = "DB";
        const string BULLS_RESULT = "SB";
        const string TRIPPLE_RESULT = "T";
        const string DOUBLE_RESULT = "D";

        readonly int[,] QUARTER_VALUES = new int[4, 6] { { 20, 1, 18, 4, 13, 6 }, { 11, 14, 9, 12, 5, 20 }, { 11, 8, 16, 7, 19, 3 }, { 6, 10, 15, 2, 17, 3 } };

        public string GetScore(double x, double y)
        {
            var range = GetRange(x, y);
            var rangeResult = GetRangeResult(range);

            if (IsBullOrOut(rangeResult))
            {
                return rangeResult;
            }

            var angle = GetAngle(x, y);

            var sector = GetSectorOrder(angle);

            var quarter = GetQuarter(x, y);

            int hitValue = GetHitValue(sector, quarter);

            return $"{rangeResult}{hitValue}";
        }

        private int GetHitValue(int sector, int quarter)
        {
            return QUARTER_VALUES[quarter, sector];
        }

        private int GetQuarter(double x, double y)
        {
            if (x < 0)
            {
                return y > 0 ? 1 : 2;
            }
            else
            {
                return y > 0 ? 0 : 3;
            }
        }

        private int GetSectorOrder(double angle)
        {
            if (angle < 9)
            {
                return 0;
            }
            else if (angle > 81)
            {
                return 5;
            }

            return (int)(angle - 9) / 18 + 1;
        }

        private bool IsBullOrOut(string rangeResult) => rangeResult is OUT_RESULT or BULLS_EYE_RESULT or BULLS_RESULT;

        private string GetRangeResult(double range)
        {
            switch (range)
            {
                case < BULLS_EYE_RANGE:
                    return BULLS_EYE_RESULT;
                case < BULL_RANGE:
                    return BULLS_RESULT;
                case > TRIPLE_RING_INNER_RANGE and < TRIPLE_RING_OUTER_RANGE:
                    return TRIPPLE_RESULT;
                case > DOBULE_RING_INNER_RANGE and < DOUBLE_RING_OUTER_RANGE:
                    return DOUBLE_RESULT;
                case > DOUBLE_RING_OUTER_RANGE:
                    return OUT_RESULT;
                default:
                    return string.Empty;
            }
        }

        private double GetRange(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        private double GetAngle(double x, double y) => Math.Atan(Math.Abs(y) / Math.Abs(x)) * 180 / Math.PI;
    }
}
