using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Networking;
using control;

public class WebRequest : MonoBehaviour {

    public TextAsset file;

    private void Start()
    {
        if (file.text != "")
        {
            GameController.Instance.register = JsonConvert.DeserializeObject<List<Register>>(file.text);
        }
        GameController.Instance.OnNewRegister += SerializeJson;
    }

    public void SerializeJson()
    {
        string json = JsonConvert.SerializeObject(GameController.Instance.register);
        File.WriteAllText(@"C:\Users\Eventos.Desktop-09\Project_TimeLine\Assets\Assets\Resources\json.json", json);
    }

    IEnumerator GetRequest()
    {
        UnityWebRequest http = UnityWebRequest.Get("http://localhost:3000/");
        yield return http.SendWebRequest();

        if (http.isNetworkError)
        {
            Debug.Log(http.error);
        }
        else
        {
            Debug.Log(http.downloadHandler.text);
        }

    }

    IEnumerator Upload()
    {
        string json = JsonConvert.SerializeObject(GameController.Instance.register);
        Debug.Log(json);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/",json);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log("foi");
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("json upload complete!");
        }

    }




}
