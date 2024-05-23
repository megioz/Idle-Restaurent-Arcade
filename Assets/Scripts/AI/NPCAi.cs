using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAi : MonoBehaviour
{

    public GameObject interactImage;
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public bool isActive = false;
    public Animator anim;
    public NavMeshAgent Agent { get => agent; }
    [SerializeField]
    private string currentState;
    public Path path;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
    }
}
