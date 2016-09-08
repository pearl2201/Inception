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

    public void CheckColor()
    {
        color1 = Color.white;
        color2 = Color.black;
        mapScreenManager.currMap.SetColor(color1, color2);
    }
}
