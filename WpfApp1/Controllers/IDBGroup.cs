using System.Collections.Generic;
using WpfApp1.Models;

namespace WpfApp1.Controllers
{
    public interface IDBGroup
    {
        IEnumerable<GroupComputer> GetAllGroups();
        GroupComputer CreateNewGroup(string name);
        void Update(GroupComputer group);
    }
}