using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Safe
{
    /// <summary>
    /// A view model for each current user in the current users overview
    /// </summary>

    public class CurrentUserViewModel : BaseViewModel 
    {
        public string Initials { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Entry_time { get; set; }

        public static CurrentUserViewModel Instance => new CurrentUserViewModel();

        public CurrentUserViewModel()
        {
            Initials = "BZ";
            Name = "Beimnet Zewdu";
            Id = "ATR/8563/09";
            Entry_time = "08:00";
        }

    }
}
