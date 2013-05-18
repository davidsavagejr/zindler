using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace zindler.data
{
    public static class Seed
    {
        public static IEnumerable<InspectionRecord> ReadRecords()
        {
            var csv = new CsvReader(new StreamReader(Path.Combine(Environment.CurrentDirectory, "src", "inspection-data.csv")));
            return csv.GetRecords<InspectionRecord>();
        }
    }
}
