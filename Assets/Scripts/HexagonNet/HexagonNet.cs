using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using static HexagonNetEnums;

/// <summary>
/// The data structure, which consists of rows of 6 hexagons each. Every odd row is shifted by one postion to the right:
/// * * * * * *    - row 0
///  * * * * * *   - row 1 (shifted by 1 to the right)
/// * * * * * *    - row 2 (not shifted)
///  * * * * * *   - row 3
///  ... and so on ...
/// </summary>
/// <typeparam name="T"></typeparam>
public class HexagonNet<T> : IEnumerable<IHexagonNetNode<T>> where T : class
{
    private SortedDictionary<int, HexagonNetRow<T>> net = new SortedDictionary<int, HexagonNetRow<T>>();
    /// <summary>
    /// Provides access to the current top row of the HexagonNet.
    /// </summary>
    public HexagonNetRow<T> TopRow { get; protected set; }
    /// <summary>
    /// Provides acess to the current bottom row of the HexagonNet.
    /// </summary>
    public HexagonNetRow<T> BottomRow { get; protected set; }

    private void InitializeNet(HexagonNetRow<T> firstRow)
    {
        firstRow.Shifted = false;
        firstRow.Index = 0;
        SetCompleteRow(firstRow);
        TopRow = firstRow;
        BottomRow = firstRow;
    }

    /// <summary>
    /// Replaces the TopRow with the newTopRow.
    /// </summary>
    /// <param name="newTopRow"></param>
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

    /// <summary>
    /// Replaces the BottomRow with the newBottomRow.
    /// </summary>
    /// <param name="newBottomRow"></param>
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
        // Remove current
        if (TopRow != null)
        {
            net.Remove(TopRow.Index);
        }

