using UnityEngine;
using System.Collections;

public class LevelDesigner : MonoBehaviour {

	[Range(0f,100.0f)] public float range = 100;
	[Range(0,10)] 	  public int numberOfObjects = 10;

	public GameObject gameObject = null;
	public Vector3 pos = new Vector3(100, 100, 100);

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(pos, range);
	}
}
