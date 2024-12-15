using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemyState
{
    void Enter(EnemyStateMachine enemy);
    void Update(EnemyStateMachine enemy);
    void FixedUpdate(EnemyStateMachine enemy);

    void Exit(EnemyStateMachine enemy);
}