using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 3;
    public delegate void EnemyDeath(int pointWorth);
    public static event EnemyDeath OnEnemyDeath;

    public delegate void HitLeftWall();

    public delegate void HitRightWall();
    public static event HitLeftWall OnHitLeftWall;
    public static event HitRightWall OnHitRightWall;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Ouch!");
            OnEnemyDeath.Invoke(points);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Left Wall"))
        {
            Debug.Log("Hit wall");
            OnHitLeftWall.Invoke();
        } else if (collision.gameObject.CompareTag("Right Wall"))
        {
            Debug.Log("Hit wall");
            OnHitRightWall.Invoke();
        }

    }
}
