using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FloppyBird
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ShopPage : TabbedPage
    {
        public ShopPage()
        {
            InitializeComponent();
        }

        void ShopList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }
    }
}
