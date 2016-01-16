using UnityEngine;
using System.Collections.Generic;

public class Map1 : MonoBehaviour {
	
	public GameObject wallUp; //0
	public GameObject wallDown; //1
	public GameObject wallLeft; //2
	public GameObject wallRight; //3
	public GameObject tile; //4
	public GameObject carpet; //5
	
	Node[,] graph;
	GameObject bluePrints;
	Vector2 dimensions;
	int[,] floorPlan;
	Vector2 playerSpawn;
	List<Vector2> enemySpawns;

    public GameObject playerSpawnPoint;
    public GameObject enemySpawn;
	
	public void initialize(){
		bluePrints = GameObject.FindGameObjectWithTag("bluePrints");
		dimensions = bluePrints.GetComponent<LevelOneBlueprints>().getDimensions();      //CHANGE THESE LINES FOR DIFFERENT LEVELS
		floorPlan = bluePrints.GetComponent<LevelOneBlueprints>().getFloorPlan();
		playerSpawn = bluePrints.GetComponent<LevelOneBlueprints>().getPlayerSpawn();
		enemySpawns = bluePrints.GetComponent<LevelOneBlueprints>().getEnemySpawns();
		
		generateGraph();
		generateVisuals();
       // placeSpawns();
	}
	
    void placeSpawns()
    {
        Instantiate(playerSpawnPoint, new Vector3(playerSpawn.x, playerSpawn.y, 0), Quaternion.identity);
        foreach(Vector2 point in enemySpawns)
        {
            Instantiate(enemySpawn, new Vector3(point.x, point.y, 0), Quaternion.identity);
        }
    }

    public List<Node> generatePath(Vector2 targetPos, Vector2 sourcePos)
    {
        Dictionary<Node, float> dist = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();
		List<Node> unvisited = new List<Node>();
        Node source = graph[(int)sourcePos.x, (int)sourcePos.y];
        Node target = graph[(int)targetPos.x, (int)targetPos.y];
        dist[source] = 0;
        prev[source] = null;

        foreach(Node v in graph)
        {
            if(v != source)
            {
                dist[v] = Mathf.Infinity;
                prev[v] = null;
            }
            unvisited.Add(v);
        }
        while(unvisited.Count > 0)
        {
            Node u = null;
            foreach(Node possibleU in unvisited)
            {
                if (u == null || dist[possibleU] < dist[u])
                    u = possibleU;
            }
            if(u == target)
            {
                break;
            }
            unvisited.Remove(u);
            foreach(Node v in u.neighbours)
            {
                float alt = dist[u];
                if (alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }
            }
        }
        List<Node> currentPath = new List<Node>();
        Node cur = target;
        while(cur != null)
        {
            currentPath.Add(cur);
            cur = prev[cur];
        }
        currentPath.Reverse();
        return currentPath;
    }

	void generateVisuals(){
		int x,y,z;
		for(x=0; x<dimensions.x; x++){
			for(y=0; y<dimensions.y; y++){
                z = floorPlan[x, y];
				if(z == 0)
					Instantiate(wallUp, new Vector3(x, y, 0), Quaternion.identity);
				else if(z == 1)
					Instantiate(wallDown, new Vector3(x, y, 0), Quaternion.identity);
				else if(z == 2)
                    Instantiate(wallLeft, new Vector3(x, y, 0), Quaternion.identity);
				else if(z == 3)
                    Instantiate(wallRight, new Vector3(x, y, 0), Quaternion.identity);
				else if(z == 4)
                    Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity);
				else if(z == 5)
                    Instantiate(carpet, new Vector3(x, y, 0), Quaternion.identity);
			}
		}
	}


                                //DO NOT TOUCH THIS
    void generateGraph()
    {
        int x, y;
        graph = new Node[(int)dimensions.x, (int)dimensions.y];
        for (x = 0; x < dimensions.x; x++)
        {    //initialize nodes
            for (y = 0; y < dimensions.y; y++)
            {
                graph[x, y] = new Node();
                graph[x, y].xPos = x;
                graph[x, y].yPos = y;
            }
        }
        for (x = 0; x < dimensions.x; x++)
        {    //connect graph
            for (y = 0; y < dimensions.y; y++)
            {
                if (x > 0)
                {
                    graph[x, y].neighbours.Add(graph[x - 1, y]);
                    if (y > 0)
                        graph[x, y].neighbours.Add(graph[x - 1, y - 1]);
                    if (y < dimensions.y - 1)
                        graph[x, y].neighbours.Add(graph[x - 1, y + 1]);
                }
                if (x < dimensions.x - 1)
                {
                    graph[x, y].neighbours.Add(graph[x + 1, y]);
                    if (y > 0)
                        graph[x, y].neighbours.Add(graph[x + 1, y - 1]);
                    if (y < dimensions.y - 1)
                        graph[x, y].neighbours.Add(graph[x + 1, y + 1]);
                }
                if (y > 0)
                    graph[x, y].neighbours.Add(graph[x, y - 1]);
                if (y < dimensions.y - 1)
                    graph[x, y].neighbours.Add(graph[x, y + 1]);
            }
        }
    }
}