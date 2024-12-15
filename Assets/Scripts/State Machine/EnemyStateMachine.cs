using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private IEnemyState _currentState;
    void Start()
    {
        SetState(new Wander());
    }
    void Update()
    {
        _currentState?.Update(this);
    }
    private void FixedUpdate()
    {
        _currentState.FixedUpdate(this);
    }
    public void SetState(IEnemyState newState)
    {
        if (newState == null)
        {
            Debug.LogWarning("Attempted to set a null state!");
            return;
        }
        if (_currentState == newState) return;
        Debug.Log($"Transitioning from {_currentState} to {newState}");
        _currentState?.Exit(this);
        _currentState = newState;
        _currentState.Enter(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetState(new Attacking(other.gameObject));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetState(new Wander());
        }
    }
}
