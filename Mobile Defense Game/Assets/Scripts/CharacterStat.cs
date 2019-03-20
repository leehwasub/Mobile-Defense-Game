using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public int level = 1;
    public int hp = 30;
    public int maxHp = 30;
    public int damage = 5;
    public int cost = 130;
    public int upgradeCost = 200;
    public float coolTime = 2.0f;

    private Animator animater;

    public int attacked(int damage)
    {
        hp = hp - damage;
        if(hp <= 0)
        {
            animater.SetTrigger("Die");
            Destroy(gameObject, 1.5f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        return hp;
    }

    //캐릭터 타워를 설치할 수 있는지 여부를 반환합니다.
    public bool canCreate(int seed)
    {
        if (cost <= seed) return true;
        else return false;
    }

    //래벨업이 가능한지 여부를 반환합니다.
    public bool canLevelUp(int seed)
    {
        if(level < 3)
        {
            if(upgradeCost <= seed)
            {
                return true;
            }
            else return false;
        }
        else
        {
            return false;
        }
    }

    //실제로 래벨업을 수행하는 함수입니다.
    public void incraselevel()
    {
        if(level == 1)
        {
            level = 2;
            maxHp += 25;
            hp = maxHp;
            damage += 5;
            transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
        else if(level == 2)
        {
            level = 3;
            maxHp += 50;
            hp = maxHp;
            damage += 5;
            transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animater = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
