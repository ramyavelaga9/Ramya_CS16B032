using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using SimpleJSON;


public class test : MonoBehaviour
{

    public GameObject Content;
    public GameObject hospItem;



    private const string URL = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=13.65,79.42&radius=1500&type=hospital&key=AIzaSyCjG19Z-7Ppm-7-KHs-Eng8HOa-fXkcxJk";


    string apiKey = "AIzaSyCjG19Z-7Ppm-7-KHs-Eng8HOa-fXkcxJk";

    float lattitute=17.448294f;
    float longitude=78.391487f;


	private void Start()
	{

        request();

	}


    void request()
    {
        
        //WWW req = new WWW("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="+GPS.instance.lattitue.ToString()+","+GPS.instance.longitude.ToString()+"&radius=1500&type=hospital&key="+apiKey);

        WWW req = new WWW("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="+"17.41"+","+"78.513"+"&radius=1500&type=hospital&key="+apiKey);

        StartCoroutine(OnResponse(req));

    }

    private IEnumerator OnResponse(WWW req)

    {

        yield return req;

        string JsonDataText = req.text;

        JSONNode jSONNode = SimpleJSON.JSON.Parse(JsonDataText);
        int i = 0;
        while (jSONNode["results"][i]!=null)
        {

            GameObject newItem = Instantiate(hospItem) as GameObject;
            newItem.transform.parent = Content.transform;
            newItem.GetComponent<hospitalItem>().setProperties(jSONNode["results"][i]["name"].ToString(),jSONNode["results"][i]["opening_hours"]["open_now"],jSONNode["results"][i]["rating"]);
            Debug.Log(jSONNode["results"][i]["name"]);
            i += 1;

        }


    }

}