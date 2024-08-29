namespace WebViewShareUpload
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if (args.Length == 0)
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            else
            {
                int i = 0;
                try
                {
                    string dir = args[0];
                    AddWebView.Instance.AddNewWebView(dir);
                    MessageBox.Show("Đã public webview. Ấn Copy URL Webview để sao chép đường dẫn", "Thông báo");
                }
                catch (Exception ex)
                {
                    File.WriteAllText(@"C:\Users\Public\logErrorMain.txt", "UpdateWebView Error - " + ex + "at line " + i);
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
    }
}