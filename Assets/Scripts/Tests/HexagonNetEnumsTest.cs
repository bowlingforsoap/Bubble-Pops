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
            var upperLeftNeighbour = Neighbours.UpperLeft;
            var upperRightNeighbour = Neighbours.UpperRight;
            var leftNeighbour = Neighbours.Left;
            var rightNeighbour = Neighbours.Right;
            var lowerLeftNeighbour = Neighbours.LowerLeft;
            var lowerRightNeighbour = Neighbours.LowerRight;

            // act
            var upperLeftNeighbourOpposite = GetOppositeNeighbourNode(upperLeftNeighbour);
            var upperRightNeighbourOpposite = GetOppositeNeighbourNode(upperRightNeighbour);
            var leftNeighbourOpposite = GetOppositeNeighbourNode(leftNeighbour);
            var rightNeighbourOpposite = GetOppositeNeighbourNode(rightNeighbour);
            var lowerLeftNeighbourOpposite = GetOppositeNeighbourNode(lowerLeftNeighbour);
            var lowerRightNeighbourOpposite = GetOppositeNeighbourNode(lowerRightNeighbour);

            // assert
            Assert.AreEqual(OppositeNeighbours.LowerRight, upperLeftNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbours.LowerLeft, upperRightNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbours.Right, leftNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbours.Left, rightNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbours.UpperRight, lowerLeftNeighbourOpposite);
            Assert.AreEqual(OppositeNeighbours.UpperLeft, lowerRightNeighbourOpposite);
        }

        [Test]
        public void HexagonNetEnums_ConversionOppositeToNeighbour_Correct()
        {
            // arrange
            var upperLeftNeighbour = OppositeNeighbours.UpperLeft;
            var upperRightNeighbour = OppositeNeighbours.UpperRight;
            var leftNeighbour = OppositeNeighbours.Left;
            var rightNeighbour = OppositeNeighbours.Right;
            var lowerLeftNeighbour = OppositeNeighbours.LowerLeft;
            var lowerRightNeighbour = OppositeNeighbours.LowerRight;

            // act
            var upperLeftNeighbourOpposite = GetOppositeNeighbourNode(upperLeftNeighbour);
            var upperRightNeighbourOpposite = GetOppositeNeighbourNode(upperRightNeighbour);
            var leftNeighbourOpposite = GetOppositeNeighbourNode(leftNeighbour);
            var rightNeighbourOpposite = GetOppositeNeighbourNode(rightNeighbour);
            var lowerLeftNeighbourOpposite = GetOppositeNeighbourNode(lowerLeftNeighbour);
            var lowerRightNeighbourOpposite = GetOppositeNeighbourNode(lowerRightNeighbour);

            // assert
            Assert.AreEqual(Neighbours.LowerRight, upperLeftNeighbourOpposite);
            Assert.AreEqual(Neighbours.LowerLeft, upperRightNeighbourOpposite);
            Assert.AreEqual(Neighbours.Right, leftNeighbourOpposite);
            Assert.AreEqual(Neighbours.Left, rightNeighbourOpposite);
            Assert.AreEqual(Neighbours.UpperRight, lowerLeftNeighbourOpposite);
            Assert.AreEqual(Neighbours.UpperLeft, lowerRightNeighbourOpposite);
        }
    }
}
