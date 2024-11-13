using pairProgrammingØvelse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordTest
{
    [TestClass]
    public class RepoTest
    {
        private RecordRepo _repo;
        private Record _goodRecord = new Record(1, "showshow", "Eminem", 200, 2021);
        private Record _badTitle = new Record(2, null, "Eminem", 200, 2021);

        [TestInitialize]
        public void Init()
        {
            {
                _repo = new RecordRepo();
            }
        }

        [TestMethod]
        public void TestAdd()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(_badTitle));
        }
        [TestMethod]
        public void TestGetAll()
        {
            IEnumerable<Record> records = _repo.GetAll();
            Assert.AreEqual(3, _repo.GetAll().Count);

            IEnumerable<Record> sortedTitlesAsc = _repo.GetAll(sortBy: "titleasc");
            Assert.AreEqual("Halo", sortedTitlesAsc.First().Title);
            
            IEnumerable<Record> sortedTitlesDesc = _repo.GetAll(sortBy: "titledesc");
            Assert.AreEqual("showshow", sortedTitlesDesc.First().Title);

            IEnumerable<Record> filteredRecords = _repo.GetAll(title: "P");
            Assert.AreEqual(1, filteredRecords.Count());

            IEnumerable<Record> sortedYearAsc = _repo.GetAll(sortBy: "yearasc");
            Assert.AreEqual("Halo", sortedYearAsc.First().Title);

            IEnumerable<Record> sortedYearDesc = _repo.GetAll(sortBy: "yeardesc");
            Assert.AreEqual("showshow", sortedYearDesc.First().Title);

            IEnumerable<Record> sortedDurationAsc = _repo.GetAll(sortBy: "durationasc");
            Assert.AreEqual("Parap", sortedDurationAsc.First().Title);

        }
    }
}
