using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMover : MonoBehaviour
{
    public List<GameObject> mapObjects = new List<GameObject>();
    public float mapMoveSpeed = 8;

    private void Update()
    {
        for (int i = 0; i < mapObjects.Count; i++)
        {
            mapObjects[i].transform.Translate(Vector3.back * Time.deltaTime * mapMoveSpeed);
            if(mapObjects[i].transform.position.z <= -215)
            {
                mapObjects[i].transform.position = new Vector3(mapObjects[i].transform.position.x, mapObjects[i].transform.position.y, 340);
            }
        }
    }
}
