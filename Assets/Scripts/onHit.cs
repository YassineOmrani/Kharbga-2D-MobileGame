using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHit : MonoBehaviour {

    public int index;

    GameplayScript gps;

    private void Start()
    {
        gps = GameObject.Find("GameManager").GetComponent<GameplayScript>();
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        gps.insert(this.gameObject, index);
        gps.turnCount++;    
    }
}
