using UnityEngine;
using System.Collections;

public class Windmill : WorkBuilding {

    public override void finishBuilding()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("isBuild", true);
    }
}
