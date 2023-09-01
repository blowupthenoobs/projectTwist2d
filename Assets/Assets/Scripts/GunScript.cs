using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firingPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
        CheckInputs();
    }

    private void CheckInputs()
    {
        if(Input.GetAxisRaw("Fire1")!=0)
            Fire();
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(bullet, firingPosition.transform.position, transform.rotation);
    }

    private void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition=Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
