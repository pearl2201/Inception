using UnityEngine;
using System.Collections;

public class ARMapPlayer : AbstractMapPlayer
{
    private float velocityX = 0.075f;
    private float velocityY = 0.075f;
    private float accY = -0.0098f;
    private float baseVelocityY = 0.16f;

    [SerializeField]
    private tk2dSprite sprite;

    private Vector3 currRot;
    private int noStage;
    private int[,] map1 = new int[32, 18];

    // Use this for initialization
    void Start()
    {

        float deltaXJump = 1.5f;
        float deltaYJump = 1.5f;
        float timeJump = deltaXJump / velocityX;
        float halfTimeJump = timeJump / 2;
        baseVelocityY = (-1 / 2 * accY * halfTimeJump * halfTimeJump + deltaYJump) / halfTimeJump;
        Debug.Log("base velocityY: " + baseVelocityY);


    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == MAP_PLAYER_STATE.MOVING)
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

            if (currPos.y > 3.6f || currPos.y < -3.6f)
            {
                playerState = MAP_PLAYER_STATE.EXPLO;
            }
            currPos.x += velocityX;
            velocityY += accY;
            currPos.y += velocityY;

            currRot.z = Mathf.Atan(velocityY / velocityX) * Mathf.Rad2Deg;

            transform.position = currPos;
            transform.eulerAngles = currRot;
            LogPos();
        }
    }

    public override void ResetEnterStage()
    {

    }
    public override void Init()
    {
        currPos = transform.position;
        currRot = transform.eulerAngles;
        velocityY = baseVelocityY;
        baseYStage = 0;
        playerState = MAP_PLAYER_STATE.MOVING;
        sizeX = 0.4f;
        sizeY = 0.4f;
    }
    public override void Tap()
    {
        if (playerState == MAP_PLAYER_STATE.MOVING)
        {
            velocityY = baseVelocityY;
            int posStartJumpX = (int)(transform.position.x / 0.4f);
            int posStartJumpY = (int)((transform.position.y) / 0.4f);
            if (noStage == 1)
            {
                posStartJumpX = -posStartJumpX;
            }
            Debug.Log("pos jump: " + posStartJumpX + " - " + posStartJumpY);
        }
    }
    public override void ChangeStage(int noStage)
    {
        this.noStage = noStage;
        if (noStage == 0)
        {
            velocityX = 0.075f;
            baseYStage = 0;
            currPos.y = currPos.y + 3.6f;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {

            velocityX = -0.075f;
            baseYStage = -3.6f;
            currPos.y = currPos.y - 3.6f;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        sprite.color = map.arrStages[noStage].subColor;
    }

    private int posStartJumpX;
    private int posStartJumpY;
    private int lastPosX;
    private int lastPosY;
    private void LogPos()
    {
        int posX = (int)(transform.position.x / 0.4f);
        int posY = (int)((transform.position.y) / 0.4f);
        if (noStage == 1)
        {
            posX = -posX;
        }
        if (posY + 9 > 0)
        {

            map1[16 + posX, posY + 9] = 1;
        }
        string s = "";
        for (int i = 17; i >=0 ; i--)
        {
            for (int j = 0; j < 32; j++)
            {
                s = s + map1[j, i];
            }
            s = s + "\n";
        }
        Debug.Log("s: " + s);
    }
}
