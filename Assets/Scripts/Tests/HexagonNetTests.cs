using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class HexagonNetTests
    {
        [Test]
        public void HexagonNet_EnumeratedThrough_ValuesShouldBeSortedByKeys()
        {
            // arrange
            HexagonNet<Bubble> net = new HexagonNet<Bubble>();

            var bubblesForTopRow = new BubbleNode[]
            {
                new BubbleNode(-1).SetHexagonNet(net),
                new BubbleNode(-1).SetHexagonNet(net),
                new BubbleNode(-1).SetHexagonNet(net),
                new BubbleNode(-1).SetHexagonNet(net),
                new BubbleNode(-1).SetHexagonNet(net),
                new BubbleNode(-1).SetHexagonNet(net)
            };
            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);

            var bubblesForMiddleRow = new BubbleNode[]
            {
                new BubbleNode(0).SetHexagonNet(net),
                new BubbleNode(0).SetHexagonNet(net),
                new BubbleNode(0).SetHexagonNet(net),
                new BubbleNode(0).SetHexagonNet(net),
                new BubbleNode(0).SetHexagonNet(net),
                new BubbleNode(0).SetHexagonNet(net)
            };
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);

            var bubblesForLowerMiddleRow = new BubbleNode[]
            {
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net)
            };
            var lowerMiddleRow = new HexagonNetRow<Bubble>(bubblesForLowerMiddleRow);

            var bubblesForBottomRow = new BubbleNode[]
            {
                null,
                null,
                null,
                null,
                null,
                null
            };
            var bottomRow = new HexagonNetRow<Bubble>(bubblesForBottomRow);

            net.AddTopRow(middleRow);
            net.AddTopRow(topRow);
            net.AddBottomRow(lowerMiddleRow);
            net.AddBottomRow(bottomRow);

            var expectedNetAsString = 
                " -1 -1 -1 -1 -1 -1" + Environment.NewLine +
                " 0 0 0 0 0 0" + Environment.NewLine + 
                " 1 1 1 1 1 1" + Environment.NewLine +
                " null null null null null null" + Environment.NewLine;

            // act
            string netAsString = net.ToString();

            // assert
            Assert.AreEqual(expectedNetAsString, netAsString, $"HexagonNet as string: {Environment.NewLine}{netAsString}");
        }

        [Test]
        public void HexagonNet_GetNeighbourFor_ReturnsCorrectNeighbour()
        {
            // arrange
            HexagonNet<Bubble> net = new HexagonNet<Bubble>();

            var bubblesForTopRow = new BubbleNode[]
            {
                new BubbleNode(0).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(2).SetHexagonNet(net),
                new BubbleNode(3).SetHexagonNet(net),
                new BubbleNode(4).SetHexagonNet(net),
                new BubbleNode(5).SetHexagonNet(net)
            };
            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);

            var bubblesForMiddleRow = new BubbleNode[]
            {
                new BubbleNode(6).SetHexagonNet(net),
                new BubbleNode(7).SetHexagonNet(net),
                new BubbleNode(8).SetHexagonNet(net),
                new BubbleNode(9).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(11).SetHexagonNet(net)
            };
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);

            var bubblesForBottomRow = new BubbleNode[]
            {
                new BubbleNode(12).SetHexagonNet(net),
                new BubbleNode(13).SetHexagonNet(net),
                new BubbleNode(14).SetHexagonNet(net),
                new BubbleNode(15).SetHexagonNet(net),
                new BubbleNode(16).SetHexagonNet(net),
                new BubbleNode(17).SetHexagonNet(net)
            };
            var bottomRow = new HexagonNetRow<Bubble>(bubblesForBottomRow);

            net.AddTopRow(topRow);
            net.AddBottomRow(middleRow);
            net.AddBottomRow(bottomRow);

            var secondNodeMiddleRow = middleRow.Nodes[1];

            // act
            var secondNodeMiddleRow_LowerLeftNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.LowerLeft);
            var secondNodeMiddleRow_LowerRightNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.LowerRight);
            var secondNodeMiddleRow_LeftNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.Left);
            var secondNodeMiddleRow_RightNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.Right);
            var secondNodeMiddleRow_UpperLeftNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.UpperLeft);
            var secondNodeMiddleRow_UpperRightNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.UpperRight);

            // assert
            Assert.AreEqual(13, secondNodeMiddleRow_LowerLeftNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(14, secondNodeMiddleRow_LowerRightNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(6, secondNodeMiddleRow_LeftNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(8, secondNodeMiddleRow_RightNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(1, secondNodeMiddleRow_UpperLeftNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(2, secondNodeMiddleRow_UpperRightNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        // Given When Then
        [Test]
        public void HexagonNet_NewRowsAreAdded_NeighboursSetupCorrectly()
        {
            // arrange
            HexagonNet<Bubble> net = new HexagonNet<Bubble>();

            var bubblesForTopRow = new BubbleNode[]
            {
                new BubbleNode(0).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(2).SetHexagonNet(net),
                new BubbleNode(3).SetHexagonNet(net),
                new BubbleNode(4).SetHexagonNet(net),
                new BubbleNode(5).SetHexagonNet(net)
            };
            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);

            var bubblesForMiddleRow = new BubbleNode[]
            {
                new BubbleNode(6).SetHexagonNet(net),
                new BubbleNode(7).SetHexagonNet(net),
                new BubbleNode(8).SetHexagonNet(net),
                new BubbleNode(9).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(11).SetHexagonNet(net)
            };
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);

            var bubblesForBottomRow = new BubbleNode[]
            {
                new BubbleNode(12).SetHexagonNet(net),
                new BubbleNode(13).SetHexagonNet(net),
                new BubbleNode(14).SetHexagonNet(net),
                new BubbleNode(15).SetHexagonNet(net),
                new BubbleNode(16).SetHexagonNet(net),
                new BubbleNode(17).SetHexagonNet(net)
            };
            var bottomRow = new HexagonNetRow<Bubble>(bubblesForBottomRow);

            net.AddTopRow(topRow);
            net.AddBottomRow(middleRow);
            net.AddBottomRow(bottomRow);

            var secondNodeMiddleRow = middleRow.Nodes[1];

            // act
            var secondNodeMiddleRow_LowerLeftNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.Neighbours.LowerLeft];
            var secondNodeMiddleRow_LowerRightNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.Neighbours.LowerRight];
            var secondNodeMiddleRow_LeftNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.Neighbours.Left];
            var secondNodeMiddleRow_RightNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.Neighbours.Right];
            var secondNodeMiddleRow_UpperLeftNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.Neighbours.UpperLeft];
            var secondNodeMiddleRow_UpperRightNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.Neighbours.UpperRight];

            // assert
            // assert
            Assert.AreEqual(13, secondNodeMiddleRow_LowerLeftNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(14, secondNodeMiddleRow_LowerRightNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(6, secondNodeMiddleRow_LeftNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(8, secondNodeMiddleRow_RightNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(1, secondNodeMiddleRow_UpperLeftNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(2, secondNodeMiddleRow_UpperRightNeighbour.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }
    }
}
