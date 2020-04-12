using ColorPicker.Commands.MainViewCommands;
using System.Linq;

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
        private System.Windows.Media.Color color;
        #endregion

        #region Properties
        public System.Windows.Media.Color Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged(nameof(HEX));
                OnPropertyChanged(nameof(RGB));
                OnPropertyChanged(nameof(Brush));
            }
        }
        public System.Windows.Media.Brush Brush
        {
            get
            {
                if (Color != null)
                {
                    (byte r, byte g, byte b) = (Color.R, Color.G, Color.B);
                    return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(r, g, b));
                }
                return System.Windows.Media.Brushes.Transparent;
            }
        }
        public string RGB
        {
            get => $"{Color.R}, {Color.G}, {Color.B}";
            set
            {
                try
                {
                    var values = value
                        .Split(',')
                        .Select(value => byte.Parse(value))
                        .ToList();
                    Color = System.Windows.Media.Color.FromRgb(values[0], values[1], values[2]);
                }
                catch
                {
                }
            }
        }
        public string HEX
        {
            get => string.Format("{0:X2}{1:X2}{2:X2}", Color.R, Color.G, Color.B);
            set
            {
                try
                {
                    Color = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString($"#{value}");
                }
                catch
                {
                }
            }
        }
        #endregion

        #region Commands
        public System.Windows.Input.ICommand PickColorCommand { get; private set; }
        #endregion
    }
}
