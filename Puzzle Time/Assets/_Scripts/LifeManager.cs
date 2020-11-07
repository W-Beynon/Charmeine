using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
	public int amtLives = 5;
	public PastLives[] pastLife;

	private int currRunning;
	private TimeKeeper timeKeep;
	
    // Start is called before the first frame update
    void Start()
    {
        currRunning = 0;
	timeKeep = gameObject.GetComponent<TimeKeeper>();
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
	if(currRunning < amtLives)
		pastLife[currRunning].addRound(pos);
    }
}
