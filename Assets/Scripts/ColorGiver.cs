using Coherence;
using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGiver : MonoBehaviour
{
    public Color[] AvailableColors = new Color[] { Color.red, Color.blue, Color.green, Color.magenta, Color.white, Color.cyan };
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color GetColor()
    {
        return AvailableColors[index++ % AvailableColors.Length];
    }

    public void RequestColor(CoherenceSync requester)
    {
        var color = GetColor();
        Debug.Log("Color Given");
        requester.SendCommand<ColorRequester>(
            nameof(ColorRequester.GotColor),
            MessageTarget.AuthorityOnly,
            color);
    }
}
