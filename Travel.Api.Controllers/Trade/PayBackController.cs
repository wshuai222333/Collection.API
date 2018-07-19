using Microsoft.AspNetCore.Mvc;

namespace Collection.Api.Controllers.Trade {
    [Route("PayBack")]
    public class PayBackController: BaseController {

        public ActionResult PayBack() {
            return View();
        }
    }
}
