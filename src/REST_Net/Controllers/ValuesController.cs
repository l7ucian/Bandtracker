using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnecToDB;

namespace REST_Net.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public String Get()
        {
            return "Heya there";
        } 

        // GET api/values/metallica
        [HttpGet("{search_item}")]
        public JsonResult Get(string search_item)
        {
            System.Diagnostics.Debug.WriteLine(search_item);
            return Json(PythonProcess.CallPython(search_item));
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
