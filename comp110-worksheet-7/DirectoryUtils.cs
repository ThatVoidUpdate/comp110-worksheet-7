﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_7
{
	public static class DirectoryUtils
	{
        public static List<string> Traverse(string filePath, bool includeFiles, bool includeFolders)
        {
            List<string> ret = new List<string>();
            foreach (string item in Directory.GetFileSystemEntries(filePath))
            {//loop over every path in the directory
                if (IsDirectory(item))
                {//if it is a directory, then also search that
                    if (includeFolders)
                    {//if we want to return folders, add it to the return variable
                        ret.Add(item);
                    }
                    
                    ret.AddRange(Traverse(item, includeFiles, includeFolders));
                }
                else
                {
                    if (includeFiles)
                    {//if we want to return files, add it to the return variable
                        ret.Add(item);
                    }
                }
            }

            return ret;
        }

		// Return the size, in bytes, of the given file
		public static long GetFileSize(string filePath)
		{
			return new FileInfo(filePath).Length;
		}

		// Return true if the given path points to a directory, false if it points to a file
		public static bool IsDirectory(string path)
		{
			return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
		}

		// Return the total size, in bytes, of all the files below the given directory
		public static long GetTotalSize(string directory)
		{
            long ret = 0;
            foreach (string file in Traverse(directory, true, false))
            {//add the size of every file to the return variable
                ret += GetFileSize(file);
            }
            return ret;
		}

		// Return the number of files (not counting directories) below the given directory
		public static int CountFiles(string directory)
		{//return the amount of entries when searching for only files
            return Traverse(directory, true, false).Count;
		}

		// Return the nesting depth of the given directory. A directory containing only files (no subdirectories) has a depth of 0.
		public static int GetDepth(string directory)
		{
            int baseLength = directory.Split('\\').Length;
            int maxLength = 0;
            //calculate a base length to be subtracted from everything else

            foreach (string file in Traverse(directory, true, false))
            {//for every file, subtract the base amount of '\' from the current amount of '\', which gives the depth
                if (file.Split('\\').Length - baseLength > maxLength)
                {
                    maxLength = file.Split('\\').Length - baseLength;
                }
            }

            return maxLength;
		}

		// Get the path and size (in bytes) of the smallest file below the given directory
		public static Tuple<string, long> GetSmallestFile(string directory)
		{
            string SmallestPath = "";
            long SmallestSize = long.MaxValue;
            foreach (string path in Traverse(directory, true, false))
            {//for every file, if it is smaller that the previous best, then store it
                if (GetFileSize(path) < SmallestSize)
                {
                    SmallestPath = path;
                    SmallestSize = GetFileSize(path);
                }
            }
            //return the smallest
            return new Tuple<string, long>(SmallestPath, SmallestSize);
		}

		// Get the path and size (in bytes) of the largest file below the given directory
		public static Tuple<string, long> GetLargestFile(string directory)
		{
            string LargestPath = "";
            long LargestSize = long.MinValue;
            foreach (string path in Traverse(directory, true, false))
            {//for every file, if it is bigger that the previous best, then store it
                if (GetFileSize(path) > LargestSize)
                {
                    LargestPath = path;
                    LargestSize = GetFileSize(path);
                }
            }
            //return the largest
            return new Tuple<string, long>(LargestPath, LargestSize);
        }

		// Get all files whose size is equal to the given value (in bytes) below the given directory
		public static IEnumerable<string> GetFilesOfSize(string directory, long size)
		{
            List<string> ret = new List<string>();

            foreach (string path in Traverse(directory, true, false))
            {//for every file, if the size is correct, add it to be returned
                if (GetFileSize(path) == size)
                {
                    ret.Add(path);
                }
            }
            //return them
            return ret;
        }
	}
}
