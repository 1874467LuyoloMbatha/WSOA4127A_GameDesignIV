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
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot; 
    //stopped @1:22//

    
    

   
}
