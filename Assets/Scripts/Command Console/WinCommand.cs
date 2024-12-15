using System.Collections.Generic;
using UnityEngine;

internal class WinCommand : ICommand
{
    public void Execute()
    {
        foreach (GameObject enemy in GameManager.Instance.enemyList) 
        {
            GameObject.Destroy(enemy);
        }
    }
}