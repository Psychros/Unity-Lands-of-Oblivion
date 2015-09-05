using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour {

	public static NPCManager instance;

	//Need and Morality
	public int morality = 100;	
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
		set{morality = value;}
	}



	void Start(){
		instance = this;
	}

	void Update(){
		timer += Time.deltaTime;
		if(timer >= time){
			foreach(Need n in needs){
				n.consume();
			}
		}
	}

	public void addNPC(NPC npc){
		numberPeople++;
		freePeople.Add(npc);
		referNPCToWorkBuilding();
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
		}
	}
}
