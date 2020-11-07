using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : Action
{
    public GameObject attachedObject;
    private bool on;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            attachedObject.GetComponent<Action>().performAction();
        }
    }

    public override void performAction()
    {
        if (on)
        {
            on = false;
        }
        else
        {
            on = true;
        }
    }
}
