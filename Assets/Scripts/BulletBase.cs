using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float BulletSpeed;
    public Vector3 Dir = Vector3.forward;

    protected virtual void Start()
    {
        Destroy(gameObject, 6f);
    }

    protected virtual void Update()
    {
        transform.Translate(Dir * Time.deltaTime * BulletSpeed);
    }
}
