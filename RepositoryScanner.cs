﻿using ByteSizeLib;
using LibGit2Sharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectStatFinder {
	class ProjectScanner {
		private Dictionary<string, int> fileTypeCount = new Dictionary<string, int>();
		/// <summary>A list of mappings between file extension and count.</summary>
		public List<KeyValuePair<string, int>> FileCount {
			get {
				return fileTypeCount.ToList();
			}
		}

		private int totalFiles = 0;
		/// <summary>The count of all committed project files, ignoring non-repository files.</summary>
		public int TotalFiles {
			get {
				return totalFiles;
			}
		}

		private long totalBytes = 0;
		/// <summary>The size of all committed project files, ignoring non-repository files.</summary>
		public ByteSize TotalSize {
			get {
				return new ByteSize(totalBytes);
			}
		}

		private Repository repo;

		/// <summary>This method opens a repository for later scanning.</summary>
		/// <param name="path">A path to the directory where the repository is located.</param>
		/// <exception cref="LibGit2Sharp.RepositoryNotFoundException">This exception is thrown if no repository exists at the given location.</exception>
		public ProjectScanner(string path) {
			// Open the repository.
			repo = new LibGit2Sharp.Repository(path);
			if (hasUncommittedChanges()) {
				throw new UncommittedChangesException();
			}
		}

		/// <summary>This method scans the opened repository and adds its data to the list.</summary>
		/// <exception cref="FileNotFoundException">This exception is thrown if a file no longer exists, such as if there have been uncommitted changes.</exception>
		public Task Scan(ICollection<string> ignoredExtensions = null) {
			if (ReferenceEquals(repo, null)) return null;

			return Task.Factory.StartNew(() => {

				// Loop through every file that is part of the repository (skips ignored).
				foreach (IndexEntry e in repo.Index) {
					string path = repo.Info.WorkingDirectory + e.Path;
					// Get file info.
					FileInfo file = new FileInfo(path);
					string extension = file.Extension;

					// Check if we need to ignore this extension.
					if (ReferenceEquals(ignoredExtensions, null) || !ignoredExtensions.Contains(extension)) {
						if (!fileTypeCount.ContainsKey(extension)) {
							fileTypeCount.Add(extension, 1);
						} else {
							++fileTypeCount[extension];
						}

						// Update metrics.
						++totalFiles;
						totalBytes += file.Length;
					}
				}
			});
		}

		/// <summary>This method returns true if the repository has not been committed.</summary>
		private bool hasUncommittedChanges() {
			// From https://stackoverflow.com/a/30311693
			return ReferenceEquals(repo, null) || repo.RetrieveStatus().IsDirty;
		}
	}
}
