using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;  // สำหรับ UI
using UnityEngine.SceneManagement;  // สำหรับการเปลี่ยนฉาก

public class FinishTrigger : MonoBehaviourPun
{
    private bool isFinished = false;  // ตัวแปรที่ใช้ตรวจสอบว่าเกมจบแล้วหรือยัง

    public Text winText;  // Text UI เพื่อแสดงข้อความผู้ชนะ

    // ฟังก์ชันนี้จะถูกเรียกเมื่อมีการชนกับ BoxCollider2D ที่ตั้งค่าเป็น Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าเป็นผู้เล่นที่มี PhotonView ของตัวเองหรือไม่
        if (!photonView.IsMine || isFinished) return;

        // ถ้าผู้เล่นชนเส้นชัย
        if (other.CompareTag("Player"))
        {
            isFinished = true;  // ตั้งค่า isFinished เป็น true
            photonView.RPC("AnnounceWinner", RpcTarget.All, PhotonNetwork.NickName);  // เรียก RPC เพื่อประกาศผู้ชนะ
        }
    }

    // ฟังก์ชันนี้จะทำการประกาศผู้ชนะไปยังผู้เล่นทุกคนในเกม
    [PunRPC]
    void AnnounceWinner(string winnerName)
    {
        Debug.Log($"{winnerName} เป็นผู้ชนะ!");

        // แสดงข้อความใน UI
        if (winText != null)
        {
            winText.text = $"{winnerName} เป็นผู้ชนะ!";
        }

        // รอ 3 วินาทีแล้วเปลี่ยนฉาก
        Invoke("GoToGameOverScene", 3f);  // 3 วินาทีหลังจากประกาศผู้ชนะ
    }

    // ฟังก์ชันสำหรับเปลี่ยนฉาก
    void GoToGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
