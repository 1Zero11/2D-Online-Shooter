using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIctoryHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowVictory(Color color, int coins)
    {
        Debug.Log("Show Victory");
        var shower = FindObjectOfType<VictoryShower>();
        shower.ShowVictoryScreen(color, coins);
    }
}
