using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;

namespace BrightnessWheel
{
    public partial class frmDownloadUpdate : CustomForm
    {
        private string _DownloadFile = "";

        private System.Windows.Forms.Timer timTimeout = new Timer();

        public string DownloadFile
        {
            get
            {
                if (_DownloadFile == string.Empty)
                {
                    int spos = DownloadURL.LastIndexOf("/");
                    string file = DownloadURL.Substring(spos + 1);

                    string tempdir = System.IO.Path.GetTempFileName() + "setup";

                    System.IO.Directory.CreateDirectory(tempdir);

                    _DownloadFile =System.IO.Path.Combine(tempdir, file);
                }
                                
                return _DownloadFile;
                
            }
        }
        public string DownloadURL
        {
            get
            {
                return GetEXEDownloadURL();
            }
        }

        //public WebClient client = null;

        public WebDownload client = null;
        public bool Cancelled = false;

        public frmDownloadUpdate()
        {
            InitializeComponent();
            
            pgBar.Value = 0;
            pgBar.Maximum = 100;

            ulDownloadFile.Text = DownloadURL;
        }

        private void DownloadUpdate()
        {
            try
            {
                if (System.IO.File.Exists(DownloadFile))
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(DownloadFile);
                    fi.Attributes = System.IO.FileAttributes.Normal;
                    fi.Delete();

                    //System.IO.File.Delete(DownloadFile);
                }

                timTimeout.Interval = 50 * 1000;
                timTimeout.Tick += TimTimeout_Tick;

                //client = new WebClient();

                client = new WebDownload();

                string autodetect = RegistryHelper2.GetKeyValue("Proxy Settings", "Auto Detect").ToString();

                if (autodetect == string.Empty)
                {
                    autodetect = bool.TrueString;
                }

                bool bautodetect = bool.Parse(autodetect);

                string host = RegistryHelper2.GetKeyValue("Proxy Settings", "Host").ToString();
                string port = RegistryHelper2.GetKeyValue("Proxy Settings", "Port").ToString();

                if (bautodetect)
                {
                    client.Proxy = System.Net.WebRequest.GetSystemWebProxy();
                }
                else
                {
                    client.Proxy = new System.Net.WebProxy(host, int.Parse(port));
                }

                string defcr = RegistryHelper2.GetKeyValue("Proxy Settings", "Default Credentials").ToString();
                bool usedef = ((defcr == string.Empty) || (defcr == bool.TrueString));

                string username = RegistryHelper2.GetKeyValue("Proxy Settings", "Username").ToString();

                string proxypass = RegistryHelper2.GetKeyValue("Proxy Settings", "Password").ToString();

                StringDecrypter sd = new StringDecrypter(proxypass, "12323493849230423040");

                string password = sd.Value;                

                if (usedef)
                {
                    client.UseDefaultCredentials = true;
                    client.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
                else
                {
                    client.UseDefaultCredentials = false;
                    client.Proxy.Credentials = new System.Net.NetworkCredential(username, password);
                }                

                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;                
                client.DownloadFileAsync(new Uri(DownloadURL), DownloadFile);

                timTimeout.Enabled = true;
            }
            catch (Exception ex)
            {
                Cancelled = true;

                Module.ShowError("Error could not download update !", ex);

                btnClose.Enabled = true;
            }
        }

        private void TimTimeout_Tick(object sender, EventArgs e)
        {
            timTimeout.Enabled = false;

            client.CancelAsync();

            while (client.IsBusy)
            {
                Application.DoEvents();
            }

            Cancelled = true;

            Module.ShowMessage(TranslateHelper.Translate("Error ! Download Timeout !"));

            btnClose.Enabled = true;
        }        

        private void frmDownloadUpdate_Load(object sender, EventArgs e)
        {
            DownloadUpdate();

            this.TopMost = false;
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            timTimeout.Enabled = false;

            if (!Cancelled)
            {
                Module.ShowMessage("The application will now exit and run the updated setup file");

                try
                {
                    System.Diagnostics.Process.Start(DownloadFile,"/S");

                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Cancelled = true;

                    Module.ShowError("Error. Could not run new Setup File !", ex);

                    this.DialogResult = DialogResult.Cancel;

                    this.Close();
                }
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage;
            pgBar.SetText(e.ProgressPercentage.ToString() + " %");
            
            decimal ukb=(decimal)e.TotalBytesToReceive/(decimal)1024;
            decimal umb=ukb/(decimal)1024;

            lblTotalSize.Text = umb.ToString("#0.0") + " MB";

            timTimeout.Enabled = false;
            timTimeout.Enabled = true;
        }

        public string GetEXEDownloadURL()
        {
            string durl = Module.DownloadURL;

            if (!durl.ToLower().EndsWith(".exe"))
            {
                if (durl.EndsWith("/"))
                {
                    durl = durl.Substring(0, durl.Length - 1);
                }
                int spos = durl.LastIndexOf("/", durl.Length - 1);

                string program = durl.Substring(spos + 1);

                return "http://softpcapps.com/downloads/" + program + "Setup.exe";
            }
            else
            {
                return durl;
            }
        }

        private void btnCancelDownload_Click(object sender, EventArgs e)
        {
            Cancelled = true;

            client.CancelAsync();

            this.DialogResult = DialogResult.Cancel;
        }

        private void frmDownloadUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Cancelled)
            {
                e.Cancel = true;

                Module.ShowMessage("Please wait for the application to download the update !");
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(DownloadURL);
        }

        private void btnProxy_Click(object sender, EventArgs e)
        {
            timTimeout.Enabled = false;

            frmProxySettings f = new frmProxySettings();

            if (f.ShowDialog()==DialogResult.OK)
            {
                client.CancelAsync();

                while (client.IsBusy)
                {
                    Application.DoEvents();
                }

                DownloadUpdate();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }

    public class WebDownload : WebClient
    {
        /// <summary>
        /// Time in milliseconds
        /// </summary>
        public int Timeout { get; set; }

        public WebDownload() : this(15000) { }

        public WebDownload(int timeout)
        {
            this.Timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request != null)
            {
                request.Timeout = this.Timeout;
            }
            return request;
        }
    }
}
