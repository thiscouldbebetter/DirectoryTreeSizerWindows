using System;
using System.Collections.Generic;
using System.IO;
 
namespace ThisCouldBeBetter.DirectoryTreeSizer
{ 
    public class DirectoryTreeSizer
    {
        private string _directoryPathToStartIn;
 
        public DirectoryTreeSizer(string directoryPathToStartIn)
        {
            _directoryPathToStartIn = directoryPathToStartIn;
        }
 
        public DirectoryNode BuildDirectorySizeTree()
        {
            var directoryToStartInNode = new DirectoryNode(this._directoryPathToStartIn);
            directoryToStartInNode.CalculateSizeWithAllDescendants();
            return directoryToStartInNode;
        }
    }

}