        // Assign new
        if (net.Keys.Count > 0)
        {
            TopRow = net[TopRow.Index + 1];
            UpdateNeighboursForAllNodes(TopRow);
        }
    }

    public void RemoveBottomRow()
    {
        // Remove current
        if (BottomRow != null)
        {
            net.Remove(BottomRow.Index);
        }

        // Assign new
        if (net.Keys.Count > 0)
        {
            BottomRow = net[BottomRow.Index - 1];
            UpdateNeighboursForAllNodes(BottomRow);
        }

    }

    /// <summary>
    /// Retrieves the specified neighbour of this node.
    /// </summary>
    /// <param name="node"></param>
    /// <param name="neighbour"></param>
    /// <returns>The neighbour or null, if no neighbour is found.</returns>
    public IHexagonNetNode<T> GetNeighbourFor(IHexagonNetNode<T> node, HexagonNetEnums.Neighbours neighbour)
    {
        if (node == null) throw new ArgumentException("Cannot find the neigbour for the node that is null!");
        if (node.Position == null) throw new ArgumentException("The node has to be positioned within the HexagonNet!");

        IHexagonNetNode<T> neighbourNode = null;

        try
        {
            var row = net[node.Position.x];
            if (row.Shifted)
            {
                neighbourNode = GetNeighbourForShiftedRowNode(node, neighbour);
            }
            else
            {
                neighbourNode = GetNeighbourForNotShiftedRowNode(node, neighbour);
            }
        }
        catch (Exception ex)
        {
            Type exType = ex.GetType();
            if (exType == typeof(IndexOutOfRangeException) || exType == typeof(KeyNotFoundException))
            {
                // Means we are at the border or the row above/below is not yet added
                // Simply leave the neighbourNode == null;
            }
            else
            {
                throw;
            }
        }

        return neighbourNode;
    }

    private IHexagonNetNode<T> GetNeighbourForShiftedRowNode(IHexagonNetNode<T> node, HexagonNetEnums.Neighbours neighbour)
    {
        IHexagonNetNode<T> neighbourNode = null;

        var nodePosition = node.Position;
        switch (neighbour)
        {
            case HexagonNetEnums.Neighbours.UpperLeft:
                neighbourNode = net[nodePosition.x - 1].Nodes[nodePosition.y];
                break;
            case HexagonNetEnums.Neighbours.UpperRight:
                neighbourNode = net[nodePosition.x - 1].Nodes[nodePosition.y + 1];
                break;
            case HexagonNetEnums.Neighbours.Left:
                neighbourNode = net[nodePosition.x].Nodes[nodePosition.y - 1];
                break;
            case HexagonNetEnums.Neighbours.Right:
                neighbourNode = net[nodePosition.x].Nodes[nodePosition.y + 1];
                break;
            case HexagonNetEnums.Neighbours.LowerLeft:
                neighbourNode = net[nodePosition.x + 1].Nodes[nodePosition.y];
                break;
            case HexagonNetEnums.Neighbours.LowerRight:
                neighbourNode = net[nodePosition.x + 1].Nodes[nodePosition.y + 1];
                break;
        }

        return neighbourNode;
    }

    private IHexagonNetNode<T> GetNeighbourForNotShiftedRowNode(IHexagonNetNode<T> node, HexagonNetEnums.Neighbours neighbour)
    {
        IHexagonNetNode<T> neighbourNode = null;
        var nodePosition = node.Position;

        switch (neighbour)
        {
            case HexagonNetEnums.Neighbours.UpperLeft:
                neighbourNode = net[nodePosition.x - 1].Nodes[nodePosition.y - 1];
                break;
            case HexagonNetEnums.Neighbours.UpperRight:
                neighbourNode = net[nodePosition.x - 1].Nodes[nodePosition.y];
                break;
            case HexagonNetEnums.Neighbours.Left:
                neighbourNode = net[nodePosition.x].Nodes[nodePosition.y - 1];
                break;
            case HexagonNetEnums.Neighbours.Right:
                neighbourNode = net[nodePosition.x].Nodes[nodePosition.y + 1];
                break;
            case HexagonNetEnums.Neighbours.LowerLeft:
                neighbourNode = net[nodePosition.x + 1].Nodes[nodePosition.y - 1];
                break;
            case HexagonNetEnums.Neighbours.LowerRight:
                neighbourNode = net[nodePosition.x + 1].Nodes[nodePosition.y];
                break;
        }

        return neighbourNode;
    }


    /// <summary>
    /// Set a completely setup row at its Index.
    /// </summary>
    /// <param name="row"></param>
    private void SetCompleteRow(HexagonNetRow<T> row)
    {
        PositionNodesWithinNet(row);
        net.Add(row.Index, row);

        UpdateNeighboursForAllNodes(row);
    }

    /// <summary>
    /// Position nodes of the given row within the net by assigning them a correct IHexagonNetRow.Position index.
    /// </summary>
    public void PositionNodesWithinNet(HexagonNetRow<T> row)
    {
        for (int i = 0; i < 6; i++)
        {
            if (row.Nodes[i] != null)
            {
                row.Nodes[i].Position = new Vector2Int(row.Index, i);
            }
        }
    }

    /// <summary>
    /// Update neighbours of all nodes in the given row.
    /// </summary>
    /// <param name="row"></param>
    private void UpdateNeighboursForAllNodes(HexagonNetRow<T> row)
    {
        foreach (var node in row)
        {
            UpdateNeighboursFor(node);
        }
    }

    /// <summary>
    /// Binds the neighbouring nodes together withing and in-between the HexagonRows.
    /// </summary>
    /// <param name="node"></param>
    private void UpdateNeighboursFor(IHexagonNetNode<T> node)
    {
        UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.Left);
        UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.LowerLeft);
        UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.LowerRight);
        UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.Right);
        UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.UpperLeft);
        UpdateNeighbourFor(node, HexagonNetEnums.Neighbours.UpperRight);
    }

    private void UpdateNeighbourFor(IHexagonNetNode<T> node, Neighbours neighbour)
    {
        IHexagonNetNode<T> neighbourNode = GetNeighbourFor(node, neighbour);

        if (node != null)
        {
            node.SetNeighbour(neighbourNode, neighbour);
        }

        if (neighbourNode != null)
        {
            // Find which neighbour from HexaonNetEnums.Neighbours is this node for the neighbourNode
            var oppositeNeighbour = GetOppositeNeighbourNode(neighbour);
            Neighbours neighbourForNeighbour = GetNeighbourWithSameNameAsOpposite(oppositeNeighbour);

            neighbourNode.SetNeighbour(node, neighbourForNeighbour);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<IHexagonNetNode<T>> GetEnumerator()
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
