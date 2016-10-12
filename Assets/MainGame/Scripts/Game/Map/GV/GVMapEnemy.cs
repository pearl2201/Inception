
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum TYPE_GV_MAP_ENEMY
{
    MOVING_BT,
    MOVING_LR,
    ROTATE,
    NONE
}

public class GVMapEnemy : MonoBehaviour
{
    [SerializeField]
    private TYPE_GV_MAP_ENEMY type = TYPE_GV_MAP_ENEMY.NONE;
    private bool isMoveBack;


    [SerializeField]
    private Vector3 APoint;

    [SerializeField]
    private Vector3 BPoint;
    private Vector3 currPos;
    [SerializeField]
    public tk2dSprite img;
    private float p;

    public Vector3 vt;
    public float speed;
    public void InitBT(Color c)
    {
        type = TYPE_GV_MAP_ENEMY.MOVING_BT;
        currPos = transform.position;
        APoint = currPos + new Vector3(0, -1.03f, 0);
        BPoint = currPos + new Vector3(0, 1.03f, 0);
        isMoveBack = false;
        img.color = c;
    }

    public void InitLR(float lengthSegment, Color c)
    {
        type = TYPE_GV_MAP_ENEMY.MOVING_LR;
        currPos = transform.position;
        APoint = currPos + new Vector3(-lengthSegment / 2 + 0.35f, 0, 0);
        BPoint = currPos + new Vector3(lengthSegment / 2 - 0.35f, 0, 0);
        isMoveBack = false;
        img.color = c;
    }

    public void InitRotate(Color c)
    {
        type = TYPE_GV_MAP_ENEMY.ROTATE;
        img.color = c;
        vt = new Vector3(0, 0, Random.Range(-1f, 1f));
        speed = Random.Range(100, 300);
    }

    void Update()
    {
        if (type == TYPE_GV_MAP_ENEMY.MOVING_BT || type == TYPE_GV_MAP_ENEMY.MOVING_LR)
        {
            p += Time.deltaTime / 2f;
            if (isMoveBack)
            {
                currPos.x = BPoint.x * (1 - p) + APoint.x * p;
                currPos.y = BPoint.y * (1 - p) + APoint.y * p;
            }
            else
            {
                currPos.x = APoint.x * (1 - p) + BPoint.x * p;
                currPos.y = APoint.y * (1 - p) + BPoint.y * p;
            }
            if (p >= 1)
            {
                p = 0;
                isMoveBack = !isMoveBack;
                transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y * (-1), 1);
            }
            transform.position = currPos;
        }
        else if (type == TYPE_GV_MAP_ENEMY.ROTATE)
        {
            transform.Rotate(vt, speed * Time.deltaTime);
        }
    }
}

