using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AbstractBullet : MonoBehaviour
{
    private bool isBulletAlive;
    [SerializeField]
    private float velocity;
    private Vector3 currPos;
    private AbstractBoss boss;
    public void Setup( AbstractBoss boss)
    {


        isBulletAlive = true;
        this.boss = boss;

    }

    void Start()
    {
        currPos = transform.position;
    }
    void Update()
    {
        if (isBulletAlive)
        {
            currPos.x += velocity;
            transform.position = currPos;
        }


    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (isBulletAlive && coll.gameObject.tag.Equals("Boss"))
        {
            isBulletAlive = false;
            boss.AttackHpBoss();
            Destroy(gameObject);
        }
    }
}

