using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleReset : MonoBehaviour {

    RectTransform rectTransform;

	void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(1, 1, 1);

    }

    // Update is called once per frame
    void Update () {

    }
}
