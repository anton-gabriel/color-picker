using ColorPicker.ViewModel;
using System.Windows;

namespace ColorPicker.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            Topmost = true;
        }
    }
}
