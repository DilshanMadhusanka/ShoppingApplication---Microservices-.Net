using AutoMapper;
using ShoppingApplication.Services.CouponAPI.Models;
using ShoppingApplication.Services.CouponAPI.Models.Dto;

namespace ShoppingApplication.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()  //return type eka MapperConfiguration. me moethod eka program.cs eke call krann oni 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                  config.CreateMap<CouponDto ,Coupon>();
                    config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
