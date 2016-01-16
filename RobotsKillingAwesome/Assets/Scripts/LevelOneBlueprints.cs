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
		int x,y;
		dimensions.x = 100;
		dimensions.y = 100;
        floorPlan = new int[(int)(dimensions.x), (int)(dimensions.y)];
   
		for(x=0; x<dimensions.x; x++){
			for(y=0; y<dimensions.y; y++){
				if(x == 0 || y == 0)
					floorPlan[x,y] = 0;
				else if(x == (dimensions.x-1) || y == (dimensions.y-1))
					floorPlan[x,y] = 0;
				else
					floorPlan[x,y] = 5;
			}
		}
		mapMaker = GameObject.FindGameObjectWithTag("mapMaker");
		mapMaker.GetComponent<Map>().initialize();
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