using System;
using System.Linq;
using AutoMapper;
using YelpSharp.Data;
using zindler.data;

namespace zindler.web.Models.Mappings
{
	public class ZindlerProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<Location, Address>()
				.ForMember(dest => dest.StreetLine1, opt => opt.ResolveUsing<LocationAddressMapResolver>().FromMember(src => src.address))
				.ForMember(dest => dest.City, opt => opt.MapFrom(src => src.city))
				.ForMember(dest => dest.State, opt => opt.MapFrom(src => src.state_code))
				.ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.postal_code))
				.ForMember(dest => dest.Latitude, opt=>opt.MapFrom(src=>src.coordinate.latitude))
				.ForMember(dest => dest.Longitude, opt=>opt.MapFrom(src=>src.coordinate.longitude))
				.ForMember(dest => dest.GeoAccuracy, opt=>opt.MapFrom(src=>src.geo_accuracy));

			CreateMap<Business, Restaurant>()
				.ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.rating))
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
				.ForMember(dest => dest.Address, opt=>opt.MapFrom(src=>src.location))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
				.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.phone))
				.ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.image_url))
				.ForMember(dest => dest.Violations, opt => opt.Ignore())
				.ForMember(dest => dest.RatingImage, opt => opt.MapFrom(src => src.rating_img_url));

			CreateMap<Review, YelpReview>()
				.ForMember(dest => dest.DateOfReview, opt => opt.MapFrom(src => DateTime.FromOADate(src.time_created)))
				.ForMember(dest => dest.Excerpt, opt => opt.MapFrom(src => src.excerpt))
				.ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.rating))
				.ForMember(dest => dest.Url, opt => opt.Ignore());

		    CreateMap<InspectionRecord, Violation>()
                .ForMember(dest => dest.DateOfViolation, opt => opt.ResolveUsing(src =>
                    {
                        DateTime outD;
                        DateTime.TryParse(src.InspectionDate, out outD);
                        return outD;
                    }))
		        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ActivityType))
		        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => int.Parse(src.Account)));

		}
	}

	public class LocationAddressMapResolver : ValueResolver<string[], string>
	{
		protected override string ResolveCore(string[] source)
		{
			return source.FirstOrDefault();
		}
	}
}