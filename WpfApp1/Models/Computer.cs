using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    [TableName("computers")]
    public partial class Computer : DBObject
    {
        [TableColumn("ip-address")]
        public string IPAddress { get; set; } ="";
        [TableColumn("mac-address")]
        public string MACAddress { get; set; } ="";
        [TableColumn("domainname")]
        public string DomainName { get; set; } ="";
        [TableColumn("inumber")]
        public string INumber { get; set; } ="";
        [TableColumn("groupid")]
        public int GroupID { get; set; }
    }
}
