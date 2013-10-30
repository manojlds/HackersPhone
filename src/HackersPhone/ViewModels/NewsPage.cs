using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HackersPhone.ViewModels
{
    public class NewsPage
    {
        private ObservableCollection<NewsItem> _items = new ObservableCollection<NewsItem>();
        public ObservableCollection<NewsItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public string Title { get; set; }
    }
}
