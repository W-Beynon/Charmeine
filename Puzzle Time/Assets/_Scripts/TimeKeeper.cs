using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
<<<<<<< HEAD
	[SerializeField]
    private int round;
=======
    public int round;
>>>>>>> Kris-branch

    // Start is called before the first frame update
    void Start()
    {
        round = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increments the round
    public void incRound()
    {
        round++;
    }

    // Returns the round
    public int getRound()
    {
        return round;
    }

    // Resets the round counter
    public void resetRound()
    {
        round = 0;
    }
}
