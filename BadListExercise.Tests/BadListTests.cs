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


        [Fact()]
        public void CountNumbersTest()
        {
            Assert.True(false, "This test needs an implementation");
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