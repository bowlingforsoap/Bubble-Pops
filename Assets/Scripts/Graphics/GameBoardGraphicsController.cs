using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameBoardController))]
/// <summary>
/// Responsible for all the graphical tasks related to the GameBoard.
/// </summary>
public class GameBoardGraphicsController : MonoBehaviour
{
    [Tooltip("in units")]
    public int gameBoardResolution = 1;

    protected Dictionary<IHexagonNetNode<Bubble>, BubbleGraphics> bubblesGraphics = new Dictionary<IHexagonNetNode<Bubble>, BubbleGraphics>();
    protected GameBoard gameBoard;

    private void Awake()
    {
        // Setup events
        gameBoard = GetComponent<GameBoardController>().GameBoard;
        gameBoard.BubblesAddedEvent += HandleNewBubblesOnGameBoard;

        // Pre-heat BubbleGraphics
        BubbleGraphicsPool.Instance.AddGameObjects(50);

    }

    public void HandleNewBubblesOnGameBoard(object sender, BubbleEventArgs bubbleEventArgs)
    {
        Debug.Log($"GameBoardGraphicsController: About to handle {bubbleEventArgs.BubbleNodes.Count} bubbleNodes.");

        foreach (var bubbleNode in bubbleEventArgs.BubbleNodes)
        {
            SetupBubbleGraphics(bubbleNode);
        }
    }

    private void SetupBubbleGraphics(IHexagonNetNode<Bubble> bubbleNode)
    {
        if (bubbleNode.Value != null)
        {
            var bubbleGraphics = BubbleGraphicsPool.Instance.Get();
            bubbleGraphics.Bubble = bubbleNode.Value;
            bubbleGraphics.SyncGraphicsWithBubble();

            var bubbleGraphicsPosition = ComputeBubbleGraphicsPosition(bubbleNode.Position);
            bubbleGraphics.SetPosition(bubbleGraphicsPosition);

            bubbleGraphics.gameObject.SetActive(true);

            bubblesGraphics.Add(bubbleNode, bubbleGraphics);
        }
    }

    private Vector3 ComputeBubbleGraphicsPosition(Vector2Int indexOnGameBoard)
    {
        var position = transform.position;

        position.x += indexOnGameBoard.x * gameBoardResolution;
        position.y += indexOnGameBoard.y * gameBoardResolution;

        return position;
    }
}
