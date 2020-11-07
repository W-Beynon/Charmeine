using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateAction : Action
{
    public GameObject attachedObject;
    private bool weight;

    // Start is called before the first frame update
    void Start()
    {
        weight = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        performAction();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        performAction();
    }

    public override void performAction()
    {
        if (weight)
        {
            attachedObject.GetComponent<Action>().performAction();
            weight = false;
        }
        else
        {
            attachedObject.GetComponent<Action>().performAction();
            weight = true;
        }
    }
}
