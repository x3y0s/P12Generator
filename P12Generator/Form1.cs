using System.Diagnostics;

namespace P12Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonSearchCertificate_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new() { Filter = "Certificate files(*.cer;)|*.cer;" };
            dialog.ShowDialog(this);

            textBoxCertificatePath.Text = dialog.FileName;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string certPath = textBoxCertificatePath.Text;
            string pemFile = "certificate.pem";
            string privateKeyFile = "privateKey.key";

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string opensslPath = @"OpenSSL\openssl.exe";
            string processPath = Path.Combine(basePath, opensslPath);

            try
            {
                if (PreChecks(processPath) == false) return;

                File.WriteAllText(privateKeyFile, richTextBoxPrivateKey.Text);

                var pemProcess = Process.Start(processPath, $"x509 -in {certPath} -inform DER -out {pemFile} -outform PEM");
                pemProcess.WaitForExit();

                if (File.Exists(pemFile) == false)
                {
                    Show("Errore estrazione del file PEM dal certificato!!!");
                    return;
                }

                string p12File = $"{Path.GetFileNameWithoutExtension(textBoxCertificatePath.Text)}.p12";

                var process = Process.Start(processPath, $"pkcs12 -export -out {p12File} -inkey {privateKeyFile} -in {pemFile}");
                process.WaitForExit();

                if (File.Exists(p12File) == false)
                {
                    Show("Errore generazione del file P12!!!");
                    return;
                }

                Show($"FILE P12 GENERATO CORRETTAMENTE AL PERCORSO \n\n {Path.GetFullPath(p12File)}");
            }
            catch (Exception ex)
            {
                Show($"Errore: {ex}");
            }

        }

        private static bool VerifyPrivateKey(string privateKey)
        {
            string keyHeader = "-----BEGIN PRIVATE KEY-----";
            string keyEnd = "-----END PRIVATE KEY-----";

            List<string> lines = privateKey.Split(new char[] { '\n', }).ToList();

            //check delimiters
            if (lines.FirstOrDefault() != keyHeader || lines.LastOrDefault() != keyEnd)
                return false;

            //"trim" it
            lines = lines.Skip(1).SkipLast(1).ToList();

            //check content
            if (lines.Any() == false)
                return false;

            return true;
        }

        private void Show(string msg)
            => MessageBox.Show(this, msg);

        private bool PreChecks(string processPath)
        {
            if (string.IsNullOrEmpty(textBoxCertificatePath.Text) || string.IsNullOrEmpty(richTextBoxPrivateKey.Text))
            {
                Show("Percorso certificato e chiave privata richiesti!!!");
                return false;
            }

            if (VerifyPrivateKey(richTextBoxPrivateKey.Text) == false)
            {
                Show("Chiave privata NON VALIDA!!!");
                return false;
            }

            if (File.Exists(textBoxCertificatePath.Text) == false)
            {
                Show("Il certificato NON ESISTE!!!");
                return false;
            }

            if (File.Exists(processPath) == false)
            {
                Show($"Eseguibile di OpenSSL non presente al percorso {processPath}");
                return false;
            }

            return true;
        }
    }
}