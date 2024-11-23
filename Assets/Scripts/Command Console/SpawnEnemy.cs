using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : ICommand
{
    private GameObject _object;
    private GameObject _player;

    public SpawnEnemy(GameObject enemy, GameObject player)
    {
        _object = enemy;
        _player = player;
    }

    public void Execute()
    {
        Vector3 spawnPosition = _player.transform.position + _player.transform.forward * 50;
        GameObject.Instantiate(_object, spawnPosition, _player.transform.rotation);
    }
}
