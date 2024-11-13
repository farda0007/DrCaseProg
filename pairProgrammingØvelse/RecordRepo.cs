using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace pairProgrammingØvelse
{
    public class RecordRepo
    {
        private List<Record> recordList = new List<Record>()
        {
            new Record(1, "showshow", "Eminem", 200, 2021),
            new Record(2, "Parap", "Rihanna", 180, 2007),
            new Record(3, "Halo", "Beyonce", 210, 1998),
        };

        public Record GetById(int id)
        {
            return recordList.Find(record => record.Id == id);
        }

        public Record? Add(Record record)
        {
            record.Validate();
            recordList.Add(record);
            return record;
        }

        public List<Record> GetAll(string title = null, string sortBy = null)
        {
            List<Record> records = new(recordList);
           
            if (title != null)
            {
            records = records.FindAll(record => record.Title.StartsWith(title));
            }
            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "titleasc":
                        records = records.OrderBy(record => record.Title).ToList();
                        break;
                    case "titledesc":
                        records = records.OrderByDescending(record => record.Title).ToList();
                        break;
                    case "yearasc":
                        records = records.OrderBy(record => record.PublicationYear).ToList();
                        break;
                    case "yeardesc":
                        records = records.OrderByDescending(record => record.PublicationYear).ToList();
                        break;
                    case "durationasc":
                        records = records.OrderBy(record => record.Duration).ToList();
                        break;
                    case "durationdesc":
                        records = records.OrderByDescending(record => record.Duration).ToList();
                        break;
                }
            }
            return records;
        }

        public Record Delete(int id)
        {
            Record record = GetById(id);
            if (record == null)
            {
                throw new ArgumentNullException("Record not found");
            }
            recordList.Remove(record);
            return record;
        }

    }
}
