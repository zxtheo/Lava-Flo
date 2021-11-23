using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushController : MonoBehaviour
{
    public AudioClip clip1, clip2;
    private int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "punch") 
        {
            Destroy(collision.gameObject);
            int index = Random.Range(1, 2);
            switch (index)
            {
                case 1:
                    AudioSource.PlayClipAtPoint(clip1, GameObject.Find("Main Camera").transform.position, 0.2f);
                    break;
                case 2:
                    AudioSource.PlayClipAtPoint(clip2, GameObject.Find("Main Camera").transform.position, 0.2f);
                    break;
            }
            
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
