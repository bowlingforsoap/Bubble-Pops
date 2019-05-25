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

            return net;
        }
    }
}
