using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    //public GameObject upgrade;
    [SerializeField]
    private GameObject[] levels;
    public StatSO[] statSO;
    public int currentLv = 0;
    public bool finalUpgrade;
    //public GameObject interaction;
    // Start is called before the first frame update

    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag != "NPC")
        {
            if(GameManager.Instance.Money >= statSO[currentLv].upGradeCost)
            {
               
                GameManager.Instance.Money -= statSO[currentLv].upGradeCost;
                Upgradelv();
            }
        }
    }
    public void Upgradelv()
    {
        if (currentLv < levels.Length -1 )
        {
            currentLv++;
            SwitchObject(currentLv);

            SwitchStat(currentLv);
          
        }
    }
    void SwitchObject(int lv)
    {
        for(int i = 0; i< levels.Length; i++)
        {
            if (i == lv)
            {
                levels[i].SetActive(true);

            }
            else
                levels[i].SetActive(false);
        }
    }
    void SwitchStat(int lv)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (i == lv)
            {
                statSO[i] = statSO[lv];
                if (lv == levels.Length -1)
                {
                Debug.Log(statSO[i]);
                    finalUpgrade = true;
                }
            }
        }
    }


    
}
