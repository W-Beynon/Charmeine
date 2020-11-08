using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PastLives : MonoBehaviour
{
	public int amtMoves = 75;
	public TimeKeeper getTime;
	public float movementSpeed;

	public Vector3[] pastMoves;
	private int rounds;
	private int currRound;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
        pastMoves = new Vector3[amtMoves];
	    currRound = 0;
        ((MeshRenderer)GetComponent(typeof(MeshRenderer))).enabled = false;
    }

    public void startIt(){
        ((MeshRenderer)GetComponent(typeof(MeshRenderer))).enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //   movement();
    }

    public void setStartPos(Vector3 s)
    {
        startPos = s;
    }

    public void addRound(Vector3 pos){
	    pastMoves[currRound++] = pos;
    }

    public void movement()
    {
        transform.position = pastMoves[getTime.getRound()];
        // transform.position = Vector3.MoveTowards(transform.position, pastMoves[getTime.getRound()], movementSpeed * Time.deltaTime);
    }

    public void setMoves(Vector3[] moves)
    {
        pastMoves = moves;
    }
}
