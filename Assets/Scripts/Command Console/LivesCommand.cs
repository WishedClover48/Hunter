using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCommand : ICommand
{
    private GameObject _object;

    public LivesCommand(GameObject player)
    {
        _object = player;
    }

    public void Execute()
    {
        _object.GetComponent<PlayerLives>().RefreshHealth();
    }

}
