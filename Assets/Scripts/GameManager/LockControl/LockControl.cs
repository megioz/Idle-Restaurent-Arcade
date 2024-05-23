using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockControl : MonoBehaviour
{
    public bool isUnlocked = false;
    public GameObject lockcontrol;
    public GameObject tableInRoom;
    public GameObject interaction;
    public int upgradeCost;
    public TextMeshPro cost;
    void Start()
    {
        tableInRoom.SetActive(false);
        interaction.SetActive(true);
        cost.text = upgradeCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1");
        if (collision.gameObject.tag != "NPC")
        {
            if (GameManager.Instance.Money >= upgradeCost)
            {
                GameManager.Instance.Money -= upgradeCost;
                lockcontrol.SetActive(false);
                interaction.SetActive(false);

                tableInRoom.SetActive(true);
                isUnlocked = true;

            }

        }
    }
}
