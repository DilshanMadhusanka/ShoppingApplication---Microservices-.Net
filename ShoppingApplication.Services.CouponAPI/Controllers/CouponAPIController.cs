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



namespace ShoppingApplication.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
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
    } 
}
