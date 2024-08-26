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
    [SerializeField] public GameObject myself;
    private Rigidbody playerRB;
    private bool usingMainShot;
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
    IShot mainShotMode;
    IShot backupShotMode;
    IShot auxShotMode;

    private void Start()
    {
        mainShotMode = new StraightBullet();
        backupShotMode = new CurveBullet();
        usingMainShot = true;
        gameManager = GameManager.Instance;
        playerRB = myself.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(timer < 0) 
        { 
            if (Input.GetKeyDown(KeyCode.Space) && gameManager.GetState() == GameManager.gameState.MainWorld)
            {
                Shooting.UseShot(myself, bullet, mainShotMode);
                StartTimer();
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                usingMainShot = !usingMainShot;
                auxShotMode = mainShotMode;
                mainShotMode = backupShotMode;
                backupShotMode = auxShotMode;

            }
        }
        else
        {
            Timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameManager.SwitchState(GameManager.gameState.BattleGamemode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameManager.SwitchState(GameManager.gameState.MainWorld);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameManager.SwitchState(GameManager.gameState.MenuPrincipal);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gameManager.SwitchState(GameManager.gameState.Pause);
        }
    }
    void FixedUpdate()
    {
        //Controls the movement
        if (timer < 0 && gameManager.GetState() == GameManager.gameState.MainWorld) 
        { 
            wantedPosition = transform.position + transform.forward * Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
            playerRB.MovePosition(wantedPosition);
        }

        //Controls the rotation
        if (Input.GetAxisRaw("Vertical") <= 0.4 && Input.GetAxisRaw("Vertical") >= -0.4 && timer < 0 && gameManager.GetState() == GameManager.gameState.MainWorld) 
        { 
            wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime );
        }
        else if(timer < 0 && gameManager.GetState() == GameManager.gameState.MainWorld)
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
