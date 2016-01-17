using UnityEngine;
using System.Collections.Generic;

public class LevelOneBlueprints : MonoBehaviour{

	int[,] floorPlan;
	Vector2 dimensions;
	Vector2 playerSpawn;
	List<Vector2> enemySpawns;
	Vector2 exit;
	GameObject mapMaker;
	
	void Start(){
		playerSpawn = new Vector2(4f,-12f);

		enemySpawns = new List<Vector2>();

		//setting enemy spawns for map 1.
		//enemySpawns.Add(new Vector2(5.5f,-3.5f));
		enemySpawns.Add(new Vector2(7.5f,-4.5f));
		enemySpawns.Add(new Vector2(13.5f,-6.5f));
		enemySpawns.Add(new Vector2(10f,-10f));
		enemySpawns.Add(new Vector2(9f,-15f));
		enemySpawns.Add(new Vector2(7f,-17f));
		enemySpawns.Add(new Vector2(4f,-18f));
		enemySpawns.Add(new Vector2(7f,-19f));
		enemySpawns.Add(new Vector2(4f,-20f));
		enemySpawns.Add(new Vector2(12.3f,-16f));
		enemySpawns.Add(new Vector2(14f,-14.5f));
		enemySpawns.Add(new Vector2(17.5f,-10f));
		enemySpawns.Add(new Vector2(19f,-15f));
		enemySpawns.Add(new Vector2(20f,-18.5f));
		enemySpawns.Add(new Vector2(21.5f,-20f));
		enemySpawns.Add(new Vector2(23f,-18.5f));
		enemySpawns.Add(new Vector2(25f,-20f));
		enemySpawns.Add(new Vector2(25f,-13f));
		enemySpawns.Add(new Vector2(25f,-10f));
		enemySpawns.Add(new Vector2(25f,-7f));
		enemySpawns.Add(new Vector2(21f,-4f));


		dimensions.x = 25;
		dimensions.y = 30;
        //floorPlan = new int[(int)(dimensions.x), (int)(dimensions.y)];
		floorPlan = new int[,]{
			{6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},
			{6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},
			{6,6,6,6,2,5,5,5,5,3,6,6,6,2,5,5,5,5,5,5,5,5,5,5,5,5,5,3,6,6},
			{6,6,6,6,2,4,4,4,4,3,6,6,6,2,4,4,4,4,4,4,4,4,4,4,4,4,4,3,6,6},
			{6,6,6,6,2,4,4,4,4,3,6,6,6,2,4,4,4,4,4,4,4,4,4,4,4,4,4,3,6,6},
			{6,6,6,6,2,4,4,4,4,5,5,5,5,5,4,4,4,4,4,4,4,4,4,4,4,4,4,3,6,6},
			{6,6,2,5,5,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,1,1,1,4,4,4,4,3,6,6},
			{6,6,2,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,3,6,6,6,2,4,4,4,3,6,6},
			{6,6,2,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,3,6,6,6,2,4,4,4,3,6,6},
			{6,6,2,4,4,4,3,2,4,4,4,4,4,4,4,4,4,4,4,3,6,6,6,2,4,4,4,3,6,6},
			{6,6,2,4,4,4,3,2,4,4,4,4,4,4,4,4,4,4,4,3,6,6,6,2,4,4,4,3,6,6},
			{6,6,2,4,4,4,3,2,4,4,4,4,4,4,4,4,4,4,4,3,6,6,6,2,4,4,4,3,6,6},
			{6,6,2,4,4,4,3,2,4,4,4,6,6,6,4,4,4,4,4,3,6,6,6,2,4,4,4,3,6,6},
			{6,6,2,4,4,4,3,2,4,4,4,6,6,5,4,4,4,4,4,4,3,6,6,2,4,4,4,3,6,6},
			{6,6,6,1,1,1,6,2,4,4,4,6,5,4,4,4,4,4,4,4,4,3,6,2,4,4,4,3,6,6},
			{6,6,2,5,5,5,5,5,4,4,4,5,4,4,4,4,4,4,4,4,4,3,6,2,4,4,4,3,6,6},
			{6,6,2,4,4,4,4,4,4,4,4,4,4,4,4,1,1,1,4,4,4,5,5,5,4,4,4,3,6,6},
			{6,6,2,4,4,4,4,4,4,4,4,4,4,4,3,6,6,6,2,4,4,4,4,4,4,4,4,3,6,6},
			{6,6,2,4,4,4,4,4,4,4,4,4,4,4,3,6,6,6,2,4,4,4,4,4,4,4,4,3,6,6},
			{6,6,2,4,4,4,4,4,4,4,4,4,4,4,3,6,6,6,2,4,4,4,4,4,4,4,4,3,6,6},
			{6,6,2,4,4,4,4,4,4,4,4,1,1,1,6,6,6,6,2,4,4,4,4,4,4,4,4,3,6,6},
			{6,6,2,4,4,4,4,4,4,1,1,6,6,6,6,6,6,6,2,4,4,4,4,4,4,4,4,3,6,6},
			{6,6,6,1,1,1,1,1,1,6,6,6,6,6,6,6,6,6,6,1,1,1,1,1,1,1,1,6,6,6},
			{6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},
			{6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6},
		};
		/*for(x=0; x<dimensions.x; x++){
			for(y=0; y<dimensions.y; y++){
				floorPlan [x, y] = floorArray [x,y];
			}
		}*/
		mapMaker = GameObject.FindGameObjectWithTag("mapMaker");
		mapMaker.GetComponent<Map1>().initialize();
	}
    public Vector2 getDimensions()
    {
        return dimensions;
    }

    public int[,] getFloorPlan()
    {
        return floorPlan;
    }

    public Vector2 getPlayerSpawn()
    {
        return playerSpawn;
    }

    public List<Vector2> getEnemySpawns()
    {
        return enemySpawns;
    }
}