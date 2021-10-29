using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFToursProject
{
    class Tours
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int TicketCount { get; set; }

        public bool IsActive { get; set; }

        public string ActualText {
            get
            {
                return (IsActive) ? "Актуально" : "Не актуально";
            }
        }
    }
}
