using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal enum NodeType
    {
        Directory,
        File
    }

    internal class TreeNode
    {
        public string Name { get; set; } = string.Empty;
        public NodeType NodeType { get; set; }
        public int Size { get; set; }
        public TreeNode? Parent { get; set; }
        public List<TreeNode> Children { get; } = new List<TreeNode>();

        public void AddChild(TreeNode child)
        {
            child.Parent = this;
            Children.Add(child);
        }

        public void CalcSize()
        {
            if (NodeType == NodeType.File)
                return;

            foreach (var child in Children)
            {
                if (child.NodeType == NodeType.Directory)
                    child.CalcSize();

                Size += child.Size;
            }
        }

        public IEnumerable<TreeNode> EnumerateDirectories()
        {
            var dirs = new List<TreeNode>() { this };
            foreach (var child in Children.Where(c => c.NodeType == NodeType.Directory))
                dirs.AddRange(child.EnumerateDirectories());

            return dirs;
        }

        public string Print(int indent = 0)
        {
            var builder = new StringBuilder();
            builder.Append($"{new string(' ', indent)}- {Name} ");

            switch (NodeType)
            {
                case NodeType.Directory:
                    builder.Append($"(dir, size_tot={Size})");
                    break;
                case NodeType.File:
                    builder.Append($"(file, size={Size})");
                    break;
            }
            builder.AppendLine();

            foreach (var child in Children)
                builder.Append(child.Print(indent + 2));

            return builder.ToString();
        }
    }
}
