
using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [OnValueSynced(nameof(UpdateHealthBar))]
    public int Health;

    public GameObject[] HealthGos;
    public GameObject BulletPrefab;
    public MainGameManager gameManager;

    CoherenceSync _sync;

    private void Awake()
    {
        _sync = GetComponent<CoherenceSync>();
        gameManager = FindObjectOfType<MainGameManager>();
    }

    public void ChangeHealthValue(int newValue)
    {
        Health = newValue;

        if (Health <= 0)
        {
            if (_sync.HasStateAuthority)
            {
                gameManager.OnPlayerDeath(this);
                //gameManager.GetComponent<CoherenceSync>().SendCommand<MainGameManager>(nameof(MainGameManager.Victory), Coherence.MessageTarget.All);
                Destroy(gameObject);
            }
        }
        UpdateHealthBar(Health, Health);
    }

    public void UpdateHealthBar(int oldHealth, int newHealth)
    {
        for (int i = 0; i < HealthGos.Length; i++)
        {
            HealthGos[i].SetActive(!(Health - 1 < i));
        }
    }


    public void SpawnBullet(Vector3 direction)
    {
        GameObject bulletGo = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        var entityState = _sync.EntityState;
        bulletGo.GetComponent<Bullet>().Init(entityState, direction);
    }

    public void Hit()
    {
        ChangeHealthValue(Health-1);
    }

}
