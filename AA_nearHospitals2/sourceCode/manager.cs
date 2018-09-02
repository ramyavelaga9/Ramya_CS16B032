using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour {


    public GameObject main;
    public GameObject info;
    public GameObject intro;

    public static manager instance { set; get; }
    public Image image;
    public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
    public Text addressTEXT;
    public Text nameOfTheHospital;

    public string namee;
    public string Address;



	// Use this for initialization
	void Start () 

    {

        info.SetActive(false);
        instance = this;
        loadImage(url);

	}
	
    public void loadImage(string url)
    {


        StartCoroutine(putImage(url));


    }


    public void SetPage(string iconURL,string name,string address)
    {



        namee = name;
        Address = address;
        info.SetActive(true);
        loadImage(iconURL);
        addressTEXT.text = address;
        nameOfTheHospital.text = name;


    }


    IEnumerator putImage(string urlImg)
    {
        WWW www = new WWW(urlImg);
        yield return www;
        if(www.texture==null)
        {
            Debug.LogError("Network");


        }
        image.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }


    public void back()
    {


        info.SetActive(false);


    }


    public void introCome()
    {


        intro.SetActive(true);


    }

    public void introGo()
    {


        intro.SetActive(false);


    }


    public void shareThisInfo()
    {


        ShareTheText("hospital", "Name : " + namee + ", Address: " +Address );


    }


     public void ShareTheText(string subject, string TEXT)
    {



        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), TEXT);
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("startActivity", intentObject);




    }


}
