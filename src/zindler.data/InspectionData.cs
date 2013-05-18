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
        static IEnumerable<InspectionRecord> _records { get; set; }
        static object mutex = new object();
        public static IEnumerable<InspectionRecord> GetRecords(string path)
        {
            if (_records == null)
            {
                lock (mutex)
                {
                    if (_records == null)
                    {
                        var csv = new CsvReader(new StreamReader(path));
                        csv.Configuration.Delimiter = "\t";
                        csv.Configuration.QuoteNoFields = true;
                        _records = csv.GetRecords<InspectionRecord>().ToList();
                    }
                }
            }
            return _records;
        }
    }
}