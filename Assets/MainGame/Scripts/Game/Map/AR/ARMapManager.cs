using UnityEngine;
using System.Collections;
using System;
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
        // setup lane 2 and lane 3 first


        // chia ra 2 the loai
        // setup lane 1 and lane 4 here

        // setup door here

        // setup map here
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
