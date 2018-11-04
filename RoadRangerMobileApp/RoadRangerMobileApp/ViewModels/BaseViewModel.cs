
namespace RoadRangerMobileApp.ViewModels
{
    public class BaseViewModel
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { Title = value; }
        }

    }
}
