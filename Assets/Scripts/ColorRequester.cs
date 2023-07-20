using Coherence.Toolkit;
using Coherence;
using QFSW.QC.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRequester : MonoBehaviour
{
    public Color color;

    private void Start()
    {
        if (color == Color.clear)
            Invoke(nameof(AskColor), 1f);
    }

    public void AskColor()
    {
        var giver = FindObjectOfType<ColorGiver>();
        var gsync = giver.GetComponent<CoherenceSync>();

        gsync.SendCommand<ColorGiver>(
            nameof(ColorGiver.RequestColor),
            MessageTarget.AuthorityOnly,
            GetComponent<CoherenceSync>()
        );
        Debug.Log("Asked for a color");
    }

    public void GotColor(Color color)
    {
        this.color = color;
        GetComponent<SpriteRenderer>().color = color;
        Debug.Log("Got color");
    }
}
