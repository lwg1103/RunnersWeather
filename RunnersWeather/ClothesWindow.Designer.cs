namespace RunnersWeather
{
    partial class ClothesWindow
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
            this.components = new System.ComponentModel.Container();
            this.SaveClothesButton = new System.Windows.Forms.Button();
            this.ClothesDataGridView = new System.Windows.Forms.DataGridView();
            this.clothesPiecesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClothesUsageDataGridView = new System.Windows.Forms.DataGridView();
            this.clothesUsageConditionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClothesNameUsageColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MinValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClothesNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ClothesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clothesPiecesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClothesUsageDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clothesUsageConditionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveClothesButton
            // 
            this.SaveClothesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveClothesButton.Location = new System.Drawing.Point(0, 416);
            this.SaveClothesButton.Name = "SaveClothesButton";
            this.SaveClothesButton.Size = new System.Drawing.Size(840, 34);
            this.SaveClothesButton.TabIndex = 1;
            this.SaveClothesButton.Text = "Save Changes";
            this.SaveClothesButton.UseVisualStyleBackColor = true;
            this.SaveClothesButton.Click += new System.EventHandler(this.SaveClothesButton_Click);
            // 
            // ClothesDataGridView
            // 
            this.ClothesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClothesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClothesNameColumn});
            this.ClothesDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClothesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ClothesDataGridView.Name = "ClothesDataGridView";
            this.ClothesDataGridView.Size = new System.Drawing.Size(267, 416);
            this.ClothesDataGridView.TabIndex = 2;
            // 
            // clothesPiecesBindingSource
            // 
            this.clothesPiecesBindingSource.DataMember = "ClothesPieces";
            // 
            // ClothesUsageDataGridView
            // 
            this.ClothesUsageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClothesUsageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClothesNameUsageColumn,
            this.ParameterColumn,
            this.MinValueColumn,
            this.MaxValueColumn});
            this.ClothesUsageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClothesUsageDataGridView.Location = new System.Drawing.Point(267, 0);
            this.ClothesUsageDataGridView.Name = "ClothesUsageDataGridView";
            this.ClothesUsageDataGridView.Size = new System.Drawing.Size(573, 416);
            this.ClothesUsageDataGridView.TabIndex = 3;
            // 
            // clothesUsageConditionsBindingSource
            // 
            this.clothesUsageConditionsBindingSource.DataMember = "ClothesUsageConditions";
            // 
            // ClothesNameUsageColumn
            // 
            this.ClothesNameUsageColumn.HeaderText = "Clothes";
            this.ClothesNameUsageColumn.Name = "ClothesNameUsageColumn";
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterColumn";
            // 
            // MinValueColumn
            // 
            this.MinValueColumn.HeaderText = "Min";
            this.MinValueColumn.Name = "MinValueColumn";
            // 
            // MaxValueColumn
            // 
            this.MaxValueColumn.HeaderText = "Max";
            this.MaxValueColumn.Name = "MaxValueColumn";
            // 
            // ClothesNameCol
            // 
            this.ClothesNameColumn.HeaderText = "Name";
            this.ClothesNameColumn.Name = "ClothesNameCol";
            // 
            // ClothesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 450);
            this.Controls.Add(this.ClothesUsageDataGridView);
            this.Controls.Add(this.ClothesDataGridView);
            this.Controls.Add(this.SaveClothesButton);
            this.Name = "ClothesWindow";
            this.Text = "ClothesWindow";
            this.Load += new System.EventHandler(this.ClothesWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClothesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clothesPiecesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClothesUsageDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clothesUsageConditionsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SaveClothesButton;
        private System.Windows.Forms.DataGridView ClothesDataGridView;
        private System.Windows.Forms.BindingSource clothesPiecesBindingSource;
        private System.Windows.Forms.DataGridView ClothesUsageDataGridView;
        private System.Windows.Forms.BindingSource clothesUsageConditionsBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn ClothesNameUsageColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn ParameterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClothesNameColumn;
    }
}