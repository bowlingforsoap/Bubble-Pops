using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BubbleEventArgs : EventArgs
{
    public List<IHexagonNetNode<Bubble>> BubbleNodes { get; } = new List<IHexagonNetNode<Bubble>>();

    /// <summary>
    /// Convenience short-hand method for setting the BubbleNodes from IEnumerable.
    /// </summary>
    /// <param name="nodes"></param>
    /// <returns></returns>
    public BubbleEventArgs SetBubbleNodes(IEnumerable<IHexagonNetNode<Bubble>> nodes)
    {
        foreach (var node in nodes)
        {
            BubbleNodes.Add(node);
        }

        return this;
    }
}
