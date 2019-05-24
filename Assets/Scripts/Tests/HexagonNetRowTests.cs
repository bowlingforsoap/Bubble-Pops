using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    class HexagonNetRowTests
    {
        [Test]
        public void PositionNodesWithinNet_RowIndexCorrectlySetup_NodesReceiveCorrectPositions()
        {
            // arrange
            var net = HexagonNetTestHelper.GenerateTestNet3Rows(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            var expectedIndices = $" (0, 0) (0, 1) (0, 2) (0, 3) (0, 4) (0, 5){Environment.NewLine}" +
                $" (1, 0) (1, 1) (1, 2) (1, 3) (1, 4) (1, 5){Environment.NewLine}" +                $" (2, 0) (2, 1) (2, 2) (2, 3) (2, 4) (2, 5){Environment.NewLine}";

            // act
            string actualIndices = "";
            int nodeCounter = 0;
            foreach (var node in net)
            {
                actualIndices += " ";
                actualIndices += node.Position.Value;

                nodeCounter++;
                if (nodeCounter == 6)
                {
                    actualIndices += Environment.NewLine;
                    nodeCounter = 0;
                }
            }

            // assert
            Assert.AreEqual(expectedIndices, actualIndices, $"Actual indices: {Environment.NewLine}{actualIndices}");
        }
    }
}
