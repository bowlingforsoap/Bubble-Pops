using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using static HexagonNetEnums;
namespace Tests
{
    public class HexagonNetEnumsTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void HexagonNetEnums_ConversionNeighbourToOpposite_Correct()
        {
            // arrange
            var upperLeftNeighbour = NeighbourNode.UpperLeft;
            var upperRightNeighbour = NeighbourNode.UpperRight;
            var leftNeighbour = NeighbourNode.Left;
            var rightNeighbour = NeighbourNode.Right;
            var lowerLeftNeighbour = NeighbourNode.LowerLeft;
            var lowerRightNeighbour = NeighbourNode.LowerRight;

            // act
            var upperLeftNeighbourOpposite = GetOppositeNeighbourNode(upperLeftNeighbour);
            var upperRightNeighbourOpposite = GetOppositeNeighbourNode(upperRightNeighbour);
            var leftNeighbourOpposite = GetOppositeNeighbourNode(leftNeighbour);
            var rightNeighbourOpposite = GetOppositeNeighbourNode(rightNeighbour);
            var lowerLeftNeighbourOpposite = GetOppositeNeighbourNode(lowerLeftNeighbour);
            var lowerRightNeighbourOpposite = GetOppositeNeighbourNode(lowerRightNeighbour);

            // assert
            Assert.AreEqual(OppositeNeighbourNode.LowerRight, upperLeftNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbourNode.LowerLeft, upperRightNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbourNode.Right, leftNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbourNode.Left, rightNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbourNode.UpperRight, lowerLeftNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbourNode.UpperLeft, lowerRightNeighbourOpposite);
        }

        [Test]
        public void HexagonNetEnums_ConversionOppositeToNeighbour_Correct()
        {
            // arrange
            var upperLeftNeighbour = OppositeNeighbourNode.UpperLeft;
            var upperRightNeighbour = OppositeNeighbourNode.UpperRight;
            var leftNeighbour = OppositeNeighbourNode.Left;
            var rightNeighbour = OppositeNeighbourNode.Right;
            var lowerLeftNeighbour = OppositeNeighbourNode.LowerLeft;
            var lowerRightNeighbour = OppositeNeighbourNode.LowerRight;

            // act
            var upperLeftNeighbourOpposite = GetOppositeNeighbourNode(upperLeftNeighbour);
            var upperRightNeighbourOpposite = GetOppositeNeighbourNode(upperRightNeighbour);
            var leftNeighbourOpposite = GetOppositeNeighbourNode(leftNeighbour);
            var rightNeighbourOpposite = GetOppositeNeighbourNode(rightNeighbour);
            var lowerLeftNeighbourOpposite = GetOppositeNeighbourNode(lowerLeftNeighbour);
            var lowerRightNeighbourOpposite = GetOppositeNeighbourNode(lowerRightNeighbour);

            // assert
            Assert.AreEqual(NeighbourNode.LowerRight, upperLeftNeighbourOpposite);
            Assert.AreEqual(NeighbourNode.LowerLeft, upperRightNeighbourOpposite);
            Assert.AreEqual(NeighbourNode.Right, leftNeighbourOpposite);
            Assert.AreEqual(NeighbourNode.Left, rightNeighbourOpposite);
            Assert.AreEqual(NeighbourNode.UpperRight, lowerLeftNeighbourOpposite);
            Assert.AreEqual(NeighbourNode.UpperLeft, lowerRightNeighbourOpposite);
        }
    }
}
