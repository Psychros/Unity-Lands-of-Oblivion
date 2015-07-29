using UnityEngine;
using System.Collections;

public class TreeGenerator : MonoBehaviour {

	public int numberTrees = 1000;
	public float minHeight = 13;
	public float maxHeight = 50;

	public Terrain terrain = null;
	public GameObject tree = null;


	void Start () {
		//Generate Trees at random positions
		for(int i=0; i<numberTrees; i++){
			int x = Random.Range(0, 2000);
			int z = Random.Range(0, 2000);
			float y = terrain.SampleHeight(new Vector3(x, 0, z));

			if(y >= minHeight && y<= maxHeight){
				Vector3 pos = new Vector3(x, y, z);
				Quaternion rotation = new Quaternion(0, Random.Range(0, 1), 0, 0);

				print(pos);
				GameObject newTree = (GameObject)Instantiate(tree, pos, rotation);
				newTree.name = "Tree" + i;
				newTree.transform.parent = transform;
			}
		}
	}
}