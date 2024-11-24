using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Gamemanager is NULL");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    private int enemyCount = 0;
    public enum gameState { Unpause, Pause}

    private gameState state = gameState.Unpause;

    public void EnemyKilled()
    {
        enemyCount--;
        if (enemyCount <= 0) 
        {
            SwitchState(gameState.Unpause);
            MySceneManager.Instance.ChangeScene("Victory");
        }
    }

    public void EnemySpawned()
    {
        enemyCount++;
    }
    public void PlayerKilled()
    {
        enemyCount = 0;
        Debug.Log("The player was killed");
        SwitchState(gameState.Unpause);
        MySceneManager.Instance.ChangeScene("Defeat");
    }
    public gameState GetState()
    {
        return state;
    }
    public void SwitchState(gameState newState)
    {
        state = newState;
        if (newState == gameState.Pause) 
        {
            Time.timeScale = 0f;
        }
        else if(newState == gameState.Unpause)
        {
            Time.timeScale = 1f;
        }
    }
}
