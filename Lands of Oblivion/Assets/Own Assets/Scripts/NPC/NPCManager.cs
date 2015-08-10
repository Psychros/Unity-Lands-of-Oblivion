using UnityEngine;
using System.Collections;

public class NPCManager : MonoBehaviour {

	public static NPCManager instance;

	public GameObject humanModel;
	private int numberPeople = 0;
	private int freePeople = 0;

	public int NumberPeople{
		get{return numberPeople;}
	}

	public int FreePeople{
		get{return freePeople;}
	}

	void Start(){
		instance = this;
	}

	public void addPeople(int number){
		numberPeople += number;
		freePeople   += number;
	}
}
