using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : Enemy
{
    public GameObject bulletPrefab;

    private void Awake()
    {
        EnemyHp = 50;
        EnemyMoveSpeed = 15;
        DeathScore = 3200;
        Damage = 18;
        isAttackPattern = true;
    }

    private void Start()
    {
        StartCoroutine(GermPattern());
    }

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * EnemyMoveSpeed);
    }

    IEnumerator GermPattern()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            for (int i = 0; i < 360; i += 40)
            {
                GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);

                obj.transform.position = transform.position;
                obj.transform.rotation = Quaternion.Euler(0, i, 0);
            }
            yield return new WaitForSeconds(2.5f);
        }
    }
}
