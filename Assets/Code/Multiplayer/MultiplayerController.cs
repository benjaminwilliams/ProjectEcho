using UnityEngine;
using System.Collections;

public class MultiplayerController : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject bossPrefab;

    private GameObject player;

    private void StartServer()
    {
        Network.InitializeServer(4, 25123, !Network.HavePublicAddress());
    }

    void OnGUI()
    {
        if (!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
                StartServer();
        }
        if (!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(400, 100, 300, 100), "Join Server"))
                JoinServer();
        }
    }

    private void JoinServer()
    {
        Network.Connect("144.132.69.142", 25123);
    }


    void OnServerInitialized()
    {
        SpawnPlayer();
        SpawnBoss();
    }

    void OnConnectedToServer()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        player = (GameObject)Network.Instantiate(playerPrefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
    }

    private void SpawnBoss()
    {
        GameObject boss = (GameObject)Network.Instantiate(bossPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
        boss.GetComponent<BossOne>().targetedEnemy = player;
    }
}