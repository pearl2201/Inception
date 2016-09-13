using UnityEngine;
using System.Collections;
using System;
using SimpleJSON;
public class GVMapManager : AbstractMap
{
    private GVMapPlayer rPlayer;

    void Awake()
    {
        rPlayer = (GVMapPlayer)player;
    }
    public override void SetupDoor(DoorInfo info)
    {

    }

    public override void SetupMap()
    {
        TYPE_GV_SEGMENT typeSegmentAdd = TYPE_GV_SEGMENT.LANE1;
        TYPE_GV_SEGMENT virtualSegment = TYPE_GV_SEGMENT.LANE1;


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


}
