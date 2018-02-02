namespace ProjectStatFinder {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnBrowseDirectory = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.linkPath = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.lblFileCount = new System.Windows.Forms.Label();
			this.lblProjectSize = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnBrowseDirectory
			// 
			this.btnBrowseDirectory.Location = new System.Drawing.Point(6, 19);
			this.btnBrowseDirectory.Name = "btnBrowseDirectory";
			this.btnBrowseDirectory.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseDirectory.TabIndex = 1;
			this.btnBrowseDirectory.Text = "Browse...";
			this.btnBrowseDirectory.UseVisualStyleBackColor = true;
			this.btnBrowseDirectory.Click += new System.EventHandler(this.btnBrowseDirectory_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.linkPath);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnBrowseDirectory);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(341, 51);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Project Directory";
			// 
			// linkPath
			// 
			this.linkPath.AutoSize = true;
			this.linkPath.Location = new System.Drawing.Point(125, 24);
			this.linkPath.Name = "linkPath";
			this.linkPath.Size = new System.Drawing.Size(0, 13);
			this.linkPath.TabIndex = 3;
			this.linkPath.Click += new System.EventHandler(this.linkPath_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(87, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Path:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblProjectSize);
			this.groupBox2.Controls.Add(this.lblFileCount);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.tableLayoutPanel1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(13, 71);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(341, 168);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Stats";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(180, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Project Size:";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 20);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(167, 142);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(180, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "File Count:";
			// 
			// lblFileCount
			// 
			this.lblFileCount.AutoSize = true;
			this.lblFileCount.Location = new System.Drawing.Point(243, 20);
			this.lblFileCount.Name = "lblFileCount";
			this.lblFileCount.Size = new System.Drawing.Size(34, 13);
			this.lblFileCount.TabIndex = 3;
			this.lblFileCount.Text = "0 files";
			// 
			// lblProjectSize
			// 
			this.lblProjectSize.AutoSize = true;
			this.lblProjectSize.Location = new System.Drawing.Point(252, 42);
			this.lblProjectSize.Name = "lblProjectSize";
			this.lblProjectSize.Size = new System.Drawing.Size(41, 13);
			this.lblProjectSize.TabIndex = 4;
			this.lblProjectSize.Text = "0 bytes";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(365, 261);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnBrowseDirectory;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.LinkLabel linkPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblProjectSize;
		private System.Windows.Forms.Label lblFileCount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label2;
	}
}

