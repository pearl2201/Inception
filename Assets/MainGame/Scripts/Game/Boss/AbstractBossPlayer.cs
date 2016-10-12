
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public abstract class AbstractBossPlayer : MonoBehaviour
{
    public BOSS_PLAYER_STATE playerState;
    public ParticleSystem parExplo;
    protected float sizeX;
    protected float sizeY;
    protected Vector3 currPos;
    protected Vector3 currRot;
    protected float baseYStage;
    public AbstractBossManager bossManager;

    public abstract void Setup();

    public abstract void SetStart();

    public abstract void Tap();

    public abstract void Dying();
}

