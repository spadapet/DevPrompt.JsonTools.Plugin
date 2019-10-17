using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using DevPrompt.Api;
using JsonTools.Plugin.UI;

namespace JsonTools.Plugin
{
    [Guid("ab69a7a5-d5da-43a0-82b0-06132ba57453")]
    internal sealed class JsonToolsTab : PropertyNotifier, ITab, IDisposable
    {
        private UIElement viewElement;

        public JsonToolsTab(IWindow window, IWorkspace workspace)
        {
        }

        public void Dispose()
        {
            this.ViewElement = null;
        }

        Guid ITab.Id => this.GetType().GUID;
        string ITab.Name => Resources.JSONToolsTabName;
        string ITab.Title => Resources.JSONToolsTabName;
        string ITab.Tooltip => string.Empty;
        ITabSnapshot ITab.Snapshot => null;
        IEnumerable<FrameworkElement> ITab.ContextMenuItems => null;

        public UIElement ViewElement
        {
            get
            {
                if (this.viewElement == null)
                {
                    this.viewElement = new Tools(this);
                }

                return this.viewElement;
            }

            set
            {
                if (this.viewElement != value)
                {
                    if (this.viewElement is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }

                    this.viewElement = value;
                    this.OnPropertyChanged(nameof(this.ViewElement));
                }
            }
        }

        void ITab.Focus()
        {
            if (this.viewElement != null)
            {
                Action action = () => this.viewElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
                this.viewElement.Dispatcher.BeginInvoke(action, DispatcherPriority.Normal);
            }
        }

        void ITab.OnShowing()
        {
        }

        void ITab.OnHiding()
        {
        }

        bool ITab.OnClosing()
        {
            return true;
        }

        void ITab.OnSetTabName()
        {
        }

        void ITab.OnClone()
        {
        }

        void ITab.OnDetach()
        {
        }
    }
}
