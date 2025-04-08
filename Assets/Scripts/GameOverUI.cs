using UnityEngine;
using UnityEngine.SceneManagement;  // สำหรับการเปลี่ยนฉาก

public class GameOverManager : MonoBehaviour
{
    // ฟังก์ชันที่ถูกเรียกเมื่อผู้เล่นคลิกปุ่ม
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");  // เปลี่ยนไปที่เมนูหลัก
    }
}
