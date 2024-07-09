using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace BrightnessWheel
{
    public partial class frmProxySettings : BrightnessWheel.CustomForm
    {
        public frmProxySettings()
        {
            InitializeComponent();
        }

        private void frmProxySettings_Load(object sender, EventArgs e)
        {
            string autodetect = RegistryHelper2.GetKeyValue("Proxy Settings", "Auto Detect").ToString();

            if (autodetect==string.Empty)
            {
                autodetect = bool.TrueString;
            }

            bool bautodetect = bool.Parse(autodetect);

            rdAutoDetect.Checked = bautodetect;
            rdSet.Checked = !bautodetect;

            txtProxyHost.Text= RegistryHelper2.GetKeyValue("Proxy Settings", "Host").ToString();
            txtProxyPort.Text = RegistryHelper2.GetKeyValue("Proxy Settings", "Port").ToString();
            txtProxyUsername.Text = RegistryHelper2.GetKeyValue("Proxy Settings", "Username").ToString();

            string proxypass=RegistryHelper2.GetKeyValue("Proxy Settings", "Password").ToString();

            StringDecrypter sd= new StringDecrypter(proxypass, "12323493849230423040");

            txtProxyPassword.Text = sd.Value;

            string defcr= RegistryHelper2.GetKeyValue("Proxy Settings", "Default Credentials").ToString();

            chkDefaultCredentials.Checked= ((defcr == string.Empty) || (defcr == bool.TrueString));

            txtProxyUsername.Enabled = !chkDefaultCredentials.Checked;
            txtProxyPassword.Enabled = !chkDefaultCredentials.Checked;

        }

        private void rdAutoDetect_CheckedChanged(object sender, EventArgs e)
        {
            grpProxySettings.Enabled = !rdAutoDetect.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!rdAutoDetect.Checked)
            {
                if (txtProxyHost.Text.Trim() == string.Empty)
                {
                    Module.ShowMessage("Please specify Proxy Host !");
                    return;
                }

                if (txtProxyPort.Text.Trim() == string.Empty)
                {
                    Module.ShowMessage("Please specify Proxy Port !");
                    return;
                }

                try
                {
                    int port = int.Parse(txtProxyPort.Text);
                }
                catch
                {
                    Module.ShowMessage("Please specify valid Proxy Port !");
                    return;
                }

                if (!chkDefaultCredentials.Checked)
                {
                    if (txtProxyUsername.Text.Trim()==string.Empty)
                    {
                        Module.ShowMessage("Please specify Proxy Username !");
                        return;
                    }
                }
            }

            StringEncrypter se = new StringEncrypter(txtProxyPassword.Text, "12323493849230423040");

            RegistryHelper2.SetKeyValue("Proxy Settings", "Auto Detect", rdAutoDetect.Checked.ToString());
            RegistryHelper2.SetKeyValue("Proxy Settings", "Host", txtProxyHost.Text);
            RegistryHelper2.SetKeyValue("Proxy Settings", "Port", txtProxyPort.Text);
            RegistryHelper2.SetKeyValue("Proxy Settings", "Username", txtProxyUsername.Text);
            RegistryHelper2.SetKeyValue("Proxy Settings", "Password", se.Value);
            RegistryHelper2.SetKeyValue("Proxy Settings", "Default Credentials", chkDefaultCredentials.Checked.ToString());

            this.DialogResult = DialogResult.OK;
        }

        private void chkDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            txtProxyUsername.Enabled = !chkDefaultCredentials.Checked;
            txtProxyPassword.Enabled = !chkDefaultCredentials.Checked;
        }
    }

    public class StringEncrypter
    {
        private readonly string message;
        private readonly string passphrase;

        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(passphrase))
                {
                    return string.Empty;
                }

                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5
                // We use the MD5 hash generator as the result is a 128 bit byte array
                // which is a valid length for the TripleDES encoder we use below

                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));

                // Step 2. Create a new TripleDESCryptoServiceProvider object
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. Setup the encoder
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert the input string to a byte[]
                byte[] DataToEncrypt = UTF8.GetBytes(message);

                // Step 5. Attempt to encrypt the string
                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Step 6. Return the encrypted string as a base64 encoded string
                return Convert.ToBase64String(Results);
            }
        }

        public StringEncrypter(string Message, string Passphrase)
        {
            message = Message;
            passphrase = Passphrase;
        }
    }

    public class StringDecrypter
    {
        private readonly string message;
        private readonly string passphrase;

        public string Value
        {
            get
            {
                if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(passphrase))
                {
                    return string.Empty;
                }

                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5
                // We use the MD5 hash generator as the result is a 128 bit byte array
                // which is a valid length for the TripleDES encoder we use below

                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));

                // Step 2. Create a new TripleDESCryptoServiceProvider object
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. Setup the decoder
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert the input string to a byte[]
                byte[] DataToDecrypt = Convert.FromBase64String(message);

                // Step 5. Attempt to decrypt the string
                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Step 6. Return the decrypted string in UTF8 format
                return UTF8.GetString(Results);
            }
        }

        public StringDecrypter(string Message, string Passphrase)
        {
            message = Message;
            passphrase = Passphrase;
        }
    }
}
