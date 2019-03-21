﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public BulletStat bulletStat { get; set; }
    public GameObject character;

    public float activeTime = 3.0f;
    public float spawnTime;

    public BulletBehavior()
    {
        bulletStat = new BulletStat(0, 0);
    }

    void Start()
    {
        Spawn();
    }

    public void Spawn() {
        gameObject.SetActive(true);
        spawnTime = Time.time;
    }

    void Update()
    {
        if(Time.time - spawnTime >= activeTime)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.Translate(Vector2.right * bulletStat.speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            gameObject.SetActive(false);
            other.GetComponent<MonsterStat>().atatcked(bulletStat.damage);
        }
    }

}
