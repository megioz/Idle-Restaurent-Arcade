using UnityEngine;
using System.Collections;
using System;

public class DynamicInterval : MonoBehaviour
{
    private IEnumerator coroutine;
    private float interval;
    private System.Action action;

    // Start the interval execution
    public void StartIntervalExecution(System.Action action, float interval)
    {
        this.action = action;
        this.interval = interval;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = ExecuteActionAtInterval();
        StartCoroutine(coroutine);
    }
    public void StopIntervalExecution()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
    // Coroutine that executes the action at intervals
    private IEnumerator ExecuteActionAtInterval()
    {
        while (true)
        {
            action?.Invoke();
            yield return new WaitForSeconds(interval);
        }
    }
}
