



/*

Modified to better fit blueprinting from the unity tutorial here: https://catlikecoding.com/unity/tutorials/hex-map/ Uses parts 1,15,and 16 but ignoring the sections involving
sorting since they are replaced by the priority queue in part 16 (blueprint arrays don't have a native sort function anyway)

*/



public HexGrid {
	
	HexCellPriorityQueue searchFrontier;
	Timer timer; //Semi pseudo code


	public void FindPath (HexCell fromCell, HexCell toCell) {
		if (fromCell == toCell) {
			return;
		}
		StopAllTimers(); //Semi pseudo code
		
		for (int i = 0; i < cells.Length; i++) {
			cells[i].Distance = 10000; //using 10000 instead of int.MaxValue as used in the unity tutorial
		}
		
		if (searchFrontier == null) {
			searchFrontier = new HexCellPriorityQueue(); //Semi pseudo code
		}
		else {
			searchFrontier.Clear();
		}
			
		cell.Distance = 0;
		searchFrontier.Enqueue(fromCell);
		
		if (timer == null) {
			timer = new Timer((1/60),Search(fromCell, toCell)); //Semi pseudo code. Usage: Timer(tick rate per second, function to execute)
		}
		timer.StartTimer(); //Semi pseudo code
	}
	
	
	
	
	public void Search (HexCell fromCell, HexCell toCell) {
		if (searchFrontier.Count < 0) {
			timer.PauseTimer();  //Semi pseudo code
		}
		HexCell current = searchFrontier.Dequeue();
		
		if (current == toCell) {
			current = current.PathFrom;
			while (current != fromCell) {
				current.SetCellHexVisibilityAndColor(true, White); //My own method to change colors and visibility. Not from tutorial. Usage: (bool visibility, LinearColor color)
				current = current.PathFrom;
			}
			timer.PauseTimer(); //Semi pseudo code
			break;
		}
		
		for (HexDirection searchDirection = HexDirection.NE; searchDirection <= HexDirection.NW; searchDirection++) { //HexDirection is an enumerator with the values {NE,E,SE,SW,W,NW}
			HexCell neighbor = current.GetNeighbor(searchDirection); //Get neighbor of current cell from searchDirection
				
			if (neighbor == null) { // == null is equivalent to false node of IsValid in blueprint
				continue;
			}
			
			int tempDistance = current.Distance;
			tempDistance += 10;
			
			if (neighbor.Distance == 10000) {
				neighbor.Distance = tempDistance;
				neighbor.PathFrom = current;
				neighbor.SearchHeuristic = 
					neighbor.hexCoordinates.DistanceTo(toCell.hexCoordinates);
				searchFrontier.Enqueue(neighbor);
			}
				
			else if (distance < neighbor.Distance) {
				int oldPriority = neighbor.SearchPriority;
				neighbor.Distance = tempDistance;
				neighbor.PathFrom = current;
				searchFrontier.Change(neighbor, oldPriority);
			}
				
		}
	}
		

}