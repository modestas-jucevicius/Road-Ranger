namespace Road_rangerVS
{
    partial class FindForm
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
            this.search = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(291, 29);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 0;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(12, 29);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(273, 20);
            this.inputText.TabIndex = 1;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(12, 87);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(16, 13);
            this.result.TabIndex = 2;
            this.result.Text = "...";
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 319);
            this.Controls.Add(this.result);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.search);
            this.Name = "FindForm";
            this.Text = "FindForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Label result;
    }
}