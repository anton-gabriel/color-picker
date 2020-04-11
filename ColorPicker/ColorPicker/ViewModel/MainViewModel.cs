using ColorPicker.Commands.MainViewCommands;
using ColorPicker.Model;
using System.Windows.Input;
using System.Windows.Media;

namespace ColorPicker.ViewModel
{
    internal sealed class MainViewModel
         : BaseViewModel
    {
        #region Constructors
        public MainViewModel()
        {
            PickColorCommand = new PickColorCommand(this);
        }
        #endregion

        #region Private fields
        private ColorInfo color;
        #endregion

        #region Properties
        public ColorInfo Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Brush));
            }
        }
        public Brush Brush
        {
            get
            {
                (byte r, byte g, byte b) = Color.RGBComponents;
                return new SolidColorBrush(System.Windows.Media.Color.FromRgb(r, g, b));
            }
        }
        #endregion

        #region Commands
        public ICommand PickColorCommand { get; private set; }
        #endregion
    }
}
