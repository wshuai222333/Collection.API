using Microsoft.AspNetCore.Mvc;

namespace Collection.Api.Controllers {
    /// <summary>
    /// Controller基类
    /// </summary>
    public class BaseController : Controller {

        public int RetrueMemberlevel(int Integral) {

            if (Integral >= 100 && Integral < 500) {
                return 1;
            } else if (Integral >= 500 && Integral < 1000) {
                return 2;
            } else if (Integral >= 1000 && Integral <2000) {
                return 3;
            } else if (Integral >= 2000 && Integral < 5000) {
                return 4;
            } else if (Integral >= 5000) {
                return 5;
            } else {
                return 0;
            }
        }
    }
}
