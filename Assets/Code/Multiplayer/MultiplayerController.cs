using UnityEngine;
using System.Collections;

public class MultiplayerController : MonoBehaviour
{
    public GameObject characterAbilitySelector;

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
    }

    void OnConnectedToServer()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Instantiate(characterAbilitySelector);
    }
}