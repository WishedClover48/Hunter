using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour, ITimer
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
     private Rigidbody playerRB;
    [SerializeField] private Rigidbody bullet;
    [SerializeField] public float TargetTime;
    [SerializeField] public GameObject myself;
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
    ShootingPattern Shooting = new ShootingPattern();

    private void Start()
    {
        playerRB = myself.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(timer < 0) 
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shooting.shoot = ShootingPattern.Shot.Straight;
                Shooting.UseShot(myself, bullet);
                StartTimer();
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Shooting.shoot = ShootingPattern.Shot.Parabolic;
                Shooting.UseShot(myself, bullet);
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

    public void StartTimer()
    {
        Timer = TargetTime;
    }
}
