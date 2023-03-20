using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateRoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputField _roomNameInputField;
    [SerializeField]
    private GameObject _roomScreen;
    [SerializeField]
    private GameObject _createRoomScreen;
    [SerializeField]
    private Button _createRoomButton;

    void Start()
    {
        PhotonNetwork.JoinLobby();
        _createRoomButton.onClick.AddListener(() => CreateRoom());
    }

    public void CreateRoom()
    {
        var roomOption = new RoomOptions
        {
            MaxPlayers = 4,
            EmptyRoomTtl = 0,
            IsVisible = true,
            IsOpen = true
        };
        roomOption.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();
        roomOption.CustomRoomProperties.Add("hostName", "tralala");
        if (_roomNameInputField.text.Length > 0)
        {

            PhotonNetwork.CreateRoom(_roomNameInputField.text, roomOption);
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["hostName"]);
        //PhotonNetwork.LoadLevel("Room");
        _roomScreen.SetActive(true);
        _createRoomScreen.SetActive(false);


    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log(returnCode);
        Debug.Log(message);
    }


}
