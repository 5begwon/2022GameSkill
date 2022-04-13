using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    isInvinsibility,
    HpPlus,
    PPMinus,
}

public class ItemManager : Singleton<ItemManager>
{
    public ItemType type;
    public int Speed;
    public static int ItemCount;
    protected override void Awake()
    {
        base.Awake();
        Speed = Random.Range(10, 30);
        ItemCount = 0;
    }

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ItemEvent(type);
            ItemCount++;
            Debug.Log(ItemCount);
            Destroy(this.gameObject);
        }
    }

    public void ItemEvent(ItemType type)
    {
        if(type == ItemType.Weapon)
        {
            GameManager.Instance.WeaponLV += 1;
            Debug.Log("Weapon" + GameManager.Instance.WeaponLV.ToString());
        }
        else if(type == ItemType.isInvinsibility)
        {
            // ¹«Àû
        }
        else if(type == ItemType.HpPlus)
        {
            GameManager.Instance.PlayerHP += 20;
            Debug.Log("HP" + GameManager.Instance.PlayerHP);
        }
        else if(type == ItemType.PPMinus)
        {
            GameManager.Instance.PlayerPP -= 15;
            Debug.Log("PP" + GameManager.Instance.PlayerPP);
        }

        Destroy(gameObject);
    }
}
