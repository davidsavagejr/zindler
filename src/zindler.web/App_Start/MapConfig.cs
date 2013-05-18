using AutoMapper;
using zindler.web.Models.Mappings;

namespace zindler.web.App_Start
{
    public class MapConfig
    {
        public static void Configure()
        {
<<<<<<< HEAD
            MapConfig.Configure();
            
=======
			  Mapper.Initialize(cfg => cfg.AddProfile<ZindlerProfile>());
>>>>>>> b0e126520659f16b6e98afdd91ff6f316ccc4cea
        }
    }
}