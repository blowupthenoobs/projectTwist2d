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
    public Tile stage2;
    public Tile stage3;
    public Tile potentiolTile;
    public Grid grid;
    Vector3Int cellPosition;
    bool tileConfirmed = false;
    bool isInteracting = false;

    public List<int> GridData = new List<int>(); //First is the position index for GridLocations, then the days in current stage, and last is stage number
    public List<Vector3Int> GridLocations = new List<Vector3Int>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if(Input.GetMouseButtonDown(0) && MoonTimer.Instance.isday)
            {
                if (isInteracting  && GameManager.Instance.seeds>0)
                {
                    GameManager.Instance.seeds-=1;
                    SetInteracted((Vector3Int)cellPosition);
                    tileConfirmed = true;
                    isInteracting=false;
                }
                else if(IsFlower(cellPosition))
                {
                    GameManager.Instance.GainMoney();
                    SetInteracted((Vector3Int)cellPosition);
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

    public bool IsFlower(Vector3Int position)
    { 
        TileBase tile = interactableMap.GetTile(position);
        if(tile != null)
        {
            if(tile.name == "PlantStage3")
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
        if(MoonTimer.Instance.isday)
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
        
    }
    private void OnMouseExit()
    {
        if(MoonTimer.Instance.isday)
        {
            if (!tileConfirmed && interactableMap.GetTile(cellPosition).name != "PlantStage1" && interactableMap.GetTile(cellPosition).name != "PlantStage2" && interactableMap.GetTile(cellPosition).name != "PlantStage3")
            {
                SetInteractedHidden((Vector3Int)cellPosition);
            }
            else
            {
            tileConfirmed = false;

            GridLocations.Add(cellPosition);

            GridData.Add(GridLocations.IndexOf(cellPosition));
            GridData.Add(0);
            GridData.Add(1);
            }
        }
        

    }

    public void NewDay()
    {
        for(int i=0; i<GridLocations.Count; i++)
        {
            GridData[i+1]++;

            if(GridData[i+2]==1 && GridData[i+1]==2)
            {
                GridData[i+2]+=1;
            }
            else if(GridData[i+2]==2 && GridData[i+1]==5)
            {
                GridData[i+2]+=1;
            }

            if(GridData[i+2]==2)
            {
                interactableMap.SetTile(GridLocations[i], stage2);
            }
            else if(GridData[i+2]==3)
            {
                interactableMap.SetTile(GridLocations[i], stage3);
            }
        }
    }
}
