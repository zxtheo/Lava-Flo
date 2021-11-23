using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public AudioClip clip1, clip2, clip3;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlaySound();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollectables>().CollectedGem();
        Destroy(gameObject);
    }

    private void PlaySound()
    {

        int index = Random.Range(1, 3);
        switch (index)
        {
            case 1:
                AudioSource.PlayClipAtPoint(clip1, GameObject.Find("Main Camera").transform.position);
                break;
            case 2:
                AudioSource.PlayClipAtPoint(clip2, GameObject.Find("Main Camera").transform.position);
                break;
            case 3:
                AudioSource.PlayClipAtPoint(clip3, GameObject.Find("Main Camera").transform.position);
                break;
        }
    }
}
