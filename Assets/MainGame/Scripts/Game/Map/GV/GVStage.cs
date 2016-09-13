
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
public class GVStage : AbstractMapStage
{

    [SerializeField]
    private GameObject modelLane;
    [SerializeField]
    private GameObject modelEnemy;

    public List<TYPE_GV_SEGMENT> listTypeGVSegment;
    public override void SetupStage(bool isHasDoor)
    {

    }


    private void RandomAddDoubleSegment(List<TYPE_GV_SEGMENT> listSM, TYPE_GV_SEGMENT typeAdd)
    {

    }

    public void SetupStage(bool isHasDoor, TYPE_GV_SEGMENT forcelastSegmentBf, TYPE_GV_SEGMENT realForceSegment, bool isNeedAddEnemy)
    {
        bool isAddedEnemy = false;
        int countSegment = (int)(4 + 4f * MapScreenManager.Instance.levelMap / 7);
        float lengthSegment = 12.8f / countSegment;
        List<TYPE_GV_SEGMENT> listTypeGVSegment = new List<TYPE_GV_SEGMENT>();
        TYPE_GV_SEGMENT lastSegmentBf = realForceSegment;
        listTypeGVSegment.Add(forcelastSegmentBf);



        while (listTypeGVSegment.Count < countSegment)
        {
            bool changeLane = Random.Range(0, 2) == 0;
            if (changeLane)
            {
                if (lastSegmentBf == TYPE_GV_SEGMENT.LANE1)
                {

                }
                else if (lastSegmentBf == TYPE_GV_SEGMENT.LANE3)
                {

                }
            }
            else
            {

            }
        }


    }


}

