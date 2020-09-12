using Microsoft.AspNetCore.Mvc;
using ObrasBibliograficas.Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObrasBibliograficas.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult GetResponse<T>(ResponseModel<T> result)
        {
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
