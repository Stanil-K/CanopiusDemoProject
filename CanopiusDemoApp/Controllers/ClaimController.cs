using Data.Models;
using Data.Repositories;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CanopiusDemoApp.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ClaimRepository claimRepository;
        private readonly PolicyRepository policyRepository;

        public ClaimController(ClaimRepository _claimRepository, PolicyRepository _policyRepository)
        {
            claimRepository = _claimRepository;
            policyRepository = _policyRepository;

        }

        [HttpGet]
        public IActionResult All()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAllClaimsJSON([DataSourceRequest] DataSourceRequest request)
        {
            List<Claim> claims = claimRepository.GetAll();
            return Json(claims.ToDataSourceResult(request));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var claim = claimRepository.GetById(id);
                return View(claim);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching claim with id {id}: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            var policiesWithoutClaims = policyRepository.GetAll()
                                                            .Where(p => !claimRepository.GetAll().Any(c => c.PolicyId == p.Id))
                                                            .ToList();
            ViewBag.PoliciesWithoutClaims = new SelectList(policiesWithoutClaims, "Id", "PolicyType");

            return View();
        }

        [HttpPost]
        public IActionResult Add(Claim claim)
        {
            try
            {
                claimRepository.Add(claim);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding claim: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var claim = claimRepository.GetById(id);
                return View(claim);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching claim with id {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Update(Claim claim)
        {
            try
            {
                claimRepository.Update(claim);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating claim: {ex.Message}");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                claimRepository.Delete(id);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting claim with id {id}: {ex.Message}");
            }
        }
    }
}
