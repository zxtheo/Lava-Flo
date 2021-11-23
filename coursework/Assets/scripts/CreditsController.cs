using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{


    public Image black;
    public Animator anim;    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(scroll());

    }

    IEnumerator scroll()
    {
        print("wait 10");
        yield return new WaitForSeconds(20);
        print("waited");
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(0);
    }

}
