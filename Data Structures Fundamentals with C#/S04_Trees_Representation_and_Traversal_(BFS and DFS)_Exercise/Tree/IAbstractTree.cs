namespace Tree
{
    using System.Collections.Generic;

    public interface IAbstractTree<T>
    {
        T Key { get; }
        IReadOnlyCollection<Tree<T>> Children { get; }

        void AddParent(Tree<T> parent);

        void AddChild(Tree<T> child);

        string AsString();

        IEnumerable<T> GetLeafKeys();

        IEnumerable<T> GetInternalKeys();

        T GetDeepestKey();

        IEnumerable<T> GetLongestPath();
    }
}
