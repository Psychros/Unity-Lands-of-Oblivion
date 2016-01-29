using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


public class RessourceManager : MonoBehaviour {

    private static RessourceManager instance;
    public  List<Ressource> icons = new List<Ressource>();

    public static RessourceManager Instance
    {
        get { return instance; }
    }

    void Start () {
        //Initialisation
        if (instance == null) {
            instance = this;
        }
	}

    public Sprite getSprite(string name)
    {
        foreach(Ressource r in icons)
        {
            if (r.name.Equals(name))
            {
                Texture2D texture = (Texture2D)r.prefab;
                return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f)); 
            }
        }

        throw new IllegalArgumentException("This Sprite isn't saved!");
    }

    //Get a Ressourcesprite
    public Sprite getSprite(Ressources r)
    {
        if (r != (int)Ressources.None)
            return getSprite(r.ToString());
        else
            return null;
    }
}
