using UnityEngine;
using System.Collections;

public class WorkBuilding : Building {

	public Ressources product;
    public Ressources ressource;
	public int numberProduct = 1;
    public int numberRessource = 1;
    public float productionTime;

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

	/*
     *Produce the product every in productionTime seconds
     */
	protected void produce(){
		timerRessources += Time.deltaTime;

		if(worker != null){
			if(timerRessources >= productionTime){
                if (((int)ressource == (int)Ressources.None) || (numberRessource <= GlobalStore.instance.getNumberOfRessource(ressource))){

                    //Remove ressource
                    if(((int)ressource != (int)Ressources.None))
                        GlobalStore.instance.addRessources(ressource, -numberRessource);

                    //Add Product
                    GlobalStore.instance.addRessources(product, numberProduct);
                    timerRessources = 0;

                    //The morality has an influence on the productionTime
                    float time = productionTime / (NPCManager.instance.Morality / 100f);
                    timerRessources = productionTime - time;
                }
			}
		}
	}
}
