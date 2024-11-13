using pairProgrammingÿvelse;

namespace RecordTest
{
    [TestClass]
    public class UnitTest1
    {

        private Record goodRecord = new Record("showshow", "Eminem", 200, 2021);
        private Record badTitle = new Record(null, "Eminem", 200, 2021);
        private Record badDuration = new Record("showshow", "Eminem", 0, 2021);
        private Record badYear = new Record("showshow", "Eminem", 200, 2025);
        private Record badArtist = new Record("showshow", null, 200, 2021);


        [TestMethod]
        public void TestTitle()
        {
            goodRecord.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => badTitle.ValidateTitle());

        }

        [TestMethod]
        public void TestArtist()
        {
            goodRecord.ValidateArtist();
            Assert.ThrowsException<ArgumentNullException>(() => badArtist.ValidateArtist());
        }
        [TestMethod]
        public void TestYear()
        {
            goodRecord.ValidateYear();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => badYear.ValidateYear());
        }
        [TestMethod]
        public void TestDuration()
        {
            goodRecord.ValidateDuration();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => badDuration.ValidateDuration());
        }
    }
}