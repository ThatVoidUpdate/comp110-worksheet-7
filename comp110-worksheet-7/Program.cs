using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_7
{
	class Program
	{
		static void Main(string[] args)
		{
			const string c_baseDirectory = "..\\..\\..\\comp110-worksheet-7-tests\\pixelcarpack_kenney\\PNG";

            foreach (var item in DirectoryUtils.Traverse(c_baseDirectory))
            {
                Console.WriteLine(item);
            }
            

			try
			{
				Console.WriteLine("Total size: {0} bytes", DirectoryUtils.GetTotalSize(c_baseDirectory));
			}
			catch (NotImplementedException)
			{
				Console.WriteLine("GetTotalSize is not implemented");
			}

			try
			{
				Console.WriteLine("Number of files: {0}", DirectoryUtils.CountFiles(c_baseDirectory));
			}
			catch (NotImplementedException)
			{
				Console.WriteLine("CountFiles is not implemented");
			}

			try
			{
				Console.WriteLine("Folder depth: {0}", DirectoryUtils.GetDepth(c_baseDirectory));
			}
			catch (NotImplementedException)
			{
				Console.WriteLine("GetDepth is not implemented");
			}

			try
			{
				var smallest = DirectoryUtils.GetSmallestFile(c_baseDirectory);
				Console.WriteLine("Smallest file:\n  {0}\n  ({1} bytes)", smallest.Item1, smallest.Item2);
			}
			catch (NotImplementedException)
			{
				Console.WriteLine("GetSmallestFile is not implemented");
			}

			try
			{
				var largest = DirectoryUtils.GetLargestFile(c_baseDirectory);
				Console.WriteLine("Largest file:\n  {0}\n  ({1} bytes)", largest.Item1, largest.Item2);
			}
			catch (NotImplementedException)
			{
				Console.WriteLine("GetLargestFile is not implemented");
			}

			try
			{
				Console.WriteLine("Files of size 253 bytes:");
				foreach (string f in DirectoryUtils.GetFilesOfSize(c_baseDirectory, 253))
					Console.WriteLine("   {0}", f);
			}
			catch (NotImplementedException)
			{
				Console.WriteLine("GetFilesOfSize is not implemented");
			}

			Console.WriteLine("Press enter to continue");
			Console.ReadLine();
		}
	}
}
