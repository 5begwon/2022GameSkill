using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NEED.
// ó���� �������� ������ �ڵ� (Start());
// �ð��� ���� LEFT�� RIGHT / RIGHT�� LEFT�� �ٲ��� �ڵ� (VacteriaPattern());
// ������ LEFT�� Translate�� �־��� ������ Vector3.Left�� �ٲ��� �ڵ�

public enum DirectionType
{
    DEFAULT,
    LEFT,
    RIGHT,
}

public class Vacteria : Enemy
{
    DirectionType direction;
    Vector3 dir;
    float patternDelayTime = 1f;

    private void Awake()
    {
        int random = Random.Range(0, 2);
        EnemyHp = 10;
        EnemyMoveSpeed = 30;
        DeathScore = 1000;
        Damage = 5;
        direction = random == 0 ? DirectionType.LEFT : DirectionType.RIGHT;
    }

    private void Start()
    {
        StartCoroutine(VacteriaPattern());
    }

    private void Update()
    {
        transform.Translate((Vector3.back.normalized + ChangeDirection()) * Time.deltaTime * EnemyMoveSpeed);
    }

    IEnumerator VacteriaPattern()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            direction = direction == DirectionType.LEFT ? DirectionType.RIGHT : DirectionType.LEFT;
            yield return new WaitForSeconds(patternDelayTime);
        }
    }

    Vector3 ChangeDirection()
    {
        Vector3 temp = Vector3.back;
        if (direction == DirectionType.LEFT)
            return (temp = Vector3.left).normalized;
        else if (direction == DirectionType.RIGHT)
            return (temp = Vector3.right).normalized;
        else return temp.normalized;
    }
}
