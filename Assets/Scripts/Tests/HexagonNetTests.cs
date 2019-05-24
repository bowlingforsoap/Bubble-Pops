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
                new Bubble() { Exponent =-1, HexagonNet = net },
                new Bubble() { Exponent =-1, HexagonNet = net },
                new Bubble() { Exponent =-1, HexagonNet = net },
                new Bubble() { Exponent =-1, HexagonNet = net },
                new Bubble() { Exponent =-1, HexagonNet = net },
                new Bubble() { Exponent =-1, HexagonNet = net }
            };
            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);

            var bubblesForMiddleRow = new Bubble[]
            {
                new Bubble() { Exponent = 0, HexagonNet = net },
                new Bubble() { Exponent = 0, HexagonNet = net },
                new Bubble() { Exponent = 0, HexagonNet = net },
                new Bubble() { Exponent = 0, HexagonNet = net },
                new Bubble() { Exponent = 0, HexagonNet = net },
                new Bubble() { Exponent = 0, HexagonNet = net }
            };
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);

            var bubblesForLowerMiddleRow = new Bubble[]
            {
                new Bubble() { Exponent = 1, HexagonNet = net },
                new Bubble() { Exponent = 1, HexagonNet = net },
                new Bubble() { Exponent = 1, HexagonNet = net },
                new Bubble() { Exponent = 1, HexagonNet = net },
                new Bubble() { Exponent = 1, HexagonNet = net },
                new Bubble() { Exponent = 1, HexagonNet = net }
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
    }
}
