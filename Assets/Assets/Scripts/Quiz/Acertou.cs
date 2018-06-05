using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acertou : MonoBehaviour {

    Text txtAcertos;

	void Start () {
        txtAcertos = GetComponent<Text>();
        txtAcertos.text = ArrayQuest.nnn.ToString("00");
	}
	
	
}
