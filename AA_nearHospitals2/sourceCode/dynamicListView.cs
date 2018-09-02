using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicListView : MonoBehaviour {

    public GameObject itemPRefab;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 5; i++)
        {

            GameObject newItem = Instantiate<GameObject>(itemPRefab, transform);

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
