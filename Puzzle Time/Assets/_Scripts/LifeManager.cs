using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
	public int amtLives = 5;
	public PastLives[] pastLife;

    [SerializeField]
	private int currRunning;
	private TimeKeeper timeKeep;
	
    // Start is called before the first frame update
    void Start()
    {
        currRunning = 0;
	    timeKeep = gameObject.GetComponent<TimeKeeper>();
    }

    public void setStartPos(Vector3 s)
    {
        for(int i=0; i < amtLives; i++)
        {
            pastLife[i].setStartPos(s);
        }
    }

    public void setMoves(Vector3[] s)
    {
        if(currRunning < amtLives)
            pastLife[currRunning].setMoves(s);
    }

    public void addLife(){
	    if(currRunning < amtLives){
		    pastLife[currRunning].startIt();
		    for(int i = 0; i < currRunning; i++){
			    pastLife[i].movement();
		    }
            currRunning++;
	    }
	
    }
    
    public void addAction(Vector3 pos){
	    for(int i = 0; i < currRunning; i++){
		    pastLife[i].movement();
	    }
	    /*if(currRunning < amtLives)
		    pastLife[currRunning].addRound(pos);*/
    }
}
