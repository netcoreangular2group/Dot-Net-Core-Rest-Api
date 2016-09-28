using Microsoft.AspNetCore.Mvc;
using KPI.Catalog.Domain;
using KPI.Catalog.Service;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace KPI.WebAPI
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private ICategoryService _categoryService;
        public CatalogController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/catalog
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{
            
        //    var cat = _categoryService.GetCategory(1);
        //    if (cat != null)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.OK)
        //        {
        //            Content = new ObjectContent<Category>(cat, new XmlMediaTypeFormatter())
        //        };
        //    }
        //    else
        //        return new HttpResponseMessage(HttpStatusCode.NoContent);
        //}

        // GET api/catalog/5
        [HttpGet("{id}")]
        public Category Get(long id)
        {
            var cat = _categoryService.GetCategory(id);
            return cat;
        }

        // POST api/catalog
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/catalog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/catalog/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
