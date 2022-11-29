using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    //Gun control variables
    public int damage;
    public float timeBtwnShooting, range, reloadTime, timeBtwnShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //Bools
    bool shooting, readyToShoot, reloading;

    //Text objects
    public Text BulletsText;

    //Graphics
    public GameObject muzzleFlash, bulletHole, cube;

    

    //Reference
    public Camera shootingModeCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    private void Start()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        //Change text as well
        BulletsText.text = bulletsLeft + "/" + magazineSize;

    }

    // Update is called once per frame
    void Update()
    {
        //Shooting inputs
        myInput();
    }

    private void myInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKey(KeyCode.Mouse0);


        //If bullets less than magazine size, reload
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shooting -- not reloading and ready to shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();

        }


    }

    private void Shoot()
    {
        readyToShoot = false;
        bulletsLeft--;

        //Raycasts #shootingModeCam.transform.position, shootingModeCam.transform.forward,
        if (Physics.Raycast(shootingModeCam.transform.position, shootingModeCam.transform.forward, out rayHit, range))
        {

        
        
            Debug.Log(rayHit.collider.name);
            

           if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
        }



        //Graphics
        Instantiate(cube, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.Euler(0, 180, 0));
        //blah
        bulletsShot--;
        BulletsText.text = bulletsLeft + "/" + magazineSize;

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBtwnShots);



        Invoke("ResetShot", timeBtwnShooting);
    }

    private void ResetShot()
    {
        readyToShoot = true;

    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        reloading = true;
        bulletsLeft = magazineSize;
        BulletsText.text = bulletsLeft + "/" + magazineSize;
        reloading = false;

    }
}
