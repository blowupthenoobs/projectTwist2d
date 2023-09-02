using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float maxmoveSpeed;
    public float deccelleration;
    public float accelleration;
    private Vector2 moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public int maxhp;
    public int hp;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp=maxhp;
    }


    void FixedUpdate()
    {
       moveAndRotate();
    }



    private void moveAndRotate() //does not rotate yet
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");


        moveInput.Normalize();


        Move();


        rb.velocity = moveSpeed * Time.fixedDeltaTime * 100;


        rotateController();


    }




    private void rotateController()
    {
	
    }

    public void Hurt(int damage)
    {
        hp-=damage;
        if(hp<=0)
            Debug.Log("You're dead");
    }


    private void Move()
    {
        if(moveInput.x==0)
        {
            if(rb.velocity.x<2 && rb.velocity.x>-2)
            {
                moveSpeed.x=0;
            }
            else if(rb.velocity.x>0)
            {
                moveSpeed.x-=deccelleration*10*Time.fixedDeltaTime;
            }
            else if(rb.velocity.x<0)
            {
                moveSpeed.x+=deccelleration*10*Time.fixedDeltaTime;
            }
        }


        if(moveInput.y==0)
        {
            if(rb.velocity.y<2 && rb.velocity.y>-2)
            {
                moveSpeed.y=0;
            }
            else if(rb.velocity.y>0)
            {
                moveSpeed.y-=deccelleration*10*Time.fixedDeltaTime;
            }
            else if(rb.velocity.y<0)
            {
                moveSpeed.y+=deccelleration*10*Time.fixedDeltaTime;
            }
        }


        {
            //Checking X
            if(rb.velocity.x>maxmoveSpeed)
            {
                if(moveSpeed.x>0)
                    moveInput.x=0;
               
                moveSpeed.x-=deccelleration*Time.fixedDeltaTime;
            }


            if(rb.velocity.x<-maxmoveSpeed)
            {
                if(moveSpeed.x<0)
                    moveInput.x=0;
               
                moveSpeed.x+=deccelleration*Time.fixedDeltaTime;
            }


            //Checking Y
            if(rb.velocity.y>maxmoveSpeed)
            {
                if(moveSpeed.y>0)
                    moveInput.y=0;
               
                moveSpeed.y-=deccelleration*Time.fixedDeltaTime;
            }


            if(rb.velocity.y<-maxmoveSpeed)
            {
                if(moveSpeed.y<0)
                    moveInput.y=0;
               
                moveSpeed.y+=deccelleration*Time.fixedDeltaTime;
            }  
           
        }


        moveSpeed+=moveInput*accelleration*Time.fixedDeltaTime;


        //X redirect speed bonus
        if(moveSpeed.x>0 && moveInput.x<0)
        {
            moveSpeed.x-=deccelleration;
        }
        else if(moveSpeed.x<0 && moveInput.x>0)
        {
            moveSpeed.x+=deccelleration;
        }


        //Y redirect speed bonus
        if(moveSpeed.y>0 && moveInput.y<0)
        {
            moveSpeed.y-=deccelleration;
        }
        else if(moveSpeed.y<0 && moveInput.y>0)
        {
            moveSpeed.y+=deccelleration;
        }
    }

    private void getMouseposition()
    {

    }
}
