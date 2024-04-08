using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_server.models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public bool[] Days { get; set; }
        // public static List<Volunteer> Volunteers {get;set;}
        public Volunteer()
        {
    //         Volunteers= new List<Volunteer>()
    //     {
    //     new Volunteer(1, "Sari", "Noigershel", "0548484848",new bool[5]),
    //     new Volunteer(2, "Ayala", "Noigershel", "0533131313",new bool[5]),
    //     new Volunteer(3, "Tamar", "Yosefi","0527676767",new bool[5]),
    //     new Volunteer(4, "Naama", "Yosefi","0583232323",new bool[5])

    // } ;
            this.Id = 0;
            this.FirstName = "";
            this.LastName = "";
            this.Tel = "";
            this.Days = new bool[5];
        }
        public Volunteer(int id, string fname, string lname,string tel,bool[] days)
        {
            
            this.Id = id;
            this.FirstName = fname;
            this.LastName = lname;
            this.Tel = tel;
            this.Days = days;
            
        }
        
    }
    
  
}
