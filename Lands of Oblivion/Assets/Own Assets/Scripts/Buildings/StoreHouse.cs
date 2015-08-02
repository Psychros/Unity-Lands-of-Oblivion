using UnityEngine;
using System.Collections;

public class StoreHouse : MonoBehaviour {

	public static int size = 10;


	public void Start () {
		GlobalStore.instance.addSize(size);
	}
}
