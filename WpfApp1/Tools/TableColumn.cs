using System;

namespace WpfApp1
{
    class TableColumnAttribute : Attribute
    {
        public TableColumnAttribute(string column)
        {
            Column = column;
        }

        public string Column { get; }
    }
}