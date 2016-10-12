using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SIKBossPlayer : AbstractBossPlayer
{
    private float velocityX = 0.075f;
    private float velocityY = 0.075f;
    private float accY = -0.0098f;
    private float baseVelocityY = 0.16f;
    [SerializeField]
    private tk2dSprite sprite;


    void Update()
    {
        if (playerState == BOSS_PLAYER_STATE.MOVING || playerState == BOSS_PLAYER_STATE.INTAP)
        {

            currPos.x += velocityX;
            if (playerState == BOSS_PLAYER_STATE.INTAP)
            {
                velocityY += accY;
                currPos.y += velocityY;

                if (currPos.y <= baseYStage + sizeY / 2)
                {
                    currPos.y = baseYStage + sizeY / 2;
                    playerState = BOSS_PLAYER_STATE.MOVING;

                }

            }
            transform.position = currPos;

        }
    }

    public override void Setup()
    {
        currPos = transform.position;
        baseYStage = 0;
        playerState = BOSS_PLAYER_STATE.WAITING;
        sizeX = 0.4f;
        sizeY = 0.4f;
    }

    public override void SetStart()
    {
        playerState = BOSS_PLAYER_STATE.MOVING;
    }
    public override void Tap()
    {
        if (playerState == BOSS_PLAYER_STATE.MOVING || playerState == BOSS_PLAYER_STATE.INVC)
        {
            playerState = BOSS_PLAYER_STATE.INTAP;
            velocityY = baseVelocityY;
        }
    }

    public override void Dying()
    {
        StartCoroutine(IEDying());
    }

    IEnumerator IEDying()
    {
        yield return null;
    }


    void OnTriggerEnter2D(Collider2D coll)
    {

    }

}

