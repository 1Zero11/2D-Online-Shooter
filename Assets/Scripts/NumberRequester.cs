using UnityEngine;
using Coherence;
using Coherence.Toolkit;

public class NumberRequester : MonoBehaviour
{
    CoherenceSync sync;

    private void Awake()
    {
        sync = GetComponent<CoherenceSync>();
    }

    void Update()
    {
        if (sync.HasStateAuthority && Input.GetKeyDown(KeyCode.Return))
        {
            var counter = FindObjectOfType<Counter>();
            var counterSync = counter.GetComponent<CoherenceSync>();

            counterSync.SendCommand<Counter>(
                nameof(Counter.NextNumber),
                MessageTarget.AuthorityOnly,
                sync);
        }
    }

    public void GotNumber(int number)
    {
        Debug.Log($"Got number: {number}");
    }
}
