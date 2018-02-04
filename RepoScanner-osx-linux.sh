#!/bin/sh
# Give execute permissions before attempting to run:
#   chmod +x RepoScanner-osx-linux.sh
#
# How to run:
#   ./RepoScanner-osx-linux.sh "<path_to_repository_directory>"

DIR=$@
if [ $# -ne 1 ]; then
  echo "Usage:"
  echo "./RepoScanner-osx-linux.sh \"<path_to_repository_directory>\""
elif [ ! -d $DIR ]; then
  echo "Directory does not exist."
else
  cd $DIR
  echo
  echo "Counted files:"
  git ls-files | awk -F . '{print $NF}' | sort | uniq -c | awk '{print $2,$1}'
  echo
  printf "Counted size: "
  git gc >/dev/null 2>&1; git count-objects -vH | sed -n -e "s/^.*size-pack: //p"
  echo
fi
