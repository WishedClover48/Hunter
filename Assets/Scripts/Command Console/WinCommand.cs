using System.Collections.Generic;
using UnityEngine;

internal class WinCommand : ICommand
{
    public void Execute()
    {
        GameObject[] enemies =  GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) 
        {
            GameObject.Destroy(enemy);
        }
    }
}