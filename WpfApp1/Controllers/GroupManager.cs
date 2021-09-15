using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Controllers
{
    public class GroupManager : Manager<GroupComputer>
    {

        public GroupManager(IDB<GroupComputer> iDBGroup) : base(iDBGroup)
        {

        }

        
        public List<GroupComputer> GetAllGroups() => 
            db.GetAll().ToList();

        public GroupComputer SelectGroupByID(int groupId)
        {
            GroupComputer group = db.GetAll().
                FirstOrDefault(g => g.ID == groupId);
            if (group == null)
                group = new GroupComputer {
                    Name = "Группа не найдена" };
            return group;
        }

        internal IEnumerable<GroupComputer> Search(string searchText)
        {
            searchText = searchText.ToLower();
            return db.GetAll().Where(g => g.Name.ToLower().Contains(searchText));
        }
    }
}
