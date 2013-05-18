using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zindler.data
{
    public class InspectionRecord
    {
        public string Account { get; set; }
        public string Name { get; set; }
        public string StNum { get; set; }
        public string StName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string PermitTypes { get; set; }
        public string Expiration { get; set; }
        public string FacilityType { get; set; }
        public string District { get; set; }
        public string Risk { get; set; }
        public string Employees { get; set; }
        public string Score { get; set; }
        public string InspectionDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ActivityType { get; set; }
        public string InspectorID { get; set; }
        public string InspectorName { get; set; }
        public string SiteCount { get; set; }
    }
}
