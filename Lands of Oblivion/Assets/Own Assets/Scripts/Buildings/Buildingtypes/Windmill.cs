using UnityEngine;
using System.Collections;

public class Windmill : Building {

    public override void finishBuilding()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("isBuild", true);
    }
}
