using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_server.models;

namespace my_server.interfaces
{
    
        public interface IVolunteer
        {
            List<Volunteer> All();
            Volunteer ById(int id);
            bool Create(Volunteer v);
            bool Update(Volunteer v);



            bool Delete(int id);
        }
    
}
