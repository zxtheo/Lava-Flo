using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movePower = 10f;
    public float KickBoardMovePower = 15f;
    public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

    private Rigidbody2D rb;
    private Animator anim;
    Vector3 movement;
    private int direction = 1;
    bool isJumping = false;
    private bool alive = true;
    private bool dieing = false;

    public Vector3 startPos = new Vector3(-28, 10, 0);
    public GameObject punch;
    public GameObject punchLocation;
    public GameObject wave;
    public bool bossLevel = false;
    public GameObject levelController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        transform.position = startPos;
        
    }

    private void Update()
    {
        Restart();
        if (alive)
        {
            Attack();
            Jump();
            Run();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("isJump", false);
        isJumping = false;
    }
 

    void Run()
    {
        
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;

        

    }
    void Jump()
    {
        if (( Input.GetAxisRaw("Vertical") > 0)
        && !anim.GetBool("isJump"))
        {
            isJumping = true;
            anim.SetBool("isJump", true);
        }
        if (!isJumping)
        {
            return;
        }

        rb.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("attack");
            if (transform.localScale.x < 0)
            {
                Instantiate(punch, punchLocation.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
            else
            {
                Instantiate(punch, punchLocation.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            
        }
    }

    public void Die()
    {

        StartCoroutine(DieAnimation());
        alive = false;
        

    }
    void Restart()
    { 
        anim.SetTrigger("idle");
        alive = true;

    }

    public void Reset()
    {
        if(bossLevel)
        {
            wave.GetComponent<WaveController>().Reset();
        }
        alive = true;
        transform.position = startPos;
        this.GetComponent<PlayerHealth>().LooseLife();
    }

    IEnumerator DieAnimation()
    {
        if (!dieing)
        {
            dieing = true;
            alive = false;
            anim.SetTrigger("die");
            
            if(GetComponent<PlayerHealth>().health == 0)
            {
                levelController.GetComponent<LevelController>().Dead();
            }
            else
            {
                yield return new WaitForSecondsRealtime(1.3f);
                Reset();
                dieing = false;
            }
            
        }
        
    }


}

