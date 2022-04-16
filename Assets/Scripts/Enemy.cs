using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float HP;
    public float EnemyMoveSpeed;
    public int DeathScore;
    public float Damage;
    public GameObject ParticlePrefab;

    public bool isAttackPattern;
    public float EnemyHp
    { 
        get { return HP; }
        set
        {
            HP = value;
            if(HP <= 0)
            {
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        GameManager.Instance.Score += DeathScore;
        var obj = Instantiate(ParticlePrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(obj, 5f);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerBullet"))
        {
            EnemyHp -= GameManager.Instance.Damage;
        }
        else if(other.gameObject.CompareTag("Border"))
        {
            GameManager.Instance.PlayerPP += (Damage / 2);
            Destroy(this.gameObject);
        }
    }
}
