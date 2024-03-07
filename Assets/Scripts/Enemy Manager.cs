using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject grid;
    public GameObject lowAlien;
    public GameObject midAlien;
    public GameObject highAlien;
    public GameObject mothership;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = new Vector3(0, 0, 0);
        for (float i = -5; i <= 5; ++i)
        {
            offset = new Vector3(i, 0, 0);
            Instantiate(highAlien, grid.transform.position + offset, Quaternion.identity, grid.transform);
            offset = new Vector3(i, -1, 0);
            Instantiate(midAlien, grid.transform.position + offset, Quaternion.identity, grid.transform);
            offset = new Vector3(i, -2, 0);
            Instantiate(midAlien, grid.transform.position + offset, Quaternion.identity, grid.transform);
            offset = new Vector3(i, -3, 0);
            Instantiate(lowAlien, grid.transform.position + offset, Quaternion.identity, grid.transform);
            offset = new Vector3(i, -4, 0);
            Instantiate(lowAlien, grid.transform.position + offset, Quaternion.identity, grid.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
