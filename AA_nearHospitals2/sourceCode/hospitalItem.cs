using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hospitalItem : MonoBehaviour {

    public Text iteration;
    public Text nameOfHosp;
    public Text status;
    public Image statusImage;
    public Text rating;
    public List<Image> stars;

    public float ratingIs;
    public string ADDRESS;
    public string iconURL;
    public string nameHspt;

    public void setProperties(string name,bool op,float Rating,int iter,string address="No Address found",string icon="ICON")
    {

        ADDRESS = address;
        iconURL = icon;
        iteration.text = iter.ToString();
        nameHspt = name;
        nameOfHosp.text = name;
        if (op)
        {
            status.text = "OPENED";
            statusImage.color = Color.green;
        }
        else
        {
            status.text = "CLOSED";
            statusImage.color = Color.red;


        }

        rating.text = Rating.ToString() + "/5";
        foreach (var item in stars)
        {
            item.fillAmount = 0f;
        }
        applyrating(Rating);
    
    }


    public void applyrating(float value)
    {


        ratingIs = value;
        int imagevalue = 0;
        float ratingNumber = 0;
        ratingNumber = value;

        while(ratingNumber>=1f)
        {

            ratingNumber -= 1;

            stars[imagevalue].fillAmount = 1;
            imagevalue += 1;


        }

        if(ratingNumber<1f && imagevalue<5)
        {


            stars[imagevalue].fillAmount = ratingNumber;

        }


    }


    public void getInfo()
    {


        manager.instance.SetPage(iconURL, nameHspt, ADDRESS);


    }


    public void shareInfo()
    {


        manager.instance.ShareTheText("hospital", "Name : " + nameHspt + ", Address: " + ADDRESS + ", Rating: " + ratingIs + "/5");


    }
	
	
}
