using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Controllers;
using WpfApp1.Models;
using WpfApp1.Tools;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
   public class EditComputerViewModel : NotifyViewModel
    {
        public Computer SelectedComputer { get; set; }
        public List<GroupComputer> Groups { get; set; }
        public GroupComputer SelectedGroup { get; set; }
        public CommandBinding Save { get; set; }

        public EditComputerViewModel()
        {
            Groups = DB.GetGroupManager().GetAllGroups();
            SelectedComputer = new Computer();
            InitSave();
        }

        public EditComputerViewModel(Computer edit)
        {
            Groups = DB.GetGroupManager().GetAllGroups();
            SelectedComputer = edit;
            InitSave();
        }

        private void InitSave()
        {
            Save = new CommandBinding(() =>
           {
               SelectedComputer.GroupID = SelectedGroup?.ID ?? 0;
               if (SelectedComputer.ID == 0)
                   DB.GetComputerManager().
                   Add(SelectedComputer);
               else
                   DB.GetComputerManager().Update(SelectedComputer);
               Pager.ChangedPageTo(new ComputerListPage());
           });
        }
    }
}
