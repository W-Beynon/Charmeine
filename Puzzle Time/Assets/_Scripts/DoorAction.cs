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
    private TileBase door2;
    private Tilemap postDoors;
    private Tilemap doors;
    private GameObject tileDoors;
    private TilemapRenderer doorsRender;

    // Start is called before the first frame update
    void Start()
    {
        lifted = false;
        wall = (Tilemap)GameObject.Find("Wall").GetComponent(typeof(Tilemap));
        postDoors = (Tilemap)GameObject.Find("PostDoors").GetComponent(typeof(Tilemap));
        doors = (Tilemap)GameObject.Find("Doors").GetComponent(typeof(Tilemap));
        doorPos = wall.WorldToCell(transform.position);
        doorPos.x = doorPos.x;
        doorPos.y = doorPos.y;
        doorPos.z = 0;
        door = wall.GetTile(doorPos);
        door2 = doors.GetTile(doorPos);
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
            postDoors.SetTile(doorPos, null);
        }
        else
        {
            // lifts door
            lifted = true;
            postDoors.SetTile(doorPos, door2);
            wall.SetTile(doorPos, null);
        }
    }
}
