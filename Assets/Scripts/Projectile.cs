using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
{
    //bullet
    public GameObject bullet;
    //bullet force
    public float shootForce, upwardForce;

    //Gun stats 
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //booleans
    bool shooting, readyToShoot, reloading;

    //Reference
    //
    public Camera fpsCam;
    public Transform attackPoint;


    //Graphics 
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;


    //bugfixing 
    public bool allowInvoke = true;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();


        if(ammunitionDisplay!=null)
        {
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + "/" + magazineSize / bulletsPerTap);
        }
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R)&& bulletsLeft < magazineSize && !reloading )Reload() ;
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        if(readyToShoot && shooting && !reloading && bulletsLeft > 0 )
        {
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75); // far away point from the player 
        }

        // Calculate direction from attackpoint to targetpoint 
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        // Calculate spread 
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        // Spawn the bullet 
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithoutSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        // Destroy the bullet after a set time (e.g., 5 seconds)
        Destroy(currentBullet, 5f);

        if (muzzleFlash != null)
        {
            GameObject flash = Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
            Destroy(flash, 1f); // Destroy muzzle flash after a short time
        }

        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
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
