using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour {

    public int tileX, tileY;
    public TileMap map;

    private void OnMouseUp()
    {
        Debug.Log("Click");

        map.MoveSelectedUnitTo(tileX, tileY);
    }
}
