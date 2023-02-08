using System.Diagnostics;

namespace P12Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition= FormStartPosition.CenterScreen;
        }

        private void buttonSearchCertificate_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new() { Filter = "Certificate files(*.cer;)|*.cer;" };
            dialog.ShowDialog(this);

            textBoxCertificatePath.Text = dialog.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCertificatePath.Text) || string.IsNullOrEmpty(richTextBoxPrivateKey.Text))
            {
                Show("Percorso certificato e chiave privata richiesti!!!");
                return;
            }

            if(VerifyPrivateKey(richTextBoxPrivateKey.Text) == false) 
            {
                Show("Chiave privata NON VALIDA!!!");
                return;
            }

            string certPath = textBoxCertificatePath.Text;
            string pemFile = "certificate.pem";
            string p12File = "exctracted.p12";
            string privateKeyFile = "privateKey.key";

            File.WriteAllText(privateKeyFile, richTextBoxPrivateKey.Text);

            var pemProcess = Process.Start(@"OpenSSL\openssl.exe", $"x509 -in {certPath} -inform DER -out {pemFile} -outform PEM");
            pemProcess.WaitForExit();

            if (File.Exists(pemFile) == false)
            {
                Show("Errore estrazione del file PEM dal certificato!!!");
                return;
            }

            var process = Process.Start(@"OpenSSL\openssl.exe", $"pkcs12 -export -out {p12File} -inkey {privateKeyFile} -in {pemFile}");
            process.WaitForExit();

            if (File.Exists(p12File) == false)
            {
                Show("Errore estrazione generazione del file P12!!!");
                return;
            }

            Show($"FILE P12 GENERATO CORRETTAMENTE AL PERCORSO \n\n {Path.GetFullPath(p12File)}");
        }

        private bool VerifyPrivateKey(string privateKey)
        {
            string keyHeader = "-----BEGIN PRIVATE KEY-----";
            string keyEnd = "-----END PRIVATE KEY-----";

            List<string> lines = privateKey.Split(new char[] { '\n', }).ToList();

            if (lines.FirstOrDefault() != keyHeader || lines.LastOrDefault() != keyEnd)
                return false;
            
            return true;
        }

        private void Show(string msg)
            => MessageBox.Show(this, msg);
    }
}