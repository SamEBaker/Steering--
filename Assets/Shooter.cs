using System.Collections;
using UnityEngine;
using System;
using UnityEngine.TextCore.Text;

public class Shooter : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject Bullet;
    public float velocity = 30f;
    public bool canShoot = true;
    public float bulletWait = 1.5f;
    public Rigidbody rb;
    public float rotSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Shoot(pos1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Shoot(pos2);
        }
        else if( Input.GetKeyDown(KeyCode.Alpha3))
        {
            Shoot(pos3);
        }
    }
    public void Shoot(GameObject pos)
    {
        if (canShoot)
        {

            GameObject bullet = Instantiate(Bullet, pos.transform.position, Quaternion.identity);
            rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(pos.transform.forward * velocity, ForceMode.VelocityChange);
            StartCoroutine(bulletWaitTimer());
        }
    }
    IEnumerator bulletWaitTimer()
    {
        yield return new WaitForSeconds(bulletWait);
        canShoot = true;
    }
}
