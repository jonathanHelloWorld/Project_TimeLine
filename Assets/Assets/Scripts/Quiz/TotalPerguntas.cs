using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalPerguntas : MonoBehaviour {

    Text totalPgts;

	void Start () {

        totalPgts = GetComponent<Text>();
        totalPgts.text = ArrayQuest.totalPgts.ToString("00");
      

	}
    private void Update()
    {
        //Debug.Log(ArrayQuest.totalPgts);
    }


}
