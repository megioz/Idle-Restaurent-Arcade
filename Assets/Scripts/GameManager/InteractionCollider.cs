using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionCollider : MonoBehaviour
{
    public GameObject npc;
    public GameObject interaction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "NPC"  )
        {
            if (npc.GetComponent<NPCAi>().isActive == true && GameManager.Instance.Pizza >0)
            {   
                
                GameManager.Instance.Money += 50;
                GameManager.Instance.Pizza -= 1;
                interaction.SetActive(false);
                npc.GetComponent<NPCAi>().isActive = false;
            }
        }
    }
}
