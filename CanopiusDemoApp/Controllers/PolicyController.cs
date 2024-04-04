using Data.Models;
using Data.Repositories;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CanopiusDemoApp.Controllers
{
    public class PolicyController : Controller
    {

        private readonly PolicyRepository policyRepository;
        private readonly CustomerRepository customerRepository;

        public PolicyController(PolicyRepository _policyRepository, CustomerRepository _customerRepository)
        {
             policyRepository = _policyRepository;
            customerRepository = _customerRepository;
        }


        [HttpGet]
        public IActionResult All()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAllPoliciesJSON([DataSourceRequest] DataSourceRequest request)
        {
            List<Policy> policies = policyRepository.GetAll();
            return Json(policies.ToDataSourceResult(request));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var policy = policyRepository.GetById(id);
                return View(policy);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching policy with id {id}: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            var allCustomers = customerRepository.GetAll();

            ViewBag.Customers = new SelectList(allCustomers, "Id", "Name");

            return View();
        }



        [HttpPost]
        public IActionResult Add(Policy policy)
        {
            try
            {
                policyRepository.Add(policy);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding policy: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var policy = policyRepository.GetById(id);
                return View(policy);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching policy with id {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Update(Policy policy)
        {
            try
            {
                policyRepository.Update(policy);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating policy: {ex.Message}");
            }
        }


        public IActionResult Delete(int id)
        {
            try
            {
                policyRepository.Delete(id);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting policy with id {id}: {ex.Message}");
            }
        }
    }
}
