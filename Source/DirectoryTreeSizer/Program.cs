using System;
using System.Collections.Generic;
using System.IO;
 
namespace ThisCouldBeBetter.DirectoryTreeSizer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Directory Tree Sizer");
            Console.WriteLine("====================");

            Console.WriteLine("Usage: DirectoryTreeSizer.exe <rootDirectoryPath>");

            Console.WriteLine("Program begins: " + DateTime.Now.ToString());

            Console.WriteLine("<directoryPath>:<sizeInBytes>"); 

            var directoryPathToStartIn = (args.Length > 0 ? args[0] : ".");
            var directoryTreeSizer = new DirectoryTreeSizer(directoryPathToStartIn);
            var directorySizeTree = directoryTreeSizer.BuildDirectorySizeTree();
 
            Console.WriteLine("Program ends: " + DateTime.Now.ToString());
        }
    } 
}
