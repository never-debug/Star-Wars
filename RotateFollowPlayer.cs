using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFollowPlayer : MonoBehaviour
{
    // 玩家位置
    public GameObject Player;
    // 旋转速度
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

    // 炮台将瞄准玩家
    void RotateWithPlayer()
    {
        // 方向向量 player - enemy
        Vector3 dir = Player.transform.position - m_transform.position;
        // 旋转角度
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // 缓慢旋转
        Quaternion lookRotationLerp = Quaternion.Slerp(m_transform.rotation, lookRotation, rotateSpeed);
        m_transform.rotation = lookRotationLerp;

    }
}
