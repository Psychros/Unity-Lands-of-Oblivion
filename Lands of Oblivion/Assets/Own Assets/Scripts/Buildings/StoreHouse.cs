using UnityEngine;
using System.Collections;

public class StoreHouse : Building {

	public static int size = 10;


	public void Start () {
		GlobalStore.instance.addSize(size);
	}

	public virtual void Update(){
		base.Update();
	}
}
