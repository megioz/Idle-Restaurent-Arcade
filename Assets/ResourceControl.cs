using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceControl : MonoBehaviour
{
    bool isActive;
    public Upgrade upgrade;
    public GameObject interaction;
    public TextMeshPro cost;
    public GameObject costAnnounce;
    void OnEnable()
    {
        GameManager.Instance.dynamicInterval.StartIntervalExecution(ResourceSpawn, upgrade.statSO[upgrade.currentLv].speed);
        if (upgrade.currentLv < upgrade.statSO.Count())
        {
            cost.text = upgrade.statSO[upgrade.currentLv].upGradeCost.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void ResourceSpawn()
    {
        interaction.SetActive(true);
        isActive = true;

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "NPC")
        {
            if (upgrade.finalUpgrade == true)
            {
                Debug.Log("!");
                costAnnounce.gameObject.SetActive(false);
            }
            if (isActive == true && GameManager.Instance.Pizza == 0)
            {
                interaction.SetActive(false);
                GameManager.Instance.Pizza += 1; 
            }

        }
    }
}
