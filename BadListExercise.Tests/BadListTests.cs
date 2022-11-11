using Xunit;
using BadListExercise;

namespace BadListExercise.Tests
{

    public class BadListTests
    {
        [Fact()]
        public void BadList_NewInstance_StartsOutEmpty()
        {
            var bl = new BadList();
            Assert.Equal(0, bl.Length);
        }

        [Theory]
        [InlineData(3, 3, 1, 2,3,4,3,3)]
        [InlineData(0, 25, 1, 2,3,4,3,3)]
        public void CountNumbers_InsertRandomNumbersPlusNNoi_FindNoiExpectedCountTimes(int expectedcount, int noi, params int[] ints)
        {
            var bl = ints.ToBadList();
            Assert.Equal(expectedcount, bl.CountNumbers(noi));
        }

        [Theory]
        [InlineData(1,9,0)]
        [InlineData(0,0,0,0)]
        [InlineData(10,10,10,10)]
        [InlineData(1,0,0)]
        [InlineData(0, 0,1)]
        public void Add_InsertRandomNumbers_ExpectInsertedInOrder(params int[] ints )
        {
            var bl = ints.ToBadList();

            var bl_ascollection = Enumerable.Range(0,bl.Length).Select(bl.Get);

            Assert.Equal(ints, bl_ascollection);            
        }

        [Theory]
        [InlineData(1, 9, 0)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10, 10, 10, 10)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 1)]
        public void Get_InsertRandomNumbersGetAllMultipleTimes_ExpectGetIdempotent(params int[] ints)
        {
            var bl = ints.ToBadList();
            List<int> bl_ascollection;
            bl_ascollection = Enumerable.Range(0, bl.Length).Select(bl.Get).ToList();
            bl_ascollection = Enumerable.Range(0, bl.Length).Select(bl.Get).ToList();
            bl_ascollection = Enumerable.Range(0, bl.Length).Select(bl.Get).ToList();

            Assert.Equal(ints, bl_ascollection);
        }

        [Theory]
        [InlineData(3, 3, 1, 2, 3, 4, 3, 3)]
        [InlineData(0, 25, 1, 2, 3, 4, 3, 3)]
        public void Remove_RemoveRandomElement_DecreasesListSize(int randomIndex, params int[] ints)
        {
            var bl = ints.ToBadList();
            var expectedLength = bl.Length - 1;

            bl.Remove(randomIndex);

            Assert.Equal(expectedLength, bl.Length);
        }

        [Theory]
        [InlineData(3, 3, 1, 2, 3, 4, 3, 3)]
        [InlineData(0, 25, 1, 2, 3, 4, 3, 3)]
        public void Remove_RemoveRandomElement_ContentExpectedBySTDLIBList(int randomIndex, params int[] ints)
        {
            var bl = ints.ToBadList();
            var expectedResult = ints.ToList();
            expectedResult.RemoveAt(randomIndex);

            bl.Remove(randomIndex);

            Assert.Equal(expectedResult , bl.ToList());
        }
        [Theory]
        [InlineData(1, 0, 9, 0)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10, 10, 10, 10,10,10,10,10,10,10,10,10,10)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1,0)]
        public void InsertAt_InsertNAtIndexInRandomList_ExpectLengthIncreaseAndCorrectValueFoundAtIndex(int n, int index, params int[] ints)
        {
            int expectedLength=ints.Length+1;
            var bl = ints.ToBadList();
            bl.InsertAt(index, n);

            Assert.Multiple(
                () => Assert.Equal(expectedLength, bl.Length), // expect n incease by one
                ()=> Assert.Equal(n, bl.Get(index))             // expect to find element at index
            );
        }
        [Theory]
        [InlineData(1, 0, 9, 0)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 0)]
        [InlineData(0)]
        public void InsertAt_InsertAtEnd_ExpectFoundAtEnd(int n, params int[] ints)
        {
            var bl = ints.ToBadList();

            bl.InsertAt(bl.Length, n);

            Assert.Equal(n, bl.Get(bl.Length - 1));
        }


        [Fact]
        public void IsEmpty_NewList_StartsOutEmpty()
        {
            var bl = new BadList();

            var result = bl.IsEmpty;

            Assert.True(result);
        }


        [Theory]
        [InlineData(1, 0, 9, 0)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 0)]
        public void InsertAt_InsertOutsideRandomList_ExpectException(params int[] ints)
        {
            var bl = ints.ToBadList();

            var badindex = ints.Length + 1;

            Assert.Multiple(
                ()=> Assert.Throws<IndexOutOfRangeException>(() => bl.InsertAt(-1, 0)),
                ()=> Assert.Throws<IndexOutOfRangeException>(() => bl.InsertAt(badindex, 0))
                );

        }
        [Theory]
        [InlineData(1, 0, 9, 0)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 0)]
        public void Remove_RemoveOutsideRandomListOffByOneAtEnd_ExpectException(params int[] ints)
        {
            var bl = ints.ToBadList();

            var badindex = ints.Length + 1;
            
            Assert.Throws<IndexOutOfRangeException>(() => bl.Remove(badindex));
        }
        [Theory]
        [InlineData(1, 0, 9, 0)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 0)]
        public void Remove_RemoveOutsideRandomListNegativeOne_ExpectException(params int[] ints)
        {
            var bl = ints.ToBadList();

            var badindex = ints.Length + 1;

            Assert.Throws<IndexOutOfRangeException>(() => bl.Remove(-1));
        }

        [Theory]
        [InlineData(1, 0, 9, 0)]
        [InlineData(0, 0, 0, 0)]
        [InlineData(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 1)]
        [InlineData(1, 0)]
        public void Remove_RemoveOutsideRandomListDirectlyAtLengthIndex_ExpectException_(params int[] ints)
        {
            var bl = ints.ToBadList();

            var badindex = ints.Length;

            Assert.Throws<IndexOutOfRangeException>(() => bl.Remove(badindex));
        }
    }
}