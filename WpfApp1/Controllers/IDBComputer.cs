using WpfApp1.Models;

namespace WpfApp1
{
    public interface IDBComputer
    {
        Computer CreateComputer();
        void Update(Computer computer);
    }
}