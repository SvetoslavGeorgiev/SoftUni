namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly ICollection<Tree<T>> children;

        public Tree(T key, params Tree<T>[] _children)
        {
            Key = key;
            children = new List<Tree<T>>();

            foreach (var child in _children)
            {
                AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => (IReadOnlyCollection<Tree<T>>)children;

        public void AddChild(Tree<T> child)
        {
            children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            DfsAsString(sb, this, 0);

            return sb.ToString().Trim();

        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int depth)
        {
            sb.Append(' ', depth)
              .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                DfsAsString(sb, child, depth + 2);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            return BfsWithResultKeys(tree => tree.children.Count != 0 && tree.Parent != null)
                .Select(tree => tree.Key);
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return BfsWithResultKeys(tree => tree.children.Count == 0)
                .Select(tree => tree.Key);
        }

        public T GetDeepestKey()
        {
            return GetDeepestNode().Key;
        }

        private Tree<T> GetDeepestNode()
        {
            var leafs = BfsWithResultKeys(tree => tree.children.Count == 0);

            Tree<T> deepestNode = null;
            var maxDepth = int.MinValue;

            foreach (var leaf in leafs)
            {
                var depth = GetDepth(leaf);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            var depth = int.MinValue;

            var tree = leaf;

            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Tree<T>> BfsWithResultKeys(Predicate<Tree<T>> predicate)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var curruentSubTree = queue.Dequeue();

                if (predicate.Invoke(curruentSubTree))
                {
                    result.Add(curruentSubTree);
                }

                foreach (var child in curruentSubTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}
