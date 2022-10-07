using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestory : MonoBehaviour
{
    private float time_out = 5f;
    private void Awake()
    {
        Invoke("DestroyNow",time_out);
    }

    private void DestroyNow()
    {
        DestroyObject(this.gameObject);
    }
}
