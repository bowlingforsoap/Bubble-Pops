using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HexagonNetEnums;

namespace Tests
{

    public class GameBoardTests
    {
        [Test]
        public void GameBoard_MergeBubbles_OneSimilarBubbleToTheRightValid()
        {
            // arrange
            var net = HexagonNetTestHelper.GenerateTestNet3Rows(3, 3, 3, 3, 3, 3,
                                                                 3, 3, 1, 1, 3, 3,
                                                                3, 3, 3, 3, 3, 3);
            var gameBoard = new GameBoard(net);

            var startBubble = net.BottomRow.Nodes[2].GetNeighbour(Neighbours.UpperRight);
            // Make sure startBubble was chosen correctly
            Debug.Assert(3 == startBubble.GetNeighbour(Neighbours.Left).Value.Exponent);
            Debug.Assert(1 == startBubble.GetNeighbour(Neighbours.Right).Value.Exponent);

            var expectedNetToString =
                $" 3 3 3 3 3 3{Environment.NewLine}" +
                $" 3 3 2 null 3 3{Environment.NewLine}" +
                $" 3 3 3 3 3 3{Environment.NewLine}";

            // act
            gameBoard.MergeBubbles(startBubble);

            // assert

            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void GameBoard_MergeBubbles_OneSimilarBubbleToTheLeftValid()
        {
            // arrange
            var net = HexagonNetTestHelper.GenerateTestNet3Rows(3, 3, 3, 3, 3, 3,
                                                                 3, 1, 1, 3, 3, 3,
                                                                3, 3, 3, 3, 3, 3);
            var gameBoard = new GameBoard(net);

            var startBubble = net.BottomRow.Nodes[2].GetNeighbour(Neighbours.UpperRight);

            var expectedNetToString =
                $" 3 3 3 3 3 3{Environment.NewLine}" +
                $" 3 null 2 3 3 3{Environment.NewLine}" +
                $" 3 3 3 3 3 3{Environment.NewLine}";

            // act
            gameBoard.MergeBubbles(startBubble);

            // assert

            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void GameBoard_MergeBubbles_OneSimilarBubbleAtTheTopValid()
        {
            // arrange
            var net = HexagonNetTestHelper.GenerateTestNet3Rows(3, 3, 1, 3, 3, 3,
                                                                 3, 3, 1, 3, 3, 3,
                                                                3, 3, 3, 3, 3, 3);
            var gameBoard = new GameBoard(net);

            var startBubble = net.BottomRow.Nodes[2].GetNeighbour(Neighbours.UpperRight);

            var expectedNetToString =
                $" 3 3 null 3 3 3{Environment.NewLine}" +
                 $" 3 3 2 3 3 3{Environment.NewLine}" +
                $" 3 3 3 3 3 3{Environment.NewLine}";

            // act
            gameBoard.MergeBubbles(startBubble);

            // assert

            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void GameBoard_MergeBubbles_OneSimilarBubbleAtTheBottomValid()
        {
            // arrange
            var net = HexagonNetTestHelper.GenerateTestNet3Rows(3, 3, 3, 3, 3, 3,
                                                                 3, 3, 1, 3, 3, 3,
                                                                3, 3, 3, 1, 3, 3);
            var gameBoard = new GameBoard(net);

            var startBubble = net.BottomRow.Nodes[2].GetNeighbour(Neighbours.UpperRight);

            var expectedNetToString =
                $" 3 3 3 3 3 3{Environment.NewLine}" +
                 $" 3 3 2 3 3 3{Environment.NewLine}" +
                $" 3 3 3 null 3 3{Environment.NewLine}";

            // act
            gameBoard.MergeBubbles(startBubble);

            // assert

            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void GameBoard_MergeBubbles_MultipleSimilarAtTheTopValid()
        {
            // arrange
            // arrange
            HexagonNet<Bubble> net = new HexagonNet<Bubble>();

            var bubblesForTopRow = new BubbleNode[]
            {
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net)
            };
            var bubblesForMiddleRow = new BubbleNode[]
            {
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net)
            };
            var bubblesForBottomRow = new BubbleNode[]
            {
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net)
            };

            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);
            var bottomRow = new HexagonNetRow<Bubble>(bubblesForBottomRow);

            net.AddTopRow(topRow);
            net.AddBottomRow(middleRow);
            net.AddBottomRow(bottomRow);

            var gameBoard = new GameBoard(net);

            var startBubble = net.BottomRow.Nodes[3];

            var expectedNetToString =
                $" 10 null 10 10 10 10{Environment.NewLine}" +
                 $" null 10 null null 10 10{Environment.NewLine}" +
                $" null null null 3 null null{Environment.NewLine}";

            // act
            gameBoard.MergeBubbles(startBubble);

            // assert

            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void GameBoard_MergeBubbles_EvenMoreSimilarAtTheTopValid()
        {
            // arrange
            // arrange
            HexagonNet<Bubble> net = new HexagonNet<Bubble>();

            var bubblesForTopRow = new BubbleNode[]
            {
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net)
            };
            var bubblesForMiddleRow = new BubbleNode[]
            {
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net),
                new BubbleNode(10).SetHexagonNet(net)
            };
            var bubblesForBottomRow = new BubbleNode[]
            {
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(1).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net),
                new BubbleNode(null).SetHexagonNet(net)
            };

            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);
            var bottomRow = new HexagonNetRow<Bubble>(bubblesForBottomRow);

            net.AddTopRow(topRow);
            net.AddBottomRow(middleRow);
            net.AddBottomRow(bottomRow);

            var gameBoard = new GameBoard(net);

            var startBubble = net.BottomRow.Nodes[3];

            var expectedNetToString =
                $" 10 10 10 10 10 10{Environment.NewLine}" +
                 $" 10 10 null null 10 10{Environment.NewLine}" +
                $" null null null 3 null null{Environment.NewLine}";

            // act
            gameBoard.MergeBubbles(startBubble);

            // assert

            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }

        [Test]
        public void GameBoard_MergeBubbles_NoSimilarValid()
        {
            // arrange
            var net = HexagonNetTestHelper.GenerateTestNet3Rows(3, 3, 3, 3, 3, 3,
                                                                 3, 3, 1, 3, 3, 3,
                                                                3, 3, 3, 3, 3, 3);
            var gameBoard = new GameBoard(net);

            var startBubble = net.BottomRow.Nodes[2].GetNeighbour(Neighbours.UpperRight);

            var expectedNetToString =
                $" 3 3 3 3 3 3{Environment.NewLine}" +
                $" 3 3 1 3 3 3{Environment.NewLine}" +
                $" 3 3 3 3 3 3{Environment.NewLine}";

            // act
            gameBoard.MergeBubbles(startBubble);

            // assert

            Assert.AreEqual(expectedNetToString, net.ToString(), $"Actual HexagonNet as string: {Environment.NewLine}{net.ToString()}");
        }
    }
}
