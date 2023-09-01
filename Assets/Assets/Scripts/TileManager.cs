using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap interactableMap;
    public Tile hiddenIteractableTile;
    public Tile interactedTile;
    void Start()
    {
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            interactableMap.SetTile(position, hiddenIteractableTile);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }



    public bool IsIteractable(Vector3Int position)
    { 
        TileBase tile = interactableMap.GetTile(position);
        if(tile != null)
        {
            if(tile.name == "Interactable")
            {
                return true;
            }
        }
        return false;
    
    }


    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
    }
}
