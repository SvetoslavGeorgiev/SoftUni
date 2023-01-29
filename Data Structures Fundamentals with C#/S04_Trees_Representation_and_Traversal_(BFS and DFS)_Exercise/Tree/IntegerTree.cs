namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {


            var leafNodes = GetLeafNodes();

            var result = new List<Stack<int>>();

            foreach (var leafNode in leafNodes)
            {

                var longestSequence = new Stack<int>();

                var curentNode = leafNode;

                while (curentNode != null)
                {

                    longestSequence.Push(curentNode.Key);

                    curentNode = curentNode.Parent;
                }

                if (longestSequence.Sum() == sum)
                {
                    result.Add(longestSequence);
                }
            }

            return result;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}
