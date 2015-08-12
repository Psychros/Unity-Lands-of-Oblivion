using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour {

	public static NPCManager instance;

	public GameObject humanModel;
	private int numberPeople = 0;

	private List<WorkBuilding> freeWorkBuildings = new List<WorkBuilding>();
	private List<NPC> freePeople = new List<NPC>();

	public int NumberPeople{
		get{return numberPeople;}
	}

	void Start(){
		instance = this;
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
