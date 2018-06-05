using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using control;

public class Button_Popup : MonoBehaviour {

    Button _btn;
    public GameObject img;
	
	void Start () {

        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(() =>
        {
            img.SetActive(true);
        });

	}
}
