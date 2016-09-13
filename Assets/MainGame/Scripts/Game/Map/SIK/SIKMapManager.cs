using UnityEngine;
using System.Collections;
using System;
using SimpleJSON;
public class SIKMapManager : AbstractMap
{
    public override void SetupDoor(DoorInfo info)
    {

    }

    public override void SetupMap()
    {
        for (int i = 0; i < arrStages.Length; i++)
        {
            arrStages[i].SetupStage(false);
        }

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
