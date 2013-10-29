using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackersPhone.ViewModels
{
    public class NewsPage
    {
        private List<NewsItem> _items = new List<NewsItem>();

        public List<NewsItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public string Title { get; set; }
    }
}
