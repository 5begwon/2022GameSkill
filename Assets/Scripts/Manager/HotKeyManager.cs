using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeyManager : Singleton<HotKeyManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            SceneChangeManager.Instance.SceneChange("Ingame");
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            GameManager.Instance.WeaponLV++;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            GameManager.Instance.Player.GetComponent<PlayerController>().InvinsibilityHotKey();
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            GameManager.Instance.Player.GetComponent<PlayerController>().UnInvinsibilityHotKey();
        }
        else if(Input.GetKeyDown(KeyCode.F5))
        {
            GameManager.Instance.AllDie();
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {

        }

    }
}
