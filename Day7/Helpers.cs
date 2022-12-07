using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal static class Helpers
    {
        public static int SizeRecurse(TreeNode root)
        {
            return root.Children.Aggregate(0, (t, current) =>
            {
                if (current.NodeType == NodeType.File)
                    return t;

                if (current.Size < 100_000) 
                    t += current.Size;

                return t + SizeRecurse(current);
            });
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> input)
        {
            foreach (var item in input)
            {
                if (item is IEnumerable<T> enumerable)
                    foreach (var t in Flatten(enumerable))
                        yield return t;
                else
                    yield return item;
            }
        }
    }
}
