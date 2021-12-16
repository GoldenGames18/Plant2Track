using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VINCENT.Nicolas.Poo.Tracker.Gui
{
    public partial class CommentaryView :  UserControl
    {
        public CommentaryView()
        {
            InitializeComponent();
#if DEBUG
            
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
