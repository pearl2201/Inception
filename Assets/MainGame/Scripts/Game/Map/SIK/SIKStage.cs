
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SIKStage : AbstractMapStage
{

    [SerializeField]
    private GameObject modelSIKMapEnemy;
    public override void SetupStage(bool isHasDoor)
    {
        float defaultLengthSegment = 3f;
        if (MapScreenManager.Instance.levelMap < 7)
        {
            defaultLengthSegment = 5.2f - MapScreenManager.Instance.levelMap * 0.15f;
        }

        float posStartSegment = -6.4f;

        List<float> listPosStartSegment = new List<float>();
        List<int> listTypeEnemySegment = new List<int>();
        listPosStartSegment.Add(posStartSegment);
        while (posStartSegment + 2.5f < 6.4f)
        {
            float lengthSegment = Random.Range(2.5f, defaultLengthSegment);
            posStartSegment += lengthSegment;
            int typeSegment = Random.Range(0, MapScreenManager.Instance.levelMap + 1);
            listPosStartSegment.Add(posStartSegment);
            listTypeEnemySegment.Add(typeSegment);
        }

        for (int i = 0; i < listPosStartSegment.Count; i++)
        {
            listPosStartSegment[i] = listPosStartSegment[i] + i * (6.4f - posStartSegment) / (listPosStartSegment.Count - 1);
        }

        if (isHasDoor)
        {
            int r = Random.Range(0, listTypeEnemySegment.Count);
            listTypeEnemySegment[r] = -1;
        }

        // render to map
        for (int i = 0; i < listTypeEnemySegment.Count; i++)
        {
            if (listTypeEnemySegment[i] != -1)
            {
                GameObject go = Instantiate(modelSIKMapEnemy) as GameObject;
                go.transform.SetParent(transform);
                if (idStage == 0)
                    go.transform.localPosition = new Vector3((listPosStartSegment[i] + listPosStartSegment[i + 1]) * 0.5f, baseYStage, 0);
                else
                {
                    go.transform.localPosition = new Vector3(-(listPosStartSegment[i] + listPosStartSegment[i + 1]) * 0.5f, baseYStage, 0);
                }
                listEnemies.Add(go);
                SIKMapEnemy enemyScript = go.GetComponent<SIKMapEnemy>();
        enemyScript.SetColor(subColor);
        if (listTypeEnemySegment[i] == 0)
        {
            // BASIC = 0,
            enemyScript.SetupBasic();
        }
        else if (listTypeEnemySegment[i] == 1)
        {
            //  DYNAMIC_HEIGHT = 1,
            enemyScript.SetupDynamicHeight();
        }
        else if (listTypeEnemySegment[i] == 2)
        {
            //  DYNAMIC_WEIGHT_BOT = 2,
            enemyScript.SetupDynamicWeightBot();
        }
        else if (listTypeEnemySegment[i] == 3)
        {
            // STATIC_HEIGHT = 3,
            enemyScript.SetupStaticHeight();
        }
        else if (listTypeEnemySegment[i] == 4)
        {
            //  STATIC_WEIGHT_BOT = 4,
            enemyScript.SetupStaticWeightBot();
        }
        else if (listTypeEnemySegment[i] == 5)
        {
            // STATIC_WEIGHT_TOP = 5,
            enemyScript.SetupStaticWeightTop();
        }
        else if (listTypeEnemySegment[i] == 6)
        {
            // MOVING_BASIC = 6,
            enemyScript.SetupMovingBasic();
        }
        else if (listTypeEnemySegment[i] == 7)
        {
            // TOP_BOT_ATTACK = 7,
            // that ra la install them 1 cai o tren lam mau, move len move xuong thoi, dam bao hok cham vao bo con thang nao
            enemyScript.SetupTopBotAtt(false);
        }
        else
        {
            enemyScript.SetupStaticHeight();
        }

    }
}
    }




   
}

