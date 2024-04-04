using Data.Models;
using Data.Repositories;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CanopiusDemoApp.Controllers
{
    public class PaymentController : Controller
    {

        private readonly PaymentRepository paymentRepository;
        private readonly PolicyRepository policyRepository;
        private readonly ClaimRepository claimRepository;

        public PaymentController(PaymentRepository _paymentRepository,
                                 PolicyRepository _policyRepository, 
                                 ClaimRepository _claimRepository)
        {
            paymentRepository = _paymentRepository;
            policyRepository = _policyRepository;
            claimRepository = _claimRepository; 

        }

        [HttpGet]   
        public IActionResult All()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAllPaymentsJSON([DataSourceRequest] DataSourceRequest request)
        {
            List<Payment> payments = paymentRepository.GetAll();
            return Json(payments.ToDataSourceResult(request));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var payment = paymentRepository.GetById(id);
                return View(payment);
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while fetching payment with id {id}");
            }
        }


        [HttpGet]
        public IActionResult Add()
        {

            ViewBag.Policies = policyRepository.GetAll()
                                               .Where(p => claimRepository.GetAll().Any(c => c.PolicyId == p.Id && c.ClaimStatus == "Approved"))
                                               .Select(p => new SelectListItem
                                               {
                                                   Value = p.Id.ToString(),
                                                   Text = $"{p.Id} - {p.PolicyType}"
                                               })
                                               .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Payment payment)
        {
            try
            {
                paymentRepository.Add(payment);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while adding payment");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var payment = paymentRepository.GetById(id);
                return View(payment);
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while fetching payment with id {id}");
            }
        }

        [HttpPost]
        public IActionResult Update(Payment payment)
        {
            try
            {
                paymentRepository.Update(payment);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while updating payment");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                paymentRepository.Delete(id);
                return RedirectToAction("All");
            }
            catch (Exception)
            {
                throw new Exception($"An error occurred while deleting payment with id {id}");
            }
        }

        [HttpGet]
        public JsonResult GetClaimsByPolicy(int policyId)
        {
            var claims = claimRepository.GetAll()
                .Where(c => c.ClaimStatus == "Approved" && c.PolicyId == policyId)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Id} - {c.ClaimStatus}"
                })
                .ToList();

            return Json(claims);
        }

    }
}
