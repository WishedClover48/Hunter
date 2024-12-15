using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : IEnemyState , ITimer
{
    private float targetTime = 3f;
    private float timer = 1.5f;
    private Rigidbody rb;
    private GameObject target;

    public Attacking(GameObject player)
    {
        target = player; 
    }

    public void Enter(EnemyStateMachine enemy)
    {
        rb = enemy.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }

    public void Exit(EnemyStateMachine enemy)
    {
        rb.constraints -= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }
    public void Update(EnemyStateMachine enemy)
    {
        timer -= Time.deltaTime;
    }
    public void FixedUpdate(EnemyStateMachine enemy)
    {
        if (timer < 0)
        {
            ServiceLocator.Instance.GetService<ShootingPattern>().UseShot(
                enemy.transform,
                ServiceLocator.Instance.GetService<StraightPatternFactory>().Create());
            StartTimer();
        }
        else
        {
            Vector3 relativePos = target.transform.position - rb.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            rb.rotation = rotation; 
        }
    }

    public void StartTimer()
    {
        timer = targetTime;
    }
}
