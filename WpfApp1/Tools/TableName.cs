using System;

namespace WpfApp1
{
    class TableNameAttribute : Attribute
    {
        public TableNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}