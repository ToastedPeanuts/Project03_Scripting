using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour
{
    public UnityEvent onEnterTrigger;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //validate object; ie can certain things work with the trigger?
        //Will call whatever is set in the list to trigger
        Debug.Log("Entered");
        onEnterTrigger.Invoke();


    }
}
