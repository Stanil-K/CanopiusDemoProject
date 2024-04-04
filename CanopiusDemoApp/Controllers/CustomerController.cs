using Data.Models;
using Data.Repositories;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        //IActionResult Add([DataSourceRequest] DataSourceRequest request, Customer newCustomer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        customerRepository.Add(newCustomer);
        //    }

        //    // Return a collection which contains only the newly created item and any validation errors.
        //    return Json(new[] { newCustomer }.ToDataSourceResult(request, ModelState));
        //}

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            try
            {
                customerRepository.Add(customer);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while adding customer");
            }
        }


        [HttpGet]
        public IActionResult Update(int id)
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

        //public IActionResult UpdateCustomer([DataSourceRequest] DataSourceRequest request, Customer customerToUpdate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        customerRepository.Update(customerToUpdate);
        //    }

        //    return Json(new[] { customerToUpdate }.ToDataSourceResult(request, ModelState));
        //}

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            try
            {
                customerRepository.Update(customer);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while updating customer");
            }
        }

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
