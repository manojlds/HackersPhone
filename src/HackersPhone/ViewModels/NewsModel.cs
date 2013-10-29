using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackersPhone.ViewModels
{
    public class NewsModel
    {
        public NewsPage FrontPage { get; set; }
        public NewsPage New { get; set; }
        public bool IsDataLoaded { get; set; }
        public void LoadData()
        {
            IsDataLoaded = true;
        }
    }
}
