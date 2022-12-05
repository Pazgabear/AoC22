using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal static class Helpers
    {
        public static string GetStacksDisplay(Stack<string>[] stacks)
        {
            var displayStacks = new Stack<string>[stacks.Length];
            for (int i = 0; i < displayStacks.Length; ++i)
                displayStacks[i] = new Stack<string>(stacks[i].Reverse());

            var builder = new StringBuilder();
            int maxStack = displayStacks.Max(s => s.Count);
            int stackCount = displayStacks.Length;

            for (int i = maxStack; i > 0; --i)
            {
                var boxes = new List<string>();
                for (int j = 0; j < stackCount; ++j) 
                {
                    if (displayStacks[j].Count >= i)
                        boxes.Add(displayStacks[j].Pop());
                    else
                        boxes.Add("   ");
                }
                builder.AppendLine(string.Join(' ', boxes));
            }

            builder.AppendLine($" {string.Join("   ", Enumerable.Range(1, stackCount))}");
            return builder.ToString();
        }
    }
}
