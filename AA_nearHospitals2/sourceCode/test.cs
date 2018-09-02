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
    string geoAPI = "ef361f5b935f43e3becf5766819cc79a";

    float lattitute=17.448294f;
    float longitude=78.391487f;


	private void Start()
	{
        clear();
        request();
        //searchWithNAME("Madhapur");

	}


    public void request()
    {



        //WWW req = new WWW("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="+GPS.instance.lattitue.ToString()+","+GPS.instance.longitude.ToString()+"&radius=1500&type=hospital&key="+apiKey);



        WWW req = new WWW("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="+"13.62"+","+"79.47"+"&radius=3500&type=hospital&key="+apiKey);
        StartCoroutine(OnResponse(req));

    }

    private IEnumerator OnResponse(WWW req)

    {

        yield return req;
        string JsonDataText = req.text;

        JSONNode jSONNode = SimpleJSON.JSON.Parse(JsonDataText);
        int i = 0;

        if(jSONNode["results"][i] == null)

        {
            Debug.Log("Network error !");


        }

        while (jSONNode["results"][i]!=null)
        {

            GameObject newItem = Instantiate(hospItem,transform.position,Quaternion.identity) as GameObject;
            newItem.transform.parent = Content.transform;
            newItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            newItem.GetComponent<hospitalItem>().setProperties(jSONNode["results"][i]["name"].ToString(),jSONNode["results"][i]["opening_hours"]["open_now"],jSONNode["results"][i]["rating"],i+1,jSONNode["results"][i]["vicinity"],jSONNode["results"][i]["icon"]);
            //Debug.Log(jSONNode["results"][i]["name"]);
            i += 1;

        }


    }


    public void clear()
    {

        int i = 0;

        while(Content.transform.childCount>=1)
        {

            if (Content.transform.GetChild(i).gameObject != null)
            {
                Destroy(Content.transform.GetChild(i).gameObject);
                i += 1;
            }

        }



    }


    //public void searchWithNAME(string placeName)
    //{


    //    WWW req2 = new WWW("https://api.opencagedata.com/geocode/v1/json?q="+placeName+"&key="+geoAPI);

    //    StartCoroutine(OnResponseGEO(req2));



    //}

    //private IEnumerator OnResponseGEO(WWW req2)

    //{

    //    yield return req2;

    //    string JsonDataText = req2.text;

    //    JSONNode jSONNode = SimpleJSON.JSON.Parse(JsonDataText);
    //    float lat=jSONNode["results"][0]["geometry"]["lat"];
    //    float lng = jSONNode["results"][0]["geometry"]["lng"];
    //    string LAT = lat.ToString("F2");
    //    string LNG = lng.ToString("F2");


    //    Debug.Log(LAT+","+LNG);
    //    //WWW req3 = new WWW("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + LAT + "," + LNG + "&radius=1500&type=hospital&key=" + apiKey);
    //    clear();
    //    WWW req3 = new WWW("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + "17.13" + "," + "78.58" + "&radius=1500&type=hospital&key=" + apiKey);

    //    StartCoroutine(OnResponse(req3));


    //}


}