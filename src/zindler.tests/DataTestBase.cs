using System;
using AutoMapper;
using zindler.web.Models.Mappings;

namespace zindler.tests
{
	public class DataTestBase
	{
		private static readonly Lazy<bool> InitializeAutoMapper = new Lazy<bool>(() =>
		{
			Mapper.Initialize(cfg => cfg.AddProfile<ZindlerProfile>());

			return true;
		});

		protected DataTestBase()
		{
			var initialized = InitializeAutoMapper.Value;
		}
	}
}