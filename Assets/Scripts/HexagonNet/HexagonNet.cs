using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

/// <summary>
/// The data structure, which consists of rows of 6 hexagons each. Every odd row is shifted by one postion to the right:
/// * * * * * *    - row 0
///  * * * * * *   - row 1 (shifted by 1 to the right)
/// * * * * * *    - row 2 (not shifted)
///  * * * * * *   - row 3
///  ... and so on ...
/// </summary>
/// <typeparam name="T"></typeparam>
public class HexagonNet<T> : IEnumerable<T> where T : class, IHexagonNetNode
{
    private SortedDictionary<int, HexagonNetRow<T>> net = new SortedDictionary<int, HexagonNetRow<T>>();
    public HexagonNetRow<T> TopRow { get; protected set; }
    public HexagonNetRow<T> BottomRow { get; protected set; }

    public HexagonNet()
    {
        
    }

    private void InitializeNet(HexagonNetRow<T> firstRow)
    {
        firstRow.Shifted = false;
        firstRow.Index = 0;
        SetCompleteRow(firstRow);
        TopRow = firstRow;
        BottomRow = firstRow;
    }

    public void AddTopRow(HexagonNetRow<T> newTopRow)
    {
        if (TopRow == null)
        {
            InitializeNet(newTopRow);
            return;
        }

        newTopRow.Shifted = !TopRow.Shifted;
        newTopRow.Index = TopRow.Index - 1;
        SetCompleteRow(newTopRow);
        TopRow = newTopRow;
    }

    public void AddBottomRow(HexagonNetRow<T> newBottomRow)
    {
        if (BottomRow == null)
        {
            InitializeNet(newBottomRow);
            return;
        }

        newBottomRow.Shifted = !BottomRow.Shifted;
        newBottomRow.Index = BottomRow.Index + 1;
        SetCompleteRow(newBottomRow);
        BottomRow = newBottomRow;
    }

    public void RemoveTopRow()
    {

    }

    public void RemoveBottomRow()
    {

    }

    /// <summary>
    /// Set a completely setup row at its Index.
    /// </summary>
    /// <param name="row"></param>
    private void SetCompleteRow(HexagonNetRow<T> row)
    {
        net.Add(row.Index, row);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var row in net.Values)
        {
            foreach (var node in row)
            {
                yield return node;
            }
        }
    }

    public override string ToString()
    {
        StringBuilder netAsString = new StringBuilder();

        int i = 0;
        foreach (var node in this)
        {
            netAsString.Append(" ");
            if (node == null)
            {
                netAsString.Append("null");
            }
            else
            {
                netAsString.Append(node);
            }

            i++;
            if (i == 6)
            {
                netAsString.Append(Environment.NewLine);
                i = 0;
            }
        }

        return netAsString.ToString();
    }
}
