using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameManager : Singleton<GameManager>
{
    private float HP;
    private float PP;
    private int score;
    private int weaponLV;
    private float damage;

    public List<GameObject> enemyList = new List<GameObject>();
    public GameObject Player;
    public PlayableDirector hpEnding;
    public PlayableDirector ppEnding;
    
    public float PlayerHP
    {
        get { return HP; }
        set 
        {
            value = Mathf.Clamp(value, 0, 100);
            HP = value;
            HpSlider.value = HP;
            txtHp.text = $"HP : {value}";

            if (HpSlider.value <= 0)
                HpSlider.fillRect.gameObject.SetActive(false);
            else
                HpSlider.fillRect.gameObject.SetActive(true);

            if (HP <= 0)
            {
                HpDie();
            }
        }
    }
    public float PlayerPP
    {
        get { return PP; }
        set 
        {
            value = Mathf.Clamp(value, 0, 100);
            PP = value;
            PpSlider.value = PP;
            txtPp.text = $"PP : {value}";

            if (PpSlider.value <= 0)
                PpSlider.fillRect.gameObject.SetActive(false);
            else
                PpSlider.fillRect.gameObject.SetActive(true);

            if (PP >= 100)
            {
                PpDie();
            }
        }
    }
    public int Score
    {
        get { return score; }
        set 
        {
            score = value;
            ScoreText.text = score.ToString();
        }
    }
    public int WeaponLV
    {
        get { return weaponLV; }
        set
        {
            value = Mathf.Clamp(value, 1, 5);
            weaponLV = value;
        }
    }

    public float Damage
    {
        get { return damage;  }
        set 
        {
            damage = value;
        }
    }
    public Slider HpSlider;
    public Slider PpSlider;
    public Text ScoreText;
    public Text txtHp;
    public Text txtPp;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        if (SceneChangeManager.Instance.SceneName() == "Ingame")
        {
            PlayerHP = 100.0f;
            PlayerPP = 15.0f;
            Score = 0;
            WeaponLV = 1;
        }
        //else if(SceneChangeManager.Instance.SceneName() == "Stage2")
        //{
        //    PlayerHP = 100.0f;
        //    PlayerPP = 30.0f;
        //    Score = 0;
        //    WeaponLV = 1;
        //}
    }

    void Update()
    {
        switch(WeaponLV)
        {
            case 1:
                Damage = 10;
                break;
            case 2:
                Damage = 20;
                break;
            case 3:
                Damage = 30;
                break;
            case 4:
                Damage = 40;
                break;
            case 5:
                Damage = 50;
                break;
        }

        if(Input.GetKeyDown(KeyCode.Delete))
        {
            AllDestroy();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            AllDie();
        }
    }

    public void HpDie()
    {
        Player.gameObject.GetComponent<PlayerController>().StopAllCoroutines();
        hpEnding.Play();
        AllDestroy();
    }

    public void PpDie()
    {
        Player.gameObject.GetComponent<PlayerController>().StopAllCoroutines();
        ppEnding.Play();
        AllDestroy();
    }

    public void AllDie()
    {
        for (int i = 0; i < GameManager.Instance.enemyList.Count; i++)
        {
            GameManager.Instance.enemyList[i].GetComponent<Enemy>().EnemyHp = 0;
        }
        GameManager.Instance.enemyList.Clear();
    }

    public void AllDestroy()
    {
        for (int i = 0; i < GameManager.Instance.enemyList.Count; i++)
        {
            Destroy(GameManager.Instance.enemyList[i]);
        }
        GameManager.Instance.enemyList.Clear();
    }
}
