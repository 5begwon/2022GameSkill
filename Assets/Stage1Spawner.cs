using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject whiteSphere;
    void Start()
    {
        StartCoroutine(VacteriaCreate());
        StartCoroutine(SekunCreate());
        StartCoroutine(VirusCreate());
        StartCoroutine(GermCreate());
    }

    IEnumerator VacteriaCreate()
    {
        while(true)
        {
            GameManager.Instance.enemyList.Add(Instantiate(enemies[0], new Vector3(Random.Range(-40f, 40f), 0, 220f), Quaternion.identity));

            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator SekunCreate()
    {
        while (true)
        {
            GameManager.Instance.enemyList.Add(Instantiate(enemies[1], new Vector3(Random.Range(-50f, 50f), 0, 220f), Quaternion.identity));

            yield return new WaitForSeconds(3f);
        }
    }
    IEnumerator VirusCreate()
    {
        while (true)
        {
            GameManager.Instance.enemyList.Add(Instantiate(enemies[2], new Vector3(Random.Range(-50f, 50f), 0, 220f), Quaternion.identity));

            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator GermCreate()
    {
        while (true)
        {
            GameManager.Instance.enemyList.Add(Instantiate(enemies[3], new Vector3(Random.Range(-50f, 50f), 0, 220f), Quaternion.identity));

            yield return new WaitForSeconds(7f);
        }
    }

    IEnumerator WhiteSphere()
    {
        while (true)
        {
            if(D.Persent(30))
            {
                var obj = Instantiate(whiteSphere, new Vector3(Random.Range(-40, 40), 0, 220), Quaternion.identity);
            }
            yield return new WaitForSeconds(8f);
        }
    }

    IEnumerator BossCreate()
    {
        GameManager.Instance.enemyList.Add(Instantiate(enemies[4], new Vector3(0, 0, 220f), Quaternion.identity));
        yield return null;
    }

    public void SpawnAllStop()
    {
        StopAllCoroutines();
    }
}
