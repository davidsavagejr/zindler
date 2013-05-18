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
        private static readonly Lazy<IEnumerable<InspectionRecord>> _records = new Lazy<IEnumerable<InspectionRecord>>(() => ReadRecords());

        private static IEnumerable<InspectionRecord> ReadRecords()
        {
            var csv =
                new CsvReader(new StreamReader(Path.Combine(Environment.CurrentDirectory, "src", "inspection-data.csv")));

            var records = csv.GetRecords<InspectionRecord>();
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://maps.googleapis.com");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    string queryFormat = "maps/api/geocode/json?address={0}+{1},{2},{3}&sensor=false";
            //    foreach (var record in records)
            //    {
            //        var response =
            //            client.GetAsync(string.Format(queryFormat, record.StNum, record.StName.Replace(" ", "+"),
            //                                                record.City, record.StName)).Result;

            //        var result = JsonConvert.DeserializeObject<GoogleResult>(response.Content.ReadAsStringAsync().Result);
            //        if (!string.IsNullOrEmpty(result.status) && result.status == "OK")
            //            record.Geometry = result.results[0].geometry.location;

            //    }
            //}
            return records;
        }

        public static IEnumerable<InspectionRecord> Records { get { return _records.Value; } }
    }
}