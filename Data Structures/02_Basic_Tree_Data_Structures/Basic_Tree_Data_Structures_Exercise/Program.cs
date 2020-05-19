using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Tree_Data_Structures_Exercise
{
    class Program
    {
        static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        static void Main(string[] args)
        {
            ReadTree();

            // 01. Root Node
            Console.WriteLine($"Root node: {GetRootNode().Value}");

            // 02. Print Tree
            PrintTree(GetRootNode());

            // 03. Leaf Nodes
            Console.WriteLine($"Leaf nodes: {string.Join(" ", GetLeafNodes())}");

            // 04. Middle Nodes
            Console.WriteLine($"Middle nodes: {string.Join(" ", GetMiddleNodes())}");

            // 05. Deepest Node
            Console.WriteLine($"Deepest node: {GetDeepestNode().Value}");

            // 06. Longest Path
            Console.WriteLine($"Longest path: {string.Join(" ", GetPathToRoot(GetDeepestNode()))}");

            // 07. Paths With Given Sum
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine($"Paths of sum {sum}:");
            Console.WriteLine($"{string.Join(Environment.NewLine, GetPathsOfSum(sum))}");
        }

        private static IEnumerable<string> GetPathsOfSum(int sum)
            => tree.Values
                .Where(n => !n.Children.Any())
                .Where(n => CalculatePathToRootSum(n) == sum)
                .Select(n => string.Join(" ", GetPathToRoot(n)));

        private static int CalculatePathToRootSum(Tree<int> node)
        {
            var sum = 0;
            var current = node;

            while (current != null)
            {
                sum += current.Value;
                current = current.Parent;
            }

            return sum;
        }

        private static IEnumerable<int> GetPathToRoot(Tree<int> node)
        {
            var path = new Stack<int>();
            var current = node;

            while (current != null)
            {
                path.Push(current.Value);
                current = current.Parent;
            }

            return path;
        }

        private static Tree<int> GetDeepestNode() =>
            tree.Values.Where(v => !v.Children.Any())
                .Select(n => new
                {
                    Node = n,
                    Depth = CalculateNodeDepth(n)
                }).OrderByDescending(n => n.Depth)
                .Select(n => n.Node)
                .FirstOrDefault();

        private static int CalculateNodeDepth(Tree<int> node)
        {
            int depth = 0;
            var current = node;

            while (current != null)
            {
                depth++;
                current = current.Parent;
            }

            return depth;
        }

        private static IEnumerable<int> GetMiddleNodes() =>
            tree.Values.Where(v => v.Parent != null && v.Children.Any()).Select(v => v.Value).OrderBy(v => v);

        private static IEnumerable<int> GetLeafNodes() =>
            tree.Values.Where(v => !v.Children.Any()).Select(v => v.Value).OrderBy(v => v);

        private static void PrintTree(Tree<int> node, int indent = 0)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine($"{new string(' ', indent)}{node.Value}");

            foreach (var child in node.Children)
            {
                PrintTree(child, indent + 2);
            }
        }

        private static Tree<int> GetRootNode() =>
            tree.Values.FirstOrDefault(v => v.Parent == null);

        private static void ReadTree()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i < count; i++)
            {
                int[] edge = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int parent = edge[0];
                int child = edge[1];
                AddEdge(parent, child);
            }
        }

        private static void AddEdge(int parent, int child)
        {
            Tree<int> parentNode = GetTreeNodeByValue(parent);
            Tree<int> childNode = GetTreeNodeByValue(child);

            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!tree.ContainsKey(value))
            {
                tree[value] = new Tree<int>(value);
            }

            return tree[value];
        }
    }
}
