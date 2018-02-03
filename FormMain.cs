using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectStatFinder {
	public partial class FormMain : Form {
		private const string NO_EXTENSION = "<no extension>";
		private CommonOpenFileDialog openFolderDialog = new CommonOpenFileDialog();

		public FormMain() {
			InitializeComponent();
			openFolderDialog.IsFolderPicker = true;
			openFolderDialog.Title = "Select a repository folder...";
		}

		private void btnBrowseDirectory_Click(object sender, EventArgs e) {
			// Open the prompt to select a path.
			if (openFolderDialog.ShowDialog() == CommonFileDialogResult.Ok) {

				// Set the path.
				linkPath.Text = openFolderDialog.FileName;
				btnRefresh.Enabled = true;

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


			try {
				// Verify the directory exists.
				if (linkPath.Text.Length <= 0 || !Directory.Exists(linkPath.Text)) throw new DirectoryNotFoundException();

				// Create a new project scanner.
				ProjectScanner scanner = new ProjectScanner(linkPath.Text);

				// Scan the repository.
				List<string> ignoredExtensions = new List<string>();
				foreach (string extension in lstIgnoredExtensions.Items) {
					ignoredExtensions.Add((extension != NO_EXTENSION) ? extension : "");
				}
				await scanner.Scan(ignoredExtensions);

				// Update the status of the repository.
				lblStatus.ForeColor = Color.Green;
				lblStatus.Text = "Found";

				// Loop through the results and fill the table.
				foreach (KeyValuePair<string, int> pair in scanner.FileCount) {
					string key = pair.Key;
					if (key.Length <= 0)
						key = NO_EXTENSION;

					dataFileExtensions.Rows.Add(key, pair.Value);
				}

				// Update table display.
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
					lblStatus.Text = "Uncommitted changes found. Commit changes and try again.";
					MessageBox.Show("Error: File not found. Try committing any changes and trying again.", "Error scanning repository", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else if (e is DirectoryNotFoundException) {
					lblStatus.ForeColor = Color.Red;
					lblStatus.Text = "Not Found";
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

		private void btnRemoveIgnored_Click(object sender, EventArgs e) {
			// Make a list of the files to delete.
			List<string> toDelete = new List<string>();
			foreach (string extension in lstIgnoredExtensions.SelectedItems) {
				toDelete.Add(extension);
			}

			// Remove selected file extensions from the ignored list.
			foreach (string extension in toDelete) {
				lstIgnoredExtensions.Items.Remove(extension);
			}

			// Update the project stats.
			getProjectStats();
		}

		private void btnAddIgnored_Click(object sender, EventArgs e) {
			// Add the file extensions for selected rows.
			foreach (DataGridViewCell cell in dataFileExtensions.SelectedCells) {
				string extension = dataFileExtensions.Rows[cell.RowIndex].Cells[0].Value.ToString();
				if (!lstIgnoredExtensions.Items.Contains(extension))
					lstIgnoredExtensions.Items.Add(extension);
			}

			// Update the project stats.
			getProjectStats();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			new FormAbout().ShowDialog();
		}
	}
}
