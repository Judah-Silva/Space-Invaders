using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
  
    public delegate void ProjectileDestroy();
    public static event ProjectileDestroy OnProjectileDestroy;
  

    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
        myRigidbody2D.velocity = Vector2.down * speed; 
        Debug.Log("Wwweeeeee");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnProjectileDestroy.Invoke();
        }
    }
}
