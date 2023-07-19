using UnityEngine;
using Coherence;
using Coherence.Toolkit;

public class Counter : MonoBehaviour
{
    public int counter = 0;
    public NumberRequester requester;

    public void NextNumber(CoherenceSync requester)
    {
        requester.SendCommand<NumberRequester>(
            nameof(NumberRequester.GotNumber),
            MessageTarget.AuthorityOnly,
            counter);
        counter++;
    }
}