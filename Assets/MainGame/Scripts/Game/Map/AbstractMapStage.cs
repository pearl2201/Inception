using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class AbstractMapStage : MonoBehaviour
{
    public float baseYStage;
    public Color mainColor;
    public Color subColor;
    public int idStage; //  0->1
    public List<GameObject> listEnemies;
    public abstract void SetupStage(bool isHasDoor);
    public void Clear()
    {
        for (int i = 0; i < listEnemies.Count; i++)
        {
            Destroy(listEnemies[i].gameObject);



        }
        listEnemies.Clear();
    }
    public void SetColor(Color mainColor, Color subColor)
    {
        this.mainColor = mainColor;
        this.subColor = subColor;
    }
}

