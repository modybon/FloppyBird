using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("CartoonFun-rg0zO.ttf", Alias = "TitleFont")]
[assembly: ExportFont("Thickdeco-V8Gz.ttf", Alias = "ButtonFont")]
namespace FloppyBird
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new GamePage());
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
