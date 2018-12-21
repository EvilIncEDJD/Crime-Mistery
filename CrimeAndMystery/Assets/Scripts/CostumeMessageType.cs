using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CostumeMessageType : MessageBase
{
    public const short COSTUME_MESSAGE_HIGH_VALUE= MsgType.Highest + 1;
    private short playerID;
    private short controllerID;
    public short PlayerID
    {
        get
        {
            return playerID;
        }

        set
        {
            playerID = value;
        }
    }

    public short ControllerID
    {
        get
        {
            return controllerID;
        }

        set
        {
            controllerID = value;
        }
    }

    public CostumeMessageType()
    {
        playerID = PlayerID;
        controllerID = ControllerID;
    }

    
}
