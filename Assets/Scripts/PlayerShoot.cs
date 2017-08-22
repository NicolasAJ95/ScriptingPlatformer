using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private int actualBullets;
    [SerializeField]
    private bool isReloading;

    public int chargerSize = 8;
    public float reloadTime;
    public bool canShoot = true;
    public GameObject bulletPrefab;

    // Use this for initialization
    void Start () {
        isReloading = false;
        actualBullets = chargerSize;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input .GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var bullet = GameObject.Instantiate(bulletPrefab, transform.position, transform .rotation);
        var bulletRigidBody = bullet.GetComponent<Rigidbody>();


        bulletRigidBody.AddForce(transform.right * bulletSpeed, ForceMode.Impulse);
        actualBullets--;

        if (actualBullets == 0)
        {
            Debug.Log("Sin balas");
            canShoot = false;
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        actualBullets += chargerSize;
        canShoot = true;
        isReloading = false;
    }
}
