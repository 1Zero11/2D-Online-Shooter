using Coherence.Entity;
using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool inited;
    Vector3 direction;
    NetworkEntityState owner;
    public float speed = 5f;

    public void Init(NetworkEntityState owner, Vector3 target)
    {
        this.owner = owner;
        direction = target.normalized;
        inited = true;
    }

    void Update()
    {
        if (inited)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            foreach (var item in Physics2D.OverlapCircleAll(transform.position, 0.5f))
            {
                var player = item.GetComponent<Player>();
                if (player)
                {
                    var sync = item.GetComponent<CoherenceSync>();
                    if (sync.EntityState != owner)
                    {
                        sync.SendCommand<Player>(nameof(Player.Hit), Coherence.MessageTarget.AuthorityOnly);
                        Debug.Log("Hit");
                        Destroy(gameObject);
                    }
                    
                    
                }
            }
            Invoke(nameof(DestroyByTime), 5f);
        }
        
    }

    private void DestroyByTime()
    {
        Destroy(gameObject);
    }

}
