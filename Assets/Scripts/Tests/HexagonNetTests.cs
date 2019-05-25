using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HexagonNetEnums;

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
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net)
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
            var secondNodeMiddleRow_LowerLeftNeighbour = (BubbleNode)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.LowerLeft);
            var secondNodeMiddleRow_LowerRightNeighbour = (BubbleNode)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.LowerRight);
            var secondNodeMiddleRow_LeftNeighbour = (BubbleNode)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.Left);
            var secondNodeMiddleRow_RightNeighbour = (BubbleNode)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.Right);
            var secondNodeMiddleRow_UpperLeftNeighbour = (BubbleNode)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.UpperLeft);
            var secondNodeMiddleRow_UpperRightNeighbour = (BubbleNode)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.Neighbours.UpperRight);

            // assert
            Assert.AreEqual(13, secondNodeMiddleRow_LowerLeftNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(14, secondNodeMiddleRow_LowerRightNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(6, secondNodeMiddleRow_LeftNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(8, secondNodeMiddleRow_RightNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(1, secondNodeMiddleRow_UpperLeftNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(2, secondNodeMiddleRow_UpperRightNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
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
            var secondNodeMiddleRow_LowerLeftNeighbour = (BubbleNode)secondNodeMiddleRow.GetNeighbour(Neighbours.LowerLeft);
            var secondNodeMiddleRow_LowerRightNeighbour = (BubbleNode)secondNodeMiddleRow.GetNeighbour(Neighbours.LowerRight);
            var secondNodeMiddleRow_LeftNeighbour = (BubbleNode)secondNodeMiddleRow.GetNeighbour(Neighbours.Left);
            var secondNodeMiddleRow_RightNeighbour = (BubbleNode)secondNodeMiddleRow.GetNeighbour(Neighbours.Right);
            var secondNodeMiddleRow_UpperLeftNeighbour = (BubbleNode)secondNodeMiddleRow.GetNeighbour(Neighbours.UpperLeft);
            var secondNodeMiddleRow_UpperRightNeighbour = (BubbleNode)secondNodeMiddleRow.GetNeighbour(Neighbours.UpperRight);


            // assert
            Assert.AreEqual(7, secondNodeMiddleRow.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");

            Assert.AreEqual(13, secondNodeMiddleRow_LowerLeftNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(14, secondNodeMiddleRow_LowerRightNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(6, secondNodeMiddleRow_LeftNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(8, secondNodeMiddleRow_RightNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(1, secondNodeMiddleRow_UpperLeftNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
            Assert.AreEqual(2, secondNodeMiddleRow_UpperRightNeighbour.Value.Exponent, $"HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void HexagonNet_ChangingNeighbours_ChangesNeighbourNodesInNet()
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

            var expectedNet = HexagonNetTestHelper.GenerateTestNet3Rows(0, 1, -1000, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            var expectedNetToString = expectedNet.ToString();

            // act
            secondNodeMiddleRow.GetNeighbour(Neighbours.UpperRight).Value.Exponent = -1000;

            // assert
            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void HexagonNet_RemoveTopRow_RemovesTheRowFromNet()
        {
            // arrange
            HexagonNet<Bubble> net = HexagonNetTestHelper.GenerateTestNet3Rows(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            var expectedNetToString = $" 6 7 8 9 10 11{Environment.NewLine}" +
                $" 12 13 14 15 16 17{Environment.NewLine}";

            // act
            net.RemoveTopRow();

            // assert
            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void HexagonNet_RemoveTopRow_ReassignsNeighbours()
        {
            // arrange
            HexagonNet<Bubble> net = HexagonNetTestHelper.GenerateTestNet3Rows(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            // act
            net.RemoveTopRow();
            var topRowNodes = net.TopRow.Nodes;

            // assert
            Assert.AreEqual(null, topRowNodes[0].GetNeighbour(Neighbours.UpperLeft));
            Assert.AreEqual(null, topRowNodes[0].GetNeighbour(Neighbours.UpperRight));
            Assert.AreEqual(null, topRowNodes[1].GetNeighbour(Neighbours.UpperLeft));
            Assert.AreEqual(null, topRowNodes[1].GetNeighbour(Neighbours.UpperRight));
            Assert.AreEqual(null, topRowNodes[2].GetNeighbour(Neighbours.UpperLeft));
            Assert.AreEqual(null, topRowNodes[2].GetNeighbour(Neighbours.UpperRight));
            Assert.AreEqual(null, topRowNodes[3].GetNeighbour(Neighbours.UpperLeft));
            Assert.AreEqual(null, topRowNodes[3].GetNeighbour(Neighbours.UpperRight));
            Assert.AreEqual(null, topRowNodes[4].GetNeighbour(Neighbours.UpperLeft));
            Assert.AreEqual(null, topRowNodes[4].GetNeighbour(Neighbours.UpperRight));
            Assert.AreEqual(null, topRowNodes[5].GetNeighbour(Neighbours.UpperLeft));
            Assert.AreEqual(null, topRowNodes[5].GetNeighbour(Neighbours.UpperRight));
        }

        [Test]
        public void HexagonNet_RemoveBottomRow_RemovesTheRowFromNet()
        {
            // arrange
            HexagonNet<Bubble> net = HexagonNetTestHelper.GenerateTestNet3Rows(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            var expectedNetToString =
                $" 0 1 2 3 4 5{Environment.NewLine}" +
                $" 6 7 8 9 10 11{Environment.NewLine}";

            // act
            net.RemoveBottomRow();

            // assert
            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void HexagonNet_RemoveBottomRow_ReassignsNeighbours()
        {
            // arrange
            HexagonNet<Bubble> net = HexagonNetTestHelper.GenerateTestNet3Rows(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            // act
            net.RemoveBottomRow();
            var bottomRowNodes = net.BottomRow.Nodes;

            // assert
            Assert.AreEqual(null, bottomRowNodes[0].GetNeighbour(Neighbours.LowerLeft));
            Assert.AreEqual(null, bottomRowNodes[0].GetNeighbour(Neighbours.LowerRight));
            Assert.AreEqual(null, bottomRowNodes[1].GetNeighbour(Neighbours.LowerLeft));
            Assert.AreEqual(null, bottomRowNodes[1].GetNeighbour(Neighbours.LowerRight));
            Assert.AreEqual(null, bottomRowNodes[2].GetNeighbour(Neighbours.LowerLeft));
            Assert.AreEqual(null, bottomRowNodes[2].GetNeighbour(Neighbours.LowerRight));
            Assert.AreEqual(null, bottomRowNodes[3].GetNeighbour(Neighbours.LowerLeft));
            Assert.AreEqual(null, bottomRowNodes[3].GetNeighbour(Neighbours.LowerRight));
            Assert.AreEqual(null, bottomRowNodes[4].GetNeighbour(Neighbours.LowerLeft));
            Assert.AreEqual(null, bottomRowNodes[4].GetNeighbour(Neighbours.LowerRight));
            Assert.AreEqual(null, bottomRowNodes[5].GetNeighbour(Neighbours.LowerLeft));
            Assert.AreEqual(null, bottomRowNodes[5].GetNeighbour(Neighbours.LowerRight));
        }
    }
}
