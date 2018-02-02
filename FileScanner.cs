using ByteSizeLib;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStatFinder {
	class ProjectScanner {
		private Dictionary<string, int> fileTypeCount = new Dictionary<string, int>();
		public List<KeyValuePair<string, int>> FileCount {
			get {
				// Sort the list by value.
				// Reference: https://stackoverflow.com/a/298
				List<KeyValuePair<string, int>> result = fileTypeCount.ToList();
				result.Sort(delegate (KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2) {
					return pair2.Value.CompareTo(pair1.Value);
				});
				return result;
			}
		}

		private int totalFiles = 0;
		public int TotalFiles {
			get {
				return totalFiles;
			}
		}

		private long totalBytes = 0;
		public ByteSize TotalSize {
			get {
				return new ByteSize(totalBytes);
			}
		}

		/// <summary>This method scans a repository and adds its data to the list.</summary>
		/// <param name="gitPath">A path to a directory where the repository is located.</param>
		/// <exception cref="LibGit2Sharp.RepositoryNotFoundException">This exception is thrown if no repository exists at the given location.</exception>
		/// <exception cref="FileNotFoundException">This exception is thrown if a file no longer exists, such as .</exception>
		public async Task ScanRepository(string gitPath) {
			await Task.Factory.StartNew(() => {
				// Open the repository.
				Repository repo = new LibGit2Sharp.Repository(gitPath);

				// Loop through every file that is part of the repository (skips ignored).
				foreach (IndexEntry e in repo.Index) {

					// Get file info.
					FileInfo file = new FileInfo(gitPath + "/" + e.Path);
					if (!fileTypeCount.ContainsKey(file.Extension)) {
						fileTypeCount.Add(file.Extension, 1);
					} else {
						++fileTypeCount[file.Extension];
					}

					// Update metrics.
					++totalFiles;
					totalBytes += file.Length;
				}
			});
		}
	}
}
