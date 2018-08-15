using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningBox : MonoBehaviour {

    float maxLifeTime, lifeTime;
    float myAlpha;
    bool isFading;
    public Image myImage;
    Color myColorImage, myColorText;

    public TextMeshProUGUI txtText;

	void Start ()
    {
        maxLifeTime = 2.3f;
        lifeTime = maxLifeTime;

        myColorImage = myImage.color;
        myColorText = txtText.color;

        myColorImage.a = 0f;
        myColorText.a = 0f;

        myImage.color = myColorImage;
        txtText.color = myColorText;
	}
	
	void Update ()
    {
        // not fading, do nothing
        if(!isFading)
        {
            this.gameObject.SetActive(false);
        }

        // fading, countdown
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            FadeOut();
        }
	}

    public void SetText(string DisplayText)
    {
        txtText.text = DisplayText;
    }

    public void ValuesReset()
    {
        myColorImage.a = 1f;
        myColorText.a = 1f;
        myImage.color = myColorImage;
        txtText.color = myColorText;

        lifeTime = maxLifeTime;

        isFading = true;
    }

    void FadeOut()
    {
        myColorImage.a = myColorImage.a - (Time.deltaTime * .4f);
        myImage.color = myColorImage;

        myColorText.a = myColorText.a - (Time.deltaTime * .4f);
        txtText.color = myColorText;

        if (myColorImage.a <= 0)
        {
            isFading = false;
        }
    }
}
