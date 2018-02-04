# GitRepositoryScanner
Scans repository directories and displays information about the committed files.<br/>
Built to assist Harding University's Computer Science Capstone class.

Displays committed file count by extension, the total number of files counted, and the combined size of all those files. Includes the ability to filter by file extension.

A standalone executable for Windows and a shell script for OSX and Linux are both available in [Releases](https://github.com/cjwilsontech/GitRepositoryScanner/releases).

## Usage
**Windows:**
* Start the application.
* Press 'Browse' and select the root directory of the repository you wish to scan.
* Filter by selecting scanned extensions and pressing the '>>' button.
* Remove filters by selecting ignored extensions and pressing the '<<' button.

<br/>

**OSX/Linux:**
* Give the execute permission to the script with `chmod +x RepoScanner-osx-linux.sh`.
* Call the script by calling `./RepoScanner-osx-linux.sh "<path_to_repository_directory>"`.
