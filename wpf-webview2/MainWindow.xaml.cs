using Microsoft.Web.WebView2.Core;
using System;
using System.Windows;

namespace wpf_webview2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

            webView.CoreWebView2.Navigate(new Uri($"{Environment.CurrentDirectory}/AppData/index.html").AbsoluteUri);
        }

        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            textEditor.Text = e.TryGetWebMessageAsString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.ExecuteScriptAsync("runCode()");
        }
    }
}
