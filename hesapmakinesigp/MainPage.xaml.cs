using System.Runtime.Intrinsics.X86;

namespace hesapmakinesigp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext =new MainPageViewModel();
        }

        
    }

}
