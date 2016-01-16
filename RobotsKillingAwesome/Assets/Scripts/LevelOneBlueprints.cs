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
		dimensions.x = 24;
		dimensions.y = 24;
        floorPlan = new int[(int)(dimensions.x), (int)(dimensions.y)];
   
		for(x=0; x<dimensions.x; x++){
			for(y=0; y<dimensions.y; y++){
				if (y == 0) {
					floorPlan [x, y] = 1;
				} else if (x == 0) {
					floorPlan [x, y] = 2;
				} else if (y == (dimensions.y - 1)) {
					floorPlan [x, y] = 0;
				} else if (x == (dimensions.x - 1)) {
					floorPlan [x, y] = 3;
				} else {
					floorPlan [x, y] = 4;
				}
			}
		}
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