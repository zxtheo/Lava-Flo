//source: https://stackoverflow.com/questions/59031509/move-an-object-up-down-slowly-in-unity?rq=1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGroundController : MonoBehaviour
{
    public bool triggered = false;
    public bool up = true;
    public bool active = true;
    public float timed = 0f;
    public bool fake = false;
    public bool triggerOnHit = false;

    private float speed = 1f;
    private float height = 2.5f;
    private float startY;

    private float sinAlter = 0;
    private float startTime = 0; 


    private 
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = 0;
        if (up)
        {
            sinAlter = Mathf.PI;
        }
        gameObject.SetActive(active);
        
        startY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()   
    {
        if (triggered)
        {
            Move();
        }
        if (startTime > 0)
        {
            Timed();
        }
        if (Time.time-startTime > 5 && !GetComponent<BoxCollider2D>().enabled && !fake)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void Move()
    {
        if (startTime == 0)
        {
            startTime = Time.time;
        }
        var pos = transform.position;
        var newY = startY + height * (Mathf.Sin((Time.time - startTime) * speed+(sinAlter))+1);
        transform.position = new Vector3(pos.x, newY, pos.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Timed();
        if (triggerOnHit)
        {
            triggered = true;
        }
    }

    private void Timed()
    {
        if (startTime == 0)
        {
            startTime = Time.time;
        }
        if (Time.time - startTime > timed && timed != 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}

