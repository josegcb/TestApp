using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Library.Helpers {
    public static class ClaimHelper {

        public static object GetCurrentMFC(string valKey) {
            var claimsprincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
            if (claimsprincipal == null) {
                return 0;
            }
            var claim = claimsprincipal.Claims.FirstOrDefault(c => c.Type == LibraryConst.KeyMFCs);
            if (claim == null || string.IsNullOrEmpty(claim.Value)) {
                return 0;
            }
            List<MfcDto> vList = JsonConvert.DeserializeObject<List<MfcDto>>(claim.Value);
            if (vList != null) {
                MfcDto vMfc = vList.Where(p => p.Key.Equals(valKey, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (vMfc != null) {
                    return vMfc.Value;
                }
            }
            return 0;
        }

        public static object GetCurrentMFCOrNull(string valKey) {
            var claimsprincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
            if (claimsprincipal == null) {
                return null;
            }
            var claim = claimsprincipal.Claims.FirstOrDefault(c => c.Type == LibraryConst.KeyMFCs);
            if (claim == null || string.IsNullOrEmpty(claim.Value)) {
                return 0;
            }
            List<MfcDto> vList = JsonConvert.DeserializeObject<List<MfcDto>>(claim.Value);
            if (vList != null) {
                MfcDto vMfc = vList.Where(p => p.Key.Equals(valKey, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (vMfc != null) {
                    return vMfc.Value;
                }
            }
            return null;
        }

        public static IEnumerable<MfcDto> GetCurrentMFCs() {
            ClaimsPrincipal claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
            var identity = claimsPrincipal.Identities.First();
            var Claim = identity.FindFirst(LibraryConst.KeyMFCs);
            List<MfcDto> vList = new List<MfcDto>();
            if (Claim != null) {
                vList = JsonConvert.DeserializeObject<List<MfcDto>>(Claim.Value);
            }
            return vList;
        }

        public static void SetCurrentMFCs(List<MfcDto> valCurrentMFCs) {
           // var authenticationManager = HttpContext.GetOwinContext().Authentication;
            //var identity = new System.Security.Claims.ClaimsIdentity(User.Identity);
            ClaimsPrincipal claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
            var identity = claimsPrincipal.Identities.First();
            var Claim = identity.FindFirst(LibraryConst.KeyMFCs);
            List<MfcDto> vList = new List<MfcDto>();
            if (Claim != null) {
                vList = JsonConvert.DeserializeObject<List<MfcDto>>(Claim.Value);
                identity.RemoveClaim(identity.FindFirst(LibraryConst.KeyMFCs));
            }
            if (vList != null) {
                foreach (var item in valCurrentMFCs) {
                    ActualizarListaMfc(item.Key, item.Value, vList);
                }

            }
            identity.AddClaim(new System.Security.Claims.Claim(LibraryConst.KeyMFCs, JsonConvert.SerializeObject(vList)));
            
            
            //authenticationManager.AuthenticationResponseGrant 
            //  = new AuthenticationResponseGrant( new ClaimsPrincipal(identity),new AuthenticationProperties { IsPersistent = true });
        }

        public static  void SetCurrentMFC(string valKey, object valvalue) {
            List<MfcDto> vList = new List<MfcDto>();
            vList.Add(new MfcDto() { Key = valKey, Value = valvalue });
            SetCurrentMFCs(vList);
        }

        private static void ActualizarListaMfc(string valKey, object valvalue, List<MfcDto> vList) {
            if (vList.Count(p => p.Key.Equals(valKey, StringComparison.CurrentCultureIgnoreCase)) > 0) {
                MfcDto vMfc = vList.Where(p => p.Key.Equals(valKey, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                vMfc.Value = valvalue;
            } else {
                vList.Add(new MfcDto() { Key = valKey, Value = valvalue });
            }
        }
    }

   
}
