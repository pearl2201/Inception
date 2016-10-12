
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public enum TYPE_GV_SEGMENT : int
{
    LANE1 = 0,
    LANE2 = 1,
    LANE3 = 2,
    LANE12 = 3,
    LANE23 = 4,
    LANE13 = 5,
    LANE123 = 6
}


public enum TYPE_GV_POS : int
{
    POS1 = 0,
    POS2 = 1,
    POS3 = 2,
    POS4 = 3
}

public enum TYPE_ENEMY_GV : int
{
    HOZ = 0, // 2
    VER = 1, // 3
    ROT = 2 // 3 
}
public class GVStage : AbstractMapStage
{

    [SerializeField]
    private GameObject modelLane;
    [SerializeField]
    private GameObject modelEnemyHoz;
    [SerializeField]
    private GameObject modelEnemyVer;
    [SerializeField]
    private GameObject modelEnemyRot;
    [HideInInspector]
    public float lengthSegment;
    public TYPE_GV_SEGMENT[] listTypeGVSegment;
    public override void SetupStage(bool isHasDoor)
    {

    }
    public void test()
    {

    }

    private void RandomAddDoubleSegment(List<TYPE_GV_SEGMENT> listSM, TYPE_GV_SEGMENT typeAdd)
    {

    }

    public void AddLane(TYPE_GV_SEGMENT[] listTypeGVSegment, int posStart, int countSegment)
    {

        List<TYPE_GV_SEGMENT> listAddLine = new List<TYPE_GV_SEGMENT>();
        TYPE_GV_SEGMENT lastLine = listTypeGVSegment[posStart - 1];
        bool found = false;
        for (int i = posStart; i >= 0; i--)
        {
            if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE1 || listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE12)
            {
                lastLine = TYPE_GV_SEGMENT.LANE3;
                found = true;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE3 || listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE23)
            {
                lastLine = TYPE_GV_SEGMENT.LANE1;
                found = true;
            }
        }
        if (!found)
        {
            if (lastLine == TYPE_GV_SEGMENT.LANE12)
            {
                lastLine = TYPE_GV_SEGMENT.LANE1;
            }
            else if (lastLine == TYPE_GV_SEGMENT.LANE23)
            {
                lastLine = TYPE_GV_SEGMENT.LANE3;
            }
            else if (lastLine == TYPE_GV_SEGMENT.LANE13)
            {
                lastLine = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE1 : TYPE_GV_SEGMENT.LANE3;
            }
        }

