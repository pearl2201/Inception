using UnityEngine;
using System.Collections;

public abstract class AbstractMapPlayer : MonoBehaviour {

    [SerializeField]
    protected AbstractMap map;
    [SerializeField]
    protected ParticleSystem parExplo;

    public MAP_PLAYER_STATE playerState;

    protected float baseYStage; // defind in changeState hoac init;
    protected Vector3 currPos;
    protected float sizeX;
    protected float sizeY;
    public abstract void Init();
    public abstract void Tap();
    public abstract void ChangeStage(int noStage);
    public abstract void ResetEnterStage();

    public IEnumerator IEExplosion()
    {
        yield return null;
    }

}
