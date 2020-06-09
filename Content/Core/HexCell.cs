Public HexCell {
	
	public HexCell PathFrom { get; set; } // the previous cell in the path that is closer to the beginning cell
	
	public HexCell NextWithSamePriority { get; set; } //the next cell with the same priority as this one. More info here: https://catlikecoding.com/unity/tutorials/hex-map/part-16/
	
	public HexCell[] Neighbors; //Array of the six neighboring cells around this one
	
	
	
	public HexCoordinates hexCoordinates { get; set; } //the x and z coordinates of this cell. the y coordinate can be calculated as y = ((-x) - z)
	
	
	
	public int GridIndex; {get; set; } // the index of the current cell
	
	public int Distance { 
		get {
			return distance;
		}
		set {
			distance = value;
			UpdateDistanceLabel();
		}
	}
	
	public int SearchPriority { //In blueprint, this is a function in HexCell
			get {
				return distance + SearchHeuristic; 
			}
	}
	
	public int SearchHeuristic { get; set; }
	
	
	
	
	
}