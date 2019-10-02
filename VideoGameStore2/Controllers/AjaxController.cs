using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameStore2.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult getPartial()
        {
            return PartialView();
        }
    }
}