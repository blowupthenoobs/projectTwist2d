using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewBehaviourScript : MonoBehaviour
{
    public Tile plantVegUIMarker;
    public GameManager gameManager;
    TileManager tileManager;
    void Start()
    {
        tileManager = gameManager.GetComponent<TileManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        print("Here");
        tileManager.SetInteracted(new Vector3Int((int)Input.mousePosition.x,(int)Input.mousePosition.y,0));
    }
}
