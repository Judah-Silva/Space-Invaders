using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 3;
    public delegate void EnemyDeath(int pointWorth);
    public static event EnemyDeath OnEnemyDeath;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      Destroy(collision.gameObject);
      
      OnEnemyDeath.Invoke(points);
      Destroy(gameObject);
    }
}
