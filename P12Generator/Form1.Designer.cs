namespace P12Generator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxCertificatePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearchCertificate = new System.Windows.Forms.Button();
            this.richTextBoxPrivateKey = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Generate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCertificatePath
            // 
            this.textBoxCertificatePath.Location = new System.Drawing.Point(178, 31);
            this.textBoxCertificatePath.Name = "textBoxCertificatePath";
            this.textBoxCertificatePath.Size = new System.Drawing.Size(400, 23);
            this.textBoxCertificatePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "PERCORSO CERTIFICATO (.cer)";
            // 
            // buttonSearchCertificate
            // 
            this.buttonSearchCertificate.Location = new System.Drawing.Point(584, 31);
            this.buttonSearchCertificate.Name = "buttonSearchCertificate";
            this.buttonSearchCertificate.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchCertificate.TabIndex = 2;
            this.buttonSearchCertificate.Text = "SFOGLIA";
            this.buttonSearchCertificate.UseVisualStyleBackColor = true;
            this.buttonSearchCertificate.Click += new System.EventHandler(this.buttonSearchCertificate_Click);
            // 
            // richTextBoxPrivateKey
            // 
            this.richTextBoxPrivateKey.Location = new System.Drawing.Point(6, 37);
            this.richTextBoxPrivateKey.Name = "richTextBoxPrivateKey";
            this.richTextBoxPrivateKey.Size = new System.Drawing.Size(659, 363);
            this.richTextBoxPrivateKey.TabIndex = 3;
            this.richTextBoxPrivateKey.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCertificatePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonSearchCertificate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 76);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CERTIFICATO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.richTextBoxPrivateKey);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(671, 406);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHIAVE PRIVATA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Copiare all\'interno del box la CHIAVE PRIVATA";
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(12, 506);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(671, 69);
            this.button_Generate.TabIndex = 6;
            this.button_Generate.Text = "GENERA P12";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button1_Generate);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 587);
            this.Controls.Add(this.button_Generate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "P12 GENERATOR";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox textBoxCertificatePath;
        private Label label1;
        private Button buttonSearchCertificate;
        private RichTextBox richTextBoxPrivateKey;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private Button button_Generate;
    }
}