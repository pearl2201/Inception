using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
public abstract class AbstractMap : MonoBehaviour
{
    public AbstractMapStage[] arrStages;
    public List<DoorInfo> listDoor;

    public void SetColor(Color c1, Color c2)
    {
        arrStages[0].SetColor(c1, c2);
        arrStages[1].SetColor(c2, c1);
    }

    public void CreateListDoor(DoorInfo info)
    {
        listDoor.Clear();
        if (info.LevelWorld == 8)
        {
            for (int i =1; i<9; i++)
            {
                listDoor.Add(new DoorInfo(info.TypeWorld, i));
            }
        }else
        {
            for (int i = info.LevelWorld+1; i<9;i++)
            {
                listDoor.Add(new DoorInfo(info.TypeWorld, i));
            }
            for (int i = 1; i<info.LevelWorld+1; i++)
            {
                listDoor.Add(new DoorInfo(info.TypeWorld, i));
            }
        }
    }

    
}

