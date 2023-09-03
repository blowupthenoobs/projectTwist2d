using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScript : MonoBehaviour
{
    public GameObject camera;
    public GameObject bullet;
    public GameObject firingPosition;
    public float cooldown;
    private float currentCooldown;

    //Bullet Stats
    public int damage;
    public float bulletLife;
    public float bulletSpeed;

    //Upgrade Variables
    public int damageIncrease;
    public float cooldownUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        FaceMouse();
        CheckInputs();
        Reload();
    }

    private void CheckInputs()
    {
        if(Input.GetMouseButtonDown(0))
            Scope();
        if(Input.GetMouseButtonUp(0))
            Fire();
    }

    private void Scope()
    {
        camera.GetComponent<CameraControler>().Scoping=true;
    }

    private void Fire()
    {
        camera.GetComponent<CameraControler>().Scoping=false;

        if(currentCooldown>=cooldown)
        {
            GameObject projectile = Instantiate(bullet, firingPosition.transform.position, transform.rotation);
            projectile.GetComponent<PlayerBulletScript>().SetStats(damage, bulletLife, bulletSpeed);
            currentCooldown=0;
        }
    }

    private void Reload()
    {
        if(currentCooldown<cooldown)
            currentCooldown+=Time.fixedDeltaTime;
    }

    private void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition=Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }

    public void IncreaseFireRate()
    {
        cooldown-=cooldownUpgrade;
    }

    public void IncreaseDamage()
    {
        damage+=damageIncrease;
    }
}
