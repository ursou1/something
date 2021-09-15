using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Controllers;
using WpfApp1.Models;

namespace WpfApp1.Models
{
    public partial class Computer
    {
        public GroupComputer Group
        {
            get => DB.GetGroupManager().SelectGroupByID(GroupID);
            
        }


    }
}
