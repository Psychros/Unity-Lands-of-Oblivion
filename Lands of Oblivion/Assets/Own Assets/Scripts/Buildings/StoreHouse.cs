using UnityEngine;
using System.Collections;

public class StoreHouse : Building {

	public static int size = 10;


	public void Start () {
		GlobalStore.instance.addSize(size);
	}

	void Update(){
		base.Update();
	}
}
