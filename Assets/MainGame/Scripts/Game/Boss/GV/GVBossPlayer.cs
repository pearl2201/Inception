
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GVBossPlayer : AbstractBossPlayer
{
    public int bulletCount;
    public bool isOnTop = true;
    public float posYBorderTop = 3;
    public float posYBorderBot = -3;
    public AbstractBullet bullet;
    public float velocityX;


    void Start()
    {
        currPos = transform.position;
        currRot = transform.eulerAngles;
    }


    public override void Dying()
    {
        StartCoroutine(IEDying());
    }

    public override void SetStart()
    {

    }

    public override void Setup()
    {

    }

    public override void Tap()
    {

    }

    IEnumerator IETap()
    {
        float p = 0;
        float oldY;
        float newY;
        bool isShooted = false;
        if (isOnTop)
        {
            oldY = posYBorderTop;
            newY = posYBorderBot;
        }
        else
        {
            oldY = posYBorderTop;
            newY = posYBorderBot;
        }


        currRot = transform.eulerAngles;
        float oldRotZ = currRot.z;
        float newRotZ = currRot.z + 180f;
        while (p <= 1)
        {

            p += Time.deltaTime;
            currPos.y = oldY * (1 - p) + newY * p;
            currRot.z = oldRotZ * (1 - p) + newRotZ * p;
            if (bulletCount > 0 && !isShooted && p >= 0.5f)
            {
                ShootBullet();
            }
        }
        currRot.z = newRotZ;
        transform.eulerAngles = currRot;
        currPos.y = newY;

        yield return null;
    }

    private void ShootBullet()
    {
        GameObject go = Instantiate(bullet.gameObject) as GameObject;
        go.transform.position = transform.position;
        AbstractBullet bulletScript = go.GetComponent<AbstractBullet>();
        bulletScript.Setup()
    }

    IEnumerator IEDying()
    {
        yield return null;
    }


    void OnTriggerEnter2D(Collider2D coll)
    {

    }
}

