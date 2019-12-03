using DevPrompt.Api.Utility;
using Efficient.Json;
using System;

namespace JsonTools.Plugin.UI.ViewModels
{
    internal class ToolsVM : PropertyNotifier
    {
        private string input;
        private string output;

        public string Input
        {
            get => this.input;
            set => this.SetPropertyValue(ref this.input, value);
        }

        public string Output
        {
            get => this.output ?? string.Empty;
            private set => this.SetPropertyValue(ref this.output, value);
        }

        public void OnValidate()
        {
            try
            {
                JsonValue.StringToString(this.input, formatted: false);
                this.Output = "Valid";
            }
            catch (Exception ex)
            {
                this.Output = ex.Message;
            }
        }

        public void OnPrettify()
        {
            try
            {
                this.Output = JsonValue.StringToString(this.input, formatted: true);
            }
            catch (Exception ex)
            {
                this.Output = ex.Message;
            }
        }

        public void OnStringify()
        {
            try
            {
                this.Output = JsonValue.StringToString(this.input, formatted: false);
            }
            catch (Exception ex)
            {
                this.Output = ex.Message;
            }
        }
    }
}
