using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_MVC.Controllers
{
    public class PortalCustomerController : Controller
    {
        private IPortalCustomerService portalCustomerService;

        public PortalCustomerController(IPortalCustomerService portalCustomerService)
        {
            this.portalCustomerService = portalCustomerService;
        }

        [HttpPost]
        public IActionResult AddPortalCustomer(PortalCustomerDto portalCustomerDto)
        {
            portalCustomerService.addCustomer(portalCustomerDto);
            return View();
        }

        [HttpGet]
        public IActionResult GetPortalCustomerByCustomerId(int customerId)
        {
            var portalCustomer = portalCustomerService.getPortalCustomerByCustomerId(customerId);
            return View(portalCustomer);
        }

        [HttpGet]
        public IActionResult GetPortalCustomerByPortalId(int portalId)
        {
            var portalCustomer = portalCustomerService.getPortalCustomerByPortalId(portalId);
            return View(portalCustomer);
        }
    }
}
