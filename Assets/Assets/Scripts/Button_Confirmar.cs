using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using control;

public class Button_Confirmar : MonoBehaviour {

    Button _btn;
    public GameObject txtConcluido;
    public GameObject txtNaoConcluido;
    public List<InputField> inputsTxts = new List<InputField>();

	
	void Start () {
        inputsTxts[3].characterLimit = 11;
        LogicaInputs();
        _btn = GetComponent<Button>();

        _btn.onClick.AddListener(() =>
        {
            CheckInputs();
        });

	}
	
    IEnumerator zerar()
    {
        yield return new WaitForSeconds(1f);
 
        for (int i = 0; i< inputsTxts.Count; i++)
        {
            
            inputsTxts[i].text = "";
        }
        
        txtConcluido.SetActive(false);
        Pagination.Instance.OpenPage(1);
    }
    IEnumerator OffTxtMsgNaoConcluida()
    {
        yield return new WaitForSeconds(1f);

        txtNaoConcluido.SetActive(false);

    }

    void LogicaInputs()
    {
        inputsTxts[0].onEndEdit.AddListener((texto) =>
        {
            GameController.Instance.SearchNameInRegister();
        });
        inputsTxts[1].onEndEdit.AddListener((texto) =>
        {
            GameController.Instance.SearchEmailInRegister();
        });

        inputsTxts[2].onEndEdit.AddListener((texto) =>
        {
            GameController.Instance.SearchCpfInRegister();
        });

        inputsTxts[3].onEndEdit.AddListener((texto) =>
        {
            GameController.Instance.SearchTelInRegister();
        });

    }

    void CheckInputs()
    {
        int resulAlert, resultTxt;


        resulAlert = GameController.Instance.alerts.FindIndex(x => x.activeSelf == true);
        resultTxt = GameController.Instance.text.FindIndex(x => x.text == "");
       
        if(resulAlert == -1 &&  resultTxt == -1)
        {
            GameController.Instance.NewRegister();    
            txtConcluido.SetActive(true);
            StartCoroutine(zerar());
        }
        else
        {
            txtNaoConcluido.SetActive(true);
            StartCoroutine(OffTxtMsgNaoConcluida());
        }

    }

   

}
