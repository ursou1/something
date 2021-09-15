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
    public class ComputerListViewModel : NotifyViewModel
    {
        public List<Computer> Computers { get; set; }
        public Computer SelectComputer { get; set; }
        public string SearchText { get; set; } = "";
        public CommandBinding Search { get; set; }
        public CommandBinding Edit { get; set; }
        public CommandBinding Delete { get; set; }

        public ComputerListViewModel()
        {
            Edit = new CommandBinding(() => Pager.ChangedPageTo(new EditComputerPage(SelectComputer)));
            Edit = new CommandBinding(() =>
            {
                if (SelectComputer != null)
                {
                    DB.GetComputerManager().Delete(SelectComputer);
                    Search.Execute(null);
                }
            });
            Search = new CommandBinding(() =>
            {
                var groupsId = DB.GetGroupManager().Search(SearchText).Select(g => g.ID);
                Computers = DB.GetComputerManager().Search(SearchText, groupsId);
                SignalChanged("Computers");
            });
            
        }
    }
}
