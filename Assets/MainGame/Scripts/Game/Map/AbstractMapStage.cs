using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class AbstractMapStage : MonoBehaviour
{
    public Color mainColor;
    public Color subColor;
    public int stage; //  0->1

    public abstract void SetupStage(bool isHasDoor);
    public void SetColor(Color mainColor, Color subColor)
    {
        this.mainColor = mainColor;
        this.subColor = subColor;
    }
}

