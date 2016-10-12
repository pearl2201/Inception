using UnityEngine;
using System.Collections;

public abstract class AbstractBossEnemy : MonoBehaviour
{
    public BOSS_ENEMY_STATE enemyState;
    public AbstractBossManager bossManager;
    public tk2dSprite img;
    protected Vector3 currPos;
    public virtual void SetStart()
    {
        enemyState = BOSS_ENEMY_STATE.MOVING;
    }

    public void RemoveSelf()
    {

        bossManager.listEnemeies.Remove(this);
        Destroy(gameObject);
    }

}
