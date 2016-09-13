using UnityEngine;
using System.Collections;

public class SIKMapPlayer : AbstractMapPlayer
{

    private float velocityX = 0.075f;
    private float velocityY = 0.075f;
    private float accY = -0.0098f;
    private float baseVelocityY = 0.16f;
    [SerializeField]
    private tk2dSprite sprite;
    private int noStage;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == MAP_PLAYER_STATE.MOVING || playerState == MAP_PLAYER_STATE.JUMP)
        {
            if (noStage == 0)
            {
                if (currPos.x > 6.4f + sizeX / 2)
                {
                    map.PlayerChangeStage();
                }
            }
            else
            {
                
                if (currPos.x < -6.4f - sizeX / 2)
                {
                    map.PlayerChangeStage();
                }
            }
            currPos.x += velocityX;
            if (playerState == MAP_PLAYER_STATE.JUMP)
            {
                velocityY += accY;
                currPos.y += velocityY;

                if (currPos.y <= baseYStage + sizeY / 2)
                {
                    currPos.y = baseYStage + sizeY / 2;
                    playerState = MAP_PLAYER_STATE.MOVING;

                }

            }
            transform.position = currPos;

        }

    }

    public override void Init()
    {
        currPos = transform.position;
        baseYStage = 0;
        playerState = MAP_PLAYER_STATE.MOVING;
        sizeX = 0.4f;
        sizeY = 0.4f;
    }
    public override void Tap()
    {
        if (playerState == MAP_PLAYER_STATE.MOVING)
        {
            playerState = MAP_PLAYER_STATE.JUMP;
            velocityY = baseVelocityY;

        }
    }
    public override void ChangeStage(int noStage)
    {
        this.noStage = noStage;
        if (noStage == 0)
        {
            velocityX = 0.075f;
            baseYStage = 0;
            currPos.y = baseYStage + sizeY / 2;
            
        }
        else
        {
            
            velocityX = -0.075f;
            baseYStage = -3.6f;
            currPos.y = baseYStage + +sizeY / 2;
        }
        sprite.color = map.arrStages[noStage].subColor;
    }

    public override void ResetEnterStage()
    {

    }
}
