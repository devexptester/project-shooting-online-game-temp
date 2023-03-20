using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class RoomListManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _roomItemPrefab;
    [SerializeField]
    private GameObject _joinRoomScreen;
    [SerializeField]
    private GameObject _roomItemInfoPopUp;
    private List<GameObject> _roomItemsList = new List<GameObject>();

    void Start()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log(roomList[0]);
        foreach (GameObject item in _roomItemsList)
        {
            Destroy(item);
        }
        Debug.Log(roomList[0]);
        foreach (RoomInfo roomInfo in roomList)
        {
            Debug.Log(roomInfo.Name);
            _roomItemsList.Add(Instantiate(_roomItemPrefab, gameObject.transform));
            string hostName = (string)roomInfo.CustomProperties["hostName"];
            Debug.Log(roomInfo.Name);
            Debug.Log(hostName);
            _roomItemsList[_roomItemsList.Count - 1].GetComponent<RoomItem>()
            .SetRoomInfo(roomInfo.Name, roomInfo.PlayerCount, roomInfo.MaxPlayers, (string)hostName);
            _roomItemsList[_roomItemsList.Count - 1].GetComponent<RoomItem>()
            .SetDisplay(_roomItemInfoPopUp);
        }
    }

}
