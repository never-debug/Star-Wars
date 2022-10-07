using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject model;//�ɻ�
    public Camera main_camera;//����ͷ

    private Rigidbody model_rb;//�ɻ��������
    public float speed=100f;//�ٶ�

    private float ws;//W����S����ֵ
    private float ad;//A����D����ֵ

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
