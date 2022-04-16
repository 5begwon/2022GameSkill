using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerBullet"))
        {
            int random = Random.Range(1, 101);

            if (1 <= random && random <= 26)
            {
                Instantiate(Items[0], transform.position, Quaternion.identity);
                Debug.Log("sdf");
            }
            else if (27 <= random && random <= 52)
            {
                Instantiate(Items[1], transform.position, Quaternion.identity);
                Debug.Log("sdf");
            }
            else if (53 <= random && random <= 78)
            {
                Instantiate(Items[2], transform.position, Quaternion.identity);
                Debug.Log("sdf");
            }
            else if (79 <= random && random <= 100)
            {
                Instantiate(Items[3], transform.position, Quaternion.identity);
                Debug.Log("sdf");
            }
            Destroy(gameObject);
        }
    }
}
