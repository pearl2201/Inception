using UnityEngine;
using System.Collections;

public class MapScreenManager : MonoBehaviour
{

    #region singleton
    private static MapScreenManager _instance;

    public static MapScreenManager Instance
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
    public AbstractMap currMap;
    [SerializeField]
    private SIKMapManager sikMap;
    [SerializeField]
    private GVMapManager gvMap;
    [SerializeField]
    private ARMapManager arMap;
    [HideInInspector]
    public int idStage = 0;

    public int levelMap;
    public void Tap()
    {
        if (currMap != null)
        {
            currMap.player.Tap();
        }
    }

    public void CloseMap()
    {

    }

    public void SetupMap(DoorInfo doorInfo)
    {
        if (doorInfo.TypeWorld == TYPE_WORLD.AR)
        {
            currMap = arMap;
        }
        else if (doorInfo.TypeWorld == TYPE_WORLD.GV)
        {
            currMap = gvMap;
        }
        else
        {
            currMap = sikMap;
        }
        currMap.gameObject.SetActive(true);
        currMap.SetColor(GameScreenManager.Instance.color1, GameScreenManager.Instance.color2);
        currMap.SetupMap();
        currMap.player.Init();
    }
}
