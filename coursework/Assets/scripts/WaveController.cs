using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Vector3 start;
    public float loudest;
    public float quietest;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        float vol = loudest - ((player.transform.position.x - transform.position.x) / 100);
        if (vol > quietest)
        {
            GetComponent<AudioSource>().volume = vol;
        }
        else
        {
            GetComponent<AudioSource>().volume = quietest;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("wave collided");
        if (collision.gameObject == player)
        {
            collision.gameObject.GetComponent<PlayerController>().Die();
            
        }
    }

    public void Reset()
    {
        transform.position = start;
    }
}
