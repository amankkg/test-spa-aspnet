using Microsoft.AspNetCore.Mvc;
using RestCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _db;

        public CategoriesController(ICategoryRepository db)
        {
            _db = db;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _db.GetAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _db.Find(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public (string, Category) Post([FromBody] Category category)
        {
            _db.Add(category);

            return ($"/api/categories/{category.Id}", category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            category.Id = id;

            _db.Edit(category);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Remove(id);
        }
    }
}
