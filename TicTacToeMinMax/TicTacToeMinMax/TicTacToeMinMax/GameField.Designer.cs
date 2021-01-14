
namespace TicTacToeMinMax
{
    partial class GameField
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
            this.ClearButton = new System.Windows.Forms.Button();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Playerbox = new System.Windows.Forms.ComboBox();
            this.Turns = new System.Windows.Forms.Label();
            this.PvPButton = new System.Windows.Forms.RadioButton();
            this.PvAIButton = new System.Windows.Forms.RadioButton();
            this.OpenTreeForm = new System.Windows.Forms.Button();
            this.FreezeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.White;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(198, 195);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // GamePanel
            // 
            this.GamePanel.BackColor = System.Drawing.Color.White;
            this.GamePanel.Location = new System.Drawing.Point(300, 20);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(600, 600);
            this.GamePanel.TabIndex = 1;
            this.GamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
            this.GamePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseDown);
            // 
            // Playerbox
            // 
            this.Playerbox.BackColor = System.Drawing.Color.White;
            this.Playerbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Playerbox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Playerbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Playerbox.FormattingEnabled = true;
            this.Playerbox.Items.AddRange(new object[] {
            "X",
            "O"});
            this.Playerbox.Location = new System.Drawing.Point(198, 224);
            this.Playerbox.Name = "Playerbox";
            this.Playerbox.Size = new System.Drawing.Size(75, 24);
            this.Playerbox.TabIndex = 2;
            this.Playerbox.Click += new System.EventHandler(this.Playerbox_Click);
            // 
            // Turns
            // 
            this.Turns.AutoSize = true;
            this.Turns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Turns.Location = new System.Drawing.Point(258, 419);
            this.Turns.Name = "Turns";
            this.Turns.Size = new System.Drawing.Size(15, 16);
            this.Turns.TabIndex = 3;
            this.Turns.Text = "1";
            // 
            // PvPButton
            // 
            this.PvPButton.AutoSize = true;
            this.PvPButton.Checked = true;
            this.PvPButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PvPButton.Location = new System.Drawing.Point(210, 278);
            this.PvPButton.Name = "PvPButton";
            this.PvPButton.Size = new System.Drawing.Size(51, 20);
            this.PvPButton.TabIndex = 4;
            this.PvPButton.TabStop = true;
            this.PvPButton.Text = "PvP";
            this.PvPButton.UseVisualStyleBackColor = true;
            // 
            // PvAIButton
            // 
            this.PvAIButton.AutoSize = true;
            this.PvAIButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PvAIButton.Location = new System.Drawing.Point(210, 304);
            this.PvAIButton.Name = "PvAIButton";
            this.PvAIButton.Size = new System.Drawing.Size(54, 20);
            this.PvAIButton.TabIndex = 5;
            this.PvAIButton.TabStop = true;
            this.PvAIButton.Text = "PvAI";
            this.PvAIButton.UseVisualStyleBackColor = true;
            this.PvAIButton.CheckedChanged += new System.EventHandler(this.PvAIButton_CheckedChanged);
            // 
            // OpenTreeForm
            // 
            this.OpenTreeForm.BackColor = System.Drawing.Color.White;
            this.OpenTreeForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OpenTreeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenTreeForm.Location = new System.Drawing.Point(198, 381);
            this.OpenTreeForm.Name = "OpenTreeForm";
            this.OpenTreeForm.Size = new System.Drawing.Size(75, 23);
            this.OpenTreeForm.TabIndex = 6;
            this.OpenTreeForm.Text = "Tree";
            this.OpenTreeForm.UseVisualStyleBackColor = false;
            this.OpenTreeForm.Click += new System.EventHandler(this.OpenTreeForm_Click);
            // 
            // FreezeButton
            // 
            this.FreezeButton.AccessibleDescription = "";
            this.FreezeButton.BackColor = System.Drawing.Color.White;
            this.FreezeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FreezeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FreezeButton.Location = new System.Drawing.Point(198, 352);
            this.FreezeButton.Name = "FreezeButton";
            this.FreezeButton.Size = new System.Drawing.Size(75, 23);
            this.FreezeButton.TabIndex = 7;
            this.FreezeButton.Text = "Freeze AI";
            this.FreezeButton.UseVisualStyleBackColor = false;
            this.FreezeButton.Click += new System.EventHandler(this.FreezeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Turns:";
            // 
            // GameField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FreezeButton);
            this.Controls.Add(this.OpenTreeForm);
            this.Controls.Add(this.PvAIButton);
            this.Controls.Add(this.PvPButton);
            this.Controls.Add(this.Turns);
            this.Controls.Add(this.Playerbox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.GamePanel);
            this.Name = "GameField";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Panel GamePanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox Playerbox;
        private System.Windows.Forms.Label Turns;
        private System.Windows.Forms.RadioButton PvPButton;
        private System.Windows.Forms.RadioButton PvAIButton;
        private System.Windows.Forms.Button OpenTreeForm;
        private System.Windows.Forms.Button FreezeButton;
        private System.Windows.Forms.Label label1;
    }
}

