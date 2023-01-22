namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private T value;
        private Tree<T> parent;

        public Tree(T value)
        {

            this.value = value;
            children = new List<Tree<T>>();

        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {

            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }

        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindNodeWithBfs(parentKey);

            if (parentNode != null)
            {
                parentNode.children.Add(child);
                child.parent = parentNode;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        private Tree<T> FindNodeWithBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (subTree.value.Equals(parentKey))
                {
                    return subTree;
                }

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                result.Add(subTree.value);

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result = new Stack<T>();
            var stack = new Stack<Tree<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                foreach (var child in node.children)
                {
                    stack.Push(child);
                }

                result.Push(node.value);
            }

            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }
    }
}
