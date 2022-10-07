using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    // �Ƿ񿪻�
    [HideInInspector]
    public bool isFire=false;

    public GameObject[] ballistics;//�ӵ���ʼ��λ��
    private Transform model_trans;//��̨��transform���
    //private Vector3 direction;
    public AudioSource shoot;
    public float shotSpace; //����Ƶ��
    private float nextShot;
    [Header("�ӵ������ٶ�")]
    public float shootSpeed = 150; // �ӵ������ٶ�

    private void Start()
    {
        model_trans = this.transform;
        shotSpace = 0.25f;
        shootSpeed = 750f;
    }


    private void FixedUpdate()
    {
        if (isFire && Time.time > nextShot)
        {
            nextShot = Time.time + shotSpace;
            //direction = model_trans.transform.forward;
            for (int i = 0; i < ballistics.Length; i++)
            {
                GameObject bullet = Resources.Load("EnemyBullet") as GameObject;
                bullet = Instantiate(bullet) as GameObject;
                bullet.transform.position = ballistics[i].transform.position;
                bullet.transform.rotation = ballistics[i].transform.rotation;
                Rigidbody bullet_rb = bullet.GetComponent<Rigidbody>();
                bullet_rb.velocity = ballistics[i].transform.forward * shootSpeed;
            }
            if(shoot!=null)
                shoot.Play();
        }
    }

    // ����ڹ涨�����ڣ���̨����
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            isFire = true;
    }
    //����뿪�涨������̨ͣ��
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isFire = false;
    }

}
