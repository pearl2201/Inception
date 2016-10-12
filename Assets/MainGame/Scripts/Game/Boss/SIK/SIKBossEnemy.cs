using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SIKBossEnemy : AbstractBossEnemy
{
    private float velocityX;
    private float destY;

    void Start()
    {
        currPos = transform.position;
    }

    public void Setup(float destY, Color c)
    {
        img.color = c;
    }

    void Update()
    {
        if (enemyState == BOSS_ENEMY_STATE.MOVING)
        {
            if (currPos.y > destY)
            {
                currPos.y += Config.ACC_Y;
                if (currPos.y < destY)
                {
                    currPos.y = destY;
                }
            }

            currPos.x += velocityX;
            transform.position = currPos;

            if (currPos.x <= GameScreenManager.Instance.cam.transform.position.x - 12.8f)
            {
                RemoveSelf();
            }
        }


    }



}

