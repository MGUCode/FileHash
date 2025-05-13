namespace FileHash
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PathToFiletextBox = new System.Windows.Forms.TextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.Computebutton = new System.Windows.Forms.Button();
            this.ResulttextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Copybutton = new System.Windows.Forms.Button();
            this.Writebutton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // PathToFiletextBox
            // 
            this.PathToFiletextBox.AllowDrop = true;
            this.PathToFiletextBox.Location = new System.Drawing.Point(15, 25);
            this.PathToFiletextBox.Name = "PathToFiletextBox";
            this.PathToFiletextBox.Size = new System.Drawing.Size(411, 20);
            this.PathToFiletextBox.TabIndex = 0;
            this.PathToFiletextBox.TextChanged += new System.EventHandler(this.PathToFiletextBox_TextChanged);
            this.PathToFiletextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.PathToFiletextBox_DragDrop);
            this.PathToFiletextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.PathToFiletextBox_DragEnter);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(432, 23);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 23);
            this.OpenFileButton.TabIndex = 1;
            this.OpenFileButton.Text = "Select";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFilebutton_Click);
            // 
            // Computebutton
            // 
            this.Computebutton.Location = new System.Drawing.Point(15, 51);
            this.Computebutton.Name = "Computebutton";
            this.Computebutton.Size = new System.Drawing.Size(75, 23);
            this.Computebutton.TabIndex = 2;
            this.Computebutton.Text = "Compute";
            this.Computebutton.UseVisualStyleBackColor = true;
            this.Computebutton.Click += new System.EventHandler(this.Computebutton_Click);
            // 
            // ResulttextBox
            // 
            this.ResulttextBox.Location = new System.Drawing.Point(15, 80);
            this.ResulttextBox.Name = "ResulttextBox";
            this.ResulttextBox.Size = new System.Drawing.Size(492, 20);
            this.ResulttextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select the file to compute:";
            // 
            // Copybutton
            // 
            this.Copybutton.Location = new System.Drawing.Point(15, 106);
            this.Copybutton.Name = "Copybutton";
            this.Copybutton.Size = new System.Drawing.Size(249, 23);
            this.Copybutton.TabIndex = 5;
            this.Copybutton.Text = "Copy result to clipboard";
            this.Copybutton.UseVisualStyleBackColor = true;
            this.Copybutton.Click += new System.EventHandler(this.Copybutton_Click);
            // 
            // Writebutton
            // 
            this.Writebutton.Location = new System.Drawing.Point(270, 106);
            this.Writebutton.Name = "Writebutton";
            this.Writebutton.Size = new System.Drawing.Size(237, 23);
            this.Writebutton.TabIndex = 6;
            this.Writebutton.Text = "EWrite result to file";
            this.Writebutton.UseVisualStyleBackColor = true;
            this.Writebutton.Click += new System.EventHandler(this.Writebutton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(96, 56);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "status";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 143);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.Writebutton);
            this.Controls.Add(this.Copybutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResulttextBox);
            this.Controls.Add(this.Computebutton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.PathToFiletextBox);
            this.Name = "Form1";
            this.Text = "FileHash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox PathToFiletextBox;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button Computebutton;
        private System.Windows.Forms.TextBox ResulttextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Copybutton;
        private System.Windows.Forms.Button Writebutton;
        private System.Windows.Forms.Label statusLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

