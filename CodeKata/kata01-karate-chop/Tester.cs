namespace kata01_karate_chop
{
    using System;
    using System.Collections;

    using NUnit.Framework;

    [TestFixture]
    public class Tester
    {
        private const int NotFound = -1;

        [Test, TestCaseSource(typeof(Kata01TastCaseData), nameof(Kata01TastCaseData.TestCases))]
        public int Chopv3(int integer, int[] arrayOfIntegers)
        {
            if (arrayOfIntegers == null || arrayOfIntegers.Length == 0)
            {
                return NotFound;
            }

            return this.Chop(integer, arrayOfIntegers, arrayOfIntegers.Length);
        }

        private int Chop(int integer, int[] arrayOfIntegers, int arrayLength, int lastChopEnd = 0)
        {
            int maxPosition = arrayLength - 1;
            int chopStart = lastChopEnd;
            int maxChopLength = maxPosition - chopStart;
            double midChopPosition = (double)maxChopLength / 2;

            int chopEnd = (int)Math.Round(midChopPosition, MidpointRounding.AwayFromZero);

            for (int position = chopStart; position <= chopEnd; position++)
            {
                if (arrayOfIntegers[position] == integer)
                {
                    return position;
                }
            }

            if (chopEnd < maxPosition)
            {
                return this.Chop(integer, arrayOfIntegers, arrayLength, chopEnd);
            }

            return NotFound;
        }

        //public int Chopv2(int integer, int[] arrayOfIntegers)
        //{
        //    if (arrayOfIntegers == null || arrayOfIntegers.Length == 0)
        //    {
        //        return NotFound;
        //    }

        //    return this.Chop(integer, arrayOfIntegers, arrayOfIntegers.Length);
        //}

        //private int Chopv2(int integer, int[] arrayOfIntegers, int arrayLength, int lastChopEnd = 0)
        //{
        //    int maxPosition = arrayLength - 1;
        //    int chopStart = lastChopEnd;
        //    int maxChopLength = maxPosition - chopStart;
        //    double midChopPosition = (double)maxChopLength / 2;

        //    int chopEnd = (int)Math.Round(midChopPosition, MidpointRounding.AwayFromZero);

        //    for (int position = chopStart; position <= chopEnd; position++)
        //    {
        //        if (arrayOfIntegers[position] == integer)
        //        {
        //            return position;
        //        }
        //    }

        //    if (chopEnd < maxPosition)
        //    {
        //        return this.Chop(integer, arrayOfIntegers, arrayLength, chopEnd);
        //    }

        //    return NotFound;
        //}

        //public int Chopv1(int integer, int[] arrayOfIntegers)
        //{
        //    var result = -1;

        //    if (arrayOfIntegers == null || arrayOfIntegers.Length == 0)
        //    {
        //        return result;
        //    }

        //    const int StartOfSearch = 0;
        //    result = this.Chop(integer, arrayOfIntegers, StartOfSearch, result);

        //    return result;
        //}

        //private int Chopv1(int integer, int[] arrayOfIntegers, int startOfSearch, int result)
        //{

        //    var length = arrayOfIntegers.Length;
        //    var maxIndex = length - 1;

        //    var chopPoint = (decimal)(((decimal)maxIndex - (decimal)startOfSearch) / 2);

        //    var chopIndex = (int)Math.Round(chopPoint, 0, MidpointRounding.AwayFromZero);

        //    for (var i = startOfSearch; i <= chopIndex; i++)
        //    {
        //        if (arrayOfIntegers[i] != integer)
        //        {
        //            continue;
        //        }

        //        result = i;
        //        return result;
        //    }

        //    if (maxIndex > chopIndex)
        //    {
        //        this.Chop(integer, arrayOfIntegers, chopIndex, result);
        //    }

        //    return result;
        //}
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
