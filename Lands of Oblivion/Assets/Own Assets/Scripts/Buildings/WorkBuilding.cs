using UnityEngine;
using System.Collections;

public class WorkBuilding : Building {

	public Ressources ressource;
	public float productionTime;
	public int number = 1;

	private float timerRessources = 0;

	public GameObject worker = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		base.Update();

		produce();
	}

	public override void finishBuilding ()
	{
		base.finishBuilding ();

		NPCManager.instance.addWorkBuilding(this);
	}

	//Produce the product every in productionTime seconds
	protected void produce(){
		if(worker != null){
			if(timerRessources >= productionTime){
				GlobalStore.instance.addRessources(ressource, number);
				timerRessources = 0;
			}

			timerRessources += Time.deltaTime;
		}
	}
}
