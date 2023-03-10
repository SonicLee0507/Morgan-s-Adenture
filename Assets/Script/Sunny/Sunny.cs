using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sunny : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public GameObject losepanel;
    private float jump;
    public Text healthDisplay;
    private float input;
    Rigidbody2D rb;
    Animator anim;
    AudioSource source;
    public int health;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float startdashTime;
    private float dashTime;
    public float extraSpeed;
    private bool isDashing;

    private int extraJumps;
    public int extraJumpsvalue;
    public GameObject explosiondash;
    public GameObject audioDead;

    private bool drawedSH;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthDisplay.text = health.ToString();
        extraJumps = extraJumpsvalue;

    }

    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        // Storing Player's Input
        input = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Vertical");
        if (isGrounded == true)
        {
            extraJumps = extraJumpsvalue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
        if (input != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && isDashing == false)
        {
            speed += extraSpeed;
            isDashing = true;
            dashTime = startdashTime;
            Instantiate(explosiondash, transform.position, Quaternion.identity);
        }
        if (dashTime <= 0 && isDashing == true)
        {
            isDashing = false;
            speed -= extraSpeed;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }
        
    }




    // Update is called once per frame
    void FixedUpdate()
    {


        //Moving Player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        source.Play();
        health -= damageAmount;
        healthDisplay.text = health.ToString();


        if (health <= 0)
        {
            Destroy(gameObject);
            print("You're DEAD!!!!!");
            losepanel.SetActive(true);
            Instantiate(audioDead, transform.position, Quaternion.identity);
            Destroy(audioDead, 1f);
        }
    }
}
