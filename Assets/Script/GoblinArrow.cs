using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArrow : MonoBehaviour
{
    public Transform[] garrowspawnPoints;
    public GameObject[] garrow;
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
            Transform randomGArrowSpawnPoint = garrowspawnPoints[Random.Range(0, garrowspawnPoints.Length)];
            GameObject randomGArrow = garrow[Random.Range(0, garrow.Length)];
            Instantiate(randomGArrow, randomGArrowSpawnPoint.position, Quaternion.AngleAxis(30,Vector3.forward));
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
