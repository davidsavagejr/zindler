using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using zindler.data;
using Should;

namespace zindler.tests
{
    [TestFixture]
    public class SeedTester
    {
        [Test, Explicit]
        public void Should_read_data_from_csv()
        {
            var data = InspectionData.GetRecords(Path.Combine(Environment.CurrentDirectory, "inspection-data.txt"));
            data.ShouldNotBeNull();
            data.Any().ShouldBeTrue();
        }
    }
}
