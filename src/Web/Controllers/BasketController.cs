﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

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
            return View(await _basketViewModelService.GetBasketAsync());
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            return View();
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutViewModel vm, string basketJson)
        {
            if (basketJson != JsonSerializer.Serialize(await _basketViewModelService.GetBasketAsync()))
                ModelState.AddModelError("", "Your basket has been changed recently. Please review your basket before further process.");

            if (ModelState.IsValid)
            {
                // payment
                // create order
                return RedirectToAction("OrderSuccess");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(int productId)
        {
            var basket = await _basketViewModelService.AddBasketItemAsync(productId);
            return Json(basket.Items.Count);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EmptyBasket()
        {
            await _basketViewModelService.EmptyBasketAsync();
            TempData["Message"] = "Your basket has been emptied successfully.";
            return RedirectToAction("Index", "Basket");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int basketItemId)
        {
            await _basketViewModelService.RemoveBasketItemAsync(basketItemId);
            TempData["Message"] = "The item has been removed from the basket successfully.";
            return RedirectToAction("Index", "Basket");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateItems(int[] basketItemIds, int[] quantities)
        {
            await _basketViewModelService.UpdateBasketItemsAsync(basketItemIds, quantities);
            TempData["Message"] = "The items have been updated successfully.";
            return RedirectToAction("Index", "Basket");
        }
    }
}
