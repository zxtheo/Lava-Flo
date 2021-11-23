using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    public AudioClip clip;
    public GameObject[] platforms;
    public bool activatePlayforms;
    public bool movePlatforms;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        AudioSource.PlayClipAtPoint(clip, GameObject.Find("Main Camera").transform.position);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollectables>().CollectedGold();
        foreach (GameObject platform in platforms)
        {
            if (activatePlayforms)
            {
                platform.SetActive(true);
            }
            else if (movePlatforms)
            {
                platform.GetComponent<SingleGroundController>().triggered = true;
            }
        }
        Destroy(gameObject);
    }

}
