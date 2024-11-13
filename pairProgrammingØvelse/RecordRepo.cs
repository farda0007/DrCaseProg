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
            new Record("showshow", "Eminem", 200, 2021),
            new Record("Parap", "Rihanna", 180, 2007),
            new Record("Halo", "Beyonce", 210, 1998),
        };


        public Record Add(Record record)
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
                    case "title":
                        records = records.OrderBy(record => record.Title).ToList();
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
           
    }
}
