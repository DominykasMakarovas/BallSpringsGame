using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int level;
    [SerializeField] public Enemy[] enemies;
    [SerializeField] private GameObject enemyPrefab;
    
    [Serializable]
    public struct Enemy
    {
        public int health;
        public int damage;
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        SortByHealth();
        int rows = 3;

        
        for (int y = 0; y < rows; y++) {
            for (int x = -y; x <= y; x++)
            {
                Instantiate(enemyPrefab, new Vector3(x, 0, y), Quaternion.identity);
            }
        }
    }

    public void SortByHealth()
    {
        Array.Sort<Enemy>(enemies, new Comparison<Enemy>(
            ((enemy, enemy1) => enemy1.health.CompareTo(enemy.health)))
        );
        
        foreach (var value in enemies)
        {
            Debug.Log(value.ToString());
        }
    }
}
