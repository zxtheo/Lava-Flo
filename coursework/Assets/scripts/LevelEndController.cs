using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{

    private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
        particle.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("level end");
        particle.Play();
    }
}
