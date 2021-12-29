using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_MVC.Controllers
{
    public class StarbucksCustomerController : Controller
    {
        private IStarbucksCustomerService starbucksCustomerService;

        public StarbucksCustomerController(IStarbucksCustomerService starbucksCustomerService)
        {
            this.starbucksCustomerService = starbucksCustomerService;
        }

        [HttpPost]
        public IActionResult AddStarbucksCustomer(StarbucksCustomerDto starbucksCustomerDto)
        {
            starbucksCustomerService.addCustomer(starbucksCustomerDto);
            return View();
        }

        [HttpGet]
        public IActionResult GetStarbucksCustomerByCustomerId(int customerId)
        {
            var portalCustomer = starbucksCustomerService.getStarbucksCustomerByCustomerId(customerId);
            return View(portalCustomer);
        }

        [HttpGet]
        public IActionResult GetStarbucksCustomerByStarbucksId(int starbucksId)
        {
            var portalCustomer = starbucksCustomerService.getStarbucksCustomerByStarbucksId(starbucksId);
            return View(portalCustomer);
        }
    }
}
