using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TileManager : MonoBehaviour
{
    public Tilemap interactableMap;
    public Tile hiddenIteractableTile;
    public Tile interactedTile;
    public Tile potentiolTile;
    public Grid grid;
    Vector3Int cellPosition;
    bool tileConfirmed = false;
    bool isInteracting = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetInteracted((Vector3Int)cellPosition);
                tileConfirmed = true;
                isInteracting=false;
            }
        }
    }



    public bool IsIteractable(Vector3Int position)
    { 
        TileBase tile = interactableMap.GetTile(position);
        if(tile != null)
        {
            if(tile.name == "Mound_0")
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


    public void SetInteractedHidden(Vector3Int position)
    {
        interactableMap.SetTile(position, hiddenIteractableTile);
    }

    public void SetInteractedPotential(Vector3Int position)
    {
        interactableMap.SetTile(position, potentiolTile);
    }

    private void OnMouseEnter()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // get the collision point of the ray with the z = 0 plane
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        cellPosition = grid.WorldToCell(worldPoint);
        if (IsIteractable(cellPosition))
        {
            isInteracting = true;
           SetInteractedPotential((Vector3Int)cellPosition);
            
        }
    }
    private void OnMouseExit()
    {
        if (!tileConfirmed && interactableMap.GetTile(cellPosition).name != "PlantStage1")
        {
            SetInteractedHidden((Vector3Int)cellPosition);


        }
        else
        {
            tileConfirmed = false;
        }

    }
}
