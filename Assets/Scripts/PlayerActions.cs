using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private float bulletSpeed;
    Vector3 wantedPosition;
    Quaternion wantedRotation;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StraightBullet();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CurveBullet();
        }
    }
    void FixedUpdate()
    {
        //Controls the movement
        wantedPosition = transform.position + transform.forward * Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        playerRB.MovePosition(wantedPosition);

        //Controls the rotation
        if(Input.GetAxisRaw("Vertical") <= 0.4 && (Input.GetAxisRaw("Vertical") >= -0.4)) 
        { 
            wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime );
        }
        else
        {
            wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * Input.GetAxisRaw("Horizontal") * (rotationSpeed/2) * Time.deltaTime);
        }
        playerRB.MoveRotation(wantedRotation);
    }

    void StraightBullet()
    {
        Rigidbody bulletClone = Instantiate(bullet, transform.position + (transform.rotation * new Vector3(0, 2, 6)), transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    }
    //Adds gravity to the bullet and adds curvature to its velocity
    void CurveBullet()
    {
        Rigidbody bulletClone = Instantiate(bullet, transform.position + (transform.rotation * new Vector3(0, 2, 6)), transform.rotation);
        bulletClone.useGravity = true;
        bulletClone.velocity = new Vector3(0, 15, 0) + (transform.forward/8) * bulletSpeed;
    }

}
