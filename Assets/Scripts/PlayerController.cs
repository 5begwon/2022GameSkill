using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    public float PlayerMoveSpeed;
    public float PlayerRotate;
    public GameObject BulletPrefab;
    public GameObject BulletParent;
    public float BulletInterval = 0.1f;
    public PlayableDirector Invisibility;

    public List<GameObject> BulletList = new List<GameObject>();

    public MeshRenderer[] PlayerMeshes;
    CapsuleCollider collider;

    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        StartCoroutine("EMove");
        StartCoroutine("ERotate");
        StartCoroutine("EShot");

        //CameraManager.Instance.CameraShake(5, 5, 3);
    }

    IEnumerator EMove()
    {
        float h, v = 0;
        while (true)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            Vector3 moveVector3 = new Vector3(h, 0, v) * PlayerMoveSpeed * Time.deltaTime;
            this.transform.position += moveVector3;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -55f, 55f), 0, Mathf.Clamp(transform.position.z, -10f, 90f));

            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator ERotate()
    {
        float h = 0;
        while (true)
        {
            h = -Input.GetAxisRaw("Horizontal");

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(Vector3.forward * h * PlayerRotate), Time.deltaTime * 7);

            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator EShot()
    {
        while(true)
        {
            if(Input.GetKey(KeyCode.Return))
            {
                var obj = Instantiate(BulletPrefab, transform.position, Quaternion.identity, BulletParent.transform);
                BulletList.Add(obj);
                yield return new WaitForSeconds(BulletInterval);
            }
                yield return new WaitForSeconds(0.01f);
        }
    }

    //IEnumerator Effect()
    //{
    //    for(int i = 0; i < PlayerMeshes.Length; i++)
    //    {
    //        Color transperency = new Color(1, 1, 1, 0);
    //        PlayerMeshes[i].material.color = Color.Lerp(PlayerMeshes[i].material.color, transperency, Time.deltaTime * 10);
    //    }
    //    yield return new WaitForSeconds(1f);
    //}

    IEnumerator Invinsibility(int type)
    {
        switch (type)
        {
            case 1:
                collider.enabled = false;
                Invisibility.Play();
                Debug.Log("ON");
                yield return new WaitForSeconds(1.5f);
                collider.enabled = true;
                Invisibility.Stop();
                Debug.Log("OFF");
                break;
            case 2:
                collider.enabled = false;
                Invisibility.Play();
                Debug.Log("ON");
                yield return new WaitForSeconds(2.5f);
                Invisibility.Stop();
                yield return new WaitForSeconds(0.5f);
                collider.enabled = true;
                Debug.Log("OFF");
                break;
            case 3:
                collider.enabled = false;
                Invisibility.Play();
                Debug.Log("ON");
                break;
            case 4:
                collider.enabled = true;
                Debug.Log("OFF");
                Invisibility.Stop();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && other.TryGetComponent<Enemy>(out Enemy e))
        {
            GameManager.Instance.PlayerHP -= (e.Damage / 2);
            CameraManager.Instance.CameraShake(2, 2, 0.5f);
            StartCoroutine(Invinsibility(1));
        }
        if(other.gameObject.CompareTag("Item"))
        {
            StartCoroutine(Invinsibility(2));
        }
        if(other.gameObject.CompareTag("SekunBullet") && other.TryGetComponent<SekunBullet>(out SekunBullet sb))
        {
            GameManager.Instance.PlayerHP -= sb.BulletDamage;
            CameraManager.Instance.CameraShake(2, 2, 0.75f);
            StartCoroutine(Invinsibility(1));
        }
        if (other.gameObject.CompareTag("VirusBullet") && other.TryGetComponent<VirusBullet>(out VirusBullet vb))
        {
            GameManager.Instance.PlayerHP -= vb.BulletDamage;
            CameraManager.Instance.CameraShake(3, 3, 0.5f);
            StartCoroutine(Invinsibility(1));
        }
        if (other.gameObject.CompareTag("GermBullet") && other.TryGetComponent<GermBullet>(out GermBullet gb))
        {
            GameManager.Instance.PlayerHP -= gb.BulletDamage;
            CameraManager.Instance.CameraShake(3.5f, 3.5f, 0.5f);
            StartCoroutine(Invinsibility(1));
        }
    }

    public void InvinsibilityHotKey()
    {
        StartCoroutine(Invinsibility(3));
    }
    public void UnInvinsibilityHotKey()
    {
        StartCoroutine(Invinsibility(4));
    }
}
