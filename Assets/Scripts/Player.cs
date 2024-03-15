using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public float speed = 10;
  public Transform shottingOffset;
  
  private EnemyManager _enemyManager;
  private bool fired;
  private bool allowMove = true;

  void Start()
  {
    _enemyManager = GameObject.Find("Enemy Manager").GetComponent<EnemyManager>();
    ResetSprite();
    
    Enemy.OnEnemyDeath  += EnemyOnOnEnemyDeath;
    EnemyManager.OnGameOver += EnemyManagerOnOnGameOver;
    Bullet.OnBulletDestroy += BulletOnOnBulletDestroy;
    EnemyProjectile.OnProjectileDestroy += EnemyProjectileOnOnProjectileDestroy;
  }

  private void EnemyManagerOnOnGameOver()
  {
    allowMove = false;
  }

  private void EnemyProjectileOnOnProjectileDestroy()
  {
    Animator animator = GetComponent<Animator>();
    animator.SetBool("Destroy", true);
    _enemyManager.Invoke("EndGame", 1f);
  }

  void ResetSprite()
  {
    Animator animator = GetComponent<Animator>();
    animator.SetBool("Destroy", false);
  }

  void BulletOnOnBulletDestroy()
  {
    fired = false;
  }

  private void OnDestroy()
  {
    Enemy.OnEnemyDeath -= EnemyOnOnEnemyDeath;
  }

  void EnemyOnOnEnemyDeath(int pointWorth)
  {
    Debug.Log($"Player destroyed enemy and received {pointWorth} points.");
  }
  // Update is called once per frame
  void Update()
  {
    if (allowMove)
    {
      if (Input.GetKeyDown(KeyCode.Space) && !fired)
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);
        fired = true;
      }
      float horizontalMovement = Input.GetAxis("Horizontal");

      transform.position += horizontalMovement * speed * Time.deltaTime * Vector3.right;
    }
    }
}
