using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketViewComponent(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _basketViewModelService.GetBasketAsync());
        }
    }
}
