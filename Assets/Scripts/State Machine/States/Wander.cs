using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : IEnemyState, ITimer
{
    private float targetTime = 2.5f;
    private float timer = 2.5f;
    private int speed = 5;
    Transform transform;
    Rigidbody rb;
    Vector3 wantedPosition;
    Quaternion wantedRotation;
    public void Enter(EnemyStateMachine enemy)
    {
        transform = enemy.transform;
        rb = enemy.GetComponent<Rigidbody>();
    }

    public void Exit(EnemyStateMachine enemy)
    {

    }

    public void Update(EnemyStateMachine enemy) 
    {
        timer -= Time.deltaTime;
    }
    public void FixedUpdate(EnemyStateMachine enemy)
    {
        if (timer < 0)
        {
            wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * 180);
            rb.MoveRotation(wantedRotation);
            StartTimer();
        }
        else
        {
            wantedPosition = transform.position + transform.forward * Time.deltaTime * speed;
            rb.MovePosition(wantedPosition);
            
        }
    }
    public void StartTimer()
    {
        timer = targetTime;
    }
}
