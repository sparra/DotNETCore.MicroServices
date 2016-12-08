using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroServices.DotNETCore.Web.API.Repository;
using MicroServices.DotNETCore.Domain.CORE.Models;

namespace MicroServices.DotNETCore.Web.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IDockerCommandsRepository _repo;

        public ValuesController(IDockerCommandsRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<DockerCommand>> Get()
        {
            return await _repo.GetDockerCommandsAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
