using Coherence;
using Coherence.Cloud;
using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool started;
    public CoherenceBridge Bridge;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Bridge = FindObjectOfType<CoherenceBridge>();

        Bridge.ClientConnections.OnCreated += connection =>
        {
            Debug.Log($"Connection #{connection.ClientId} " +
                      $"of type {connection.Type} created.");
        };

        // Raised whenever a connection is destroyed.
        Bridge.ClientConnections.OnDestroyed += connection =>
        {
            Debug.Log($"Connection #{connection.ClientId} " +
                      $"of type {connection.Type} destroyed.");
        };

        // Raised when all initial connections have been synced.
        Bridge.ClientConnections.OnSynced += connectionManager =>
        {
            Debug.Log($"ClientConnections are now ready to be used.");
            CheckOtherPlayers();
        };
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckOtherPlayers()
    {
        started = Bridge.ClientConnections.ClientConnectionCount > 1;

        if(started)
        {
            StartGame();
        }
        return started;
    }

    public void StartGame()
    {
        var players = FindObjectsOfType<PlayerInput>();
        var coinSpawner = FindObjectOfType<CoinSpawner>();

        coinSpawner.GetComponent<CoherenceSync>().SendCommand<CoinSpawner>(nameof(CoinSpawner.Init),
            MessageTarget.AuthorityOnly);
        foreach ( var player in players )
        {
            player.GetComponent<CoherenceSync>().SendCommand<PlayerInput>(nameof(PlayerInput.Init),
                MessageTarget.All);
        }

        

        Debug.Log("Game Started");
    }

}
