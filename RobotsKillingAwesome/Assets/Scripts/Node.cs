using UnityEngine;
using System.Collections.Generic;

public class Node {
	
	public List<Node> neighbours;
	public int xPos;
	public int yPos;
	
	public Node(){
		neighbours = new List<Node>();
	}
	
}