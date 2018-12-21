using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

enum IndexType
{
    PREFAB, POSITION
}


public class CostumeNetworkManager : NetworkManager
{
    private GameObject myPlayer;
    [SerializeField]
    private Transform[] spawnPositions;

    private int randomIndex;
    private System.Random rnd;

    public void Start()
    {
        rnd = new System.Random();
    }

    public override void OnStartServer()
    {
        Debug.Log("Server has started!");
        NetworkServer.RegisterHandler(CostumeMessageType.COSTUME_MESSAGE_HIGH_VALUE, TestDelegate2);
        base.OnStartServer();
    }



    public override void OnClientConnect(NetworkConnection connection)
    {
        Debug.Log("Client connected! ");
        client.RegisterHandler(CostumeMessageType.COSTUME_MESSAGE_HIGH_VALUE, TestDelegate);
        Debug.Log("NetworkMessage Delegate Tested!");

        ClientScene.AddPlayer(connection, 0);

    }

    public override void OnServerAddPlayer(NetworkConnection connection, short playerId)
    {
        CostumeMessageType cmt = new CostumeMessageType();
        cmt.PlayerID = playerId;
        Debug.Log("Send To Client!");
        NetworkServer.SendToClient(connection.connectionId, CostumeMessageType.COSTUME_MESSAGE_HIGH_VALUE, cmt);
    }

    private void TestDelegate2(NetworkMessage netMsg)
    {
        randomIndex = GetRandomIndex(IndexType.PREFAB);
        GameObject prefab = spawnPrefabs[randomIndex];

        randomIndex = GetRandomIndex(IndexType.POSITION);
        Transform sPosition = spawnPositions[randomIndex];

        CostumeMessageType cmt = netMsg.ReadMessage<CostumeMessageType>();
        myPlayer = Instantiate(prefab, sPosition);
        Debug.Log("Test Delegate 2");

        NetworkServer.AddPlayerForConnection(netMsg.conn, myPlayer, cmt.ControllerID);
        NetworkServer.Spawn(myPlayer);
    }

    private void TestDelegate(NetworkMessage networkMessage)
    {
        CostumeMessageType cmt = new CostumeMessageType();
        cmt = networkMessage.ReadMessage<CostumeMessageType>();
        Debug.Log("Test Delegate");
        client.Send(CostumeMessageType.COSTUME_MESSAGE_HIGH_VALUE, cmt);
        Debug.Log("Message Sent");

    }

    private int GetRandomIndex(IndexType type)
    {
        int min = 0, max = 0;

        switch (type)
        {
            case IndexType.PREFAB:
                max = 4;
                break;
            case IndexType.POSITION:
                max = 8;
                break;
        }
        return rnd.Next(min, max);
    }

}