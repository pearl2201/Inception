using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Door : MonoBehaviour
{

    private DoorInfo info;

    [SerializeField]
    private tk2dSprite sprite;

    [SerializeField]
    private tk2dTextMesh txt;
    public void Setup(DoorInfo info, Color colorBg, Color colorItem ,float posX, float posY)
    {
        sprite.color = colorBg;
        txt.color = colorItem;
        
        Vector3 tmpPos = transform.position;
        tmpPos.x = posX;
        tmpPos.y = posY;
        transform.position = tmpPos;
        this.info = info;
        txt.text = info.ToName();
    }
}

