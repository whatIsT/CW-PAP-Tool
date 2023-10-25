namespace MemClass
{
    partial class Main
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
            this.camoBtn = new System.Windows.Forms.Button();
            this.camoBox = new System.Windows.Forms.ComboBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // camoBtn
            // 
            this.camoBtn.Location = new System.Drawing.Point(12, 49);
            this.camoBtn.Name = "camoBtn";
            this.camoBtn.Size = new System.Drawing.Size(146, 23);
            this.camoBtn.TabIndex = 0;
            this.camoBtn.Text = "Set Camo";
            this.camoBtn.UseVisualStyleBackColor = true;
            this.camoBtn.Click += new System.EventHandler(this.camoBtn_Click);
            // 
            // camoBox
            // 
            this.camoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camoBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.camoBox.FormattingEnabled = true;
            this.camoBox.Items.AddRange(new object[] {
            "Gold",
            "Diamond",
            "DMU",
            "Golden Viper",
            "Plague Diamond",
            "Dark Aether",
            "PAP Orange",
            "PAP Green",
            "PAP Pink",
            "PAP Red",
            "PAP Blue/Green",
            "PAP Gold",
            "PAP Colorful",
            "PAP Glitching Pink",
            "PAP Glitching Orange",
            "Atlanta FaZe",
            "OpTic Chicago",
            "Dallas Empire",
            "Florida Mutineers",
            "Los Angeles Guerrillas",
            "Los Angeles Thieves",
            "London Royal Ravens",
            "Minnesota RØKKR",
            "New York Subliners",
            "Paris Legion",
            "Seattle Surge",
            "Toronto Ultra"});
            this.camoBox.Location = new System.Drawing.Point(12, 12);
            this.camoBox.Name = "camoBox";
            this.camoBox.Size = new System.Drawing.Size(146, 21);
            this.camoBox.TabIndex = 1;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(12, 78);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(146, 162);
            this.outputBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set Shards As One Of Your Camos";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 252);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.camoBox);
            this.Controls.Add(this.camoBtn);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "CW Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button camoBtn;
        private System.Windows.Forms.ComboBox camoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputBox;
    }
}

