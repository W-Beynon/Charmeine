using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorAction : Action
{
    private bool lifted;
    public Tilemap wall;
    private Vector3Int doorPos;
    private TileBase door;
    private Tilemap doors;

    // Start is called before the first frame update
    void Start()
    {
        lifted = false;
        wall = (Tilemap)GameObject.Find("Wall").GetComponent(typeof(Tilemap));
        doors = (Tilemap)GameObject.Find("Doors").GetComponent(typeof(Tilemap));
        doorPos = wall.WorldToCell(transform.position);
        doorPos.x = doorPos.x;
        doorPos.y = doorPos.y;
        doorPos.z = 0;
        door = wall.GetTile(doorPos);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void performAction()
    {
        if(lifted)
        {
            // drops door
            lifted = false;
            wall.SetTile(doorPos, door);
            doors.SetTile(doorPos, null);
        }
        else
        {
            // lifts door
            Debug.Log(door);
            lifted = true;
            doors.SetTile(doorPos, door);
            wall.SetTile(doorPos, null);
        }
    }
}
