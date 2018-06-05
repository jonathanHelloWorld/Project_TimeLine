using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupPopups : MonoBehaviour {

    Button _btn;
    public List<GameObject> imgs;


    void Start()
    {

        _btn = GetComponent<Button>();

        _btn.onClick.AddListener(() =>
        {
            for(int i =0; i< imgs.Count; i++)
            {
                imgs[i].SetActive(false);
            }
            
        });

    }

}
