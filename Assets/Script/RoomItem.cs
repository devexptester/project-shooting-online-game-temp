using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomItem : MonoBehaviour
{
    [SerializeField]
    private Text _roomNameDisplay;
    [SerializeField]
    private Text _currPlayerDisplay;
    private GameObject _roomItemInfoPopUp;
    private string _hostName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => ToggleDisplayRoomInfo());
    }

    public void SetRoomInfo(string roomName, int currPlayer, int maxPlayer, string hostName)
    {
        _roomNameDisplay.text = roomName;
        _currPlayerDisplay.text = currPlayer + "/" + maxPlayer;
        _hostName = hostName;
    }

    public void SetDisplay(GameObject roomItemInfoPopUp)
    {
        _roomItemInfoPopUp = roomItemInfoPopUp;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_roomNameDisplay.text);
        _roomItemInfoPopUp.SetActive(true);
    }

    public void ToggleDisplayRoomInfo()
    {
        Debug.Log("togglepopuptriggered");
        Debug.Log("host " + _hostName);
        _roomItemInfoPopUp.GetComponent<RoomItemPopUpDisplay>()
        .SetPopUpData(_roomNameDisplay.text, _hostName, _currPlayerDisplay.text);
        switch (_roomItemInfoPopUp.activeSelf)
        {
            case true:
                _roomItemInfoPopUp.SetActive(false);
                break;
            case false:
                _roomItemInfoPopUp.SetActive(true);
                break;
        }
    }

}
