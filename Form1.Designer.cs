namespace RunnersWeather
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConsoleLogWindow = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.LongitudeLabel = new System.Windows.Forms.Label();
            this.LatitudeLabel = new System.Windows.Forms.Label();
            this.LongitudeTextBox = new System.Windows.Forms.TextBox();
            this.LatitudeTextBox = new System.Windows.Forms.TextBox();
            this.SettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsoleLogWindow
            // 
            this.ConsoleLogWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConsoleLogWindow.Location = new System.Drawing.Point(0, 0);
            this.ConsoleLogWindow.Multiline = true;
            this.ConsoleLogWindow.Name = "ConsoleLogWindow";
            this.ConsoleLogWindow.ReadOnly = true;
            this.ConsoleLogWindow.Size = new System.Drawing.Size(849, 381);
            this.ConsoleLogWindow.TabIndex = 0;
            this.ConsoleLogWindow.Text = "--- console log ---";
            // 
            // StartButton
            // 
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartButton.Location = new System.Drawing.Point(0, 466);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(849, 34);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Check Data";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.Controls.Add(this.LatitudeTextBox);
            this.SettingsGroupBox.Controls.Add(this.LongitudeTextBox);
            this.SettingsGroupBox.Controls.Add(this.LatitudeLabel);
            this.SettingsGroupBox.Controls.Add(this.LongitudeLabel);
            this.SettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SettingsGroupBox.Location = new System.Drawing.Point(0, 387);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(849, 79);
            this.SettingsGroupBox.TabIndex = 2;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "Settings";
            // 
            // LongitudeLabel
            // 
            this.LongitudeLabel.AutoSize = true;
            this.LongitudeLabel.Location = new System.Drawing.Point(12, 20);
            this.LongitudeLabel.Name = "LongitudeLabel";
            this.LongitudeLabel.Size = new System.Drawing.Size(54, 13);
            this.LongitudeLabel.TabIndex = 0;
            this.LongitudeLabel.Text = "Longitude";
            // 
            // LatitudeLabel
            // 
            this.LatitudeLabel.AutoSize = true;
            this.LatitudeLabel.Location = new System.Drawing.Point(12, 46);
            this.LatitudeLabel.Name = "LatitudeLabel";
            this.LatitudeLabel.Size = new System.Drawing.Size(45, 13);
            this.LatitudeLabel.TabIndex = 1;
            this.LatitudeLabel.Text = "Latitude";
            // 
            // LongitudeTextBox
            // 
            this.LongitudeTextBox.Location = new System.Drawing.Point(72, 13);
            this.LongitudeTextBox.Name = "LongitudeTextBox";
            this.LongitudeTextBox.Size = new System.Drawing.Size(100, 20);
            this.LongitudeTextBox.TabIndex = 2;
            this.LongitudeTextBox.Text = "17,05177";
            // 
            // LatitudeTextBox
            // 
            this.LatitudeTextBox.Location = new System.Drawing.Point(72, 39);
            this.LatitudeTextBox.Name = "LatitudeTextBox";
            this.LatitudeTextBox.Size = new System.Drawing.Size(100, 20);
            this.LatitudeTextBox.TabIndex = 3;
            this.LatitudeTextBox.Text = "51,08804";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 500);
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ConsoleLogWindow);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(865, 539);
            this.MinimumSize = new System.Drawing.Size(865, 539);
            this.Name = "MainWindow";
            this.Text = "Runner\'s Weather";
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ConsoleLogWindow;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.Label LatitudeLabel;
        private System.Windows.Forms.Label LongitudeLabel;
        private System.Windows.Forms.TextBox LatitudeTextBox;
        private System.Windows.Forms.TextBox LongitudeTextBox;
    }
}

