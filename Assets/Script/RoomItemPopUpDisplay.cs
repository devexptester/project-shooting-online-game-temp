using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItemPopUpDisplay : MonoBehaviour
{
    [SerializeField]
    private Text _roomNameText;
    [SerializeField]
    private Text _hostNameText;
    [SerializeField]
    private Text _playerCountText;

    public void SetPopUpData(string roomName, string hostName, string playerCount)
    {
        _roomNameText.text = roomName;
        _hostNameText.text = "Host: " + hostName;
        _playerCountText.text = playerCount + " Players";
    }
}
