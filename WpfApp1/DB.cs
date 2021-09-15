using System;
using WpfApp1.Models;

namespace WpfApp1.Controllers
{
    public class DB
    {
        static GroupManager groupManager;
        internal static GroupManager GetGroupManager()
        {
            if (groupManager == null)
                groupManager = new GroupManager(
                    new JsonDB<GroupComputer>("groups.db"));
            return groupManager;

        }
        static ComputerManager computerManager;
        internal static ComputerManager GetComputerManager()
        {
            if (computerManager == null)
                computerManager = new ComputerManager(
                    new JsonDB<Computer>("computers.db"));
            return computerManager;
        }
    }
}