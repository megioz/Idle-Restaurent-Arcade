using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    public float time;
    [SerializeField]
    public DynamicInterval dynamicInterval;
    public int Money = 200;
    public int Pizza = 0;
    public TextMeshProUGUI money;
    public TextMeshProUGUI pizza;
    public GameObject[] npc;
    public LockControl[] tableLock;
    private void Awake()
    {
    }
    private void Update()
    {
        time += Time.deltaTime;
        money.text = Money.ToString();
        pizza.text = Pizza.ToString();
        for (int i = 0; i < tableLock.Length; i++)
        {
            if (tableLock[i].isUnlocked == true)
            {
                npc[i].gameObject.SetActive(true);
            }
        }
    }


}
