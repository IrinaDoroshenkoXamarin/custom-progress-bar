
using CustomProgressBar.PageModels;
using Xamarin.Forms;

namespace CustomProgressBar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =  FreshMvvm.FreshPageModelResolver.ResolvePageModel<MainPageModel>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
