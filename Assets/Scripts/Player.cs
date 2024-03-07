using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;

  void Start()
  {
    Enemy.OnEnemyDeath  += EnemyOnOnEnemyDeath;

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
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }
}
