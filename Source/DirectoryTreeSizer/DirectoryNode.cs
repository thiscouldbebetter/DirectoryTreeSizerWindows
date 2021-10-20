using System;
using System.Collections.Generic;
using System.IO;
 
namespace ThisCouldBeBetter.DirectoryTreeSizer
{
    public class DirectoryNode
    {
        private string _path;
        private long _sizeInBytes;
        private List<DirectoryNode> _children;
 
        public DirectoryNode(string path)
        {
            this._path = path;
 
            this._sizeInBytes = 0;
            this._children = new List<DirectoryNode>();
        }
 
        public void CalculateSizeWithAllDescendants()
        {
            var directoryInfo = new DirectoryInfo(this._path);
            try
            {
                var files = directoryInfo.GetFiles();
                foreach (var file in files)
                {
                    var fileSizeInBytes = file.Length;
                    this._sizeInBytes += fileSizeInBytes;
                }
                var subdirectories = directoryInfo.GetDirectories();
                foreach (var subdirectory in subdirectories)
                {
                    var subdirectoryAsTreeNode = new DirectoryNode(subdirectory.FullName);
                    subdirectoryAsTreeNode.CalculateSizeWithAllDescendants();
                    this._children.Add(subdirectoryAsTreeNode);
                    this._sizeInBytes += subdirectoryAsTreeNode._sizeInBytes;
                }
                Console.WriteLine(this._path + ":" + this._sizeInBytes);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access error attempting to read directory: " + this._path);
            }
        }
    }
}
