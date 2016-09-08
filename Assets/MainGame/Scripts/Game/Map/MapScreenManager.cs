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

    public AbstractMap currMap;
}
