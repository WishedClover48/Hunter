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

    public enum gameState { Unpause, Pause}

    private gameState state = gameState.Unpause;

    public List<GameObject> enemyList = new List<GameObject>();
    public void EnemySpawned(GameObject Enemy)
    {
        enemyList.Add(Enemy);
    }
    public void EnemyKilled(GameObject Enemy)
    {
        enemyList.Remove(Enemy);
        if (enemyList.Count <= 0) 
        {
            SwitchState(gameState.Unpause);
            MySceneManager.Instance.ChangeScene("Victory");
        }
    }
    public void PlayerKilled()
    {
        enemyList.Clear();
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
