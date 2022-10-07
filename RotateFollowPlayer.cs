using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFollowPlayer : MonoBehaviour
{
    // ���λ��
    public GameObject Player;
    // ��ת�ٶ�
    [Range(0,1)]
    public float rotateSpeed;
    
    private Transform m_transform;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        m_transform = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateWithPlayer();
    }

    // ��̨����׼���
    void RotateWithPlayer()
    {
        // �������� player - enemy
        Vector3 dir = Player.transform.position - m_transform.position;
        // ��ת�Ƕ�
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // ������ת
        Quaternion lookRotationLerp = Quaternion.Slerp(m_transform.rotation, lookRotation, rotateSpeed);
        m_transform.rotation = lookRotationLerp;

    }
}
