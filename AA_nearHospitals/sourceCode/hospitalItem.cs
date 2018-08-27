using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hospitalItem : MonoBehaviour {

    public Text nameOfHosp;
    public Text status;
    public Text rating;

    public void setProperties(string name,bool op,float Rating)
    {

        nameOfHosp.text = name;
        if (op)
        {
            status.text = "OPENED";
        }
        else
        {
            status.text = "CLOSED";


        }

        rating.text = Rating.ToString() + "/5";

    }
	
	
}
