using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Library;
using Microsoft.Owin.Security;
using Newtonsoft.Json;

namespace TestApp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TestAppControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }

        [HttpPost]
        public JsonResult Escoger(int PeriodoId) {
            try {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var identity = new System.Security.Claims.ClaimsIdentity(User.Identity);
                var Claim = identity.FindFirst(LibraryConst.KeyMFCs);
                List<MfcDto> vList = new List<MfcDto>();
                if (Claim != null) {
                    vList = JsonConvert.DeserializeObject<List<MfcDto>>(Claim.Value);
                    identity.RemoveClaim(identity.FindFirst(LibraryConst.KeyMFCs));
                }
                if (vList != null) {
                    string vFilterName = new DataFilters.DataFilterPeriodo().FilterName;
                    foreach (var item in vList) {
                        if (vList.Count(p => p.Key.Equals(vFilterName, StringComparison.CurrentCultureIgnoreCase)) > 0) {
                            MfcDto vMfc = vList.Where(p => p.Key.Equals(vFilterName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                            vMfc.Value = PeriodoId;
                        } else {
                            vList.Add(new MfcDto() { Key = vFilterName, Value = PeriodoId });
                        }
                    }
                }
                identity.AddClaim(new System.Security.Claims.Claim(LibraryConst.KeyMFCs, JsonConvert.SerializeObject(vList)));
                authenticationManager.AuthenticationResponseGrant =
                    new AuthenticationResponseGrant(
                        new ClaimsPrincipal(identity),
                        new AuthenticationProperties { IsPersistent = true }
                    );
                return Json(new { success = true });
            } catch (Exception ex) {
                return Json(new { success = false, errors = ex.Message });

            }
        }
    }
}