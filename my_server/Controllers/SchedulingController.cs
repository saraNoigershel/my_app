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
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedule _iscdl;
        public SchedulingController(ISchedule iscdl)
        {
            this._iscdl = iscdl;
        }
        [HttpGet]
        [Route("{day}")]
        public List<Volunteer> ByDay(int day){
            return this._iscdl.GetVoluteersByDay(day);
        }
        [HttpGet]
        public List<List<Volunteer>> All(){
            return this._iscdl.GetScheduling();
        }
        [HttpGet]
        public List<Int64> GetChosen(){
            return this._iscdl.GetChosenScheduling();

        }

        [HttpPut]
        public bool Save(List<Int64> scheduling){
            return this._iscdl.SaveScheduling(scheduling);
        }
    }
}

