using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sekun : Enemy
{
    public GameObject bulletPrefab;

    private void Awake()
    {
        EnemyHp = 20;
        EnemyMoveSpeed = 15;
        DeathScore = 1500;
        Damage = 8;
        isAttackPattern = true;
    }

    private void Start()
    {
        StartCoroutine(SekunPattern());
    }

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * EnemyMoveSpeed);
    }

    IEnumerator SekunPattern()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(1f);
        }
    }
}
