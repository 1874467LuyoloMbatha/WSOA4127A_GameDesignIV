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
     

    //Graphics//
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

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

        //Set ammo display//
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);

    }

    private void MyInput()
    {
        //Checks if allowed to hold down button and take corresponding input//
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0); //Tap everytime you need to shoot.

        //Reloading//
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload(); 

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

        //Find the exact hit position(FPS/Dont need for this game)//
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//A ray through middle of screen.
        RaycastHit hit;

        //Check if ray hits something//
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); // a point far away from the player

        //Calculate direction from attackPoint to targetPoint//
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate Spread//
        float xSpread = Random.Range(-spread, spread);
        float ySpread = Random.Range(-spread, spread);

        //Calculate new Direction with spread//
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(xSpread,ySpread,0);

        //Instantiate Bullet// 
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        //Rotate bullet to shoot direction//
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullets// Stopped @5:18
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse); /// upward force is only for boncing grenades

        //Instantiate muzzle flash//
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity); 
        //STOPPED @7:50

        
        bulletsLeft--; //count down
        bulletsShot++; //count up

        //Invoke resetShot function//
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBeweenSHooting);
            allowInvoke = false;
        }

        //If more than one bulletsPerTap make sure to repeast shoot function(i.e shotgun)
        if (bulletsShot < bulletsPerTap)
            Invoke("Shoot",timeBetweenShots);
        //Stopped @6:15//

    }
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true; 
    }

    private void Reload() 
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); 
    }

    private void ReloadFinished() 
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
