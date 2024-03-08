using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public GameObject grid;
    public GameObject lowAlien;
    public GameObject midAlien;
    public GameObject highAlien;
    public GameObject mothership;
    public GameObject enemyProjectile;
    public double delay = 300;
    public double alienCount = 55;

    private int _frameCount = 0;
    private bool _direction = true;
    private bool _animate = false;
    private bool _down = false;
    private int _shootCount;
    private int _shootCounter = 0;
    private PointManager _pointManager;
    private List<Animator> _animators = new List<Animator>();
    
    // Start is called before the first frame update
    void Start()
    {
        SetupGame();
        _pointManager = GameObject.Find("Point Manager").GetComponent<PointManager>();
        
        Enemy.OnHitRightWall += EnemyOnOnHitRightWall;
        Enemy.OnHitLeftWall += EnemyOnOnHitLeftWall;
        Enemy.OnEnemyDeath += EnemyOnOnEnemyDeath;
        
        _shootCount = Random.Range(0, 2000);
    }

    private void Update()
    {
        Debug.Log(delay);
        if (_frameCount % (int)delay == 0)
        {
            move();
            _frameCount = 0;
        }

        _frameCount++;
        if (alienCount == 0)
        {
            RestartGame();
        }

        if (_shootCounter % _shootCount == 0)
        {
            Shoot();
            _shootCount = Random.Range(0, 2000);
            _shootCounter = 0;
        }

        _shootCounter++;
    }
        
    void EnemyOnOnEnemyDeath(int pointworth)
    {
        alienCount--;
        delay = Math.Ceiling(450 * (alienCount / 55));
        if (delay < 50) delay = 50;
    }
    
    void EnemyOnOnHitLeftWall()
    {
        _direction = true;
        _down = true;
    }

    void EnemyOnOnHitRightWall()
    {
        _direction = false;
        _down = true;
    }

    void move()
    {
        if (_down)
        {
            grid.transform.position += new Vector3(0, -0.35f, 0);
            _down = false;
        }
        else if (_direction)
        {
            grid.transform.position += new Vector3(0.25f, 0, 0);
        }
        else
        {
            grid.transform.position += new Vector3(-0.25f, 0, 0);
        }

        foreach (var animator in _animators)
        {
            if (animator.Equals(null)) continue;
            animator.SetBool("Switch", _animate);
        }

        _animate = !_animate;
    }

    void Shoot()
    {
        Debug.Log("Enemy fired!");
        int alien = (int)Random.Range(0, (int)alienCount - 1);
        int i = 0;
        foreach (Transform child in grid.transform)
        {
            if (i == alien)
            {
                Instantiate(enemyProjectile, child.transform.position, Quaternion.identity);
                break;
            }

            i++;
        }
        
    }

    void SetupGame()
    {
        grid.transform.position = new Vector3(0, 3.75f, 0);
        Vector3 offset = new Vector3(0, 0, 0);
        Vector3 pos = grid.transform.position;
        for (float i = -5; i <= 5; ++i)
        {
            offset = new Vector3(i, 0, 0);
            Instantiate(highAlien, pos + offset, Quaternion.identity, grid.transform);
            offset = new Vector3(i, -1, 0);
            Instantiate(midAlien, pos + offset, Quaternion.identity, grid.transform);
            offset = new Vector3(i, -2, 0);
            Instantiate(midAlien, pos + offset, Quaternion.identity, grid.transform);
            offset = new Vector3(i, -3, 0);
            Instantiate(lowAlien, pos + offset, Quaternion.identity, grid.transform);
            offset = new Vector3(i, -4, 0);
            Instantiate(lowAlien, pos + offset, Quaternion.identity, grid.transform);
        }
        
        _animators.Clear();
        foreach (Transform child in grid.transform)
        {
            Animator animator = child.GetComponent<Animator>();
            _animators.Add(animator);
        }

        delay = 450;
        alienCount = 55;
        _animate = true;
    }

    public void RestartGame()
    {
        SetupGame();
        _pointManager.ResetScore();
    }
}
