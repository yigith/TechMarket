﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketController(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            // todo: return BasketViewModel (including total price)
            return View(await _basketViewModelService.GetBasketAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(int productId)
        {
            var basket = await _basketViewModelService.AddBasketItemAsync(productId);
            return Json(basket.Items.Count);
        }
    }
}
