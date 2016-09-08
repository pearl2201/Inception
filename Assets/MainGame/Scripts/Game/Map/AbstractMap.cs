using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleJSON;
using UnityEngine;
public abstract class AbstractMap : MonoBehaviour
{

    public abstract void SetupDoor(DoorInfo info);
    public abstract void SetupMap();
    public abstract JSONClass EncodeMap();
    public abstract void DecodeMap(JSONClass data);
    public abstract void CloseMap();
    public AbstractMapStage[] arrStages;
    public List<DoorInfo> listDoor;

    public AbstractMapPlayer player;
    public void SetColor(Color c1, Color c2)
    {
        arrStages[0].SetColor(c1, c2);
        arrStages[1].SetColor(c2, c1);
    }

    /* Create list door in currword by info door of previous door
     * 
     */
    public void CreateListDoor(DoorInfo info)
    {
        listDoor.Clear();
        if (info.LevelWorld == 8)
        {
            for (int i = 1; i < 9; i++)
            {
                listDoor.Add(new DoorInfo(info.TypeWorld, i));
            }
        }
        else
        {
            for (int i = info.LevelWorld + 1; i < 9; i++)
            {
                listDoor.Add(new DoorInfo(info.TypeWorld, i));
            }
            for (int i = 1; i < info.LevelWorld + 1; i++)
            {
                listDoor.Add(new DoorInfo(info.TypeWorld, i));
            }
        }
    }

    /*
     * Get first door, move it to last listDoor;
     * 
     */
    public DoorInfo PopDoorInfo()
    {
        DoorInfo doorInfo = listDoor[0];
        for (int i = 0; i < listDoor.Count - 1; i++)
        {
            listDoor[i] = listDoor[i + 1];
        }
        listDoor[7] = doorInfo;
        return doorInfo;
    }

   

}

