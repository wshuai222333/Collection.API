using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Api.Controllers.Trade
{
    [Route("PayBack")]
    public class PayBackController: BaseController {

        public ActionResult PayBack() {
            return View();
        }
    }
}
