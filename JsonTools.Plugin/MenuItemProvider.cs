﻿using DevPrompt.Api;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Windows.Controls;

namespace JsonTools.Plugin
{
    /// <summary>
    /// Adds custom menu items to the main window
    /// </summary>
    [Export(typeof(IMenuItemProvider))]
    public class MenuItemProvider : IMenuItemProvider
    {
        IEnumerable<MenuItem> IMenuItemProvider.GetMenuItems(MenuType menu, IWindow window)
        {
            switch (menu)
            {
                case MenuType.Tools:
                    yield return new MenuItem()
                    {
                        Header = Resources.JSONToolsDashboardMenuName,
                        Command = new DelegateCommand(() => this.ShowJsonTools(window)),
                    };
                    break;
            }
        }

        private void ShowJsonTools(IWindow window)
        {
            // Adds a new tab or activates and existing tab in the default process workspace
            if (window.FindWorkspace(Constants.ProcessWorkspaceId) is IWorkspaceHolder workspaceHolder && workspaceHolder.Workspace is ITabWorkspace workspace)
            {
                window.ActiveWorkspace = workspaceHolder;

                if (workspace.Tabs.FirstOrDefault(t => t.Id == typeof(JsonToolsTab).GUID) is ITabHolder tabHolder)
                {
                    // The tab was already open, make sure it's shown
                    workspace.ActiveTab = tabHolder;
                }
                else
                {
                    ITab tab = new JsonToolsTab(window, workspace);
                    workspace.AddTab(tab, activate: true);
                }
            }
        }
    }
}
