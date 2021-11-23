using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public Image black;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LooseLife()
    {

        Destroy(GameObject.Find("Health" + health.ToString()));
        if(health > 0)
        {
            health--;
        }
    }



}
