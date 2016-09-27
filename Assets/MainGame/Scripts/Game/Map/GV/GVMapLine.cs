using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GVMapLine : MonoBehaviour
{
    public tk2dSprite[] listLines;
    public TYPE_GV_SEGMENT type;



    public void Setup(TYPE_GV_SEGMENT _type, Color colorShow, Color colorHide)
    {
        this.type = _type;
        bool[] listCheckLaneShow = new bool[3];
        if (type == TYPE_GV_SEGMENT.LANE1)
        {
            listCheckLaneShow[0] = true;
            listCheckLaneShow[1] = false;
            listCheckLaneShow[2] = false;
        }
        else if (type == TYPE_GV_SEGMENT.LANE12)
        {
            listCheckLaneShow[0] = true;
            listCheckLaneShow[1] = true;
            listCheckLaneShow[2] = false;
        }
        else if (type == TYPE_GV_SEGMENT.LANE23)
        {
            listCheckLaneShow[0] = false;
            listCheckLaneShow[1] = true;
            listCheckLaneShow[2] = true;
        }
        else if (type == TYPE_GV_SEGMENT.LANE13)
        {
            listCheckLaneShow[0] = true;
            listCheckLaneShow[1] = false;
            listCheckLaneShow[2] = true;
        }
        else if (type == TYPE_GV_SEGMENT.LANE123)
        {
            listCheckLaneShow[0] = true;
            listCheckLaneShow[1] = true;
            listCheckLaneShow[2] = true;
        }
        else if (type == TYPE_GV_SEGMENT.LANE2)
        {
            listCheckLaneShow[0] = false;
            listCheckLaneShow[1] = true;
            listCheckLaneShow[2] = false;
        }
        else if (type == TYPE_GV_SEGMENT.LANE3)
        {
            listCheckLaneShow[0] = false;
            listCheckLaneShow[1] = false;
            listCheckLaneShow[2] = true;
        }
        Apply(listCheckLaneShow, colorShow, colorHide);
    }

    public void Apply(bool[] listCheckLaneShow, Color colorShow, Color colorHide)
    {
        for (int i = 0; i < 3; i++)
        {
            ApplyLane(listLines[i], listCheckLaneShow[i], colorShow, colorHide);
        }
    }

    public void ApplyLane(tk2dSprite lane, bool isShow, Color colorShow, Color colorHide)
    {
        if (isShow)
        {
            lane.color = colorShow;
        }
        else
        {
            lane.color = colorHide;
        }
    }
}

