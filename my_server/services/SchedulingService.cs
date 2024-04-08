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
        private readonly IFile _fs;
        public SchedulingService(IFile fs)
        {
            _fs = fs;
        }
        List<Int64> chosen = new List<Int64>(){
            -1,-1,-1,-1,-1
        };

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
        public bool SaveScheduling(List<Int64> scheduling)
        {
            Console.WriteLine(chosen);
            for (int i = 0; i < this.chosen.Count(); i++)
            {
                chosen[i] = scheduling[i];
            }
            return true;
        }
        public List<Int64> GetChosenScheduling()
        {
            return chosen;
        }
        public bool IsChoose(int id, int day)
        {
            Console.WriteLine(chosen);
            if (this.chosen[day] == id)
            {
                return true;
            }
            return false;

        }
    }
}
