namespace Tree.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using Tree;

    [TestFixture]
    public class TreeTests
    {
        [Test]
        public void AsString_WithBasicTree_ShouldWorkCorrectly()
        {
            string[] input = new string[]
               {
                "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6"
               };

            var tree = new TreeFactory().CreateTreeFromStrings(input);

            string expectedOutput =
                $"7{Environment.NewLine}" +
                $"  19{Environment.NewLine}" +
                $"    1{Environment.NewLine}" +
                $"    12{Environment.NewLine}" +
                $"    31{Environment.NewLine}" +
                $"  21{Environment.NewLine}" +
                $"  14{Environment.NewLine}" +
                $"    23{Environment.NewLine}" +
                $"    6";

            Assert.AreEqual(expectedOutput, tree.AsString());
        }

        [Test]
        [TestCaseSource("TreeTestData")]
        public void GetLeafKeys_ShouldWorkCorrectly(TreeTestData data)
        {
            int[] expected = data.expectedLeafNodes;
            IEnumerable<int> leafKeys = data.tree.GetLeafKeys();


            CollectionAssert.AreEquivalent(expected, leafKeys);
        }

        [Test]
        [TestCaseSource("TreeTestData")]
        public void GetInternalKeys_ShouldWorkCorrectly(TreeTestData data)
        {
            int[] expected = data.expectedInternalNodes;
            IEnumerable<int> middleKeys = data.tree.GetInternalKeys();

            CollectionAssert.AreEquivalent(expected, middleKeys);
        }

        [Test]
        [TestCaseSource("TreeTestData")]
        public void GetDeepestKey_ShouldWorkCorrectly(TreeTestData data)
        {
            int deepestKey = data.tree.GetDeepestKey();

            Assert.AreEqual(data.expectedDeepestNode, deepestKey);
        }


        [Test]
        [TestCaseSource("TreeTestData")]
        public void GetLongestPath_ShouldWorkCorrectly(TreeTestData data)
        {
            int[] expectedPath = data.expectedLongestPath;
            IEnumerable<int> longestLeftmostPath = data.tree.GetLongestPath();

            CollectionAssert.AreEqual(expectedPath, longestLeftmostPath);
        }

        public static IEnumerable<TreeTestData> TreeTestData()
        {
            yield return new TreeTestData(
                "First tree",
                new string[] { "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73" },
                new int[] { 17, 36, 67, 73, 59 },
                new int[] { 4, 14, 53 },
                67,
                new int[] { 9, 14, 53, 67 }
            );
            yield return new TreeTestData(
                "Second tree",
                new string[] { "2 5", "2 11", "2 18", "11 38", "38 87", "18 72" },
                new int[] { 5, 87, 72 },
                new int[] { 11, 38, 18 },
                87,
                new int[] { 2, 11, 38, 87 }
            );
            yield return new TreeTestData(
                "Third tree",
                new string[] { "35 23", "35 93", "23 19", "23 41", "93 42", "93 43", "93 44", "93 45" },
                new int[] { 19, 41, 42, 43, 44, 45 },
                new int[] { 23, 93 },
                19,
                new int[] { 35, 23, 19 }
            );
            yield return new TreeTestData(
                "Fourth tree",
                new string[] { "3 9", "3 2", "3 35", "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73", "2 5", "2 11", "2 18", "11 38", "38 87", "18 72", "35 93", "35 23", "23 19", "23 41", "93 42", "93 43", "93 44", "93 45" },
                new int[] { 17, 36, 67, 73, 59, 5, 87, 72, 19, 41, 42, 43, 44, 45 },
                new int[] { 9, 2, 35, 4, 14, 53, 11, 38, 18, 23, 93 },
                67,
                new int[] { 3, 9, 14, 53, 67 }
            );
        }
    }

    public class TreeTestData
    {
        private string testName;
        public Tree<int> tree;
        public int[] expectedLeafNodes;
        public int[] expectedInternalNodes;
        public int expectedDeepestNode;
        public int[] expectedLongestPath;

        public TreeTestData(string testName, string[] pairs, int[] leafNodes, int[] internalNodes, int deepestNode, int[] longestPath)
        {
            this.tree = new TreeFactory().CreateTreeFromStrings(pairs);
            this.expectedLeafNodes = leafNodes;
            this.expectedInternalNodes = internalNodes;
            this.expectedDeepestNode = deepestNode;
            this.expectedLongestPath = longestPath;

            this.testName = testName;
        }

        public override string ToString()
        {
            return testName;
        }
    } 
}