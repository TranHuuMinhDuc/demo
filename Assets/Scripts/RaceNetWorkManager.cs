using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class RaceNetWorkManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private SpawnObstacle spawnObstacles;
    [SerializeField] private float spawnThreshold = 3f;
    [SerializeField] private float countTime = 0f;
    [SerializeField] private int maxConn = 1;

    public void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        Vector3 spawnPoint = spawnPoint[numPlayers].position;
        var player = Instantiate(playerPrefeb, spawnPoint, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        countTime += Time.deltaTime;
        if(countTime >= spawnThreshold)
        {
            countTime -= spawnThreshold;
            spawnObstacles.Spawn();
        }
    }
}
