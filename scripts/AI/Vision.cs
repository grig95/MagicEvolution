using Godot;
using System;

public partial class Vision : Godot.Node2D {
	private VisionGenome genome;
	private double fov; // in degrees
	private uint rayCount;
	private double range;

	private RayCast2D[] rayNodes;

	public VisionData getVisionData() {
		GD.Print("Warning! Vision.getVisionData not yet implemented!");
		return new VisionData();
	}

	// this is only public because AI implementations need to see it
	public void updateGenome(VisionGenome newGenome) {
		genome=newGenome;
	}

	public Vision(VisionGenome genome) {
		this.genome=genome;
		fov=genome.getFOV()*180;
		if(genome.getRayCountCode()==0)
			rayCount=0;
		else
			rayCount=2*genome.getRayCountCode()-1;
		range=genome.getRange();
		rayNodes=null;
		// Instantiate raycast nodes
		initRaycastNodes();
	}

	public void initRaycastNodes() {
		if(rayCount==0||rayNodes!=null)
			return;
		rayNodes=new RayCast2D[rayCount];
		rayNodes[0]=new RayCast2D();
		rayNodes[0].TargetPosition=new Vector2(0, (float)-range); 
		AddChild(rayNodes[0]);
		float angle=0;
		for(uint i=1;i<rayCount;i+=2) {
			angle+=(float)fov/((float)(rayCount-1)/2);
			
			rayNodes[i]=new RayCast2D();
			rayNodes[i].TargetPosition=new Vector2(-Godot.Mathf.Cos(90-angle), -Godot.Mathf.Sin(90-angle));
			AddChild(rayNodes[i]);
			
			rayNodes[i+1]=new RayCast2D();
			rayNodes[i+1].TargetPosition=new Vector2(Godot.Mathf.Cos(90-angle), -Godot.Mathf.Sin(90-angle));
			AddChild(rayNodes[i+1]);
		}
	}
}
