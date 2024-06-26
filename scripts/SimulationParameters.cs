using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public static class SimulationParameters {
	private static SceneTree tree = (SceneTree)Engine.GetMainLoop();
	private static Node Global = tree.Root.GetNode("/root/Global");
	//public static double rangeOnWhichGenerated = 200;
	public static double rangeOnWhichGenerated = 4096;
	//public static double initialNoWizbits = 5;
	public static double initialNoWizbits = (int)Global.Get("wiz");
	//public static double initialNoMana = 20;
	public static double initialNoMana = (int)Global.Get("mana");
	public static double crtNoWizbits = 0;
	public static double crtNoMana = 0;
	public static double ManaValue = 10;
	public static class WizbitStatsParameters {
		public static double constantCost = 0.01;
		public static double useCost = 5;
		public static class MutationChances {
			public static double maxHp=0.05;
			public static double maxMana=0.05;
			public static double maxMovementSpeed=0.05;
			
			//likelihood to change enviroment stat (temperature and altitude)
			public static double envChance = 0.01;
		}

		public static class MutationParameters {
			public static double HpMaxChange = 0.4;
			public static double ManaMaxChange = 0.4;
			public static double SpeedMaxChange = 0.25;
			
			//how much enviroment stat (temperature and altitude) can change based on current enviroment
			public static double EnvMaxChangeMod = 0.01;
		}
	}
	

	public static class AIParameters {

		// max possible absolute value of a mutated synapse
		public static double synapseMaxAbsoluteWeight=5;

		public static class MutationChances {
			public static double fov=0.01;
			public static double rayCountCode=0.05;
			public static double range=0.01;

			public static double createSynapse=0.1;
			public static double modifySynapse=0.1;
			public static double evolveSynapse=0.1;
			public static double removeSynapse=0.05;
			public static double modifyNeuron=0.1;
			public static double removeNeuron=0.05;
		}

		public static class MutationParameters {
			// max possible fov change (increase or decrease) as a fraction of the current fov
			public static double visionFOVMaxChange=0.5;

			// max possible range change (increase or decrease) as a fraction of the current range
			public static double visionRangeMaxChange=0.25;

			// max possible synapse weight change as a fraction of the current weight
			public static double synapseModificationMaxChange=0.25;
			
		}

		public static MC_WeightFunctionEnum mc_weightFunction = MC_WeightFunctionEnum.Quadratic;

	}

	public static class WizbitParameters {
		public static MC_WeightFunctionEnum statsWeightFunction = MC_WeightFunctionEnum.Quadratic;
	}

	public static void resetToDefault() {
		GD.Print("Warning! SimulationParameters::resetToDefault() currently does nothing!");
	}
}
