namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.lastUpdate = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Mistnosti = new System.Windows.Forms.TabPage();
            this.Elektromery = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lastUpdate
            // 
            this.lastUpdate.AutoSize = true;
            this.lastUpdate.Location = new System.Drawing.Point(12, 245);
            this.lastUpdate.Name = "lastUpdate";
            this.lastUpdate.Size = new System.Drawing.Size(0, 13);
            this.lastUpdate.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Mistnosti);
            this.tabControl1.Controls.Add(this.Elektromery);
            this.tabControl1.Location = new System.Drawing.Point(8, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(270, 255);
            this.tabControl1.TabIndex = 9;
            // 
            // Mistnosti
            // 
            this.Mistnosti.Location = new System.Drawing.Point(4, 22);
            this.Mistnosti.Name = "Mistnosti";
            this.Mistnosti.Padding = new System.Windows.Forms.Padding(3);
            this.Mistnosti.Size = new System.Drawing.Size(262, 229);
            this.Mistnosti.TabIndex = 0;
            this.Mistnosti.Text = "Místnosti";
            this.Mistnosti.UseVisualStyleBackColor = true;
            // 
            // Elektromery
            // 
            this.Elektromery.Location = new System.Drawing.Point(4, 22);
            this.Elektromery.Name = "Elektromery";
            this.Elektromery.Padding = new System.Windows.Forms.Padding(3);
            this.Elektromery.Size = new System.Drawing.Size(262, 229);
            this.Elektromery.TabIndex = 1;
            this.Elektromery.Text = "Elektroměry";
            this.Elektromery.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 267);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lastUpdate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lastUpdate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Mistnosti;
        private System.Windows.Forms.TabPage Elektromery;
    }
}

