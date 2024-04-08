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
        //get list of volunteers who wants to volunteer on a specipic day
        public List<Volunteer> ByDay(int day){
            return this._iscdl.GetVoluteersByDay(day);
        }
        [HttpGet]
        //get list of all days in week and who wants to volunteer each day
        public List<List<Volunteer>> All(){
            return this._iscdl.GetScheduling();
        }
        //get list of days and id of who was chosen to volunteer each day 
        [HttpGet]
        public Scheduling GetChosen(){
            return this._iscdl.GetChosenScheduling();

        }
        //save who was chosen to volunteer each day 

        [HttpPut]
        public bool Save(Scheduling scheduling){
            return this._iscdl.SaveScheduling(scheduling);
        }
    }
}

