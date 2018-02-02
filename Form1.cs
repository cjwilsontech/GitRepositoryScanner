using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectStatFinder {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void btnBrowseDirectory_Click(object sender, EventArgs e) {
			// Open the prompt to select a path.
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {

				// Set the path.
				linkPath.Text = folderBrowserDialog1.SelectedPath;

				// Get the project stats.
				getProjectStats();
			}
		}

		private void getProjectStats() {

		}

		private void linkPath_Click(object sender, EventArgs e) {
			// Get the path.
			string path = linkPath.Text;

			// Check if the path exists.
			if (Directory.Exists(path)) {
				// Attempt to open the path in explorer.
				Process.Start("explorer.exe", path);

			} else {
				// Show an error message.
				MessageBox.Show("Directory does not exist.", "Could not open directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
