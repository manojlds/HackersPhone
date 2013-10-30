using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RestSharp;

namespace HackersPhone.ViewModels
{
    public class NewsModel : INotifyPropertyChanged
    {
        private NewsPage _frontPage = new NewsPage { Title = "frontpage" };
        private NewsPage _new = new NewsPage { Title = "new" };
        private const string ApiBaseUrl = "http://api.ihackernews.com";
        private const string FrontPageEndpoint = "page";
        private const string NewPageEndpoint = "new";

        public NewsPage FrontPage
        {
            get { return _frontPage; }
            set
            {
                _frontPage = value;
                OnPropertyChanged();
            }
        }

        public NewsPage New
        {
            get { return _new; }
            set
            {
                _new = value;
                OnPropertyChanged();
            }
        }

        public bool IsDataLoaded { get; set; }

        public void LoadData()
        {
            if (IsDataLoaded) return;

            var client = new RestClient(ApiBaseUrl);
            var restRequest = new RestRequest(FrontPageEndpoint, Method.GET);

            PopulateItems(FrontPageEndpoint, FrontPage);
            PopulateItems(NewPageEndpoint, New);

            IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PopulateItems(string endpoint, NewsPage pivotPage)
        {
            var client = new RestClient(ApiBaseUrl);
            var restRequest = new RestRequest(endpoint, Method.GET);

            client.ExecuteAsync(restRequest, restResponse =>
            {
                if (restResponse.Content != null && restResponse.StatusCode == HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<NewsPage>(restResponse.Content);
                    pivotPage.Items.Clear();
                    foreach (var item in data.Items)
                    {
                        pivotPage.Items.Add(item);
                    }
                }
            });
            
        }
    }
}
