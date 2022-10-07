using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameObject[] ballistics;//�ӵ���ʼ��λ��
    private Transform model_trans;//�ɻ���transform���
    private Vector3 direction;
    public AudioSource shoot;

    void Start()
    {
        model_trans = this.transform;
        ballistics = GameObject.FindGameObjectsWithTag("ballistic");
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = model_trans.transform.forward;
            for (int i = 0; i < ballistics.Length; i++)
            {
                GameObject bullet = Resources.Load("PlayerBullet") as GameObject;
                bullet = Instantiate(bullet) as GameObject;
                bullet.transform.position = ballistics[i].transform.position;
                Rigidbody bullet_rb = bullet.GetComponent<Rigidbody>();
                bullet_rb.velocity = direction * 150;
            }
            shoot.Play();
        }
    }
}
