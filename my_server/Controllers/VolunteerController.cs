using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_server.models;
using my_server.interfaces;

namespace my_server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteer _ivln;
        public VolunteerController(IVolunteer ivln)
        {
            _ivln = ivln;

        }
        [HttpGet]
        public List<Volunteer> All()
        {
            return _ivln.All();

        }
        [HttpGet]
        [Route("{id}")]
        public Volunteer ById(int id)
        {
            return _ivln.ById(id);

        }
        [HttpPost]
        public bool Create(Volunteer v)
        {
            return _ivln.Create(v);

        }
        [HttpPut]
        
        public bool Update([FromBody]Volunteer v)
        {
            return _ivln.Update(v);

        }
        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _ivln.Delete(id);
        }
    }
}

