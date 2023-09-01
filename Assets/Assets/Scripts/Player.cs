using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    // public GameObject gameManager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       moveAndRotate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, (0));
            if (gameManager.TileManager.IsIteractable(position)) {
                
                
                print("Hello"); 
                gameManager.TileManager.SetInteracted(position);
            
            } 
        }
    }




    private void moveAndRotate() //does not rotate yet
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        rb.velocity = moveInput * moveSpeed * Time.deltaTime * 100;


        rotateController();
	  if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, (0));
            if (gameManager.TileManager.IsIteractable(position)) {
               
               
                print("Hello");
                gameManager.TileManager.SetInteracted(position);
           
            }
        }


    }


    private void rotateController() 
    {

    }
}
