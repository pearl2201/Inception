
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public abstract class AbstractBoss : MonoBehaviour
{
    public int hpBoss;
    public tk2dSprite imgMinhHoa;
    public AbstractBossManager bossManager;
    public void AttackHpBoss()
    {
        hpBoss--;
        BossScreenManager.Instance.txtHpBoss.text = hpBoss + "";
        if (hpBoss <= 0)
        {
            BossScreenManager.Instance.NextMap();
        }
    }

    public void InscreateHpBoss()
    {
        hpBoss++;
        BossScreenManager.Instance.txtHpBoss.text = hpBoss + "";
    }

    protected float timeWaitGenEnemy = 1f;
    protected float eScaleTimeWait = 1;

    public abstract void SetupEnemy();

    public abstract void GenEnemy();

    public abstract void UpdateMoving();

    public void StartIEWaitGenEnemy()
    {
        StartCoroutine(IEWaitGenEnemy());
    }

    public IEnumerator IEWaitGenEnemy()
    {
        yield return new WaitForSeconds(timeWaitGenEnemy * eScaleTimeWait);
        GenEnemy();
    }



}

