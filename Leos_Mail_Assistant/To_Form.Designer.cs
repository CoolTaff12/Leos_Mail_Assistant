namespace Leos_Mail_Assistant
{
    partial class To_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(To_Form));
            this.toRichText = new System.Windows.Forms.RichTextBox();
            this.importTO = new System.Windows.Forms.Button();
            this.cancelTo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // toRichText
            // 
            this.toRichText.Location = new System.Drawing.Point(12, 38);
            this.toRichText.Name = "toRichText";
            this.toRichText.Size = new System.Drawing.Size(279, 371);
            this.toRichText.TabIndex = 17;
            this.toRichText.Text = "";
            // 
            // importTO
            // 
            this.importTO.Location = new System.Drawing.Point(163, 415);
            this.importTO.Name = "importTO";
            this.importTO.Size = new System.Drawing.Size(106, 23);
            this.importTO.TabIndex = 18;
            this.importTO.Text = "Import";
            this.importTO.UseVisualStyleBackColor = true;
            this.importTO.Click += new System.EventHandler(this.importTO_Click);
            // 
            // cancelTo
            // 
            this.cancelTo.Location = new System.Drawing.Point(38, 415);
            this.cancelTo.Name = "cancelTo";
            this.cancelTo.Size = new System.Drawing.Size(106, 23);
            this.cancelTo.TabIndex = 19;
            this.cancelTo.Text = "Remove";
            this.cancelTo.UseVisualStyleBackColor = true;
            this.cancelTo.Click += new System.EventHandler(this.cancelTo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Copy and paste the list down here:";
            // 
            // To_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(306, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelTo);
            this.Controls.Add(this.importTO);
            this.Controls.Add(this.toRichText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "To_Form";
            this.Text = "To_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox toRichText;
        private System.Windows.Forms.Button importTO;
        private System.Windows.Forms.Button cancelTo;
        private System.Windows.Forms.Label label1;
    }
}