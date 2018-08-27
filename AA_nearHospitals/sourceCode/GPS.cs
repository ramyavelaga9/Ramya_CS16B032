using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour

{

    public static GPS instance { set; get; }

    public float lattitue;
    public float longitude;

	void Start () 
    {
        StartCoroutine(StartLocationService());
	}
	
    IEnumerator StartLocationService()
    {


        if(!Input.location.isEnabledByUser)
        {

            yield break;

        }

        Input.location.Start();
        int maxWait = 20;
        while(Input.location.status==LocationServiceStatus.Initializing && maxWait>0)
        {

            yield return new WaitForSeconds(1);
            maxWait--;

        }

        if(maxWait<=0)
        {
            yield break;


        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {

            yield break;
        }


        lattitue = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

    }

}
