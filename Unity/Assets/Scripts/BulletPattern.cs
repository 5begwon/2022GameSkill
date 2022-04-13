using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Target;

    public delegate void Patterns();
    Patterns shotpattern;

    private void Start()
    {
        shotpattern += CirclePattern;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CircleGuidedPattern();

        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            CirclePattern();
        }
    }
    void CirclePattern()
    {
        for (int i = 0; i < 360; i += 13)
        {
            GameObject obj = Instantiate(BulletPrefab);

            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.Euler(0, i, 0);
        }
    }

    void CircleGuidedPattern()
    {
        List<Transform> bulletList = new List<Transform>();
        for(int i = 0; i < 360; i+= 13)
        {
            GameObject obj = Instantiate(BulletPrefab);

            obj.transform.position = transform.position;
            bulletList.Add(obj.transform);

            obj.transform.rotation = Quaternion.Euler(0, 0, i);
        }
        StartCoroutine(GuideBullet(bulletList));
    }

    IEnumerator GuideBullet(List<Transform> bulletList)
    {
        yield return new WaitForSeconds(1.0f);
        for(int i = 0; i<bulletList.Count; i++)
        {
            var dir = Target.transform.position - bulletList[i].position;
            var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
            bulletList[i].GetComponent<BulletBase>().BulletSpeed = 50;

            bulletList[i].rotation = Quaternion.Euler(0, -angle, 0);
        }

        bulletList.Clear();
    }
}
