using UnityEngine;
using System.Collections;

public class Prefs
{

    private static Prefs _instance;

    public static Prefs Instance
    {

        get
        {
            if (_instance == null)
            {
                _instance = new Prefs();

            }
            return _instance;
        }
    }

    public static string KEY_SOUND = "key_sound";
    public static string KEY_BESTSCORE = "key_best_score";
    public static string KEY_LASTSCORE = "key_last_score";
    public static string KEY_COUNT_PLAY = "key_count_play";
    public static string KEY_ANDROIDID = "key_androidid";
    public static string KEY_USERKEYCODE = "key_userkeycode";
    public static string KEY_KEYCODE = "key_keycode";
    public static string KEY_LAST_BOSS_DIFF = "last_boss_diff";

    public Prefs()
    {


    }

    public string GetKeyCode()
    {
        return PlayerPrefs.GetString(KEY_KEYCODE);
    }

    public void SetKeyCode(string key)
    {
        PlayerPrefs.SetString(KEY_KEYCODE, key);
    }

    public void SetUserKeyCode(string key)
    {
        PlayerPrefs.SetString(KEY_USERKEYCODE, key);
    }

    public string GetUserKeyCode()
    {
        return PlayerPrefs.GetString(KEY_USERKEYCODE);
    }

    public string GetAndroidID()
    {
        return PlayerPrefs.GetString(KEY_ANDROIDID);
    }

    public void SetAndroidId(string key)
    {
        Debug.Log("set android id: " + key);
        PlayerPrefs.SetString(KEY_ANDROIDID, key);
    }

    public int GetLastBossDiff(TYPE_WORLD typeBoss)
    {
        return PlayerPrefs.GetInt(KEY_LAST_BOSS_DIFF + ((int)typeBoss));
    }

    public void SetLastBossDiff(TYPE_WORLD typeBoss, int diff)
    {
        PlayerPrefs.SetInt(KEY_LAST_BOSS_DIFF + ((int)typeBoss), diff);
    }

    public void SetSound(bool on)
    {
        if (on)
        {
            PlayerPrefs.SetInt(KEY_SOUND, 1);
        }
        else
        {
            PlayerPrefs.SetInt(KEY_SOUND, 0);
        }

    }
    public bool isSoundOn()
    {
        return PlayerPrefs.GetInt(KEY_SOUND, 1) == 1;
    }
}
