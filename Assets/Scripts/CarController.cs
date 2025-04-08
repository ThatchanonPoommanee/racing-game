using UnityEngine;
using Photon.Pun;

public class CarController : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 200f;
    private Rigidbody2D rb;
    private PhotonView pv;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pv = GetComponent<PhotonView>();
    }

    void FixedUpdate()
    {
        if (!pv.IsMine) return; // ไม่ให้ผู้เล่นคนอื่นควบคุม

        float move = Input.GetAxis("Vertical");
        float turn = -Input.GetAxis("Horizontal");

        rb.velocity = transform.up * move * speed;
        rb.MoveRotation(rb.rotation + turn * turnSpeed * Time.fixedDeltaTime);
    }
}
