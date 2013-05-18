using AutoMapper;
using zindler.web.Models.Mappings;

namespace zindler.web.App_Start
{
    public class MapConfig
    {
        public static void Configure()
        {
			  Mapper.Initialize(cfg => cfg.AddProfile<ZindlerProfile>());
        }
    }
}
