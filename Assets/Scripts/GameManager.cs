using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;  // จุด spawn ของผู้เล่น
    public GameObject playerPrefab;

    void Start()
    {
        int index = PhotonNetwork.LocalPlayer.ActorNumber - 1;

        // ตรวจสอบว่า index อยู่ในขอบเขตของ spawnPoints[] หรือไม่
        if (index < 0 || index >= spawnPoints.Length)
        {
            Debug.LogError("จำนวน spawnPoints ไม่เพียงพอสำหรับจำนวนผู้เล่น");
            return;
        }

        // สร้างรถในตำแหน่งที่จุด spawn ที่กำหนด
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[index].position, Quaternion.identity);
    }
}
