using System;
using System.Linq;
using AutoMapper;
using YelpSharp.Data;

namespace zindler.web.Models.Mappings
{
	public class ZindlerProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<Location, Address>()
				.ForMember(dest => dest.StreetLine1, opt => opt.ResolveUsing<LocationAddressMapResolver>().FromMember(src => src.address));

			CreateMap<Business, Restaurant>()
				.ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.rating))
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
				.ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.phone))
				.ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.image_url))
				.ForMember(dest => dest.Violations, opt => opt.Ignore());

			CreateMap<Review, YelpReview>()
				.ForMember(dest => dest.DateOfReview, opt => opt.MapFrom(src => DateTime.FromOADate(src.time_created)))
				.ForMember(dest => dest.Excerpt, opt => opt.MapFrom(src => src.excerpt))
				.ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.rating))
				.ForMember(dest => dest.Url, opt => opt.Ignore());
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