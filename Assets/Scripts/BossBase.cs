using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    private float HP;
    public float BossMoveSpeed;
    public int DeathScore;
    public float Damage;
    public GameObject ParticlePrefab;

    public float BossHP
    {
        get { return HP; }
        set
        {
            HP = value;
            if (HP <= 0)
            {
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        GameManager.Instance.Score += DeathScore;
        GameObject obj1 = Instantiate(ParticlePrefab, this.transform.position, Quaternion.identity);
        GameObject obj2 = Instantiate(ParticlePrefab, this.transform.position, Quaternion.identity);
        GameObject obj3 = Instantiate(ParticlePrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(obj1, 5f);
        Destroy(obj2, 5f);
        Destroy(obj3, 5f);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            BossHP -= GameManager.Instance.Damage;
        }
    }
}
