using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //Gun control variables
    public int damage;
    public float timeBtwnShooting, range, reloadTime, timeBtwnShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //Bools
    bool shooting, readyToShoot, reloading;
    public GameObject bulletHole;

    //Reference
    public Transform combatLookAt;
    public RaycastHit rayHit;
    public LayerMask whatIsPlayer;

    //Attack bool
    public bool attack;

    private void Start()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        attack = false;
        //Change text as well

    }

    // Update is called once per frame
    void Update()
    {

        if (attack)
        {
            shooting = true;

            if (bulletsLeft < magazineSize && !reloading)
                Reload();

            if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
            {
                bulletsShot = bulletsPerTap;
                Shoot();

            }


        }

        //Shooting inputs
       // myInput();
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

        //Raycasts #shootingModeCam.transform.position, shootingModeCam.transform.forward, combatLookAt.forward 
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, range, whatIsPlayer))
        {



            //Debug.Log(rayHit.collider.name);


            if (rayHit.collider.CompareTag("Player"))
            {
                Debug.Log(rayHit.collider.name);
                rayHit.collider.GetComponentInParent<ModifiedPlayerMovement>().TakeDamage(damage);
            }
        }



        //Graphics
        Instantiate(bulletHole, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.Euler(0, 180, 0));

        bulletsShot--;

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
        reloading = false;

    }
}
