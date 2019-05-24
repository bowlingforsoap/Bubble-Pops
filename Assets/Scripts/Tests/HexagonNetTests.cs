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

            var bubblesForTopRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(-1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(-1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(-1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(-1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(-1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(-1).SetHexagonNet(net)
            };
            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);

            var bubblesForMiddleRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(0).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(0).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(0).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(0).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(0).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(0).SetHexagonNet(net)
            };
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);

            var bubblesForLowerMiddleRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(1).SetHexagonNet(net)
            };
            var lowerMiddleRow = new HexagonNetRow<Bubble>(bubblesForLowerMiddleRow);

            var bubblesForBottomRow = new Bubble[]
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

            var bubblesForTopRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(0).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(2).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(3).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(4).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(5).SetHexagonNet(net)
            };
            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);

            var bubblesForMiddleRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(6).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(7).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(8).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(9).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(10).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(11).SetHexagonNet(net)
            };
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);

            var bubblesForBottomRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(12).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(13).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(14).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(15).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(16).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(17).SetHexagonNet(net)
            };
            var bottomRow = new HexagonNetRow<Bubble>(bubblesForBottomRow);

            net.AddTopRow(topRow);
            net.AddBottomRow(middleRow);
            net.AddBottomRow(bottomRow);

            var secondNodeMiddleRow = middleRow.Nodes[1];

            // act
            var secondNodeMiddleRow_LowerLeftNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.NeighbourNode.LowerLeft);
            var secondNodeMiddleRow_LowerRightNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.NeighbourNode.LowerRight);
            var secondNodeMiddleRow_LeftNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.NeighbourNode.Left);
            var secondNodeMiddleRow_RightNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.NeighbourNode.Right);
            var secondNodeMiddleRow_UpperLeftNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.NeighbourNode.UpperLeft);
            var secondNodeMiddleRow_UpperRightNeighbour = (Bubble)net.GetNeighbourFor(secondNodeMiddleRow, HexagonNetEnums.NeighbourNode.UpperRight);

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

            var bubblesForTopRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(0).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(1).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(2).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(3).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(4).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(5).SetHexagonNet(net)
            };
            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);

            var bubblesForMiddleRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(6).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(7).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(8).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(9).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(10).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(11).SetHexagonNet(net)
            };
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);

            var bubblesForBottomRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(12).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(13).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(14).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(15).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(16).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(17).SetHexagonNet(net)
            };
            var bottomRow = new HexagonNetRow<Bubble>(bubblesForBottomRow);

            net.AddTopRow(topRow);
            net.AddBottomRow(middleRow);
            net.AddBottomRow(bottomRow);

            var secondNodeMiddleRow = middleRow.Nodes[1];

            // act
            var secondNodeMiddleRow_LowerLeftNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.NeighbourNode.LowerLeft];
            var secondNodeMiddleRow_LowerRightNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.NeighbourNode.LowerRight];
            var secondNodeMiddleRow_LeftNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.NeighbourNode.Left];
            var secondNodeMiddleRow_RightNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.NeighbourNode.Right];
            var secondNodeMiddleRow_UpperLeftNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.NeighbourNode.UpperLeft];
            var secondNodeMiddleRow_UpperRightNeighbour = (Bubble)secondNodeMiddleRow.Neighbours[(int)HexagonNetEnums.NeighbourNode.UpperRight];

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
