using UnityEngine;
using System.Collections;

using SimpleJSON;
public class GVMapManager : AbstractMap
{
    private GVMapPlayer rPlayer;
    private GVStage[] _arrStages;
    void Awake()
    {
        rPlayer = (GVMapPlayer)player;
    }

    void Start()
    {
        _arrStages = new GVStage[2];
        _arrStages[0] = (GVStage)arrStages[0];
        _arrStages[1] = (GVStage)arrStages[1];
    }
    public override void SetupDoor(DoorInfo info)
    {

    }

    public override void SetupMap()
    {
        bool isAddEnemyStage1 = false;
        bool isAddEnemyStage2 = false;
        if (MapScreenManager.Instance.levelMap >= 1)
        {
            if (MapScreenManager.Instance.levelMap <= 4)
            {
                if (Random.Range(0, 2) == 0)
                {
                    isAddEnemyStage1 = true;
                }
                else
                {
                    isAddEnemyStage2 = true;
                }
            }
            else
            {

                isAddEnemyStage1 = true;

                isAddEnemyStage2 = true;

            }
        }
        for (int i = 0; i < _arrStages.Length; i++)
        {
            _arrStages[i].SetupStage(false, TYPE_GV_SEGMENT.LANE1, TYPE_GV_SEGMENT.LANE1, true);
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


}
