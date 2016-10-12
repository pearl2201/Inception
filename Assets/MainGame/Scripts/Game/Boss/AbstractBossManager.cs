
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class AbstractBossManager : MonoBehaviour
{
    public AbstractBossPlayer player;
    public AbstractBoss boss;
    public int levelDiff; // fron 0-3
    public float lastPosIncLevelDiff;
    public static float DISTANCE_INC_LEVEL_DIFF = 20;
    public List<AbstractBossEnemy> listEnemeies = new List<AbstractBossEnemy>();
    public bool isBossStart;

    public abstract void UpdateCamera();


    public void SetupMap()
    {

    }

    public void CloseMap()
    {

    }

}

