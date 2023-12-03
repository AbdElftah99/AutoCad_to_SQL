namespace CADDB
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
            this.btn_LoadLines = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnLoadMText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_LoadLines
            // 
            this.btn_LoadLines.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_LoadLines.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_LoadLines.FlatAppearance.BorderSize = 0;
            this.btn_LoadLines.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadLines.Location = new System.Drawing.Point(12, 70);
            this.btn_LoadLines.Name = "btn_LoadLines";
            this.btn_LoadLines.Size = new System.Drawing.Size(118, 35);
            this.btn_LoadLines.TabIndex = 0;
            this.btn_LoadLines.Text = "Load Lines";
            this.btn_LoadLines.UseVisualStyleBackColor = false;
            this.btn_LoadLines.Click += new System.EventHandler(this.btn_LoadLines_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(157, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load PolyLines";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(23, 138);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(79, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Massage Here:";
            // 
            // btnLoadMText
            // 
            this.btnLoadMText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoadMText.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLoadMText.FlatAppearance.BorderSize = 0;
            this.btnLoadMText.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadMText.Location = new System.Drawing.Point(294, 70);
            this.btnLoadMText.Name = "btnLoadMText";
            this.btnLoadMText.Size = new System.Drawing.Size(118, 35);
            this.btnLoadMText.TabIndex = 0;
            this.btnLoadMText.Text = "Load MText";
            this.btnLoadMText.UseVisualStyleBackColor = false;
            this.btnLoadMText.Click += new System.EventHandler(this.btnLoadMText_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 167);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadMText);
            this.Controls.Add(this.btn_LoadLines);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Base Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_LoadLines;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnLoadMText;
    }
}