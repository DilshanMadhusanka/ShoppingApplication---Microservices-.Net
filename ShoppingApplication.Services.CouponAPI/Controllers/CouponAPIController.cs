using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApplication.Services.CouponAPI.Data;
using ShoppingApplication.Services.CouponAPI.Models;
using ShoppingApplication.Services.CouponAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

// coupon controller

namespace ShoppingApplication.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]

    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;  // create a private variable , type is AppDbContext
        private ResponseDto _response;    // create a  variable, type is responseDto ( me class eka wenam hadala thiyenne )
        private IMapper _mapper;    //  create a variable for automapper. type is IMapper

        public CouponAPIController(AppDbContext db, IMapper mapper)  
        {
            _db = db;   // initialize the variable 
            _mapper = mapper;
            _response = new ResponseDto();  // initialize the variable 
        }

        [HttpGet]
        public ResponseDto Get()  // me function eke return type eka ResponseDto ( wenam hadal thiyenne ) 
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();  // return coupon list( IEnumerable kiyanneth list ekakt 
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;   // ResponseDto eke thiyan isSuccess eka false nam( success naththam )
                _response.Message = ex.Message; // message ekak denn kiyanne 
            }
            return _response;  // respons ekacreturn kranwa 
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(obj);
               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("GetByCode/{code}")]  // GetByCode kiyanne methode name eka 
        public ResponseDto GetByCode(string code)   // input eka string ekak
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower()); // u => u.CouponCode kiyanne, issellam empty (id eka enter karana thana issellam empty), it passe coupon code eka lower case walata harawanwa
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }




        [HttpPost]
      //  [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] CouponDto couponDto) // request body eke thiyan eka post kranna. methanadi recieve wenne  CouponDto ekak. ekat add krankot eka ay convert krann oni coupon ekak widihata

        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);  // recieve wenne CouponDto type eken, habai add kranne Coupon type ekat. e nisa CouponDto eka convert krann oni Coupon type ekata
                _db.Coupons.Add(obj);  //this is the mothod to add entity to entity framework core. coupon type ekata convert un eka coupon table ekat add kranna ekat add kranwa
                _db.SaveChanges(); // save kroth witharai e record eka data base eke table ekata add wenne 


                _response.Result = _mapper.Map<CouponDto>(obj); // database ekat data iwar unata passe return krann oni
                /*
                                var options = new Stripe.CouponCreateOptions
                                {
                                    AmountOff = (long)(couponDto.DiscountAmount * 100),
                                    Name = couponDto.CouponCode,
                                    Currency = "usd",
                                    Id = couponDto.CouponCode,
                                };
                                var service = new Stripe.CouponService();
                                service.Create(options);

                */
               // _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }







        [HttpPut]
        //  [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] CouponDto couponDto) // request body eke thiyan eka post kranna. methanadi recieve wenne  CouponDto ekak. ekat add krankot eka ay convert krann oni coupon ekak widihata

        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);  // recieve wenne CouponDto type eken, habai add kranne Coupon type ekat. e nisa CouponDto eka convert krann oni Coupon type ekata
                _db.Coupons.Update(obj);  //this is the mothod to Update entity to entity framework core. coupon type ekata convert un eka coupon table eke update kranwa 
                _db.SaveChanges(); // save kroth witharai e record eka data base eke table ekata add wenne 


                _response.Result = _mapper.Map<CouponDto>(obj); // database ekat data iwar unata passe return krann oni
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }








        [HttpDelete]
        [Route("{id:int}")]
       // [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id); // input eka widihat dena eka coupon eke id ekata saman kranwa 
                _db.Coupons.Remove(obj); // coupon table eken remove kranna kiyanne. Remove kiyanne entity framwork wala ena method ekak 
                _db.SaveChanges();


               // var service = new Stripe.CouponService();
               // service.Delete(obj.CouponCode);


            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

    }
}
