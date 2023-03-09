using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public int damage;
    float speed;
    Player playerScript;

    public GameObject explosion;
    public GameObject explosionplayer;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            print("You Got Shot!!!!");
            print(playerScript.health - damage);
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(explosionplayer,transform.position,Quaternion.identity);
        }
        if (hitObject.tag =="Ground") {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
