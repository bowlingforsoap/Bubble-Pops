using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Graphical representation of a Bubble.
/// </summary>
public class BubbleGraphics : MonoBehaviour, IGameObjectPooled<BubbleGraphics>
{
    public SpriteRenderer bubbleCenterRenderer;
    public Text bubbleValueText;

    public Bubble Bubble { get; set; }
    public GameObjectPool<BubbleGraphics> Pool { get; set; }

    public Color[] exponentColors;

    private void Start()
    {
    }

    public void SyncGraphicsWithBubble()
    {
        bubbleCenterRenderer.color = exponentColors[Bubble.Exponent - 1];
        bubbleValueText.text = Bubble.Value.ToString();
    }

    public void SetPosition(Vector3 bubbleGraphicsPosition)
    {
        transform.position = bubbleGraphicsPosition;
    }
}
