using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TestItem : MonoBehaviour, ITakeable, IUsable
{
    //private Rigidbody rb;

    public void Drop()
    {
        Debug.Log("ups, dropped");
    }

    public void Take()
    {
        Debug.Log("Taken item");
    }

    public void Use()
    {
        Debug.Log("Item used");
    }

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
}
