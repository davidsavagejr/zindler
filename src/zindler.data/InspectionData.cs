using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using CsvHelper;
using Newtonsoft.Json;

namespace zindler.data
{
    public sealed class InspectionData
    {
        private static readonly Lazy<List<InspectionRecord>> lazy = new Lazy<List<InspectionRecord>>(() => 
            {
                var csv = new CsvReader(new StreamReader(Path.Combine(Environment.CurrentDirectory, "src", "inspection-data.csv")));
                csv.Configuration.QuoteNoFields = true;
                return csv.GetRecords<InspectionRecord>().ToList();
            });

        public static IEnumerable<InspectionRecord> Records { get { return lazy.Value; } }
    }
}