using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : IEnemyState, ITimer
{
    private float targetTime = 2.5f;
    private float timer = 2.5f;
    private int speed = 40;
    Transform transform;
    Rigidbody rb;
    Vector3 wantedPosition;
    Quaternion wantedRotation;
    public void Enter(Enemy enemy)
    {
        transform = enemy.transform;
        rb = enemy.GetComponent<Rigidbody>();
    }

    public void Exit(Enemy enemy)
    {

    }

    public void Update(Enemy enemy)
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
            timer -= Time.deltaTime;
        }
    }
    public void StartTimer()
    {
        timer = targetTime;
    }
}
