using UnityEngine;
using System.Collections;

public class AxeController : MonoBehaviour {

    private Animator anim;
    private float timer = 0.8f;
    public float reloadTime = 0.6f;

    //Timer for the short waitTime
    private bool hasClicked = false;
    private float timerClicked = 0;

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
        timer  += Time.deltaTime;
	}

    //Start the cutAnimation and cut the tree
    public void triggerCut()
    {
        if (timer >= reloadTime)
        {
            anim.SetTrigger("Cut");
            timer = 0;
            hasClicked = true;
        }
    }

    public void cutTree()
    {
        InputManager.instance.testForInteractableObject(2);
    }
}
