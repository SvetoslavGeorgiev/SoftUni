namespace Tree.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tree;

    [TestFixture]
    public class IntegerTreeTests
    {
        private IntegerTree tree;

        [SetUp]
        public void InitializeFactoryAndTree()
        {
            string[] input = new string[]
            {
                "7 19",
                "7 21",
                "7 14",
                "19 1",
                "19 12",
                "19 31",
                "14 23",
                "14 6"
            };

            this.tree = new TreeFactory().CreateTreeFromStrings(input);
        }

        [Test]
        public void GetPathsWithGivenSum_WithMultiplePaths_ShouldWorkCorrectly()
        {
            int[,] expected = new int[,]
            {
                { 7, 19, 1 },
                { 7, 14, 6 }
            };

            var paths = this.tree.GetPathsWithGivenSum(27).Select(x => x.ToList()).ToList();

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], paths[i][j]);
                }
            }
        }

        [Test]
        public void GetSubtreesWithGivenSum_WithSingleSubtree_ShouldWorkCorrectly()
        {
            List<Tree<int>> subtrees = this.tree.GetSubtreesWithGivenSum(43).ToList();

            Assert.AreEqual(1, subtrees.Count);

            string treeAsString = subtrees[0].AsString();

            string expectedOutput =
                $"14{Environment.NewLine}" +
                $"  23{Environment.NewLine}" +
                 "  6";

            Assert.AreEqual(expectedOutput, treeAsString);
        }
    }
}
