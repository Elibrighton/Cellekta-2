namespace Cellekta_2
{
    partial class MixDiscWindow
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
            this.playlistLabel = new System.Windows.Forms.Label();
            this.playlistComboBox = new System.Windows.Forms.ComboBox();
            this.bpmCheckBox = new System.Windows.Forms.CheckBox();
            this.keyCheckBox = new System.Windows.Forms.CheckBox();
            this.intensityCheckBox = new System.Windows.Forms.CheckBox();
            this.intensityStypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.totalPlaytimeLabel = new System.Windows.Forms.Label();
            this.totalPlaytimeComboBox = new System.Windows.Forms.ComboBox();
            this.mixLengthLabel = new System.Windows.Forms.Label();
            this.mixLengthComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.bpmRangeLabel = new System.Windows.Forms.Label();
            this.bpmRangeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // playlistLabel
            // 
            this.playlistLabel.AutoSize = true;
            this.playlistLabel.Location = new System.Drawing.Point(12, 13);
            this.playlistLabel.Name = "playlistLabel";
            this.playlistLabel.Size = new System.Drawing.Size(42, 13);
            this.playlistLabel.TabIndex = 0;
            this.playlistLabel.Text = "Playlist:";
            // 
            // playlistComboBox
            // 
            this.playlistComboBox.FormattingEnabled = true;
            this.playlistComboBox.Location = new System.Drawing.Point(92, 10);
            this.playlistComboBox.Name = "playlistComboBox";
            this.playlistComboBox.Size = new System.Drawing.Size(121, 21);
            this.playlistComboBox.TabIndex = 1;
            // 
            // bpmCheckBox
            // 
            this.bpmCheckBox.AutoSize = true;
            this.bpmCheckBox.Checked = true;
            this.bpmCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bpmCheckBox.Location = new System.Drawing.Point(92, 38);
            this.bpmCheckBox.Name = "bpmCheckBox";
            this.bpmCheckBox.Size = new System.Drawing.Size(47, 17);
            this.bpmCheckBox.TabIndex = 3;
            this.bpmCheckBox.Text = "Bpm";
            this.bpmCheckBox.UseVisualStyleBackColor = true;
            // 
            // keyCheckBox
            // 
            this.keyCheckBox.AutoSize = true;
            this.keyCheckBox.Checked = true;
            this.keyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keyCheckBox.Location = new System.Drawing.Point(92, 88);
            this.keyCheckBox.Name = "keyCheckBox";
            this.keyCheckBox.Size = new System.Drawing.Size(44, 17);
            this.keyCheckBox.TabIndex = 4;
            this.keyCheckBox.Text = "Key";
            this.keyCheckBox.UseVisualStyleBackColor = true;
            // 
            // intensityCheckBox
            // 
            this.intensityCheckBox.AutoSize = true;
            this.intensityCheckBox.Checked = true;
            this.intensityCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.intensityCheckBox.Location = new System.Drawing.Point(92, 112);
            this.intensityCheckBox.Name = "intensityCheckBox";
            this.intensityCheckBox.Size = new System.Drawing.Size(65, 17);
            this.intensityCheckBox.TabIndex = 5;
            this.intensityCheckBox.Text = "Intensity";
            this.intensityCheckBox.UseVisualStyleBackColor = true;
            // 
            // intensityStypeComboBox
            // 
            this.intensityStypeComboBox.FormattingEnabled = true;
            this.intensityStypeComboBox.Items.AddRange(new object[] {
            "Any",
            "Highest",
            "Lowest"});
            this.intensityStypeComboBox.Location = new System.Drawing.Point(92, 135);
            this.intensityStypeComboBox.Name = "intensityStypeComboBox";
            this.intensityStypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.intensityStypeComboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Intensity style:";
            // 
            // totalPlaytimeLabel
            // 
            this.totalPlaytimeLabel.AutoSize = true;
            this.totalPlaytimeLabel.Location = new System.Drawing.Point(12, 166);
            this.totalPlaytimeLabel.Name = "totalPlaytimeLabel";
            this.totalPlaytimeLabel.Size = new System.Drawing.Size(75, 13);
            this.totalPlaytimeLabel.TabIndex = 8;
            this.totalPlaytimeLabel.Text = "Total playtime:";
            // 
            // totalPlaytimeComboBox
            // 
            this.totalPlaytimeComboBox.FormattingEnabled = true;
            this.totalPlaytimeComboBox.Items.AddRange(new object[] {
            "30 minutes",
            "45 minutes",
            "60 minutes",
            "90 minutes",
            "120 minutes"});
            this.totalPlaytimeComboBox.Location = new System.Drawing.Point(92, 163);
            this.totalPlaytimeComboBox.Name = "totalPlaytimeComboBox";
            this.totalPlaytimeComboBox.Size = new System.Drawing.Size(121, 21);
            this.totalPlaytimeComboBox.TabIndex = 9;
            // 
            // mixLengthLabel
            // 
            this.mixLengthLabel.AutoSize = true;
            this.mixLengthLabel.Location = new System.Drawing.Point(13, 194);
            this.mixLengthLabel.Name = "mixLengthLabel";
            this.mixLengthLabel.Size = new System.Drawing.Size(58, 13);
            this.mixLengthLabel.TabIndex = 10;
            this.mixLengthLabel.Text = "Mix length:";
            // 
            // mixLengthComboBox
            // 
            this.mixLengthComboBox.FormattingEnabled = true;
            this.mixLengthComboBox.Items.AddRange(new object[] {
            "20 seconds",
            "30 seconds",
            "40 seconds",
            "50 seconds",
            "60 seconds"});
            this.mixLengthComboBox.Location = new System.Drawing.Point(92, 191);
            this.mixLengthComboBox.Name = "mixLengthComboBox";
            this.mixLengthComboBox.Size = new System.Drawing.Size(121, 21);
            this.mixLengthComboBox.TabIndex = 11;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(138, 218);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(57, 218);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // bpmRangeLabel
            // 
            this.bpmRangeLabel.AutoSize = true;
            this.bpmRangeLabel.Location = new System.Drawing.Point(13, 64);
            this.bpmRangeLabel.Name = "bpmRangeLabel";
            this.bpmRangeLabel.Size = new System.Drawing.Size(61, 13);
            this.bpmRangeLabel.TabIndex = 14;
            this.bpmRangeLabel.Text = "Bpm range:";
            // 
            // bpmRangeComboBox
            // 
            this.bpmRangeComboBox.FormattingEnabled = true;
            this.bpmRangeComboBox.Items.AddRange(new object[] {
            "3",
            "6",
            "9",
            "12"});
            this.bpmRangeComboBox.Location = new System.Drawing.Point(92, 61);
            this.bpmRangeComboBox.Name = "bpmRangeComboBox";
            this.bpmRangeComboBox.Size = new System.Drawing.Size(121, 21);
            this.bpmRangeComboBox.TabIndex = 15;
            // 
            // MixDiscWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 255);
            this.Controls.Add(this.bpmRangeComboBox);
            this.Controls.Add(this.bpmRangeLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.mixLengthComboBox);
            this.Controls.Add(this.mixLengthLabel);
            this.Controls.Add(this.totalPlaytimeComboBox);
            this.Controls.Add(this.totalPlaytimeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intensityStypeComboBox);
            this.Controls.Add(this.intensityCheckBox);
            this.Controls.Add(this.keyCheckBox);
            this.Controls.Add(this.bpmCheckBox);
            this.Controls.Add(this.playlistComboBox);
            this.Controls.Add(this.playlistLabel);
            this.Name = "MixDiscWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MixDisc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playlistLabel;
        private System.Windows.Forms.ComboBox playlistComboBox;
        private System.Windows.Forms.CheckBox bpmCheckBox;
        private System.Windows.Forms.CheckBox keyCheckBox;
        private System.Windows.Forms.CheckBox intensityCheckBox;
        private System.Windows.Forms.ComboBox intensityStypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalPlaytimeLabel;
        private System.Windows.Forms.ComboBox totalPlaytimeComboBox;
        private System.Windows.Forms.Label mixLengthLabel;
        private System.Windows.Forms.ComboBox mixLengthComboBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label bpmRangeLabel;
        private System.Windows.Forms.ComboBox bpmRangeComboBox;
    }
}