using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using SimpleJSON;
public class ARMapManager : AbstractMap
{
    [SerializeField]
    private GameObject halfMoonItem, moonItem;

    public override void SetupDoor(DoorInfo info)
    {

    }

    public override void SetupMap()
    {
        // force setup in here

        float startPosMiddle = -5.4f;
        float endPosMiddle = 5.4f;
        float lengthMiddle = 10.8f;
        float minDiameter = 0.8f;
        float maxDiameter = 1.8f;
        bool[,] maxtrixMapStage1 = new bool[32, 9];
        bool[,] maxtrixMapStage2 = new bool[32, 9];
        int sizePlayer = 2;
        List<V2F> listDefaultJumpPath = new List<V2F>();
        List<V2F> listMiddle = new List<V2F>();
        List<ARCData> listCircle = new List<ARCData>();
        List<ARCData> listHalfMoonTop = new List<ARCData>();
        List<ARCData> listHalfMoonBot = new List<ARCData>();

        // setup lane 2 and lane 3 first, middle Lane
        {
            List<float> listLengthSegment = new List<float>();
            {
                int noSegmentMiddle = Random.Range(1, 4);
                if (noSegmentMiddle == 1)
                {
                    listLengthSegment.Add(10.4f);
                }
                else if (noSegmentMiddle == 2)
                {
                    float length1 = Random.Range(2, 5.2f);
                    if (Random.Range(0, 2) == 0)
                    {
                        listLengthSegment.Add(length1);
                        listLengthSegment.Add(10.4f - length1);
                    }
                    else
                    {
                        listLengthSegment.Add(length1);
                        listLengthSegment.Add(10.4f - length1);
                    }
                }
                else if (noSegmentMiddle == 3)
                {
                    float length1 = Random.Range(2, 3.5f);
                    float length2 = Random.Range(2, (10.5f - length1) / 2);
                    float length3 = 10.4f - length1 - length2;

                    if (Random.Range(0, 2) == 0)
                    {
                        listLengthSegment.Add(length1);
                        listLengthSegment.Add(length2);
                        listLengthSegment.Add(length3);
                    }
                }
            }
            {
                float beginSegment = -5.4f;
                for (int i = 0; i < listLengthSegment.Count; i++)
                {
                    bool stopCreate = false;
                    float currEndPos = beginSegment;
                    bool isOnTop = false;
                    while (currEndPos < beginSegment + listLengthSegment[i] - 1 && !stopCreate)
                    {
                        float lengthHalfMoon = 0;
                        float diameter = Random.Range(minDiameter, Mathf.Min(beginSegment + listLengthSegment[i] - currEndPos, maxDiameter));
                        if (!isOnTop)
                        {
                            diameter *= (-1);
                        }
                        isOnTop = !isOnTop;
                        float posXLow = 0;
                        if (currEndPos == beginSegment)
                        {

                        }
                        else
                        {

                        }
                        float posXCenter = posXLow + diameter / 2;
                        listMiddle.Add(new V2F(posXCenter, diameter / 2));
                        currEndPos += lengthHalfMoon;
                        stopCreate = Random.Range(0, 3) == 0;
                    }
                }
            }

            {
                for (int i = 0; i < listMiddle.Count; i++)
                {

                    bool[,] stageCheck = null;
                    if (listMiddle[i].Y < 0)
                    {
                        stageCheck = maxtrixMapStage2;
                    }
                    else
                    {
                        stageCheck = maxtrixMapStage1;
                    }
                }
            }
        }


        // chia ra 2 the loai
        // setup lane 1 and lane 4 here 

        // setup door here

        // setup map here
    }

    public bool DeQuyMap(V2I pointJoin, List<V2I> listPointDeQuy, int[,] mapDeQuy, int directMap)
    {
        List<V2I> listPointPossile = new List<V2I>();
        // create path from join point
        int x = pointJoin.X;
        int y = pointJoin.Y;
        int option = 0; // 0: move len, 1: move xuong: 2 move sang

        // lap ra tat ca cac diem co the join
        while (isPointValid(x, y, mapDeQuy))
        {
            listPointPossile.Add(new V2I(x, y)); // nho remove 0 pos
            if (option == 0)
            {
                y = y + 1;
                if (y - pointJoin.Y == 3)
                {
                    if (directMap == 0)
                    {
                        if (isPointValid(x, y, mapDeQuy) && isPointValid(x + 1, y, mapDeQuy) && isPointValid(x + 2, y, mapDeQuy))
                        {
                            listPointPossile.Add(new V2I(x, y));
                            listPointPossile.Add(new V2I(x + 1, y));
                            listPointPossile.Add(new V2I(x + 2, y));
                            x = x + 2;
                            option = 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (isPointValid(x, y, mapDeQuy) && isPointValid(x - 1, y, mapDeQuy) && isPointValid(x - 2, y, mapDeQuy))
                        {
                            listPointPossile.Add(new V2I(x, y));
                            listPointPossile.Add(new V2I(x - 1, y));
                            listPointPossile.Add(new V2I(x - 2, y));
                            x = x + 2;
                            option = 1;
                        }
                        else
                        {
                            break;
                        }
                    }


                }
                else
                {
                    option = 2;
                }
            }
            else if (option == 1)
            {
                y = y - 1;
            }
            else if (option == 2)
            {
                if (directMap == 0)
                {
                    x = x + 1;
                }
                else
                {
                    x = x - 1;
                }
            }

        }


        // 2 kha nang xay ra o day, la x la diem cuoi o map hay x = 2 hoac la 31 , thi return true

        // neu x chua bang 2 hoac 31, thi chon ra 1 pointJoin bat ky de tiep tuc de quy
        // random 1 diem bat ky

        // remove diem ay ra khoi list

        // tiep tuc de quy

        return true;

    }

    public bool isPointValid(int x, int y, int[,] mapDeQuy)
    {
        int rightX = Mathf.Clamp(x + 2, 0, 33);
        int leftX = Mathf.Clamp(x - 2, 0, 33);
        int topY = Mathf.Clamp(y + 2, 0, 33);
        int botY = Mathf.Clamp(y - 2, 0, 33);
        for (int i = leftX; i < rightX; i++)
        {
            for (int j = botY; j < topY; j++)
            {
                if (mapDeQuy[i, j] == -1)
                {
                    return false;

                }
            }
        }
        return true;
    }

    public override JSONClass EncodeMap()
    {
        JSONClass jsClass = new JSONClass();
        return jsClass;
    }
    public override void DecodeMap(JSONClass data)
    {

    }

    public override void CloseMap()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
