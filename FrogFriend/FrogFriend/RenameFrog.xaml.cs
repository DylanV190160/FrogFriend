using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrogFriend
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RenameFrog : ContentPage
    {
        public RenameFrog()
        {
            InitializeComponent();
        }

        async void SaveFrogClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}