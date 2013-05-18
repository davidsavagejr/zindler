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
            using (var streamReader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "inspection-data")))
            {
                var csv = new CsvReader(streamReader);
                return csv.GetRecords<InspectionRecord>();
            }
        }
    }
}
