using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Tools
{
    public class NotifyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        
        public void SignalChanged(string prop)
        {
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(prop));
        }
    }
}
