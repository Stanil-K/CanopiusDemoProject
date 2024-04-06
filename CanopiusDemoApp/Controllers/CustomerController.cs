using Data.Models;
using Data.Repositories;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Telerik.SvgIcons;

namespace CanopiusDemoApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository customerRepository;

        public CustomerController(CustomerRepository _customerRepository)
        {
            customerRepository = _customerRepository;
        }

        public IActionResult All()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAllCustomersJSON([DataSourceRequest] DataSourceRequest request)
        {
            List<Customer> customers = customerRepository.GetAll();
            return Json(customers.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult GetCustomerJSON([DataSourceRequest] DataSourceRequest request, int id)
        {
            var customer = customerRepository.GetById(id);
            return Json(customer.Id);
        }


        public IActionResult Details(int id)
        {
            try
            {
                var customer = customerRepository.GetById(id);
                return View(customer);
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while fetching customer with id {id}");
            }
        }

        public IActionResult Update(int id)
        {
            try
            {
                var customer = customerRepository.GetById(id);
                return View(customer);
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception occured when loading a customer.- {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customerRepository.Update(customer);
                    return RedirectToAction("All");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception occured when updating customer. - {ex.Message}");
                }

            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customerRepository.Add(customer);
                    return RedirectToAction("All");
                }
                catch (Exception)
                {

                    throw new Exception("Exception occured when adding new customer.");
                }
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                customerRepository.Delete(id);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while deleting customer with id {id}");
            }
        }
    }
}
