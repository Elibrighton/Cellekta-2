namespace Cellekta_2
{
    partial class Cellekta
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
            this.addButton = new System.Windows.Forms.Button();
            this.musicTabControl = new System.Windows.Forms.TabControl();
            this.listTabPage = new System.Windows.Forms.TabPage();
            this.insertButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            this.populateButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.listGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.songsTabPage = new System.Windows.Forms.TabPage();
            this.rangeCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.playlistComboBox = new System.Windows.Forms.ComboBox();
            this.playlistLabel = new System.Windows.Forms.Label();
            this.keyComboBox = new System.Windows.Forms.ComboBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.bpmComboBox = new System.Windows.Forms.ComboBox();
            this.bpmLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.songsGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSongFiltersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomiseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electroHouseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weddingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.everythingElseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratedCheckBox = new System.Windows.Forms.CheckBox();
            this.musicTabControl.SuspendLayout();
            this.listTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGridView)).BeginInit();
            this.songsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songsGridView)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 267);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // musicTabControl
            // 
            this.musicTabControl.Controls.Add(this.listTabPage);
            this.musicTabControl.Controls.Add(this.songsTabPage);
            this.musicTabControl.Location = new System.Drawing.Point(12, 27);
            this.musicTabControl.Name = "musicTabControl";
            this.musicTabControl.SelectedIndex = 0;
            this.musicTabControl.Size = new System.Drawing.Size(760, 322);
            this.musicTabControl.TabIndex = 2;
            // 
            // listTabPage
            // 
            this.listTabPage.Controls.Add(this.insertButton);
            this.listTabPage.Controls.Add(this.replaceButton);
            this.listTabPage.Controls.Add(this.populateButton);
            this.listTabPage.Controls.Add(this.nextButton);
            this.listTabPage.Controls.Add(this.removeButton);
            this.listTabPage.Controls.Add(this.listGridView);
            this.listTabPage.Controls.Add(this.menuStrip1);
            this.listTabPage.Location = new System.Drawing.Point(4, 22);
            this.listTabPage.Name = "listTabPage";
            this.listTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.listTabPage.Size = new System.Drawing.Size(752, 296);
            this.listTabPage.TabIndex = 0;
            this.listTabPage.Text = "List";
            this.listTabPage.UseVisualStyleBackColor = true;
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(168, 267);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 15;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(87, 267);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(75, 23);
            this.replaceButton.TabIndex = 14;
            this.replaceButton.Text = "Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // populateButton
            // 
            this.populateButton.Location = new System.Drawing.Point(330, 267);
            this.populateButton.Name = "populateButton";
            this.populateButton.Size = new System.Drawing.Size(75, 23);
            this.populateButton.TabIndex = 13;
            this.populateButton.Text = "Populate";
            this.populateButton.UseVisualStyleBackColor = true;
            this.populateButton.Click += new System.EventHandler(this.populateButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(6, 267);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 12;
            this.nextButton.Text = "Find Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(249, 267);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // listGridView
            // 
            this.listGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listGridView.Location = new System.Drawing.Point(6, 6);
            this.listGridView.MultiSelect = false;
            this.listGridView.Name = "listGridView";
            this.listGridView.ReadOnly = true;
            this.listGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listGridView.Size = new System.Drawing.Size(740, 255);
            this.listGridView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(746, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // songsTabPage
            // 
            this.songsTabPage.Controls.Add(this.ratedCheckBox);
            this.songsTabPage.Controls.Add(this.rangeCheckBox);
            this.songsTabPage.Controls.Add(this.cancelButton);
            this.songsTabPage.Controls.Add(this.searchLabel);
            this.songsTabPage.Controls.Add(this.playlistComboBox);
            this.songsTabPage.Controls.Add(this.playlistLabel);
            this.songsTabPage.Controls.Add(this.keyComboBox);
            this.songsTabPage.Controls.Add(this.keyLabel);
            this.songsTabPage.Controls.Add(this.bpmComboBox);
            this.songsTabPage.Controls.Add(this.bpmLabel);
            this.songsTabPage.Controls.Add(this.searchTextBox);
            this.songsTabPage.Controls.Add(this.songsGridView);
            this.songsTabPage.Controls.Add(this.addButton);
            this.songsTabPage.Location = new System.Drawing.Point(4, 22);
            this.songsTabPage.Name = "songsTabPage";
            this.songsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.songsTabPage.Size = new System.Drawing.Size(752, 296);
            this.songsTabPage.TabIndex = 1;
            this.songsTabPage.Text = "Songs";
            this.songsTabPage.UseVisualStyleBackColor = true;
            // 
            // rangeCheckBox
            // 
            this.rangeCheckBox.AutoSize = true;
            this.rangeCheckBox.Location = new System.Drawing.Point(688, 271);
            this.rangeCheckBox.Name = "rangeCheckBox";
            this.rangeCheckBox.Size = new System.Drawing.Size(58, 17);
            this.rangeCheckBox.TabIndex = 12;
            this.rangeCheckBox.Text = "Range";
            this.rangeCheckBox.UseVisualStyleBackColor = true;
            this.rangeCheckBox.Click += new System.EventHandler(this.rangeCheckBox_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(87, 267);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(512, 10);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(44, 13);
            this.searchLabel.TabIndex = 10;
            this.searchLabel.Text = "Search:";
            // 
            // playlistComboBox
            // 
            this.playlistComboBox.FormattingEnabled = true;
            this.playlistComboBox.Location = new System.Drawing.Point(385, 7);
            this.playlistComboBox.Name = "playlistComboBox";
            this.playlistComboBox.Size = new System.Drawing.Size(121, 21);
            this.playlistComboBox.TabIndex = 9;
            this.playlistComboBox.SelectedIndexChanged += new System.EventHandler(this.playlistComboBox_SelectedIndexChanged);
            // 
            // playlistLabel
            // 
            this.playlistLabel.AutoSize = true;
            this.playlistLabel.Location = new System.Drawing.Point(337, 10);
            this.playlistLabel.Name = "playlistLabel";
            this.playlistLabel.Size = new System.Drawing.Size(42, 13);
            this.playlistLabel.TabIndex = 8;
            this.playlistLabel.Text = "Playlist:";
            // 
            // keyComboBox
            // 
            this.keyComboBox.FormattingEnabled = true;
            this.keyComboBox.Location = new System.Drawing.Point(208, 7);
            this.keyComboBox.Name = "keyComboBox";
            this.keyComboBox.Size = new System.Drawing.Size(121, 21);
            this.keyComboBox.TabIndex = 7;
            this.keyComboBox.SelectedIndexChanged += new System.EventHandler(this.keyComboBox_SelectedIndexChanged);
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(174, 10);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(28, 13);
            this.keyLabel.TabIndex = 6;
            this.keyLabel.Text = "Key:";
            // 
            // bpmComboBox
            // 
            this.bpmComboBox.FormattingEnabled = true;
            this.bpmComboBox.Location = new System.Drawing.Point(45, 7);
            this.bpmComboBox.Name = "bpmComboBox";
            this.bpmComboBox.Size = new System.Drawing.Size(121, 21);
            this.bpmComboBox.TabIndex = 5;
            this.bpmComboBox.SelectedIndexChanged += new System.EventHandler(this.bpmComboBox_SelectedIndexChanged);
            // 
            // bpmLabel
            // 
            this.bpmLabel.AutoSize = true;
            this.bpmLabel.Location = new System.Drawing.Point(8, 10);
            this.bpmLabel.Name = "bpmLabel";
            this.bpmLabel.Size = new System.Drawing.Size(31, 13);
            this.bpmLabel.TabIndex = 4;
            this.bpmLabel.Text = "Bpm:";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(562, 7);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(184, 20);
            this.searchTextBox.TabIndex = 3;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // songsGridView
            // 
            this.songsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.songsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.songsGridView.Location = new System.Drawing.Point(6, 33);
            this.songsGridView.MultiSelect = false;
            this.songsGridView.Name = "songsGridView";
            this.songsGridView.ReadOnly = true;
            this.songsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.songsGridView.Size = new System.Drawing.Size(740, 228);
            this.songsGridView.TabIndex = 2;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.selectionMenuItem,
            this.playlistsToolStripMenuItem,
            this.presetsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(784, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearSongFiltersMenuItem,
            this.randomiseMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // clearSongFiltersMenuItem
            // 
            this.clearSongFiltersMenuItem.Name = "clearSongFiltersMenuItem";
            this.clearSongFiltersMenuItem.Size = new System.Drawing.Size(133, 22);
            this.clearSongFiltersMenuItem.Text = "Clear filters";
            this.clearSongFiltersMenuItem.Click += new System.EventHandler(this.clearSongFiltersMenuItem_Click);
            // 
            // randomiseMenuItem
            // 
            this.randomiseMenuItem.Name = "randomiseMenuItem";
            this.randomiseMenuItem.Size = new System.Drawing.Size(133, 22);
            this.randomiseMenuItem.Text = "Randomise";
            this.randomiseMenuItem.Click += new System.EventHandler(this.randomiseMenuItem_Click);
            // 
            // selectionMenuItem
            // 
            this.selectionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMenuItem,
            this.rangeMenuItem});
            this.selectionMenuItem.Name = "selectionMenuItem";
            this.selectionMenuItem.Size = new System.Drawing.Size(67, 20);
            this.selectionMenuItem.Text = "Selection";
            // 
            // clearMenuItem
            // 
            this.clearMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afterMenuItem,
            this.allMenuItem});
            this.clearMenuItem.Name = "clearMenuItem";
            this.clearMenuItem.Size = new System.Drawing.Size(107, 22);
            this.clearMenuItem.Text = "Clear";
            // 
            // afterMenuItem
            // 
            this.afterMenuItem.Name = "afterMenuItem";
            this.afterMenuItem.Size = new System.Drawing.Size(100, 22);
            this.afterMenuItem.Text = "After";
            this.afterMenuItem.Click += new System.EventHandler(this.afterMenuItem_Click);
            // 
            // allMenuItem
            // 
            this.allMenuItem.Name = "allMenuItem";
            this.allMenuItem.Size = new System.Drawing.Size(100, 22);
            this.allMenuItem.Text = "All";
            this.allMenuItem.Click += new System.EventHandler(this.allMenuItem_Click);
            // 
            // rangeMenuItem
            // 
            this.rangeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rangeMenuItem3,
            this.rangeMenuItem6,
            this.rangeMenuItem12});
            this.rangeMenuItem.Name = "rangeMenuItem";
            this.rangeMenuItem.Size = new System.Drawing.Size(107, 22);
            this.rangeMenuItem.Text = "Range";
            // 
            // rangeMenuItem3
            // 
            this.rangeMenuItem3.Checked = true;
            this.rangeMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rangeMenuItem3.Name = "rangeMenuItem3";
            this.rangeMenuItem3.Size = new System.Drawing.Size(86, 22);
            this.rangeMenuItem3.Text = "3";
            this.rangeMenuItem3.Click += new System.EventHandler(this.rangeMenuItem3_Click);
            // 
            // rangeMenuItem6
            // 
            this.rangeMenuItem6.Name = "rangeMenuItem6";
            this.rangeMenuItem6.Size = new System.Drawing.Size(86, 22);
            this.rangeMenuItem6.Text = "6";
            this.rangeMenuItem6.Click += new System.EventHandler(this.rangeMenuItem6_Click);
            // 
            // rangeMenuItem12
            // 
            this.rangeMenuItem12.Name = "rangeMenuItem12";
            this.rangeMenuItem12.Size = new System.Drawing.Size(86, 22);
            this.rangeMenuItem12.Text = "12";
            this.rangeMenuItem12.Click += new System.EventHandler(this.rangeMenuItem12_Click);
            // 
            // playlistsToolStripMenuItem
            // 
            this.playlistsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.electroHouseMenuItem,
            this.weddingMenuItem,
            this.everythingElseMenuItem});
            this.playlistsToolStripMenuItem.Name = "playlistsToolStripMenuItem";
            this.playlistsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.playlistsToolStripMenuItem.Text = "Playlists";
            // 
            // electroHouseMenuItem
            // 
            this.electroHouseMenuItem.Name = "electroHouseMenuItem";
            this.electroHouseMenuItem.Size = new System.Drawing.Size(153, 22);
            this.electroHouseMenuItem.Text = "Electro house";
            this.electroHouseMenuItem.Click += new System.EventHandler(this.electroHouseMenuItem_Click);
            // 
            // weddingMenuItem
            // 
            this.weddingMenuItem.Name = "weddingMenuItem";
            this.weddingMenuItem.Size = new System.Drawing.Size(153, 22);
            this.weddingMenuItem.Text = "Wedding";
            this.weddingMenuItem.Click += new System.EventHandler(this.weddingMenuItem_Click);
            // 
            // everythingElseMenuItem
            // 
            this.everythingElseMenuItem.Checked = true;
            this.everythingElseMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.everythingElseMenuItem.Name = "everythingElseMenuItem";
            this.everythingElseMenuItem.Size = new System.Drawing.Size(153, 22);
            this.everythingElseMenuItem.Text = "Everything else";
            this.everythingElseMenuItem.Click += new System.EventHandler(this.everythingElseMenuItem_Click);
            // 
            // presetsToolStripMenuItem
            // 
            this.presetsToolStripMenuItem.Name = "presetsToolStripMenuItem";
            this.presetsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.presetsToolStripMenuItem.Text = "Presets";
            // 
            // ratedCheckBox
            // 
            this.ratedCheckBox.AutoSize = true;
            this.ratedCheckBox.Location = new System.Drawing.Point(627, 271);
            this.ratedCheckBox.Name = "ratedCheckBox";
            this.ratedCheckBox.Size = new System.Drawing.Size(55, 17);
            this.ratedCheckBox.TabIndex = 13;
            this.ratedCheckBox.Text = "Rated";
            this.ratedCheckBox.UseVisualStyleBackColor = true;
            this.ratedCheckBox.Click += new System.EventHandler(this.ratedCheckBox_Click);
            // 
            // Cellekta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.musicTabControl);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Cellekta";
            this.Text = "Cellekta";
            this.musicTabControl.ResumeLayout(false);
            this.listTabPage.ResumeLayout(false);
            this.listTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGridView)).EndInit();
            this.songsTabPage.ResumeLayout(false);
            this.songsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.songsGridView)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TabControl musicTabControl;
        private System.Windows.Forms.TabPage listTabPage;
        private System.Windows.Forms.DataGridView listGridView;
        private System.Windows.Forms.TabPage songsTabPage;
        private System.Windows.Forms.DataGridView songsGridView;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ComboBox playlistComboBox;
        private System.Windows.Forms.Label playlistLabel;
        private System.Windows.Forms.ComboBox keyComboBox;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.ComboBox bpmComboBox;
        private System.Windows.Forms.Label bpmLabel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem clearSongFiltersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomiseMenuItem;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button populateButton;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.ToolStripMenuItem selectionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMenuItem;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.ToolStripMenuItem playlistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weddingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electroHouseMenuItem;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox rangeCheckBox;
        private System.Windows.Forms.ToolStripMenuItem afterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allMenuItem;
        private System.Windows.Forms.ToolStripMenuItem everythingElseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rangeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rangeMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem rangeMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem rangeMenuItem12;
        private System.Windows.Forms.CheckBox ratedCheckBox;
    }
}

