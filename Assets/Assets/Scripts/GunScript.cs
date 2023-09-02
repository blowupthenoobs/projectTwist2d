using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firingPosition;
    public float cooldown;
    private float currentCooldown;

    //Bullet Stats
    public int damage;
    public float bulletLife;
    public float bulletSpeed;

    public weaponHandler currentGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = currentGun.gunSpirte;
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
        if(Input.GetAxisRaw("Fire1")!=0)
            Fire();
    }

    private void Fire()
    {
        if (currentGun.canShoot)
        {
            if (currentCooldown >= cooldown)
            {
                GameObject projectile = Instantiate(bullet, firingPosition.transform.position, transform.rotation);
                projectile.GetComponent<PlayerBulletScript>().SetStats(damage, bulletLife, bulletSpeed);
                currentCooldown = 0;
            }
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
}