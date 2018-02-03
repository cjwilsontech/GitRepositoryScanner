using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectStatFinder {
	public partial class FormMain : Form {
		public FormMain() {
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

		private async void getProjectStats() {
			// Clear the previous data.
			dataFileExtensions.Rows.Clear();

			lblStatus.ForeColor = DefaultForeColor;
			lblStatus.Text = "Scanning...";
			lblFileCount.Text = "0 files";
			lblProjectSize.Text = "0 bytes";

			// Create a new project scanner.
			ProjectScanner scanner = new ProjectScanner();

			try {
				// Scan all repositories we want to count (just one, in this case).
				scanner.OpenRepository(linkPath.Text);
				await scanner.Scan();

				// Update the status of the repository.
				lblStatus.ForeColor = Color.Green;
				lblStatus.Text = "Found";

				// Loop through the results and fill the table.
				foreach (KeyValuePair<string, int> pair in scanner.FileCount) {
					dataFileExtensions.Rows.Add(pair.Key, pair.Value);
				}
				dataFileExtensions.Sort(dataFileExtensions.Columns[1], System.ComponentModel.ListSortDirection.Descending);
				dataFileExtensions.CurrentCell = null;

				// Set the labels.
				lblFileCount.Text = String.Format("{0} files", scanner.TotalFiles);
				lblProjectSize.Text = scanner.TotalSize.ToString();

			} catch (Exception e) {

				// Handle exceptions
				if (e is LibGit2Sharp.RepositoryNotFoundException) {
					lblStatus.ForeColor = Color.Red;
					lblStatus.Text = "Not Found";
				} else if (e is UncommittedChangesException || e is FileNotFoundException) {
					lblStatus.ForeColor = Color.Red;
					lblStatus.Text = "Error. Uncommitted changes.";
					MessageBox.Show("Error: File not found. Try committing any changes and trying again.", "Error scanning repository", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else throw (e);
			}
		}

		private void linkPath_Click(object sender, EventArgs e) {
			// Get the path.
			string path = linkPath.Text;

			// Check if the path exists.
			if (Directory.Exists(path)) {
				// Attempt to open the path in explorer.
				Process.Start("explorer.exe", string.Format("/select,\"{0}\"", path));

			} else {
				// Show an error message.
				MessageBox.Show("Directory does not exist.", "Could not open directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e) {
			getProjectStats();
		}
	}
}
