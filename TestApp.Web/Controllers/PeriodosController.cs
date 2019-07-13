using Library;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Web.Controllers
{
    public class PeriodosController : TestAppControllerBase {
        public PeriodosController() {
        }

        // GET: Periodo
        public ActionResult Index()
        {
            return View();
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
                string vFilterName = new DataFilters.DataFilterPeriodo().FilterName;
                if (vList != null && vList.Count > 0) {                    
                    foreach (var item in vList) {
                        if (vList.Count(p => p.Key.Equals(vFilterName, StringComparison.CurrentCultureIgnoreCase)) > 0) {
                            MfcDto vMfc = vList.Where(p => p.Key.Equals(vFilterName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                            vMfc.Value = PeriodoId;
                        } else {
                            vList.Add(new MfcDto() { Key = vFilterName, Value = PeriodoId });
                        }
                    }
                } else {
                    vList.Add(new MfcDto() { Key = vFilterName, Value = PeriodoId });
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