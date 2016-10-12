
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SIKBoss : AbstractBoss
{
    [SerializeField]
    private GameObject modelEnemy;
    public override void GenEnemy()
    {
        int r = Random.Range(0, bossManager.levelDiff + 1);
        List<V2F> listPosX = new List<V2F>();
        List<V2F> listScaleX = new List<V2F>();

        if (r == 0)
        {
            listPosX.Add(new V2F(0, 0));
            listScaleX.Add(new V2F(1f, 1f));

            eScaleTimeWait = 1;
        }
        else if (r == 1)
        {
            listPosX.Add(new V2F(0, 0));
            listScaleX.Add(new V2F(1f, 1f));
            listPosX.Add(new V2F(0.55f, 0));
            listScaleX.Add(new V2F(1f, 1.75f));
            listPosX.Add(new V2F(1.1f, 0));
            listScaleX.Add(new V2F(1f, 2.2f));
            eScaleTimeWait = 1.2f;
        }
        else if (r == 2)
        {
            listPosX.Add(new V2F(0, 0));
            listScaleX.Add(new V2F(1f, 2.5f));
            listPosX.Add(new V2F(0.55f, 0));
            listScaleX.Add(new V2F(1f, 1.75f));
            listPosX.Add(new V2F(1.1f, 0));
            listScaleX.Add(new V2F(1f, 1f));
            eScaleTimeWait = 1.2f;
        }
        else if (r == 3)
        {

            r = Random.Range(0, 2) == 0 ? 3 : 5;
            bool down = true;
            for (int i = 0; i < r; i++)
            {
                if (down)
                {
                    listPosX.Add(new V2F(1.1f * i, 0));
                }
                else
                {
                    listPosX.Add(new V2F(1.1f * i, 1));
                }
                listScaleX.Add(new V2F(1f, 1f));
            }
            eScaleTimeWait = 0.8f + 0.2f * r;
        }
        for (int i = 0; i < listPosX.Count; i++)
        {
            GameObject go = Instantiate(modelEnemy) as GameObject;
            go.transform.position = new Vector3(transform.position.x + listPosX[i].X, transform.position.y + listPosX[i].Y, transform.position.z);
            SIKBossEnemy enemyScript = go.GetComponent<SIKBossEnemy>();
            enemyScript.Setup(listPosX[i].Y, BossScreenManager.Instance.subColor);
            bossManager.listEnemeies.Add(enemyScript);
            if (bossManager.isBossStart)
            {
                enemyScript.SetStart();
            }
        }
        if (bossManager.isBossStart)
        {
            StartCoroutine(IEWaitGenEnemy());
        }
    }

    public override void SetupEnemy()
    {
        GenEnemy();
    }

    public override void UpdateMoving()
    {
        // co che
        // 
    }
}

