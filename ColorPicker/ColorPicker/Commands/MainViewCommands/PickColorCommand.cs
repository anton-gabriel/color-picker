using ColorPicker.Model;
using ColorPicker.ViewModel;
using System.Drawing;
using System.Windows.Forms;

namespace ColorPicker.Commands.MainViewCommands
{
    internal sealed class PickColorCommand
        : RelayCommand<object>
    {
        #region Constructors
        public PickColorCommand(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            ExecuteDelegate = param => PickColor();
        }

        #endregion

        #region Properties
        private MainViewModel MainViewModel { get; set; }
        #endregion

        #region Private methods
        private void PickColor()
        {
            using var bitmap = new Bitmap(1, 1);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(Cursor.Position, new Point(0, 0), new Size(1, 1));
            }
            MainViewModel.Color = new ColorInfo(bitmap.GetPixel(0, 0));
        }
        #endregion
    }
}
