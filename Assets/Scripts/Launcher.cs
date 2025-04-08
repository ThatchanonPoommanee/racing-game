using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    public InputField inputName;  // ฟิลด์ให้ผู้เล่นกรอกชื่อ

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();  // เชื่อมต่อกับ Photon Server
    }

    // ฟังก์ชันเมื่อผู้เล่นคลิกเริ่มเกม
    public void OnClickStart()
    {
        if (string.IsNullOrEmpty(inputName.text))
        {
            Debug.LogError("กรุณากรอกชื่อก่อนเริ่มเกม");
            return;
        }

        PhotonNetwork.NickName = inputName.text;
        PhotonNetwork.JoinRandomRoom();  // เข้าห้องแบบสุ่ม

        // ถ้าไม่สามารถเข้าห้องได้จะสร้างห้องใหม่
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("GameScene");  // เมื่อเข้าห้องสำเร็จ, โหลดฉากเกม
    }
}
