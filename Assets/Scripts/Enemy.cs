using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.EnemySpawned(gameObject);
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
        {
            GameManager.Instance?.EnemyKilled(gameObject);
        }
    }
}
