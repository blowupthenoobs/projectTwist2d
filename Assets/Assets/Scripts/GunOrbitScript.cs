using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOrbitScript : MonoBehaviour
{
    public GameObject NormalGun;
    public GameObject ShotGun;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FaceMouse();
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchWeapons();
        }
    }

    private void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition=Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }

    private void SwitchWeapons()
    {
        if(NormalGun.activeInHierarchy)
        {
            NormalGun.SetActive(false);
            ShotGun.SetActive(true);
        }
        else if(ShotGun.activeInHierarchy)
        {
            NormalGun.SetActive(true);
            ShotGun.SetActive(false);
        }
    }
}
