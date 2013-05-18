using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace zindler.data
{
    public sealed class InspectionData
    {
        private static readonly Lazy<IEnumerable<InspectionRecord>> records = new Lazy<IEnumerable<InspectionRecord>>(() => ReadRecords()); 
        private static IEnumerable<InspectionRecord> ReadRecords()
        {
            var csv = new CsvReader(new StreamReader(Path.Combine(Environment.CurrentDirectory, "src", "inspection-data.csv")));
            return csv.GetRecords<InspectionRecord>();
        }
        public static IEnumerable<InspectionRecord> Records { get { return records.Value; } }
    }
}
