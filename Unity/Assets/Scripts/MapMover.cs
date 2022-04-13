using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMover : MonoBehaviour
{
    private float offset = 0;
    MeshRenderer mRenderer;

    public float MapSpeed;
    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset -= Time.deltaTime * MapSpeed;
        mRenderer.material.SetTextureOffset("_BumpMap", new Vector2(0, offset));
    }
}
