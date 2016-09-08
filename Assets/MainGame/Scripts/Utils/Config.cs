
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Config
{
    public static float SCREEN_WIDTH = 12.8f;
    public static float SCREEN_HEIGHT = 7.2f;
    public static string KEYCODE = "";
    public static string USER_KEY = "";
    public static TYPE_MODE currMode;
    public static TYPE_WORLD currWorld;
    public static DoorInfo lastDoorInfo;


    public static string GenKeyCode()
    {
        string keycode = Random.Range(1, 9).ToString("00") + Random.Range(11, 19).ToString("00") + Random.Range(21, 29).ToString("00");
        return keycode;
    }
}

public enum TYPE_WORLD : int
{
    SIK = 0,
    GV = 1,
    AR = 2
}

public enum TYPE_MODE : int
{
    MAP = 0,
    BOSS = 1
}
