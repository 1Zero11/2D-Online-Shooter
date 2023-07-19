using Coherence;
using Coherence.Toolkit;
using QFSW.QC.Actions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in Physics2D.OverlapCircleAll(transform.position, 0.5f))
        {
            var collector = item.GetComponent<CoinCollector>();
            var sync = GetComponent<CoherenceSync>();

            var collectorSync = item.GetComponent<CoinCollector>();

            if (collector)
            {
                collector.Collect();

                
                sync.SendCommand<Coin>(nameof(Coin.RequestDestroy), MessageTarget.AuthorityOnly);
                enabled = false;
            }
        }
    }

    public void RequestDestroy()
    {
        Destroy(gameObject);
    }
}
