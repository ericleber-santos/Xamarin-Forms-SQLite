using TesteSQLCipher.ViewModels;
using Xamarin.Forms;

namespace TesteSQLCipher
{
    public partial class MainPage : ContentPage
    {
        readonly Class1ViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new Class1ViewModel();
        }
    }
}
