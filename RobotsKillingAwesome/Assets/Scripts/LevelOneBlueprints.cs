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
		dimensions.x = 30;
		dimensions.y = 30;
        floorPlan = new int[(int)(dimensions.x), (int)(dimensions.y)];
   
		for(x=0; x<dimensions.x; x++){
			for(y=0; y<dimensions.y; y++){
				/*if(x == 4){ 											//row 5
					if ((y > 3 && y < 13) || (y > 15 && y < 27)) {       //All wallUp for row 5
						floorPlan [x, y] = 0;
					} else {
						floorPlan [x, y] = 6;
					}
				}
				else if(x > 4 && x < 10){
					if (y == 4 || y == 15) {
						floorPlan [x, y] = 2;
					} else if (y == 13 || y == 27) {
						floorPlan [x, y] = 3;
					} else if ((y > 4 && y < 13) || (y > 15 && y < 27)) {
						floorPlan [x, y] = 4;
					} else {
						floorPlan [x, y] = 6;
					}
				}
				else {
					floorPlan [x, y] = 6;
				}
				*/
				floorPlan [x, y] = 4;
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