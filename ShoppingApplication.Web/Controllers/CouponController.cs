﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingApplication.Web.Models;
using ShoppingApplication.Web.Service.IService;

namespace ShoppingApplication.Web.Controllers
{
    public class CouponController : Controller
    {
        
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }


        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            ResponseDto? response = await _couponService.GetAllCouponsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);

        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }


    }
}