using pairProgrammingÿvelse;

namespace RecordTest
{
    [TestClass]
    public class UnitTest1
    {

        private Record goodRecord = new Record(1, "showshow", "Eminem", 200, 2021);
        private Record badTitle = new Record(2, null, "Eminem", 200, 2021);
        private Record badDuration = new Record(3, "showshow", "Eminem", 0, 2021);
        private Record badYear = new Record(4, "showshow", "Eminem", 200, 2025);
        private Record badArtist = new Record(5, "showshow", null, 200, 2021);


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