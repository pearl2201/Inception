using UnityEngine;
using System.Collections;

public class DoorInfo
{

    private TYPE_WORLD typeWorld; // GV, AR, SIK
    private int levelWorld; // 1->8

    public DoorInfo(TYPE_WORLD typeWorld, int levelWorld)
    {
        this.typeWorld = typeWorld;
        this.levelWorld = levelWorld;
    }
    public DoorInfo()
    {

    }

    public TYPE_WORLD TypeWorld
    {
        get
        {
            return typeWorld;
        }

        set
        {
            typeWorld = value;
        }
    }

    public int LevelWorld
    {
        get
        {
            return levelWorld;
        }

        set
        {
            levelWorld = value;
        }
    }

    public string ToName()
    {
        return GetNameDoor(typeWorld, levelWorld);
    }

    public int ToValue()
    {
        return GetValueDoor(typeWorld, levelWorld);
    }

    public static string GetNameDoor(TYPE_WORLD typeWorld, int levelWorld)
    {
        string s = "" + levelWorld;
        if (typeWorld == TYPE_WORLD.AR)
        {
            s = s + "B";
        }
        else if (typeWorld == TYPE_WORLD.GV)
        {
            s = s + "A";
        }
        else if (typeWorld == TYPE_WORLD.SIK)
        {
            s = s + "C";
        }
        return s;
    }

    public static int GetValueDoor(TYPE_WORLD typeWorld, int levelWorld)
    {
        int v = 0;
        if (typeWorld == TYPE_WORLD.AR)
        {
            v = 10;
        }
        else if (typeWorld == TYPE_WORLD.GV)
        {
            v = 0;
        }
        else if (typeWorld == TYPE_WORLD.SIK)
        {
            v = 20;
        }
        v += levelWorld;
        return v;
    }

    public static DoorInfo GetDoorInfoFromName(string doorcode)
    {
        DoorInfo dinfo = new DoorInfo();
        dinfo.levelWorld = int.Parse(doorcode[0].ToString());
        if (doorcode[1].Equals('A'))
        {
            dinfo.typeWorld = TYPE_WORLD.GV;
        }
        else if (doorcode[1].Equals('B'))
        {
            dinfo.typeWorld = TYPE_WORLD.AR;
        }
        else
        {
            dinfo.typeWorld = TYPE_WORLD.SIK;
        }
        return dinfo;
    }

    public static DoorInfo GetDoorInfoFromValue(int doorvalue)
    {
        DoorInfo dinfo = new DoorInfo();
        dinfo.levelWorld = doorvalue % 10;
        if (doorvalue / 10 == 0)
        {
            dinfo.typeWorld = TYPE_WORLD.GV;
        }
        else if (doorvalue / 10 == 1)
        {
            dinfo.typeWorld = TYPE_WORLD.AR;
        }
        else
        {
            dinfo.typeWorld = TYPE_WORLD.SIK;
        }
        return dinfo;
    }

}
