using DentalProjectConstruction;

namespace CopyLink
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
            if (args.Length == 1)
            {
                try
                {
                    string fileDIR = args[0];
                    if (fileDIR.EndsWith(".html"))
                    {
                        int webViewID = WebViewShareUpload.QueryWebView.Instance.GetURL(fileDIR);
                        if (webViewID != -1)
                        {
                            string URLView = WebViewShareUpload.SettingsApplication.URL + @"?id=" + webViewID;
                            Clipboard.SetText(URLView);
                            MessageBox.Show("Đã lưu link Webview URL vào Clipboard", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("URL not found, please create first!", "Error");
                        }
                    }
                    else
                    {
                        string URLView = "";
                        if (fileDIR.EndsWith(".dentalProject"))
                        {
                            Exception? ex = new Exception();
                            Treatment treatment = XMLFuncions.DeserializeFromXML(fileDIR, out ex);
                            if (treatment == null)
                            {
                                MessageBox.Show(ex.Message,"Error");
                            }
                            else
                            {
                                string patientFName = treatment.Patient.PatientFirstName;
                                string patientLName = treatment.Patient.PatientName;
                                string ClientName = treatment.Practice.PracticeName;
                                URLView += $"{patientLName}, nha khoa {ClientName}, bệnh nhân {patientFName}\n";
                            }
                        }
                        string dir = Path.GetDirectoryName(fileDIR).TrimEnd('\\');
                        dir += "\\";
                        int webViewID = WebViewShareUpload.QueryWebView.Instance.GetURL(dir);
                        if (webViewID != -1)
                        {
                            URLView += WebViewShareUpload.SettingsApplication.URL + @"?id=" + webViewID;
                            Clipboard.SetText(URLView);
                            MessageBox.Show("Đã lưu link Webview URL vào Clipboard", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("URL not found, please create first!", "Error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}