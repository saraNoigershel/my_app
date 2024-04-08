using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_server.models;
using my_server.interfaces;
using Microsoft.VisualBasic;
using FilesService;

namespace my_server.services
{
    public class SchedulingService : ISchedule
    {
        //a service object for read and write to a file
        private readonly IFile _fs;
        public SchedulingService(IFile fs)
        {
            _fs = fs;
        }
        Scheduling chosen = new Scheduling();
           
        List<List<Volunteer>> scheduling = new List<List<Volunteer>>(){
            new List<Volunteer>(),
            new List<Volunteer>(),
            new List<Volunteer>(),
            new List<Volunteer>(),
            new List<Volunteer>()

        };

        public List<Volunteer> GetVoluteersByDay(int day)
        {
            return GetScheduling()[day];

        }
        public List<List<Volunteer>> GetScheduling()
        {
            //build a list of days and who wants to volunteer each day 
            //by the choices of the volunteers

            List<Volunteer> listi = _fs.Read<Volunteer>("data.json");
            listi.ForEach(v =>
            {
                for (int i = 0; i < v.Days.Length; i++)
                {
                    if (v.Days[i] && !scheduling[i].Exists(x => x.Id == v.Id))
                    {
                        scheduling[i].Add(v);
                    }
                    if (!v.Days[i] && scheduling[i].Exists(x => x.Id == v.Id))
                    {
                        Volunteer vToRemove = scheduling[i].Find(x => x.Id == v.Id);
                        scheduling[i].Remove(vToRemove);
                    }
                }
            });
            return scheduling;
        }
        //save the volunteers who were chosen each day
        public bool SaveScheduling(Scheduling scheduling)
        {
            for (int i = 0; i < this.chosen.Chosen.Count(); i++)
            {
                this.chosen.Chosen[i] = scheduling.Chosen[i];
            }
            return true;
        }
        public Scheduling GetChosenScheduling()
        {
            return chosen;
        }
        //check if specipic volunteer was chosen to a specipic day
        public bool IsChoose(int id, int day)
        {
            if (this.chosen.Chosen[day] == id)
            {
                return true;
            }
            return false;

        }
    }
}
