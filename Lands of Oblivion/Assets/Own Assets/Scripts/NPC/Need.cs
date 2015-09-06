using UnityEngine;
using System.Collections;

[System.Serializable]
public class Need{
	public Ressources ressource;
	public int moralityPrice = 2;		//The morality will be reduced with this value if not enough ressources are available
	public float numberPerInhabitant = 0.2f;
	private float status = 0;

	public Need(Ressources need, float numberPerInhabitant){
		this.ressource = need;
		this.numberPerInhabitant = numberPerInhabitant;
	}

	public void consume(int inhabitants){
		float neededProducts = inhabitants * numberPerInhabitant + status;
		status = neededProducts % (int)neededProducts;

		if(GlobalStore.instance.getNumberOfRessource(ressource) >= (int)neededProducts){
			GlobalStore.instance.addRessources(ressource, (int) neededProducts);
			NPCManager.instance.morality = NPCManager.instance.morality + moralityPrice;
			NPCManager.instance.actualizeNPCText();
		} else {
			NPCManager.instance.morality = NPCManager.instance.morality - moralityPrice;
			NPCManager.instance.actualizeNPCText();
		}
	}
}
