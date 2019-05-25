using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class HexagonNetTestHelper
    {
        /// <summary>
        /// Generate a HexagonNet and add three rows to it with Bubbles, whose exponents are specified in parameters.
        /// </summary>
        /// <param name="exponents"></param>
        /// <returns></returns>
        public static HexagonNet<Bubble> GenerateTestNet3Rows(params int[] exponents)
        {
            HexagonNet<Bubble> net = new HexagonNet<Bubble>();

            var bubblesForTopRow = new BubbleNode[]
            {
                new BubbleNode(exponents[0]).SetHexagonNet(net),
                new BubbleNode(exponents[1]).SetHexagonNet(net),
                new BubbleNode(exponents[2]).SetHexagonNet(net),
                new BubbleNode(exponents[3]).SetHexagonNet(net),
                new BubbleNode(exponents[4]).SetHexagonNet(net),
                new BubbleNode(exponents[5]).SetHexagonNet(net)
            };
            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);

            var bubblesForMiddleRow = new BubbleNode[]
            {
                new BubbleNode(exponents[6]).SetHexagonNet(net),
                new BubbleNode(exponents[7]).SetHexagonNet(net),
                new BubbleNode(exponents[8]).SetHexagonNet(net),
                new BubbleNode(exponents[9]).SetHexagonNet(net),
                new BubbleNode(exponents[10]).SetHexagonNet(net),
                new BubbleNode(exponents[11]).SetHexagonNet(net)
            };
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);

            var bubblesForBottomRow = new BubbleNode[]
            {
                new BubbleNode(exponents[12]).SetHexagonNet(net),
                new BubbleNode(exponents[13]).SetHexagonNet(net),
                new BubbleNode(exponents[14]).SetHexagonNet(net),
                new BubbleNode(exponents[15]).SetHexagonNet(net),
                new BubbleNode(exponents[16]).SetHexagonNet(net),
                new BubbleNode(exponents[17]).SetHexagonNet(net)
            };
            var bottomRow = new HexagonNetRow<Bubble>(bubblesForBottomRow);

            net.AddTopRow(topRow);
            net.AddBottomRow(middleRow);
            net.AddBottomRow(bottomRow);

            return net;
        }
    }
}
