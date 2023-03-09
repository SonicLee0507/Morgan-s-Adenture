using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] arrow;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public float minTimeBtwSpawns;
    public float decrease;
    // Start is called before the first frame update

    void Start()
    {
        
    }
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomArrow = arrow[Random.Range(0, arrow.Length)];
            Instantiate(randomArrow, randomSpawnPoint.position, Quaternion.AngleAxis(30,Vector3.forward));
            if(startTimeBtwSpawns> minTimeBtwSpawns)
            {
                startTimeBtwSpawns -= decrease;
            }
            timeBtwSpawns = startTimeBtwSpawns;
        } 
        else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
    }

}
