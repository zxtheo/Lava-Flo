using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectables : MonoBehaviour
{
    public int totalGold, totalGems;
    private int gold = 0, gems = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GemCounterText").GetComponent<UnityEngine.UI.Text>().text = gems.ToString() + "/" + totalGems.ToString();
        GameObject.Find("GoldCounterText").GetComponent<UnityEngine.UI.Text>().text = gold.ToString() + "/" + totalGold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectedGem()
    {
        gems++;
        GameObject.Find("GemCounterText").GetComponent<UnityEngine.UI.Text>().text = gems.ToString() + "/" + totalGems.ToString();
    }

    public void CollectedGold()
    {
        gold++;
        GameObject.Find("GoldCounterText").GetComponent<UnityEngine.UI.Text>().text = gold.ToString() + "/" + totalGold.ToString();
    }
}
