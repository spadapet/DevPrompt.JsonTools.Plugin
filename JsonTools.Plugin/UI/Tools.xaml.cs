using JsonTools.Plugin.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JsonTools.Plugin.UI
{
    internal partial class Tools : UserControl
    {
        public JsonToolsTab Tab { get; }
        public ToolsVM ViewModel { get; }

        public Tools(JsonToolsTab tab)
        {
            this.Tab = tab;
            this.ViewModel = new ToolsVM();
            this.InitializeComponent();
        }

        private void OnValidate(object sender, RoutedEventArgs e)
        {
            this.ViewModel.OnValidate();
        }

        private void OnPrettify(object sender, RoutedEventArgs e)
        {
            this.ViewModel.OnPrettify();
        }

        private void OnStringify(object sender, RoutedEventArgs e)
        {
            this.ViewModel.OnStringify();
        }
    }
}
