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

    public float maxhp;
    public float hp;
    public float healthUpgrade;
    public float healAmountPercent = .25f;

    public GameObject[] gun;


    [Header("Animations")]
    public Animator _anim;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();        
        hp=maxhp;
    }

    void Update(){

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

        AnimationStateChange();
        rotateController();


    }

    void AnimationStateChange(){ 
        // horizontal movement
        if(moveSpeed.x < 0){
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z);
        }else if(moveSpeed.x > 0){
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
        }
        if(moveSpeed.x < 0 || moveSpeed.x > 0){
            _anim.SetBool("isMovingHorizontal", true);
        }else{
            _anim.SetBool("isMovingHorizontal", false);
        }

        //vertical movement
        if(moveSpeed.y > 0){
            _anim.SetBool("isMovingUp", true);
        }else{
            _anim.SetBool("isMovingUp", false);
        }

        if(moveSpeed.y < 0){
            _anim.SetBool("isMovingDown", true);
        }else{
            _anim.SetBool("isMovingDown", false);
        }            
    }



    private void rotateController()
    {
	
    }

    public void Hurt(int damage)
    {
        hp-=damage;
        if(hp<=0)
            GameManager.Instance.Die();
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

    public void UpgradeFireRate()
    {
        if(GameManager.Instance.money>=10)
        {
            GameManager.Instance.money-=10;

            for(int i=0; i<gun.Length;i++)
            {
                gun[i].SendMessage("IncreaseFireRate");
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Mushroom"){
            if(hp > maxhp){
                hp += hp * healAmountPercent;
                if(hp >= maxhp){
                    hp = maxhp;
                }
            }
        }
    }

    public void UpgradeDamage()
    {
        if(GameManager.Instance.money>=10)
        {
            GameManager.Instance.money-=10;

            for(int i=0; i<gun.Length;i++)
            {
                gun[i].SendMessage("IncreaseDamage");
            }
        }
        
    }

    public void IncreaseMaxHP()
    {
        if(GameManager.Instance.money>=10)
        {
            GameManager.Instance.money-=10;
            maxhp+=healthUpgrade;
            hp+=healthUpgrade;
        }
        
    }
}
