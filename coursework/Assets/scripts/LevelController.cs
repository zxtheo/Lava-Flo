//source: https://www.youtube.com/watch?v=iV-igTT5yE4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    private int index;
    public int nextScene;

    public Image black;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Fading(nextScene));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {
        StartCoroutine(Fading(4));
    }

    IEnumerator Fading(int scene)
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(scene);
    }
}
