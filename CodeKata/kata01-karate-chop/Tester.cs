namespace kata01_karate_chop
{
    using System;
    using System.Collections;

    using NUnit.Framework;

    [TestFixture]
    public class Tester
    {
        [Test, TestCaseSource(typeof(Kata01TastCaseData), nameof(Kata01TastCaseData.TestCases))]
        public int Chop(int integer, int[] arrayOfIntegers)
        {
            var result = -1;

            if (arrayOfIntegers == null || arrayOfIntegers.Length == 0)
            {
                return result;
            }

            const int StartOfSearch = 0;
            result = this.Chop(integer, arrayOfIntegers, StartOfSearch, result);

            return result;
        }

        private int Chop(int integer, int[] arrayOfIntegers, int startOfSearch, int result)
        {

            var length = arrayOfIntegers.Length;
            var maxIndex = length - 1;

            var chopPoint = (decimal)(((decimal)maxIndex - (decimal)startOfSearch) / 2);

            var chopIndex = (int)Math.Round(chopPoint, 0, MidpointRounding.AwayFromZero);

            for (var i = startOfSearch; i <= chopIndex; i++)
            {
                if (arrayOfIntegers[i] != integer)
                {
                    continue;
                }

                result = i;
                return result;
            }

            if (maxIndex > chopIndex)
            {
                this.Chop(integer, arrayOfIntegers, chopIndex, result);
            }

            return result;
        }
    }

    public class Kata01TastCaseData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(3, new int[] { }).Returns(-1);
                yield return new TestCaseData(3, new[] { 1 }).Returns(-1);
                yield return new TestCaseData(1, new[] { 1 }).Returns(0);
                yield return new TestCaseData(1, new[] { 1, 3, 5 }).Returns(0);
                yield return new TestCaseData(3, new[] { 1, 3, 5 }).Returns(1);
                yield return new TestCaseData(5, new[] { 1, 3, 5 }).Returns(2);
                yield return new TestCaseData(0, new[] { 1, 3, 5 }).Returns(-1);
                yield return new TestCaseData(2, new[] { 1, 3, 5 }).Returns(-1);
                yield return new TestCaseData(4, new[] { 1, 3, 5 }).Returns(-1);
                yield return new TestCaseData(6, new[] { 1, 3, 5 }).Returns(-1);
                yield return new TestCaseData(1, new[] { 1, 3, 5, 7 }).Returns(0);
                yield return new TestCaseData(3, new[] { 1, 3, 5, 7 }).Returns(1);
                yield return new TestCaseData(5, new[] { 1, 3, 5, 7 }).Returns(2);
                yield return new TestCaseData(7, new[] { 1, 3, 5, 7 }).Returns(3);
                yield return new TestCaseData(0, new[] { 1, 3, 5, 7 }).Returns(-1);
                yield return new TestCaseData(2, new[] { 1, 3, 5, 7 }).Returns(-1);
                yield return new TestCaseData(4, new[] { 1, 3, 5, 7 }).Returns(-1);
                yield return new TestCaseData(6, new[] { 1, 3, 5, 7 }).Returns(-1);
                yield return new TestCaseData(8, new[] { 1, 3, 5, 7 }).Returns(-1);
            }
        }
    }

}
