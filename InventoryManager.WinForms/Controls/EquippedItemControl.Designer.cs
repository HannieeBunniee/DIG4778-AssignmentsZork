namespace InventoryManager.WinForms.Controls
{
    partial class EquippedItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.equippedItemComboBox = new System.Windows.Forms.ComboBox();
            this.equipLocationTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // equippedItemComboBox
            // 
            this.equippedItemComboBox.DisplayMember = "Name";
            this.equippedItemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equippedItemComboBox.FormattingEnabled = true;
            this.equippedItemComboBox.Location = new System.Drawing.Point(3, 35);
            this.equippedItemComboBox.Name = "equippedItemComboBox";
            this.equippedItemComboBox.Size = new System.Drawing.Size(184, 28);
            this.equippedItemComboBox.TabIndex = 1;
            this.equippedItemComboBox.SelectedIndexChanged += new System.EventHandler(this.EquippedItemComboBox_SelectedIndexChanged);
            // 
            // equipLocationTextBox
            // 
            this.equipLocationTextBox.Location = new System.Drawing.Point(3, 3);
            this.equipLocationTextBox.Name = "equipLocationTextBox";
            this.equipLocationTextBox.ReadOnly = true;
            this.equipLocationTextBox.Size = new System.Drawing.Size(184, 26);
            this.equipLocationTextBox.TabIndex = 0;
            this.equipLocationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EquippedItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.equippedItemComboBox);
            this.Controls.Add(this.equipLocationTextBox);
            this.Name = "EquippedItemControl";
            this.Size = new System.Drawing.Size(192, 71);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox equippedItemComboBox;
        private System.Windows.Forms.TextBox equipLocationTextBox;
    }
}
