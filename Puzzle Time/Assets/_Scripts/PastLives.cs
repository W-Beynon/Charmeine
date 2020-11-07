using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PastLives : MonoBehaviour
{
	public int amtMoves = 75;
	public TimeKeeper getTime;
	public float movementSpeed;

	private Vector3[] pastMoves;
	private int rounds;
	private int currRound;

    // Start is called before the first frame update
    void Start()
    {
        pastMoves = new Vector3[amtMoves];
	currRound = 0;
	gameObject.SetActive(false);
    }

    public void startIt(){
	gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
     //   movement();
    }

    public void addRound(Vector3 pos){
	pastMoves[currRound++] = pos;
    }

    public void movement(){
	transform.position = Vector3.MoveTowards(transform.position, pastMoves[getTime.getRound()], movementSpeed * Time.deltaTime);
    }
}
