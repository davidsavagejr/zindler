using System;
using System.Collections.Generic;
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
        [Test]
        public void Should_read_data_from_csv()
        {
            var data = Seed.ReadRecords();
            data.ShouldNotBeNull();
            data.Any().ShouldBeTrue();
        }
    }
}
