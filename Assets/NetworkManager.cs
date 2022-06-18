using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public Text m_status;
    public InputField m_nickname;
    public InputField m_room;
    public InputField m_color;
    public PlayerControll m_player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_status.text = PhotonNetwork.NetworkClientState.ToString();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = m_nickname.text;
    }
    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }
    public void CreatRoom()
    {
        PhotonNetwork.CreateRoom(m_room.text);

    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(m_room.text);
    }
    public override void OnJoinedRoom()
    {
        m_player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity).GetComponent<PlayerControll>();
    }
    public void PrintInfo()
    {
        if (PhotonNetwork.InRoom)
        {
            print("방 이름 : " + PhotonNetwork.CurrentRoom.Name);
            print("방 인원수 : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("방장 : " + PhotonNetwork.MasterClient);
            string PlayerStr = "방 접속자 명단 : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                PlayerStr += PhotonNetwork.PlayerList[i].NickName + ", ";


            }
            print(PlayerStr);
        }
        else
        {
            print("로비 접속 인원 수 : " + PhotonNetwork.CountOfPlayers);
            print("방 개수 : " + PhotonNetwork.CountOfRooms);
            print("모든 방 인원 수 : " + PhotonNetwork.CountOfPlayersInRooms);
            print("연결상태 : " + PhotonNetwork.IsConnected);
        }
    }
    public void OnChangeColor()
    {
        var value = float.Parse(m_color.text);
        m_player.setColor(value);
    }

}
