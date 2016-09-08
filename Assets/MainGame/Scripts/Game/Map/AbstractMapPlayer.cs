using UnityEngine;
using System.Collections;

public abstract class AbstractMapPlayer : MonoBehaviour {

    [SerializeField]
    private AbstractMap map;


    public abstract void Init();
    public abstract void Tap();
    public abstract void ChangeStage(int noStage);
}
