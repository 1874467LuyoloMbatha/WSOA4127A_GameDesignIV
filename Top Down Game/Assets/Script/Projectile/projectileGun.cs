using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class projectileGun : MonoBehaviour
{
    //bullet//
    public GameObject bullet;

    //bullet force// 
    public float shootForce, upwardForce;

    //Gun Stats//
    public float timeBeweenSHooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold; // is the gun automatic. 

    int bulletsLeft, bulletsShot;
    //stopped @1:22//

    //Bools//
    bool shooting, readyToShoot, reloading;

    //Reference// 
    public Camera fpsCam;
    public Transform attackPoint;

    //Bug fixes
    public bool allowInvoke = true;

    private void Awake()
    {
        //make sure magazine is full//
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        //Checks if allowed to hold down button and take corresponding input//
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0); //Tap everytime you need to shoot.

        //Shooting//
        if (readyToShoot && shooting && bulletsLeft > 0) //2:45
        {
            //set bullets shot to 0 
            bulletsShot = 0;

            Shoot();

        
        } 
    }

    private void Shoot() 
    {
        readyToShoot = false;
        bulletsLeft--;
        bulletsShot++; 
    
    }






}
