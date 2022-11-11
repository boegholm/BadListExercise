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
        public void CountNumbersTest(int expectedcount, int noi, params int[] ints)
        {
            var bl = new BadList();
            foreach (var v in ints)
                bl.Add(v);
            Assert.Equal(expectedcount, bl.CountNumbers(noi));
        }

        [Fact()]
        public void AddTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void RemoveTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void InsertAtTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}