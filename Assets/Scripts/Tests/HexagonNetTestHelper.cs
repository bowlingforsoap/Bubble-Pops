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

            var bubblesForTopRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(exponents[0]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[1]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[2]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[3]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[4]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[5]).SetHexagonNet(net)
            };
            var topRow = new HexagonNetRow<Bubble>(bubblesForTopRow);

            var bubblesForMiddleRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(exponents[6]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[7]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[8]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[9]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[10]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[11]).SetHexagonNet(net)
            };
            var middleRow = new HexagonNetRow<Bubble>(bubblesForMiddleRow);

            var bubblesForBottomRow = new Bubble[]
            {
                BubblePool.Instance.Get().SetExponent(exponents[12]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[13]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[14]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[15]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[16]).SetHexagonNet(net),
                BubblePool.Instance.Get().SetExponent(exponents[17]).SetHexagonNet(net)
            };
            var bottomRow = new HexagonNetRow<Bubble>(bubblesForBottomRow);

            net.AddTopRow(topRow);
            net.AddBottomRow(middleRow);
            net.AddBottomRow(bottomRow);

            return net;
        }
    }
}
