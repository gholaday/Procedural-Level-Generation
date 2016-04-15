using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
	This algorithm will attempt to fill each room with a randomly chosen 10x8 "template" of my own design. The template is made up of an array of strings,
	10 chars long and the array has a length of 8


*/
public class FillRoom : MonoBehaviour {


	public GameObject blank;
	public GameObject dirt;

	GenerateLevel level;

	List<StringArray> rooms_0 = new List<StringArray>();
	List<StringArray> rooms_1 = new List<StringArray>();
	List<StringArray> rooms_2 = new List<StringArray>();
	List<StringArray> rooms_3 = new List<StringArray>();

	class StringArray
	{
		public string[] template;

		public StringArray(string[] a)
		{
			template = a;
		}

		int Length()
		{
			return template.Length;
		}

	}





	void Start () {

		rooms_0.Add(new StringArray(
			new string[]{
				"1111111111",
				"1111111111",
				"1110000111",
				"1110000111",
				"1110000111",
				"1110000111",
				"1111111111",
				"1111111111"
			}

		));

		rooms_0.Add(new StringArray(
			new string[]{
				"1111111111",
				"1111111111",
				"1111111111",
				"1111111111",
				"1111111111",
				"1111111111",
				"1111111111",
				"1111111111"
			}

		));
		
		rooms_1.Add(new StringArray(
			new string[]{
			"1111111111",
			"1000000001",
			"0000000000",
			"0000000000",
			"1111111111",
			"1111111111",
			"1111111111",
			"1111111111"
			}
		
		));

		rooms_1.Add(new StringArray(
			new string[]{
			"1111111111",
			"1110000111",
			"0000000000",
			"1110000000",
			"1110001111",
			"1110001111",
			"1111111111",
			"1111111111"
			}

		));

		rooms_2.Add(new StringArray(
			new string[]{
				"0000000000",
				"0000000000",
				"1100000000",
				"1110000001",
				"1110001111",
				"1110000111",
				"1110000111",
				"1111100111"
			}

		));

		rooms_2.Add(new StringArray(
			new string[]{
				"0000000000",
				"0000000000",
				"1100000000",
				"1110000001",
				"1110001111",
				"1110000001",
				"1111111001",
				"1111100011"
			}

		));

		rooms_3.Add(new StringArray(
			new string[]{
				"0000000000",
				"0000000111",
				"1100000011",
				"0000000000",
				"1110001111",
				"1111111111",
				"1111111111",
				"1111111111"
			}

		));

		rooms_3.Add(new StringArray(
			new string[]{
				"0000000000",
				"0000000000",
				"0000000000",
				"0000000000",
				"0000000011",
				"1100001111",
				"1111111111",
				"1111111111"
			}

		));



		level = FindObjectOfType<GenerateLevel>();

		BuildRooms();

	}

	void BuildRooms()
	{
		foreach(Room r in level.rooms)
		{
			ProcessTemplate(r);
		}
			
	}

	// Each room is 10 blocks across - each block is .5m long - each room is 5m long
	// Each room is 8 blocks tall - each block is .5m tall - each room is 4m tall
	void ProcessTemplate(Room room)
	{
		int i,j, x, y;
		string[] template;

		x = room.x;
		y = room.y;

		GameObject parent = new GameObject();
		parent.name = "Room: " + room.id;

		if(room.type == 1)
		{
			template = rooms_1[Random.Range(0,rooms_1.Count)].template;
		}
		else if(room.type == 2)
		{
			template = rooms_2[Random.Range(0,rooms_1.Count)].template;
		}
		else if(room.type == 3)
		{
			template = rooms_3[Random.Range(0,rooms_1.Count)].template;
		}
		else
		{
			template = rooms_0[Random.Range(0,rooms_1.Count)].template;
		}

		for(i=0;i<8;i++)
		{
			for(j=0;j<10;j++)
			{
				char block = template[i][j];
				GameObject go;

				switch(block){

				case '0':
					go = blank;
					break;
				case '1':
					go = dirt;
					break;
				default:
					go = blank;
					break;

				}

				GameObject newBlock = (GameObject)Instantiate(go, new Vector3(x * 5 + j * .5f, -y * 4 - i * .5f, 0), Quaternion.identity);

				if(room == level.GetStartRoom())
				{
					newBlock.GetComponentInChildren<SpriteRenderer>().color = Color.green;	
				}
				else if(room == level.GetEndRoom())
				{
					newBlock.GetComponentInChildren<SpriteRenderer>().color = Color.red;
				}

				newBlock.transform.SetParent(parent.transform);

			}
		}
	}
}
