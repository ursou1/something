using WpfApp1.Controllers;
using WpfApp1.Models;
using WpfApp1.Tools;
using WpfApp1.Views;

namespace WpfApp1
{
    public class EditGroupViewModel :NotifyViewModel
    {
        private GroupComputer selectedGroup;
        public GroupComputer SelectedGroup
        { 
            get => selectedGroup; 
            set => selectedGroup = value; 
        }

        public CommandBinding SaveChangeds { get; set; }

        public EditGroupViewModel()
        {
            SelectedGroup = new GroupComputer();
            InitSaveChanges();
        }
       
        public EditGroupViewModel(GroupComputer selectedGroup)
        {
            this.SelectedGroup = selectedGroup;
            InitSaveChanges();
        }

        private void InitSaveChanges()
        {
            SaveChangeds = new CommandBinding(() =>
            {
                if (SelectedGroup.ID == 0)
                {
                    DB.GetGroupManager().
                         Add(SelectedGroup);
                }
                else
                    DB.GetGroupManager().Update(SelectedGroup);
                Pager.ChangedPageTo(new GroupListPage());
            });
        }

       
        
    }
}