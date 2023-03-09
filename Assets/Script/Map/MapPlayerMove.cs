using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerMove : MonoBehaviour
{
    public int movespeed = 10;
    public Transform player;
    private Vector3 endpos, startpos;
    // Start is called before the first frame update
    void Start()
    {
        endpos = player.transform.position;
        startpos = new Vector3(0, 0, -135);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlayerMove();
        }
        Vector3 targetpos = startpos;
        transform.position = targetpos;
        if (endpos != player.transform.position)
        {
            player.position = Vector3.MoveTowards(player.position, endpos, Time.deltaTime * movespeed);
        }
    }
    void PlayerMove()
    {
        Vector3 cursorPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(cursorPos);
        RaycastHit hit;

        if(Physics.Raycast( ray,out hit, 1000))
        {
            if (hit.collider.gameObject.tag == "Terrain")
            {
                endpos = hit.point;
            }
        }

    }
}
