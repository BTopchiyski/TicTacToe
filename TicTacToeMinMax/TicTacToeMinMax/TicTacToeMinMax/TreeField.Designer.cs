
namespace TicTacToeMinMax
{
    partial class TreeField
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
            this.TreePanel = new System.Windows.Forms.Panel();
            this.CloseForm = new System.Windows.Forms.Button();
            this.TreeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TreePanel
            // 
            this.TreePanel.BackColor = System.Drawing.Color.White;
            this.TreePanel.Location = new System.Drawing.Point(184, 12);
            this.TreePanel.Name = "TreePanel";
            this.TreePanel.Size = new System.Drawing.Size(1348, 737);
            this.TreePanel.TabIndex = 0;
            this.TreePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TreePanel_Paint);
            // 
            // CloseForm
            // 
            this.CloseForm.BackColor = System.Drawing.Color.White;
            this.CloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseForm.Location = new System.Drawing.Point(90, 561);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(75, 23);
            this.CloseForm.TabIndex = 0;
            this.CloseForm.Text = "Close Form";
            this.CloseForm.UseVisualStyleBackColor = false;
            this.CloseForm.Click += new System.EventHandler(this.CloseForm_Click);
            // 
            // TreeBox
            // 
            this.TreeBox.BackColor = System.Drawing.Color.White;
            this.TreeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TreeBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TreeBox.FormattingEnabled = true;
            this.TreeBox.Items.AddRange(new object[] {
            "MinMaxGrid",
            "MinMaxValue"});
            this.TreeBox.Location = new System.Drawing.Point(43, 162);
            this.TreeBox.Name = "TreeBox";
            this.TreeBox.Size = new System.Drawing.Size(121, 21);
            this.TreeBox.TabIndex = 1;
            this.TreeBox.SelectedIndexChanged += new System.EventHandler(this.TreeBox_SelectedIndexChanged);
            // 
            // TreeField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1544, 761);
            this.Controls.Add(this.TreeBox);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.TreePanel);
            this.Name = "TreeField";
            this.Text = "TreeField";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TreePanel;
        private System.Windows.Forms.Button CloseForm;
        private System.Windows.Forms.ComboBox TreeBox;
    }
}