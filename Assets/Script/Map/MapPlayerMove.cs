using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPlayerMove : MonoBehaviour
{
	public float speed = 10f;

	Vector2 lastClickedPos;

	bool moving;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			moving = true;
		}

		if (moving && (Vector2)transform.position != lastClickedPos)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position,lastClickedPos, step);
		}

		else
		{
			moving = false;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name =="Gob");
		{
			SceneManager.LoadScene("Game");
		}
	}
}
