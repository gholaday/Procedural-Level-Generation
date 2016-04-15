using UnityEngine;
using System.Collections;

public class GenerateLevel : MonoBehaviour {

	[Tooltip("The max size of the level in levelSize * levelSize squares")]
	[Range(3,8)]
	public int levelSize = 4;

	public Room[,] rooms;
	Room endRoom;
	Room startRoom;

	// Use this for initialization
	void Awake () {

		rooms = new Room[levelSize,levelSize];

		InitializeRooms();

		GenerateRoomType();

		PrintDebugRoom();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeRooms()
	{
		int i,j;

		for(i=0;i<rooms.GetLength(0);i++)
		{
			for(j=0;j<rooms.GetLength(1);j++)
			{
				rooms[i,j] = new Room();
				rooms[i,j].id = (i*levelSize) + j;
				rooms[i,j].x = j;
				rooms[i,j].y = i;
			}
		}
			

	}

	void GenerateRoomType()
	{
		int start, roomX, roomY, prevX, prevY, n;
		bool down = false;


		start = Random.Range(0,levelSize);

		roomX = start;
		roomY = 0;

		prevX = start;
		prevY = 0;

		rooms[roomY, roomX].type = 1;
		startRoom = rooms[roomY, roomX];

		while(roomY < 4)
		{
			down = false;

			n = Random.Range(0,5);

			if(n == 0 || n == 1)		//move left
			{
				if(roomX > 0)
				{
					if(rooms[roomY, roomX-1].type == 0) roomX -= 1;
				}
				else if(roomX < levelSize-1)
				{
					if(rooms[roomY, roomX+1].type == 0) roomX += 1;
				}
				else
				{
					n = 2;	
				}
			}
			else if(n == 3 || n == 4)	//move right
			{
				if(roomX < levelSize-1)
				{
					if(rooms[roomY, roomX+1].type == 0) roomX += 1;
				}
				else if(roomX > 0)
				{
					if(rooms[roomY, roomX-1].type == 0) roomX -= 1;
				}
				else
				{
					n = 2;	
				}
			}

			if(n == 2)		//move down
			{
				roomY += 1;
				down = true;

				if(roomY < 4)
				{
					rooms[prevY, prevX].type = 2;
					rooms[roomY, roomX].type = 3;
				}
				else
				{
					endRoom = rooms[roomY-1, roomX];
				}
			}

			if(down == false)
			{
				rooms[roomY, roomX].type = 1;
			}

			prevX = roomX;
			prevY = roomY;
		
		}
			
	}

	void PrintDebugRoom()
	{
		string p = "";

		for(int i=0;i<rooms.GetLength(0);i++)
		{
			for(int j=0;j<rooms.GetLength(1);j++)
			{
				p += rooms[i,j].type + " ";

				if((j + 1) % 4 == 0) p += "\n";
			}

		}

		print(p);
	}

	public Room GetStartRoom()
	{
		return startRoom;
	}

	public Room GetEndRoom()
	{
		return endRoom;
	}


	/*
	void FillRooms()
	{
		int i,j;
		GameObject go;

		for(i=0;i<rooms.GetLength(0);i++)
		{
			for(j=0;j<rooms.GetLength(1);j++)
			{
				if(rooms[i,j].type == 0) go = (GameObject)Instantiate(blankObj, new Vector3(j,-i,0), Quaternion.identity);
				else go = (GameObject)Instantiate(pathObj, new Vector3(j,-i,0), Quaternion.identity);

				if(rooms[i,j] == startRoom) go.GetComponent<SpriteRenderer>().color = Color.green;

				if(rooms[i,j] == endRoom) go.GetComponent<SpriteRenderer>().color = Color.red;
			}
		}
	}
	*/

}

/*
0 0 0 0
0 0 0 0
0 0 0 0
0 0 0 0
*/
