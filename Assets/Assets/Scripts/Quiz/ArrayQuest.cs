using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayQuest : MonoBehaviour
{
    public List<Quests> quest = new List<Quests>();
    public List<Button> _btns;
    public Text NameQuest, acertou;
    public Text[] text;
    string resposta;
    static int[] randons;
    static int[] embaralhar = new int[9];
    public static int num, certo = 0, nd = 0, c = 0, c2 = 0, qtd = 0, nnn = 0, contador = 0, totalPgts;
    public Image[] img;
    //public GameObject certoM, erradoM;
    Color corOriginal;



    void Awake()
    {
        nnn = 0;
        randons = new int[quest.Count];
        nullFull();
        corOriginal = img[0].color;
        escolhas();
        totalPgts = quest.Count;
        Debug.Log(totalPgts);
        Debug.Log(quest.Count);

    }

    void Update()
    {
       
    }


    void escolhas()
    {
        int aux;
        bool vdd = true;
        encher();
        c2 = 0;
        while (vdd && qtd < 9)
        {

            num = Random.Range(0, quest.Count);
            if (Search(num) == true)
            {
                vdd = true;
            }
            else
            {
                nd++;
               // Desempenho.text = nd.ToString() + "/9";
                randons[c] = num;
                NameQuest.text = quest[num].nomeQuest;
                foreach (alternativas get in quest[num].alternativa)
                {
                    aux = pegaNum();
                    text[aux].text = get.nome;


                    if (get.condicao == true)
                    {
                        resposta = get.nome;
                        certo = aux;
                    }

                }
                c++;
                qtd++;
                vdd = false;
            }


        }



    }

    public void logicaDaCoisa(int id)
    {
        contador++; 
        if (qtd <= 9)
        {
            if (resposta == text[id].text)
            {
                nnn++;
                //certoM.SetActive(true);
                mostrarResposta(id);
                offInteractable();
               
            }
            else if (text[id].text != resposta)
            {
               // erradoM.SetActive(true);
                mostrarButton(id);
                mostrarResposta(certo);
                offInteractable();
            }

            StartCoroutine("clicando");
        }
        if(qtd == 9)
        {
            acertou.text = nnn.ToString("00");
            StartCoroutine(esperaMeu());
        }
    }

    IEnumerator esperar5Sgs(int index)
    {
        yield return new WaitForSeconds(1.0f);
        img[index].color = corOriginal;
       // certoM.SetActive(false);
        //erradoM.SetActive(false);
    }
    IEnumerator clicando()
    {
        yield return new WaitForSeconds(1.0f);
        OnInteractable();
        escolhas();
    }
    IEnumerator esperaMeu()
    {
        yield return new WaitForSeconds(2.0f);
        //Desempenho.text = "/9";
        certo = 0; nd = 0; c = 0; c2 = 0; qtd = 0; contador = 0;
        Pagination.Instance.OpenPage(2);
        // Application.LoadLevel("PlacarBack");
    }
  

    bool Search(int n)
    {
        for (int i = 0; i < quest.Count; i++)
        {
            if (n == randons[i])
            {
                return true;
            }
        }

        return false;
    }

    bool Search2(int n)
    {
        for (int i = 0; i < 9; i++)
        {
            if (n == embaralhar[i])
            {
                return true;
            }
        }

        return false;
    }

    int pegaNum()
    {
        int num2 = 0;
        bool positivo = true;

        while (positivo)
        {
            num2 = Random.Range(0, 3);

            if (Search2(num2) == true)
            {
                positivo = true;
            }
            else
            {
                embaralhar[c2] = num2;
                c2++;
                positivo = false;
            }

        }
        return num2;
    }

    void nullFull()
    {
        for (int i = 0; i < quest.Count; i++)
        {
            randons[i] = -1;
        }

    }

    void encher()
    {
        for (int i = 0; i < 9; i++)
        {
            embaralhar[i] = -1;
        }
    }





    void mostrarResposta(int aux2)
    {
        
        img[aux2].color = new Color(0,1, 1);
        StartCoroutine(esperar5Sgs(aux2));
    }

    void mostrarButton(int idb)
    {
        img[idb].color = new Color(1, 1, 1);
        StartCoroutine(esperar5Sgs(idb));
    }


    void offInteractable()
    {
        for(int i = 0; i< _btns.Count; i++)
        {
            _btns[i].interactable = false;
        }
    }

   
    void OnInteractable()
    {
        for (int i = 0; i < _btns.Count; i++)
        {
            _btns[i].interactable = true;
        }
    }

}

[System.Serializable]
public class Quests
{
    public string nomeQuest;
    public List<alternativas> alternativa;

    public Quests(string nomeQuest)
    {
        this.nomeQuest = nomeQuest;
        alternativa = new List<alternativas>();
    }



    public override string ToString()
    {
        int i = 0;
        string S = nomeQuest + ", ";
        foreach (alternativas get in alternativa)
        {
            S += get.nome + ", ";
            i++;
        }
        return S;

    }

}

[System.Serializable]
public class alternativas
{
    public string nome;
    public bool condicao;


    public alternativas(string nome, bool condicao)
    {
        this.nome = nome;
        this.condicao = condicao;

    }


    public override string ToString()
    {
        return nome
             + ", "
             + condicao;

    }

    void answer()
    {
        if (this.condicao == true)
        {

        }
    }
}

