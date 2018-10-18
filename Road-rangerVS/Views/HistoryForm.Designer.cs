namespace Road_rangerVS
{
    partial class HistoryForm
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
            this.myHistory = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.history = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myHistory
            // 
            this.myHistory.AutoSize = true;
            this.myHistory.Location = new System.Drawing.Point(13, 23);
            this.myHistory.Name = "myHistory";
            this.myHistory.Size = new System.Drawing.Size(56, 13);
            this.myHistory.TabIndex = 0;
            this.myHistory.Text = "My History";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(13, 64);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(16, 13);
            this.result.TabIndex = 1;
            this.result.Text = "...";
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(197, 12);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(75, 23);
            this.history.TabIndex = 2;
            this.history.Text = "Get History";
            this.history.UseVisualStyleBackColor = true;
            this.history.Click += new System.EventHandler(this.history_Click);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 343);
            this.Controls.Add(this.history);
            this.Controls.Add(this.result);
            this.Controls.Add(this.myHistory);
            this.Name = "HistoryForm";
            this.Text = "HistoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label myHistory;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Button history;
    }
}