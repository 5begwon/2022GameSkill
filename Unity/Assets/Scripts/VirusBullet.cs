using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBullet : BulletBase
{
    public float BulletDamage;
    private void Awake()
    {
        BulletSpeed = 32;
        Dir = Vector3.back;
        BulletDamage = GetComponentInParent<Enemy>().Damage;
    }

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
}
