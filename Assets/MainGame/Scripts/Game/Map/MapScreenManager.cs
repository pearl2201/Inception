using UnityEngine;
using System.Collections;

public class MapScreenManager : MonoBehaviour {

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



    public void CloseMap()
    {

    }

    public void SetupMap(DoorInfo doorInfo)
    {

    }
}
