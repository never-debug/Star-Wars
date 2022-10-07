using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    // 是否开火
    [HideInInspector]
    public bool isFire=false;

    public GameObject[] ballistics;//子弹初始化位置
    private Transform model_trans;//炮台的transform组件
    //private Vector3 direction;
    public AudioSource shoot;
    public float shotSpace; //开火频率
    private float nextShot;
    [Header("子弹飞行速度")]
    public float shootSpeed = 150; // 子弹飞行速度

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

    // 玩家在规定区域内，炮台开火。
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            isFire = true;
    }
    //玩家离开规定区域，炮台停火。
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isFire = false;
    }

}
