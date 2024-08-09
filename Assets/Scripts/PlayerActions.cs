using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour, ITimer
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] public float TargetTime;
    public float Timer
    {
        get
        {
            return timer;
        }
        set
        {
            timer = value;
        }
    }
    private float timer = 0f;
    Vector3 wantedPosition;
    Quaternion wantedRotation;

    private void Update()
    {
        if(timer < 0) 
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StraightBullet();
                StartTimer();
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                CurveBullet();
                StartTimer();
            }
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        //Controls the movement
        if (timer < 0) 
        { 
            wantedPosition = transform.position + transform.forward * Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
            playerRB.MovePosition(wantedPosition);
        }

        //Controls the rotation
        if (Input.GetAxisRaw("Vertical") <= 0.4 && Input.GetAxisRaw("Vertical") >= -0.4 && timer < 0) 
        { 
            wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime );
        }
        else if(timer < 0)
        {
            wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * Input.GetAxisRaw("Horizontal") * (rotationSpeed/2) * Time.deltaTime);
        }
        else
        {
            wantedRotation = transform.rotation;
        }
        playerRB.MoveRotation(wantedRotation);
    }

    //Creates a bullet and sends it straight ahead.
    void StraightBullet()
    {
        Rigidbody bulletClone = Instantiate(bullet, transform.position + (transform.rotation * new Vector3(0, 2, 3)), transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    }

    //Creates a bullet and adds an angle to its velocity, it also enables its gravity.
    void CurveBullet()
    {
        Rigidbody bulletClone = Instantiate(bullet, transform.position + (transform.rotation * new Vector3(0, 2, 3)), transform.rotation);
        bulletClone.useGravity = true;
        bulletClone.velocity = new Vector3(0, 15, 0) + (transform.forward/8) * bulletSpeed;
    }

    public void StartTimer()
    {
        Timer = TargetTime;
    }

}
