using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Controllers;
using WpfApp1.Models;
using WpfApp1.Tools;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
  public class GroupListViewModel : NotifyViewModel
    {
        GroupManager manager;

           

        public IEnumerable<GroupComputer> Groups { get => manager.GetAllGroups(); } 

        public GroupComputer SelectedGroup { get; set; }

        public CommandBinding EditGroup { get; set; }

        public CommandBinding RemoveGroup { get; set; }

        public GroupListViewModel()
        {
            manager = DB.GetGroupManager();

            RemoveGroup = new CommandBinding(() =>
            {
                if (SelectedGroup != null)
                { 
                manager.Delete(SelectedGroup);
                    SignalChanged("Groups");
                }
            });

            EditGroup = new CommandBinding(() => {
                if (SelectedGroup != null)
                    Pager.ChangedPageTo(new EditGroupPage(SelectedGroup));
            });
        }

       
    }
}
