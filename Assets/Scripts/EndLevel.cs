using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    public GameObject winCanvas;

	// Use this for initialization
	void Start () {
        winCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            Time.timeScale = 0;
            winCanvas.SetActive(true);
        }
    }
}
