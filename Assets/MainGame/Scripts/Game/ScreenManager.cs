using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour
{
    #region singleton
    private static ScreenManager _instance;

    public static ScreenManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    #endregion

    [HideInInspector]
    public Color color1, color2;

    [SerializeField]
    private MapScreenManager mapScreenManager;
    [SerializeField]
    private BossScreenManager bossScreenManager;


    public void OpenMapFirstPlay()
    {
        Config.lastDoorInfo = new DoorInfo(TYPE_WORLD.SIK, 8);
        mapScreenManager.SetupMap(Config.lastDoorInfo);
    }



    public void OpenLastMap()
    {

    }

    public void OpenLastBoss()
    {

    }

    public void CheckColor()
    {
        color1 = Color.white;
        color2 = Color.black;
        // thang nao can thi tu di ma lay, de singleton roi
    }

    public void OpenDoor(DoorInfo info)
    {
        Config.lastDoorInfo = info;
        if (info.TypeWorld == TYPE_WORLD.SIK && Config.currMode == TYPE_MODE.MAP)
        {
            bossScreenManager.gameObject.SetActive(true);
            mapScreenManager.CloseMap();
            mapScreenManager.gameObject.SetActive(false);
            bossScreenManager.SetupBoss();
        }
        else
        {
            mapScreenManager.gameObject.SetActive(true);
            bossScreenManager.CloseBoss();
            bossScreenManager.gameObject.SetActive(false);
            mapScreenManager.SetupMap(info);
        }
    }
}
