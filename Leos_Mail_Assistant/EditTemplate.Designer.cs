namespace Leos_Mail_Assistant
{
    partial class EditTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTemplate));
            this.haveMailto = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fromSub = new System.Windows.Forms.TextBox();
            this.mBodyText = new System.Windows.Forms.RichTextBox();
            this.importTOO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // haveMailto
            // 
            this.haveMailto.AutoSize = true;
            this.haveMailto.Location = new System.Drawing.Point(-207, 98);
            this.haveMailto.Name = "haveMailto";
            this.haveMailto.Size = new System.Drawing.Size(82, 17);
            this.haveMailto.TabIndex = 41;
            this.haveMailto.Text = "Have mailto";
            this.haveMailto.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Subject";
            // 
            // fromSub
            // 
            this.fromSub.Location = new System.Drawing.Point(61, 21);
            this.fromSub.Name = "fromSub";
            this.fromSub.Size = new System.Drawing.Size(353, 20);
            this.fromSub.TabIndex = 39;
            // 
            // mBodyText
            // 
            this.mBodyText.Location = new System.Drawing.Point(58, 58);
            this.mBodyText.Name = "mBodyText";
            this.mBodyText.Size = new System.Drawing.Size(356, 359);
            this.mBodyText.TabIndex = 42;
            this.mBodyText.Text = resources.GetString("mBodyText.Text");
            // 
            // importTOO
            // 
            this.importTOO.Location = new System.Drawing.Point(155, 423);
            this.importTOO.Name = "importTOO";
            this.importTOO.Size = new System.Drawing.Size(106, 23);
            this.importTOO.TabIndex = 43;
            this.importTOO.Text = "Import";
            this.importTOO.UseVisualStyleBackColor = true;
            this.importTOO.Click += new System.EventHandler(this.importTOO_Click);
            // 
            // EditTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 454);
            this.ControlBox = false;
            this.Controls.Add(this.importTOO);
            this.Controls.Add(this.mBodyText);
            this.Controls.Add(this.haveMailto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fromSub);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTemplate";
            this.Text = "EditTemplate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox haveMailto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fromSub;
        private System.Windows.Forms.RichTextBox mBodyText;
        private System.Windows.Forms.Button importTOO;
    }
}