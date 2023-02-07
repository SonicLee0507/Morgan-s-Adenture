using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    int currentPointIndex;

    float waitTime;
    public float startWaitTime;

    Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = patrolPoints[0].position;
        waitTime = startWaitTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);

        if (transform.position == patrolPoints[currentPointIndex].position)
        {
            anim.SetBool("IsRunning", false);
            if (waitTime <= 0)
            {
            if (currentPointIndex + 1 < patrolPoints.Length)
            {
                currentPointIndex++;
            }
            else
            {
                currentPointIndex = 0;
            }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }


        }
        else
        {
            anim.SetBool("IsRunning", true);
        }
    }
}
