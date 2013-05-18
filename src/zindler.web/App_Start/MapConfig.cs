using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using zindler.data;

namespace zindler.web.App_Start
{
    public class MapConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<InspectionRecord, Models.Restaurant>();
            MapConfig.Configure();
            
        }
    }
}