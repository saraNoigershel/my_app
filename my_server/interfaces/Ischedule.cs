using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_server.models;

namespace my_server.interfaces
{
    public interface ISchedule
    {
        List<Volunteer> GetVoluteersByDay(int day);
        List<List<Volunteer>> GetScheduling();
        bool SaveScheduling(List<Int64> scheduling);
        public List<Int64> GetChosenScheduling();
        bool IsChoose(int id,int day);
    }
}