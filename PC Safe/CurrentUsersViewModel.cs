using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Safe
{
    public class CurrentUsersViewModel : BaseViewModel
    {

        public List<CurrentUserViewModel> Users { get; set; }

        public static CurrentUsersViewModel Instance => new CurrentUsersViewModel();

        public CurrentUsersViewModel()
        {
            Users = new List<CurrentUserViewModel>()

            //Retrieve(Users);

            {
                new CurrentUserViewModel
                {
                    Initials = "BZ",
                    Name = "Beimnet Zewdu",
                    Id = "ATR/8563/09",
                    Entry_time = "08:00",
                },
                new CurrentUserViewModel
                {
                    Initials = "AM",
                    Name = "Beimnet Zewdu",
                    Id = "ATR/8563/09",
                    Entry_time = "08:00",
                },
                new CurrentUserViewModel
                {
                    Initials = "BH",
                    Name = "Beimnet Zewdu",
                    Id = "ATR/8563/09",
                    Entry_time = "08:00",
                }
            };
        }

        //public void Retrieve(List<CurrentUserViewModel> Users)
        //{
        //    pc_safeEntities dbobj = new pc_safeEntities();
        //    List<currentuser> currentUsers = dbobj.currentusers.ToList();
        //    foreach(currentuser cu in currentUsers)
        //    {
        //        student stud = dbobj.students.Find(cu.Id);
        //        string studName = stud.Name;
        //        string studId = stud.Id;
        //        string studEntry = "9";
        //        Users.Add(
        //            new CurrentUserViewModel
        //            {
        //                Initials = "AA",
        //                Name = studName,
        //                Id = studId,
        //                Entry_time = studEntry,
        //            });
        //    }
        //}
    }
}
 

    

