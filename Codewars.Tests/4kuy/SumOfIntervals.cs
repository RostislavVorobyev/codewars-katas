﻿using NUnit.Framework;

using Interval = System.ValueTuple<int, int>;
namespace Codewars.Tests
{
    public class SumOfunderTestTests
    {
        private readonly SumOfIntervals underTest = new SumOfIntervals();

        [Test]
        public void ShouldHandleEmptySumOfIntervals()
        {
            Assert.AreEqual(0, underTest.SumIntervals(new Interval[] { }));
            Assert.AreEqual(0, underTest.SumIntervals(new Interval[] { (4, 4), (6, 6), (8, 8) }));
        }

        [Test]
        public void ShouldAddDisjoinedSumOfIntervals()
        {
            Assert.AreEqual(9, underTest.SumIntervals(new Interval[] { (1, 2), (6, 10), (11, 15) }));
            Assert.AreEqual(11, underTest.SumIntervals(new Interval[] { (4, 8), (9, 10), (15, 21) }));
            Assert.AreEqual(7, underTest.SumIntervals(new Interval[] { (-1, 4), (-5, -3) }));
            Assert.AreEqual(78, underTest.SumIntervals(new Interval[] { (-245, -218), (-194, -179), (-155, -119) }));
        }

        [Test]
        public void ShouldAddAdjacentSumOfIntervals()
        {
            Assert.AreEqual(54, underTest.SumIntervals(new Interval[] { (1, 2), (2, 6), (6, 55) }));
            Assert.AreEqual(23, underTest.SumIntervals(new Interval[] { (-2, -1), (-1, 0), (0, 21) }));
        }

        [Test]
        public void ShouldAddOverlappingSumOfIntervals()
        {
            Assert.AreEqual(7, underTest.SumIntervals(new Interval[] { (1, 4), (7, 10), (3, 5) }));
            Assert.AreEqual(6, underTest.SumIntervals(new Interval[] { (5, 8), (3, 6), (1, 2) }));
            Assert.AreEqual(19, underTest.SumIntervals(new Interval[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
        }

        [Test]
        public void ShouldHandleMixedSumOfIntervals()
        {
            Assert.AreEqual(13, underTest.SumIntervals(new Interval[] { (2, 5), (-1, 2), (-40, -35), (6, 8) }));
            Assert.AreEqual(1234, underTest.SumIntervals(new Interval[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) }));
            Assert.AreEqual(158, underTest.SumIntervals(new Interval[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) }));
        }

        [Test]
        public void ShouldHandleLargeunderTest()
        {
            Assert.AreEqual(2_000_000_000, underTest.SumIntervals(new Interval[] { (-1_000_000_000, 1_000_000_000) }));
            Assert.AreEqual(100_000_030, underTest.SumIntervals(new Interval[] { (0, 20), (-100_000_000, 10), (30, 40) }));
        }
    }
}
