using Coherence;
using Coherence.Cloud;
using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public bool started;
    public CoherenceBridge Bridge;
    private CoherenceSync sync;


    // Start is called before the first frame update
    void Start()
    {
        Bridge = FindObjectOfType<CoherenceBridge>();

        Bridge.ClientConnections.OnCreated += connection =>
        {
            Debug.Log($"Connection #{connection.ClientId} " +
                      $"of type {connection.Type} created.");
            HandleUserConnected();
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
            
        };
        
        sync = GetComponent<CoherenceSync>();

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleUserConnected()
    {
        if(Bridge.ClientConnections.ClientConnectionCount > 1)
        {
            if (!started)
            {
                StartGame();
            }

            EnablePlayerInput();
        }
        
    }

    public void StartGame()
    {
        started = true;
        var coinSpawner = FindObjectOfType<CoinSpawner>();
        coinSpawner.GetComponent<CoherenceSync>().SendCommand<CoinSpawner>(nameof(CoinSpawner.Init),
            MessageTarget.AuthorityOnly);

        Debug.Log("Game Started");
    }

    public void EnablePlayerInput()
    {
        var players = FindObjectsOfType<PlayerInput>();
        foreach (var player in players)
        {
            player.GetComponent<CoherenceSync>().SendCommand<PlayerInput>(nameof(PlayerInput.Init),
                MessageTarget.All);
        }
    }

    public void OnPlayerDeath(Player player)
    {
        var players = FindObjectsOfType<Player>().ToList();
        players.Remove(player);

        if(players.Count == 1)
        {
            var color = players[0].GetComponent<SpriteRenderer>().color;
            var coins = players[0].GetComponent<CoinCollector>().collected;



            var victoryHandler = FindObjectOfType<VIctoryHandler>();
            victoryHandler.GetComponent<CoherenceSync>().SendCommand<VIctoryHandler>(nameof(ShowVictory), MessageTarget.All, color, coins);

            sync.SendCommand<MainGameManager>(nameof(Victory), MessageTarget.All);
            sync.SendCommand<MainGameManager>(nameof(ShowVictory), MessageTarget.All, color, coins);
            
        }
    }

    public void ShowVictory(Color color, int coins)
    {
        Debug.Log("Show Victory");
        var shower = FindObjectOfType<VictoryShower>();
        shower.ShowVictoryScreen(color, coins);
    }

    public void Victory()
    {
        Debug.Log("Victory!!!");
    }

}
