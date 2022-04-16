using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{
    public GameObject bulletPrefab;

    private void Awake()
    {
        EnemyHp = 40;
        EnemyMoveSpeed = 23;
        DeathScore = 2500;
        Damage = 10;
        isAttackPattern = true;
    }

    private void Start()
    {
        StartCoroutine(VirusPattern());
    }

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * EnemyMoveSpeed);
    }

    IEnumerator VirusPattern()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            for (int i = 0; i < 360; i += 90)
            {
                GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);

                obj.transform.position = transform.position;
                obj.transform.rotation = Quaternion.Euler(0, i, 0);
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
