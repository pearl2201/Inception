using UnityEngine;
using System.Collections;

public class GameScreenManager : MonoBehaviour
{
    #region singleton
    private static GameScreenManager _instance;

    public static GameScreenManager Instance
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

    public tk2dSprite bgTop;
    public tk2dSprite bgBot;



    void Start()
    {
        OpenMapFirstPlay(); 
    }

    public void OpenMapFirstPlay()
    {
        //TODO: tat check color
        CheckColor();  
        Config.lastDoorInfo = new DoorInfo(TYPE_WORLD.GV, 8);
        mapScreenManager.SetupMap(Config.lastDoorInfo);
    }

    public void Tap()
    {
        if (Config.currMode == TYPE_MODE.BOSS)
        {
            bossScreenManager.Tap();
        }else
        {
            mapScreenManager.Tap();
        }
    }

    public void OpenLastMap()
    {
        CheckColor();
    }

    public void OpenLastBoss()
    {
        CheckColor();
    }

    public void CheckColor()
    {
        color1 = Color.white;
        color2 = Color.black;
        bgTop.color = color1;
        bgBot.color = color2;
        // thang nao can thi tu di ma lay, de singleton roi
    }

    public void OpenDoor(DoorInfo info)
    {
        Config.lastDoorInfo = info;
        CheckColor();
        if (info.TypeWorld == TYPE_WORLD.SIK && Config.currMode == TYPE_MODE.MAP)
        {
            Config.currMode = TYPE_MODE.BOSS;
            bossScreenManager.gameObject.SetActive(true);
            mapScreenManager.CloseMap();
            mapScreenManager.gameObject.SetActive(false);
            bossScreenManager.SetupBoss();
        }
        else
        {
            Config.currMode = TYPE_MODE.MAP;
            mapScreenManager.gameObject.SetActive(true);
            bossScreenManager.CloseBoss();
            bossScreenManager.gameObject.SetActive(false);
            mapScreenManager.SetupMap(info);
        }
    }
}
