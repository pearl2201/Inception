using UnityEngine;
using System.Collections;

public class GVMapPlayer : AbstractMapPlayer
{
    private float velocityX = 0.075f;
    private float velocityY = 0.075f;
    private float accY = -0.0098f;
    private float baseVelocityY = 0.16f;
    [SerializeField]
    private tk2dSprite sprite;
    private int noStage;
    public TYPE_GV_POS typePos;

    private GVStage currGvStage;
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

            transform.position = currPos;

        }
    }
    public override void Init()
    {
        currPos = transform.position;
        baseYStage = 0;
        playerState = MAP_PLAYER_STATE.MOVING;
        typePos = TYPE_GV_POS.POS4;
        currGvStage = (GVStage)MapScreenManager.Instance.currMap.currStage;
        if (currGvStage == null)
        {
            Debug.Log("wtf");
        }
        sizeX = 0.4f;
        sizeY = 0.4f;
    }
    public override void Tap()
    {
        if (playerState == MAP_PLAYER_STATE.MOVING)
        {
            playerState = MAP_PLAYER_STATE.JUMP;
            velocityY = baseVelocityY;
            float currPosX = transform.position.x;

            int right = 0;
            int left = 0;
            if (noStage == 1)
            {
                right = (int)(Mathf.Abs(6.4f - currPosX - 0.25f - 0.2f) / currGvStage.lengthSegment);
                left = (int)(Mathf.Abs(6.4f - currPosX - 0.25f + 0.2f) / currGvStage.lengthSegment);
            }
            else
            {
                right = (int)(Mathf.Abs(currPosX + 6.4f + 0.25f + 0.2f) / currGvStage.lengthSegment);
                left = (int)(Mathf.Abs(currPosX + 6.4f + 0.25f - 0.2f) / currGvStage.lengthSegment);
            }

            if (right < currGvStage.listTypeGVSegment.Length)
            {
                float destY = 0;
                if (right == left)
                {
                    TYPE_GV_SEGMENT currTypeSegment = currGvStage.listTypeGVSegment[right];

                    if (typePos == TYPE_GV_POS.POS1)
                    {
                        if (currTypeSegment == TYPE_GV_SEGMENT.LANE12 || currTypeSegment == TYPE_GV_SEGMENT.LANE123 || currTypeSegment == TYPE_GV_SEGMENT.LANE2 || currTypeSegment == TYPE_GV_SEGMENT.LANE23)
                        {
                            // move to pos 2
                            typePos = TYPE_GV_POS.POS2;
                        }
                        else
                        {
                            // move to pos 4
                            typePos = TYPE_GV_POS.POS4;
                        }
                    }
                    else if (typePos == TYPE_GV_POS.POS2)
                    {
                        // move to pos 1
                        typePos = TYPE_GV_POS.POS1;
                    }
                    else if (typePos == TYPE_GV_POS.POS3)
                    {
                        // move to pos 4
                        typePos = TYPE_GV_POS.POS4;
                    }
                    else if (typePos == TYPE_GV_POS.POS4)
                    {
                        if (currTypeSegment == TYPE_GV_SEGMENT.LANE23 || currTypeSegment == TYPE_GV_SEGMENT.LANE123 || currTypeSegment == TYPE_GV_SEGMENT.LANE2 || currTypeSegment == TYPE_GV_SEGMENT.LANE12)
                        {
                            // move to pos 3
                            typePos = TYPE_GV_POS.POS3;
                        }
                        else
                        {
                            // move to pos 1
                            typePos = TYPE_GV_POS.POS1;
                        }
                    }


                }
                else
                {
                    TYPE_GV_SEGMENT rightTypeSegment = currGvStage.listTypeGVSegment[right];
                    TYPE_GV_SEGMENT leftTypeSegment = currGvStage.listTypeGVSegment[left];
                   
                    if (typePos == TYPE_GV_POS.POS2)
                    {
                        // move to pos 1
                        typePos = TYPE_GV_POS.POS1;
                    }
                    else if (typePos == TYPE_GV_POS.POS3)
                    {
                        // move to pos 4
                        typePos = TYPE_GV_POS.POS4;
                    }
                    else
                    {
                        if (rightTypeSegment == TYPE_GV_SEGMENT.LANE12 || rightTypeSegment == TYPE_GV_SEGMENT.LANE123 || rightTypeSegment == TYPE_GV_SEGMENT.LANE2 || rightTypeSegment == TYPE_GV_SEGMENT.LANE23 || leftTypeSegment == TYPE_GV_SEGMENT.LANE12 || leftTypeSegment == TYPE_GV_SEGMENT.LANE123 || leftTypeSegment == TYPE_GV_SEGMENT.LANE2 || leftTypeSegment == TYPE_GV_SEGMENT.LANE23)
                        {
                            if (typePos == TYPE_GV_POS.POS1)
                            {
                                typePos = TYPE_GV_POS.POS2;
                            }
                            else
                            {
                                typePos = TYPE_GV_POS.POS3;
                            }
                        }
                        else
                        {
                            if (typePos == TYPE_GV_POS.POS1)
                            {
                                typePos = TYPE_GV_POS.POS4;
                            }
                            else
                            {
                                typePos = TYPE_GV_POS.POS1;
                            }
                        }
                    }
                }




                if (typePos == TYPE_GV_POS.POS1)
                {
                    destY = baseYStage + 3;
                }
                else if (typePos == TYPE_GV_POS.POS4)
                {
                    destY = baseYStage + 0.6f;
                }
                else if (typePos == TYPE_GV_POS.POS2)
                {
                    destY = baseYStage + 2.2f;
                }
                else if (typePos == TYPE_GV_POS.POS3)
                {
                    destY = baseYStage + 1.4f;
                }

                StartCoroutine(MoveToPos(currPos.y - baseYStage, destY - baseYStage));
            }
            else
            {
                playerState = MAP_PLAYER_STATE.MOVING;
            }
        }
    }

    IEnumerator MoveToPos(float oldY, float newY)
    {

        float p = 0;
        Vector3 v3 = transform.position;
        //Debug.Log("x1: " + transform.position.x);
        Vector3 currEA = transform.localEulerAngles;
        float oldcurrEAZ = currEA.z;
        float rot = 0;
        if (Mathf.Abs(oldY - newY) < 1)
        {
            rot = 180;
        }
        else
        {
            rot = 360f;
        }

        while (p <= 1)
        {
            p += Time.deltaTime / 0.1f;
            v3 = currPos;
            v3.y = baseYStage + oldY * (1 - p) + newY * p;
            currPos.y = v3.y;
            currEA.z = oldcurrEAZ + rot * p;
            transform.localEulerAngles = currEA;
            yield return null;
        }
        currPos.y = baseYStage + newY;
        currEA.z = oldcurrEAZ + rot;
        // Debug.Log("x2: " + transform.position.x);
        transform.localEulerAngles = currEA;
        playerState = MAP_PLAYER_STATE.MOVING;
    }
    public override void ChangeStage(int noStage)
    {
        this.noStage = noStage;
        currGvStage = (GVStage)MapScreenManager.Instance.currMap.currStage;

        if (noStage == 0)
        {
            velocityX = 0.075f;

            currPos.y += 3.6f;
            baseYStage = 0;
        }
        else
        {

            velocityX = -0.075f;
            baseYStage = -3.6f;
            currPos.y -= 3.6f; ;
        }
        sprite.color = map.arrStages[noStage].subColor;
    }
    public override void ResetEnterStage()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // neu la door thi duyet

        // neu hok phai la door thi phai check xem la co dang jump hay hok
        // neu hok phai la jump, ma lai con khac mau thi goodbyemylove,
    }
}
