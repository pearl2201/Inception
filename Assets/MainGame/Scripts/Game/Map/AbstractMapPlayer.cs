using UnityEngine;
using System.Collections;

public abstract class AbstractMapPlayer : MonoBehaviour {

    [SerializeField]
    private AbstractMap map;
    [SerializeField]
    private ParticleSystem parExplo;

    public abstract void Init();
    public abstract void Tap();
    public abstract void ChangeStage(int noStage);
    public abstract void ResetEnterStage();

    public IEnumerator IEExplosion()
    {
        yield return null;
    }


}
