using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Text _roomNameDisplay;
    [SerializeField]
    private Text _roomPlayerDisplay;
    [SerializeField]
    private GameObject _playerItemPrefab;
    [SerializeField]
    private GameObject _playerListViewportContent;
    private Dictionary<int, Player> _listPlayer;
    private List<GameObject> playerInfoItem = new List<GameObject>();
    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log(PhotonNetwork.CurrentRoom);
        _roomNameDisplay.text = PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }


    void Update()
    {
        if (_listPlayer != PhotonNetwork.CurrentRoom.Players)
        {
            UpdatePlayerList();
        }
    }

    void UpdatePlayerList()
    {
        _listPlayer = PhotonNetwork.CurrentRoom.Players;
        _roomPlayerDisplay.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "/" + PhotonNetwork.CurrentRoom.MaxPlayers + " Players";
        foreach (GameObject item in playerInfoItem)
        {
            Destroy(item);
        }
        foreach (var item in _listPlayer)
        {

            playerInfoItem.Add(Instantiate(_playerItemPrefab));
            playerInfoItem[playerInfoItem.Count - 1].GetComponentInChildren<Text>().text = item.Value.NickName;
            playerInfoItem[playerInfoItem.Count - 1].transform.SetParent(_playerListViewportContent.transform);
            playerInfoItem[playerInfoItem.Count - 1].transform.localScale = new Vector3(1, 1, 1);
        }
    }



}
