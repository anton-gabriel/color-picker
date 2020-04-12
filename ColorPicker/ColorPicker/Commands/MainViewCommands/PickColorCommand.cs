using ColorPicker.ViewModel;

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
            using var bitmap = new System.Drawing.Bitmap(1, 1);
            using (var graphics = System.Drawing.Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(System.Windows.Forms.Cursor.Position, new System.Drawing.Point(0, 0), new System.Drawing.Size(1, 1));
            }
            var color = bitmap.GetPixel(0, 0);
            MainViewModel.Color = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
        #endregion
    }
}
