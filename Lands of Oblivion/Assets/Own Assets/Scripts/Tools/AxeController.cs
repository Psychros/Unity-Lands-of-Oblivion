using UnityEngine;
using System.Collections;

public class AxeController : MonoBehaviour {

    private Animator anim;

    void Start () {
        //Search the right animator
        Animator[] anims = GetComponentsInParent<Animator>();
        foreach(Animator a in anims)
        {
            if (a.name.Equals("Axe"))
                anim = a;
        } 
    }
	

	void Update () {

	}

    //Start the cutAnimation and cut the tree
    public void triggerCut()
    {
        anim.SetBool("isCut", true);
    }

    //Start the cutAnimation and cut the tree
    public void resetCut()
    {
        anim.SetBool("isCut", false);
    }

    public void cutTree()
    {
        InputManager.instance.testForInteractableObject(2);
    }
}
