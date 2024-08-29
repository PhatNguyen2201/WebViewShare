using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewShareUpload
{
    public class AddWebView
    {
        private static AddWebView? instance;
        public static AddWebView Instance { get { if (instance == null) Instance = new AddWebView(); return instance; } set => instance = value; }
        public void AddNewWebView(string projectDIR)
        {
            if (projectDIR.EndsWith(".html"))
            {
                string htmlName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".html";
                string timenow = DateTime.Now.ToString();
                string desDIR = SettingsApplication.wwwrootDIR + htmlName;
                File.Copy(projectDIR, desDIR, true);
                if (!QueryWebView.Instance.AddFileName(timenow, projectDIR, htmlName, out string exeption))
                {
                    _ = MessageBox.Show(exeption, "Error");
                }
            }
            else
            {
                string folderDIR = Path.GetDirectoryName(projectDIR).TrimEnd('\\');
                folderDIR += "\\";
                if (Directory.Exists(folderDIR))
                {
                    DirectoryInfo ProjectDIRInfo = new DirectoryInfo(folderDIR);
                    FileInfo[] fileInfos = ProjectDIRInfo.GetFiles();
                    string htmlDIR = "";
                    string htmlName = "";
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        string filePath = fileInfo.FullName;
                        if (filePath.EndsWith(".html"))
                        {
                            htmlDIR = filePath;
                            htmlName = fileInfo.Name;
                            break;
                        }
                    }
                    if (htmlDIR == "")
                    {
                        _ = MessageBox.Show("HTML not found", "Error");
                    }
                    else
                    {
                        int ID = QueryWebView.Instance.CheckDIRDuplicated(folderDIR);
                        if (ID > -1)
                        {
                            string timenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string desDIR = SettingsApplication.wwwrootDIR + htmlName;
                            File.Copy(htmlDIR, desDIR, true);
                            if (!QueryWebView.Instance.UpdateWebView(ID, timenow, htmlName, out string exeption))
                            {
                                _ = MessageBox.Show(exeption, "Error");
                            }
                        }
                        else
                        {
                            string timenow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string desDIR = SettingsApplication.wwwrootDIR + htmlName;
                            File.Copy(htmlDIR, desDIR, true);
                            if (!QueryWebView.Instance.AddFileName(timenow, folderDIR, htmlName, out string exeption))
                            {
                                _ = MessageBox.Show(exeption, "Error");
                            }
                        }
                    }
                }
            }
        }
    }
}
