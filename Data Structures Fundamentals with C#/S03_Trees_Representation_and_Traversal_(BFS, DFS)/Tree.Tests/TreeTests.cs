using NUnit.Framework;
using System;
using Tree;

[TestFixture]
public class TreeTests
{
    private Tree<int> tree;

    [SetUp]
    public void InitializeTree()
    {
        this.tree = new Tree<int>(7,
                        new Tree<int>(19,
                                new Tree<int>(1),
                                new Tree<int>(12),
                                new Tree<int>(31)),
                        new Tree<int>(21),
                        new Tree<int>(14,
                                new Tree<int>(23),
                                new Tree<int>(6)));
    }

    [Test]
    public void Constructor_WithValueOnly_ShouldWorkCorrectly()
    {
        var tree = new Tree<string>("Random Value");

        string[] expected = { "Random Value" };

        CollectionAssert.AreEqual(expected, tree.OrderBfs());
    }

    [Test]
    public void Constructor_WithSubtree_ShouldWorkCorrectly()
    {
        var tree = new Tree<string>("A", new Tree<string>("B"), new Tree<string>("C"));

        string[] expected = { "B", "C", "A" };

        CollectionAssert.AreEqual(expected, tree.OrderDfs());
    }

    [Test]
    public void OrderBfs_WithMultipleElements_ShouldReturnElementsInCorrectOrder()
    {
        int[] expected = { 7, 19, 21, 14, 1, 12, 31, 23, 6 };

        CollectionAssert.AreEqual(expected, this.tree.OrderBfs());
    }

    [Test]
    public void OrderBfs_WithSingleElement_ShouldReturnSingle()
    {
        int[] expected = { 1 };

        this.tree = new Tree<int>(1);

        CollectionAssert.AreEqual(expected, this.tree.OrderBfs());
    }

    [Test]
    public void OrderDfs_WithMultipleElements_ShouldReturnElementsInCorrectOrder()
    {
        int[] expected = { 1, 12, 31, 19, 21, 23, 6, 14, 7 };

        CollectionAssert.AreEqual(expected, this.tree.OrderDfs());
    }

    [Test]
    public void OrderDfs_WithSingleElement_ShouldReturnSingle()
    {
        int[] expected = { 1 };

        this.tree = new Tree<int>(1);

        CollectionAssert.AreEqual(expected, this.tree.OrderDfs());
    }

    [Test]
    public void AddChild_SmallSubtree_SubtreeAddedCorrectly()
    {
        this.tree.AddChild(1, new Tree<int>(-1, new Tree<int>(-2), new Tree<int>(-3)));
        int[] expected = { -2, -3, -1, 1, 12, 31, 19, 21, 23, 6, 14, 7 };

        CollectionAssert.AreEqual(expected, this.tree.OrderDfs());
    }

    [Test]
    public void AddChild_SingleNode_AddedCorrectly()
    {
        this.tree.AddChild(1, new Tree<int>(13));
        int[] expected = { 13, 1, 12, 31, 19, 21, 23, 6, 14, 7 };

        CollectionAssert.AreEqual(expected, this.tree.OrderDfs());
    }

    [Test]
    public void AddChild_OnInvalidElement_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(()
            => tree.AddChild(77, new Tree<int>(-1)));
    }

    [Test]
    public void RemoveNode_InternalNode_RemovesEntireSubtree()
    {
        int[] expected = { 7, 21, 14, 23, 6 };
        tree.RemoveNode(19);
        CollectionAssert.AreEqual(expected, tree.OrderBfs());
    }

    [Test]
    public void RemoveNode_LeafNode_RemovesTheLeaf()
    {
        int[] expected = { 7, 19, 14, 1, 12, 31, 23, 6 };

        tree.RemoveNode(21);

        var resultBfs = tree.OrderBfs();

        CollectionAssert.AreEqual(expected, resultBfs);
    }

    [Test]
    public void RemoveNode_RootNode_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => tree.RemoveNode(7));
    }

    [Test]
    public void RemoveNode_InvalidNode_ShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => tree.RemoveNode(77));
    }

    [Test]
    public void Swap_TwoLeafs_WorksCorrectly()
    {
        int[] expected = { 7, 19, 31, 14, 1, 12, 21, 23, 6 };
        tree.Swap(21, 31);

        CollectionAssert.AreEqual(expected, tree.OrderBfs());
    }

    [Test]
    public void Swap_TwoInternalNodes_WorksCorrectly()
    {
        int[] expected = { 23, 6, 14, 21, 1, 12, 31, 19, 7 };
        tree.Swap(19, 14);

        CollectionAssert.AreEqual(expected, tree.OrderDfs());
    }

    [Test]
    public void Swap_LeafAndInternalNode_WorksCorrectly()
    {
        int[] expected = { 21, 1, 12, 31, 19, 23, 6, 14, 7 };
        tree.Swap(19, 21);

        CollectionAssert.AreEqual(expected, tree.OrderDfs());
    }

    [Test]
    public void Swap_InternalNodeAndDescendantLeaf_WorksCorrectly()
    {
        int[] expected = { 31, 21, 23, 6, 14, 7 };
        tree.Swap(19, 31);

        CollectionAssert.AreEqual(expected, tree.OrderDfs());
    }

    [Test]
    public void Swap_LeftParamRootWithAnyNode_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => tree.Swap(7, 19));
    }

    [Test]
    public void Swap_RightParamRootWithAnyNode_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => tree.Swap(21, 7));
    }

    [Test]
    public void Swap_WithLeftParamInvalidNode_ShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => tree.Swap(34, 19));
    }

    [Test]
    public void Swap_WithRightParamInvalidNode_ShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => tree.Swap(21, 191));
    }
}