using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineSetting : MonoBehaviour
{
    PlayableDirector introPlayable;
    // Start is called before the first frame update
    void Start()
    {
        introPlayable = GetComponent<PlayableDirector>();
        StartCoroutine("PlayableStart");
    }

    IEnumerator PlayableStart()
    {
        introPlayable.Play();
        Debug.Log("Ω√¿€");
        yield return null;
    }

}
