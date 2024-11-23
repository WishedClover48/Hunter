using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour, ITimer
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Rigidbody bullet;
    [SerializeField] public float TargetTime;
    [SerializeField] private Rigidbody playerRB;
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
    private GameManager gameManager;
    Vector3 wantedPosition;
    Quaternion wantedRotation;
    ShootingPattern Shooting = new ShootingPattern();
    BulletFactory bulletFactory = new BulletFactory();
    IShot mainShotMode;
    IShot backupShotMode;
    IShot auxShotMode;

    private void Start()
    {
        mainShotMode = bulletFactory.CreateBullet(BulletFactory.BulletType.StraightBullet);
        backupShotMode = bulletFactory.CreateBullet(BulletFactory.BulletType.CurveBullet);
        gameManager = GameManager.Instance;
    }
    private void Update()
    {
        if(timer < 0) 
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shooting.UseShot(transform, bullet, mainShotMode);
                StartTimer();
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                auxShotMode = mainShotMode;
                mainShotMode = backupShotMode;
                backupShotMode = auxShotMode;

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