        while (listAddLine.Count < countSegment - posStart)
        {
            int r = Random.Range(0, 4) / 3;
            if (r == 0)
            {

                if (lastLine == TYPE_GV_SEGMENT.LANE1)
                {
                    listAddLine.Add(Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : TYPE_GV_SEGMENT.LANE123);
                    listAddLine.Add(Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE123 : TYPE_GV_SEGMENT.LANE12);
                    listAddLine.Add(Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : TYPE_GV_SEGMENT.LANE123);
                    listAddLine.Add(Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE1 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE13 : TYPE_GV_SEGMENT.LANE123);

                }
                else
                {
                    listAddLine.Add(Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123);
                    listAddLine.Add(Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE123 : TYPE_GV_SEGMENT.LANE23);
                    listAddLine.Add(Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123);
                    listAddLine.Add(Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE3 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE13 : TYPE_GV_SEGMENT.LANE123);
                }

            }
            else
            {
                if (lastLine == TYPE_GV_SEGMENT.LANE1)
                {
                    listAddLine.Add(TYPE_GV_SEGMENT.LANE13);
                    listAddLine.Add(TYPE_GV_SEGMENT.LANE3);
                    lastLine = TYPE_GV_SEGMENT.LANE3;
                }
                else
                {
                    listAddLine.Add(TYPE_GV_SEGMENT.LANE13);
                    listAddLine.Add(TYPE_GV_SEGMENT.LANE1);
                    lastLine = TYPE_GV_SEGMENT.LANE1;
                }
            }
            lastLine = listAddLine[listAddLine.Count - 1];
        }
        for (int i = posStart; i < countSegment; i++)
        {
            listTypeGVSegment[i] = listAddLine[i - posStart];
        }
    }

    public void TraceLane(TYPE_GV_SEGMENT[] listTypeGVSegment, int _posEnd, int countSegment)
    {

        int posEnd = _posEnd % 2 == 0 ? _posEnd : _posEnd + 1;
        TYPE_GV_SEGMENT lastLine = listTypeGVSegment[0];
        if (lastLine == TYPE_GV_SEGMENT.LANE12)
        {
            lastLine = TYPE_GV_SEGMENT.LANE1;
        }
        else if (lastLine == TYPE_GV_SEGMENT.LANE23)
        {
            lastLine = TYPE_GV_SEGMENT.LANE3;
        }
        else if (lastLine == TYPE_GV_SEGMENT.LANE13)
        {
            lastLine = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE1 : TYPE_GV_SEGMENT.LANE3;
        }
        if (posEnd == 2)
        {
            int r = Random.Range(3, 7) / 4;
            if (r == 0)
            {
                listTypeGVSegment[1] = TYPE_GV_SEGMENT.LANE13;
                if (lastLine == TYPE_GV_SEGMENT.LANE1)
                {
                    listTypeGVSegment[2] = TYPE_GV_SEGMENT.LANE3;
                }
                else
                {
                    listTypeGVSegment[2] = TYPE_GV_SEGMENT.LANE1;
                }
            }
            else
            {
                if (lastLine == TYPE_GV_SEGMENT.LANE1)
                {
                    listTypeGVSegment[1] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[2] = TYPE_GV_SEGMENT.LANE1;
                }
                else
                {
                    listTypeGVSegment[1] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[2] = TYPE_GV_SEGMENT.LANE3;
                }
            }

        }
        else if (posEnd == 4)
        {
            int r = Random.Range(3, 7) / 4;
            if (r == 0)
            {
                listTypeGVSegment[1] = TYPE_GV_SEGMENT.LANE13;
                if (lastLine == TYPE_GV_SEGMENT.LANE1)
                {
                    listTypeGVSegment[2] = TYPE_GV_SEGMENT.LANE3;
                    listTypeGVSegment[3] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[4] = TYPE_GV_SEGMENT.LANE1;
                }
                else
                {
                    listTypeGVSegment[2] = TYPE_GV_SEGMENT.LANE1;
                    listTypeGVSegment[3] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[4] = TYPE_GV_SEGMENT.LANE3;
                }
            }
            else if (r == 1)
            {
                if (lastLine == TYPE_GV_SEGMENT.LANE1)
                {
                    listTypeGVSegment[1] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[2] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE123 : TYPE_GV_SEGMENT.LANE12;
                    listTypeGVSegment[3] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[4] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE1 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE13 : TYPE_GV_SEGMENT.LANE123;
                }
                else
                {
                    listTypeGVSegment[1] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[2] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE123 : TYPE_GV_SEGMENT.LANE23;
                    listTypeGVSegment[3] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[4] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                }
            }
        }
        else if (posEnd == 6)
        {
            int r = Random.Range(2, 8) / 3;
            if (r == 0)
            {
                if (lastLine == TYPE_GV_SEGMENT.LANE1)
                {
                    listTypeGVSegment[1] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[2] = TYPE_GV_SEGMENT.LANE3;
                    listTypeGVSegment[3] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[4] = TYPE_GV_SEGMENT.LANE1;
                    listTypeGVSegment[5] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[6] = TYPE_GV_SEGMENT.LANE3;
                }
                else
                {
                    listTypeGVSegment[1] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[2] = TYPE_GV_SEGMENT.LANE1;
                    listTypeGVSegment[3] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[4] = TYPE_GV_SEGMENT.LANE3;
                    listTypeGVSegment[5] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[6] = TYPE_GV_SEGMENT.LANE1;
                }
            }
            else if (r == 1)
            {
                if (lastLine == TYPE_GV_SEGMENT.LANE1)
                {
                    listTypeGVSegment[1] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[2] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE123 : TYPE_GV_SEGMENT.LANE12;
                    listTypeGVSegment[3] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[4] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE1 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE13 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[5] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[6] = TYPE_GV_SEGMENT.LANE3;
                }
                else
                {
                    listTypeGVSegment[1] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[2] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE123 : TYPE_GV_SEGMENT.LANE23;
                    listTypeGVSegment[3] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[4] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE3 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[5] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[6] = TYPE_GV_SEGMENT.LANE1;
                }
            }
            else if (r == 2)
            {
                if (lastLine == TYPE_GV_SEGMENT.LANE1)
                {
                    listTypeGVSegment[5] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[6] = TYPE_GV_SEGMENT.LANE3;
                    listTypeGVSegment[1] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[2] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE123 : TYPE_GV_SEGMENT.LANE23;

                    listTypeGVSegment[3] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[4] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : TYPE_GV_SEGMENT.LANE123;
                }
                else
                {
                    listTypeGVSegment[5] = TYPE_GV_SEGMENT.LANE13;
                    listTypeGVSegment[6] = TYPE_GV_SEGMENT.LANE1;
                    listTypeGVSegment[1] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[2] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE2 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE23 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE123 : TYPE_GV_SEGMENT.LANE12;
                    listTypeGVSegment[3] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE12 : TYPE_GV_SEGMENT.LANE123;
                    listTypeGVSegment[4] = Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE1 : Random.Range(0, 2) == 0 ? TYPE_GV_SEGMENT.LANE13 : TYPE_GV_SEGMENT.LANE123;
                }
            }
        }
        if (_posEnd % 2 == 1)
        {

            listTypeGVSegment[posEnd] = TYPE_GV_SEGMENT.LANE13;
        }
    }

    public void SetupStage(bool isHasDoor, TYPE_GV_SEGMENT forcelastSegmentBf, TYPE_GV_SEGMENT realForceSegment, bool isNeedAddEnemy)
    {
        bool isAddedEnemy = false;
        int countSegment = (int)(4 + 4f * MapScreenManager.Instance.levelMap / 7);
        lengthSegment = 12.8f / countSegment;
       listTypeGVSegment = new TYPE_GV_SEGMENT[countSegment];
        TYPE_GV_SEGMENT lastSegmentBf = realForceSegment;
        listTypeGVSegment[0] = forcelastSegmentBf;
        int posStartAddLane = 1;
        int posStartTraceLane = 1;
        if (isNeedAddEnemy)
        {
            // xac dinh type enemy add
            int maxTypeEnemy = MapScreenManager.Instance.levelMap > 3 ? 2 : MapScreenManager.Instance.levelMap - 1;
            int typeEnemy = Random.Range(0, maxTypeEnemy + 1);
            int lengthSegmentEnemy = 2;
            // rendom vi tri cua enemy
            int posStartSegmentEnemey = Random.Range(1, countSegment - lengthSegmentEnemy + 1);
            posStartTraceLane = posStartSegmentEnemey - 1;
            posStartAddLane = posStartSegmentEnemey + lengthSegmentEnemy;
            for (int i = posStartSegmentEnemey; i < posStartSegmentEnemey + lengthSegmentEnemy; i++)
            {
                listTypeGVSegment[i] = TYPE_GV_SEGMENT.LANE13;
            }
            // if need traceLane, traceLane
            if (posStartTraceLane != 1)
            {
                TraceLane(listTypeGVSegment, posStartTraceLane, countSegment);
            }
            //  posStartAddLane += 1;
        }



        // addLane.
        if (posStartAddLane < countSegment)
            AddLane(listTypeGVSegment, posStartAddLane, countSegment);

        // phan tich map
        bool[] lane1 = new bool[countSegment];
        bool[] lane2 = new bool[countSegment];
        bool[] lane3 = new bool[countSegment];
        for (int i = 0; i < countSegment; i++)
        {
            if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE1)
            {
                lane1[i] = true;
                lane2[i] = false;
                lane3[i] = false;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE2)
            {
                lane1[i] = false;
                lane2[i] = true;
                lane3[i] = false;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE3)
            {
                lane1[i] = false;
                lane2[i] = false;
                lane3[i] = true;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE12)
            {
                lane1[i] = true;
                lane2[i] = true;
                lane3[i] = false;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE13)
            {
                lane1[i] = true;
                lane2[i] = false;
                lane3[i] = true;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE123)
            {
                lane1[i] = true;
                lane2[i] = true;
                lane3[i] = true;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE23)
            {
                lane1[i] = false;
                lane2[i] = true;
                lane3[i] = true;
            }

        }

        /*
        for (int i = 1; i < countSegment - 1; i++)
        {
            if (lane1[i] && !lane1[i - 1] && !lane1[i + 1])
            {
                lane1[i] = false;
            }
            if (lane2[i] && !lane2[i - 1] && !lane2[i + 1])
            {
                lane2[i] = false;
            }
            if (lane3[i] && !lane3[i - 1] && !lane3[i + 1])
            {
                lane3[i] = false;
            }
        }

        {
            bool isMerge = true;
            for (int i = 1; i < countSegment - 1; i++)
            {
                if (!lane2[i] && lane2[i - 1] && lane2[i + 1])
                {
                    if (isMerge)
                    {
                        lane2[i] = true;
                    }
                    isMerge = !isMerge;

                }
            }
        }

        {
            bool isMerge = true;
            for (int i = 1; i < countSegment - 1; i++)
            {
                if (!lane3[i] && lane3[i - 1] && lane3[i + 1])
                {
                    if (isMerge)
                    {
                        lane3[i] = true;
                    }
                    isMerge = !isMerge;

                }
            }
        }

        {
            bool isMerge = true;
            for (int i = 1; i < countSegment - 1; i++)
            {
                if (!lane1[i] && lane1[i - 1] && lane1[i + 1])
                {
                    if (isMerge)
                    {
                        lane1[i] = true;
                    }
                    isMerge = !isMerge;

                }
            }
        }
        */
        // read map 1 lan nua, nguyen tac la thang nao le loi kieu mot minh thi vut ra sot rac


        for (int i = 0; i < countSegment; i++)
        {
            if (lane1[i])
            {
                if (lane2[i])
                {
                    if (lane3[i])
                    {
                        listTypeGVSegment[i] = TYPE_GV_SEGMENT.LANE123;
                    }
                    else
                    {
                        listTypeGVSegment[i] = TYPE_GV_SEGMENT.LANE12;
                    }
                }
                else
                {
                    if (lane3[i])
                    {
                        listTypeGVSegment[i] = TYPE_GV_SEGMENT.LANE13;
                    }
                    else
                    {
                        listTypeGVSegment[i] = TYPE_GV_SEGMENT.LANE1;
                    }
                }
            }
            else
            {
                if (lane2[i])
                {
                    if (lane3[i])
                    {
                        listTypeGVSegment[i] = TYPE_GV_SEGMENT.LANE23;
                    }
                    else
                    {
                        listTypeGVSegment[i] = TYPE_GV_SEGMENT.LANE2;
                    }
                }
                else
                {
                    if (lane3[i])
                    {
                        listTypeGVSegment[i] = TYPE_GV_SEGMENT.LANE3;
                    }
                }
            }
        }

        // create door
        int[,] dfsMap = new int[countSegment, 4];
        for (int i = 0; i < countSegment; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                dfsMap[i, j] = -1;
            }
        }
        if (forcelastSegmentBf == TYPE_GV_SEGMENT.LANE1)
        {
            dfsMap[0, 0] = 1;
        }
        else if (forcelastSegmentBf == TYPE_GV_SEGMENT.LANE2)
        {
            dfsMap[0, 1] = 1;
            dfsMap[0, 2] = 1;
        }
        else if (forcelastSegmentBf == TYPE_GV_SEGMENT.LANE3)
        {
            dfsMap[0, 3] = 1;
        }
        else if (forcelastSegmentBf == TYPE_GV_SEGMENT.LANE12)
        {
            dfsMap[0, 0] = 1;
            dfsMap[0, 1] = 1;
        }
        else if (forcelastSegmentBf == TYPE_GV_SEGMENT.LANE13)
        {
            dfsMap[0, 0] = 1;
            dfsMap[0, 3] = 1;
        }
        else if (forcelastSegmentBf == TYPE_GV_SEGMENT.LANE123)
        {
            dfsMap[0, 0] = 1;
            dfsMap[0, 3] = 1;
            dfsMap[0, 1] = 1;
            dfsMap[0, 2] = 1;
        }
        else if (forcelastSegmentBf == TYPE_GV_SEGMENT.LANE23)
        {
            dfsMap[0, 3] = 1;
            dfsMap[0, 2] = 1;
        }
        for (int i = 1; i < countSegment; i++)
        {
            if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE1)
            {
                if (dfsMap[i - 1, 0] != -1)
                    dfsMap[i, 0] = 0;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE2)
            {
                if (dfsMap[i - 1, 1] != -1)
                    dfsMap[i, 1] = 1;
                if (dfsMap[i - 1, 2] != -1)
                    dfsMap[i, 2] = 2;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE3)
            {
                if (dfsMap[i - 1, 3] != -1)
                    dfsMap[i, 3] = 3;
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE12)
            {
                if (dfsMap[i - 1, 0] != -1)
                {
                    dfsMap[i, 0] = 0;
                    dfsMap[i, 1] = 0;
                }
                else if (dfsMap[i - 1, 1] != -1)
                {
                    dfsMap[i, 0] = 1;
                    dfsMap[i, 1] = 1;
                }

            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE13)
            {
                if (dfsMap[i - 1, 0] != -1)
                {
                    dfsMap[i, 0] = 0;
                    dfsMap[i, 3] = 0;
                }
                else if (dfsMap[i - 1, 3] != -1)
                {
                    dfsMap[i, 0] = 3;
                    dfsMap[i, 3] = 3;
                }

            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE123)
            {
                if (dfsMap[i - 1, 0] != -1)
                {
                    dfsMap[i, 0] = 0;
                    dfsMap[i, 1] = 0;
                }
                else if (dfsMap[i - 1, 1] != -1)
                {
                    dfsMap[i, 0] = 1;
                    dfsMap[i, 1] = 1;
                }
                if (dfsMap[i - 1, 2] != -1)
                {
                    dfsMap[i, 3] = 2;
                    dfsMap[i, 2] = 2;
                }
                else if (dfsMap[i - 1, 3] != -1)
                {
                    dfsMap[i, 3] = 3;
                    dfsMap[i, 2] = 3;
                }
            }
            else if (listTypeGVSegment[i] == TYPE_GV_SEGMENT.LANE23)
            {

                if (dfsMap[i - 1, 2] != -1)
                {
                    dfsMap[i, 3] = 2;
                    dfsMap[i, 2] = 2;
                }
                else if (dfsMap[i - 1, 3] != -1)
                {
                    dfsMap[i, 3] = 3;
                    dfsMap[i, 2] = 3;
                }
            }
        }


        for (int i = posStartTraceLane; i < posStartTraceLane + 1; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                dfsMap[i, j] = -1;
            }
        }
        int cellXDoor = 0;
        int cellYDoor = 0;

        // remove path

        {
            List<int> listPossibilyYTrace = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                if (dfsMap[countSegment - 1, i] != -1)
                {
                    listPossibilyYTrace.Add(i);
                }
            }
            if (listPossibilyYTrace.Count > 0)
            {
                int xTrace = countSegment - 1;
                int yTrace = listPossibilyYTrace[Random.Range(0, listPossibilyYTrace.Count)];
                int oldYTrace = yTrace;
                while (xTrace > 0 && dfsMap[xTrace, yTrace] != -1)
                {
                    oldYTrace = yTrace;
                    yTrace = dfsMap[xTrace, yTrace];
                    dfsMap[xTrace, oldYTrace] = -1;
                    xTrace -= 1;
                }
                {
                    List<int> listPossibilityXDoor = new List<int>();
                    List<int> listPossibilityYDoor = new List<int>();
                    for (int i = 2; i < countSegment; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (dfsMap[i, j] != -1)
                            {
                                listPossibilityXDoor.Add(i);
                                listPossibilityYDoor.Add(j);
                            }
                        }
                    }
                    int r = Random.Range(0, listPossibilityXDoor.Count);
                    cellXDoor = listPossibilityXDoor[r];
                    cellYDoor = listPossibilityYDoor[r];
                }
            }

        }
        //



        // loop kien tao map.

        for (int i = 0; i < countSegment; i++)
        {


            GameObject go = Instantiate(modelLane) as GameObject;
            go.transform.localScale = new Vector3(lengthSegment, 1, 1);
            go.transform.SetParent(transform);
            listEnemies.Add(go);
            if (idStage == 0)
                go.transform.localPosition = new Vector3(-6.4f + (i + 0.5f) * lengthSegment, 0, 0);
            else
                go.transform.localPosition = new Vector3(6.4f - (i + 0.5f) * lengthSegment, 0, 0);
            GVMapLine lineScript = go.GetComponent<GVMapLine>();
            lineScript.Setup(listTypeGVSegment[i], subColor, mainColor);
        }


        if (isNeedAddEnemy)
        {
            int maxRdEnemy = 0;
            GameObject modelInit = null;
            if (MapScreenManager.Instance.levelMap == 1 || MapScreenManager.Instance.levelMap == 4)
            {

            }
            else if (MapScreenManager.Instance.levelMap == 2 || MapScreenManager.Instance.levelMap == 5)
            {
                maxRdEnemy = 1;
            }
            else if (MapScreenManager.Instance.levelMap == 3 || MapScreenManager.Instance.levelMap == 6)
            {
                maxRdEnemy = 2;
            }
            else
            {
                maxRdEnemy = 2;
            }
            int r = Random.Range(0, maxRdEnemy + 1);
            if (r == 0)
            {
                modelInit = modelEnemyHoz;
            }
            else if (r == 1)
            {
                modelInit = modelEnemyVer;
            }
            else if (r == 2)
            {
                modelInit = modelEnemyRot;
            }
            GameObject go = Instantiate(modelInit) as GameObject;
            go.transform.SetParent(transform);
            listEnemies.Add(go);
            if (idStage == 0)
            {
                go.transform.position = new Vector3(-6.4f + (posStartTraceLane + 2f) * lengthSegment, transform.position.y + 1.8f, -0.1f);
            }
            else
            {
                go.transform.position = new Vector3(6.4f - (posStartTraceLane + 2f) * lengthSegment, transform.position.y + 1.8f, -0.1f);
            }
            GVMapEnemy enemyScript = go.GetComponent<GVMapEnemy>();
            if (r == 0)
            {
                enemyScript.InitLR(2 * lengthSegment, subColor);
            }
            else if (r == 1)
            {
                enemyScript.InitBT(subColor);
            }
            else if (r == 2)
            {
                enemyScript.InitRotate(subColor);
            }
        }


    }


}

