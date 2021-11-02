using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFToursProject
{
    static class Paginator
    {
        public static int CurrentPage { get; set; }

        public static int DataCount { get; set; }

        public static int TotalPages {
            get 
            {
                return (DataCount % 10 == 0) ? DataCount / 10 : DataCount / 10 + 1;
            }
        }

        public static int NeedToView { get; set; }
    }

    class PagesComboBox
    {
        public int Index { get; set; }

        public int Value { get; set; }
    }
}
