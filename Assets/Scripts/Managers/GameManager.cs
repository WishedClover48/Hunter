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

    public enum gameState { MainWorld, MenuPrincipal, Pause, BattleGamemode}

    private gameState state = gameState.MainWorld;

    public gameState GetState()
    {
        return state;
    }
    public void SwitchState(gameState newState)
    {
        state = newState;
    }

}
