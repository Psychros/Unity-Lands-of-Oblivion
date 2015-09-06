using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour {

	public static NPCManager instance;

	//level
	public int level = 0;
	public int points = 0;
	public int basePoints = 10;	//Basispunktezahl für die Berechnung der nötigen Punkte

	//Need and Morality
	public int morality = 100;	
	public Text moralityText;
	public int time = 30;
	private float timer = 0;
	private List<Need> needs = new List<Need>();
	public List<Need> level0 = new List<Need>();
	public List<Need> level1 = new List<Need>();
	public List<Need> level2 = new List<Need>();
	public List<Need> level3 = new List<Need>();
	public List<Need> level4 = new List<Need>();
	public List<Need> level5 = new List<Need>();
	public List<Need> level6 = new List<Need>();
	public List<Need> level7 = new List<Need>();
	public List<Need> level8 = new List<Need>();
	public List<Need> level9 = new List<Need>();
	public List<Need> level10 = new List<Need>();


	//Organize the npcs
	public GameObject humanModel;
	private int numberPeople = 0;

	private List<WorkBuilding> freeWorkBuildings = new List<WorkBuilding>();
	private List<NPC> freePeople = new List<NPC>();

	public int NumberPeople{
		get{return numberPeople;}
	}

	public int Morality{
		get{return morality;}
		set{morality = value; actualizeNPCText();}
	}



	void Start(){
		instance = this;

		actualizeNPCText();
		addNewNeeds(level0);
	}

	void Update(){
		//Consume products
		timer += Time.deltaTime;
		if(timer >= time){
			timer = 0;

			foreach(Need n in needs){
				n.consume(numberPeople);
			}
		}
	}


	//Tests if the player reachs the next level
	public void nextLevel(){
		if(points >= basePoints){
			level++;
			basePoints *= 2;

			switch(level){
				case 1: addNewNeeds(level1); break;
				case 2: addNewNeeds(level2); break;
				case 3: addNewNeeds(level3); break;
				case 4: addNewNeeds(level4); break;
				case 5: addNewNeeds(level5); break;
				case 6: addNewNeeds(level6); break;
				case 7: addNewNeeds(level7); break;
				case 8: addNewNeeds(level8); break;
				case 9: addNewNeeds(level9); break;
				case 10: addNewNeeds(level10); break;
			}
		}
	}

	//Add the needs of the List
	public void addNewNeeds(List<Need> needs){
		foreach(Need n in needs){
			this.needs.Add(n);
		}
	}

	public void addNPC(NPC npc){
		numberPeople++;
		freePeople.Add(npc);
		referNPCToWorkBuilding();

		actualizeNPCText();
	}

	public void addWorkBuilding(WorkBuilding b){
		freeWorkBuildings.Add(b);
		referNPCToWorkBuilding();
	}


	public void referNPCToWorkBuilding(){
		if(freeWorkBuildings.Capacity>0 && freePeople.Capacity>0){
			freeWorkBuildings[0].worker = freePeople[0].gameObject;

			//The npc walks to his workplace
			freePeople[0].GetComponent<NavMeshAgent>().SetDestination(freeWorkBuildings[0].transform.position);
			freePeople[0].workPlace = freeWorkBuildings[0];

			//Remove the instances from the lists
			freePeople.RemoveAt(0);
			freePeople.TrimExcess();
			freeWorkBuildings.RemoveAt(0);
			freeWorkBuildings.TrimExcess();

			actualizeNPCText();
		}
	}
	

	public void actualizeNPCText(){
		moralityText.text = freePeople.Count + "/" + numberPeople + " (" + morality + "%)";
	}
}
