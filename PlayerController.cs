using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject model;//飞机
    public Camera main_camera;//摄像头

    private Rigidbody model_rb;//飞机刚体组件
    public float speed=100f;//速度

    private float ws;//W键和S键的值
    private float ad;//A键和D键的值

    private float multiple = 110f;

    private float rotate_x=0f;
    private float rotate_y=0f;
    private float rotate_z=0f;

    public void Start()
    {
        model_rb = this.GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        ad = Input.GetAxis("Horizontal");
        ws = -Input.GetAxis("Vertical");
        rotate_x = ws * multiple * Time.deltaTime*13;
        rotate_y += ad * multiple * Time.deltaTime;
        rotate_z = -ad * multiple * Time.deltaTime * 10;
        model.transform.rotation = Quaternion.Euler(rotate_x, rotate_y, rotate_z);
        model_rb.velocity = model.transform.forward * speed;
    }
}
