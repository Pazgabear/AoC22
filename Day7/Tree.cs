using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Tree
    {
        public TreeNode Root { get; }

        public Tree(string rootName)
        {
            Root = new TreeNode { Name = rootName };
        }

        public string Print()
        {
            var builder = new StringBuilder();
            builder.Append(Root.Print());
            return builder.ToString();
        }
    }
}
