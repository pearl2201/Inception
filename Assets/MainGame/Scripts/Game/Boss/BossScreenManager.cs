using UnityEngine;
using System.Collections;

public class BossScreenManager : MonoBehaviour
{

    private static BossScreenManager _instance;

    public static BossScreenManager Instance
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

    public tk2dTextMesh txtHpBoss;

    public AbstractBossManager sikBossManager;
    public AbstractBossManager gvBossManager;
    public AbstractBossManager arBossMaanger;

    public AbstractBossManager currMap;


    public Color mainColor;
    public Color subColor;
    public void Tap()
    {
        currMap.player.Tap();
    }
    public void SetupBoss()
    {
        currMap = sikBossManager;
        currMap.SetupMap();
    }

    public void CloseBoss()
    {
        currMap.CloseMap();

    }

    public void NextMap()
    {
        GameScreenManager.Instance.OpenDoor(Config.lastDoorInfo);
    }

    public void SetupColor(Color mainColor, Color subColor)
    {
        this.mainColor = mainColor;
        this.subColor = subColor;
    }
}
