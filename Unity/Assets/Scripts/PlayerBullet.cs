using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletBase
{
    protected override void Start()
    {
        BulletSpeed = 80;
        Dir = Vector3.forward;
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
