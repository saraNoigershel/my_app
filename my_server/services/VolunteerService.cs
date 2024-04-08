using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_server.models;
using my_server.interfaces;
using FilesService;
using static my_server.services.SchedulingService;

namespace my_server.services
{
    public class VolunteerService : IVolunteer
    {
        private readonly IFile _fs;
        private readonly ISchedule _is;
        public VolunteerService(IFile fs, ISchedule isc)
        {
            this._fs = fs;
            this._is = isc;

        }

        public List<Volunteer> All()
        {
            return _fs.Read<Volunteer>("data.json");

        }
        public Volunteer ById(int id)
        {
            return this.All().FirstOrDefault<Volunteer>(v => v.Id == id);

        }

        public bool Create(Volunteer v)
        {
            this._fs.Write<Volunteer>(v, "data.json");
            return true;

        }
        //update details of a volunteer
        //if the volunteer didn't sign a day he was schedule throwing an exception
        public bool Update(Volunteer vi)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(vi.Id + " " + i + " " + _is.IsChoose(vi.Id, i));
                if (vi.Days[i] == false && _is.IsChoose(vi.Id, i))
                {
                    throw new ArgumentException(
            "You didn't sign a day that you had chosen to it. please remove the scheduling and after we can save your new choosing");
                }
            }
            List<Volunteer> ls = this.All();
            foreach (Volunteer v in ls)
            {
                if (v.Id == vi.Id)
                {
                    int index = ls.IndexOf(v);
                    ls[index] = vi;
                    this._fs.Update<Volunteer>("data.json", ls);
                    return true;
                }

            }
            return false;

        }
        public bool Delete(int id)
        {
            List<Volunteer> ls = this.All();
            foreach (Volunteer v in ls)
            {
                if (v.Id == id)
                {
                    ls.Remove(v);
                    this._fs.Update<Volunteer>("data.json", ls);
                    return true;
                }

            }
            return false;
        }
    }
}

