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

<<<<<<< HEAD
            MainPage = new NavigationPage(new GameMenuPage());
=======
            MainPage = new NavigationPage(new FirstPage());
>>>>>>> 2177315c2221aedffe9e10f9db7338637cec0da2
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
