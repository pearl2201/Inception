
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum TYPE_SIK_MAP_ENEMY : int
{
    NONE = -1,
    BASIC = 0,
    STATIC_HEIGHT = 3,
    DYNAMIC_HEIGHT = 1,
    STATIC_WEIGHT_BOT = 4,
    STATIC_WEIGHT_TOP = 5,
    DYNAMIC_WEIGHT_BOT = 2,
    MOVING_BASIC = 6,
    TOP_BOT_ATTACK = 7,


}

public class SIKMapEnemy : MonoBehaviour
{
    public tk2dSprite sprite;
    public TYPE_SIK_MAP_ENEMY type = TYPE_SIK_MAP_ENEMY.NONE;

    private Vector3 currScale;
    private Vector3 destScale;
    private Vector3 srcScale;
    private bool isInc;

    private Vector3 leftMoving;
    private Vector3 rightMoving;
    private Vector3 currNoving;

    private float p;

    public void SetColor(Color c)
    {
        sprite.color = c;
    }

    public void SetupBasic()
    {
        type = TYPE_SIK_MAP_ENEMY.BASIC;
    }

    public void SetupDynamicHeight()
    {
        type = TYPE_SIK_MAP_ENEMY.DYNAMIC_HEIGHT;
        Debug.Log("type: " + type.ToString());
        srcScale = transform.localScale;
        destScale = srcScale;
        destScale.y = Random.Range(1.2f, 1.7f) + 0.1f * MapScreenManager.Instance.levelMap;
        currScale = srcScale;
        isInc = true;
        p = 0;
    }

    public void SetupStaticHeight()
    {
        type = TYPE_SIK_MAP_ENEMY.STATIC_HEIGHT;
        Debug.Log("type: " + type.ToString());
        currScale = transform.localScale;
        currScale.y = Random.Range(1.6f, 2.4f);
        transform.localScale = currScale;
    }

    public void SetupStaticWeightBot()
    {
        type = TYPE_SIK_MAP_ENEMY.STATIC_WEIGHT_BOT;
        Debug.Log("type: " + type.ToString());
        currScale = transform.localScale;
        currScale.x = Random.Range(2f, 3f);
        transform.localScale = currScale;
    }

    public void SetupStaticWeightTop()
    {


        type = TYPE_SIK_MAP_ENEMY.STATIC_WEIGHT_TOP;
        Debug.Log("type: " + type.ToString());
        currScale = transform.localScale;
        currScale.x = Random.Range(2f, 3f);
        transform.localScale = currScale;
        currNoving = transform.localPosition;
        currNoving.y += 0.6f;

        transform.localPosition = currNoving;
    }

    public void SetupDynamicWeightBot()
    {
        type = TYPE_SIK_MAP_ENEMY.DYNAMIC_WEIGHT_BOT;
        Debug.Log("type: " + type.ToString());
        srcScale = transform.localScale;
        destScale = srcScale;
        destScale.x = Random.Range(0.8f, 1.6f) + 0.2f * MapScreenManager.Instance.levelMap;
        currScale = srcScale;
        isInc = true;
        p = 0;
    }

    public void SetupMovingBasic()
    {
        type = TYPE_SIK_MAP_ENEMY.MOVING_BASIC;
        Debug.Log("type: " + type.ToString());
        currNoving = transform.localPosition;
        leftMoving = currNoving;
        rightMoving = currNoving;
        leftMoving.x -= 1.2f;
        rightMoving.x += 1.2f;
        p = 0.5f;
        isInc = true;

    }

    public void SetupTopBotAtt(bool isTop)
    {
        type = TYPE_SIK_MAP_ENEMY.BASIC;
    }

    void Update()
    {
        if (type == TYPE_SIK_MAP_ENEMY.DYNAMIC_HEIGHT || type == TYPE_SIK_MAP_ENEMY.DYNAMIC_WEIGHT_BOT )
        {
            if (isInc)
            {
                p += Time.deltaTime*2f;
                if (p >= 1)
                {
                    isInc = false;
                    p = 1;
                }
            }
            else
            {
                p -= Time.deltaTime*2f;
                if (p <= 0)
                {
                    isInc = true;
                    p = 0;
                }
            }
        }else if (type == TYPE_SIK_MAP_ENEMY.MOVING_BASIC)
        {
            if (isInc)
            {
                p += Time.deltaTime * 1.5f;
                if (p >= 1)
                {
                    isInc = false;
                    p = 1;
                }
            }
            else
            {
                p -= Time.deltaTime * 1.5f;
                if (p <= 0)
                {
                    isInc = true;
                    p = 0;
                }
            }
        }

        if (type == TYPE_SIK_MAP_ENEMY.DYNAMIC_HEIGHT || type == TYPE_SIK_MAP_ENEMY.DYNAMIC_WEIGHT_BOT)
        {
            if (type == TYPE_SIK_MAP_ENEMY.DYNAMIC_HEIGHT)
            {
                currScale.y = srcScale.y * (1 - p) + destScale.y * p;
            }
            else if (type == TYPE_SIK_MAP_ENEMY.DYNAMIC_WEIGHT_BOT)
            {
                currScale.x = srcScale.x * (1 - p) + destScale.x * p;
            }
            transform.localScale = currScale;
        }

        else if (type == TYPE_SIK_MAP_ENEMY.MOVING_BASIC)
        {
            currNoving.x = leftMoving.x * (1 - p) + rightMoving.x * p;
            transform.localPosition = currNoving;
        }
        else if (type == TYPE_SIK_MAP_ENEMY.TOP_BOT_ATTACK)
        {

        }
    }

}

