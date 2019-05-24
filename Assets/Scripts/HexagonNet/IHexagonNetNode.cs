using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHexagonNetNode
{
    Vector2Int? Position { get; set; }
    IHexagonNetNode[] Neighbours { get; }
    object HexagonNet { get; }
}
