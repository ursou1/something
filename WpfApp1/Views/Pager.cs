using System;
using System.Windows.Controls;
using WpfApp1.Views;

namespace WpfApp1
{
    public static class Pager
    {
        internal static void ChangedPageTo(Page page)
        {
            ChangePage?.Invoke(null, page);
        }

        internal static event EventHandler<Page> ChangePage;
    }
}