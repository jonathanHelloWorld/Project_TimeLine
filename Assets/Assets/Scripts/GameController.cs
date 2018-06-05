using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace control
{
    public class GameController : Singleton<GameController>
    {
        public delegate void SimpleEvent();
        public event SimpleEvent  OnNewRegister;
        public List<Register> register = new List<Register>();
        public List<Text> text = new List<Text>();
        public List<GameObject> alerts = new List<GameObject>();

        


        public void NewRegister()
        {
            register.Add(new Register
            {
                nome = text[0].text,
                email = text[1].text,
                cpf = text[2].text,
                tel = text[3].text
            });

            if (OnNewRegister != null)
            {
                OnNewRegister();
            }
        }

        public void SearchNameInRegister()
        {
            int resultNome;

            resultNome = register.FindIndex(x => x.nome == text[0].text);
            if (resultNome != -1)
                alerts[0].SetActive(true);
            else alerts[0].SetActive(false);
        }

        public void SearchEmailInRegister()
        {
            int resultEmail;

            resultEmail = register.FindIndex(x => x.email == text[1].text);
            if (resultEmail != -1)
                alerts[1].SetActive(true);
            else alerts[1].SetActive(false);
        }

        public void SearchCpfInRegister()
        {
            int resultCpf;
      
            resultCpf = register.FindIndex(x => x.cpf == text[2].text);
            if (resultCpf != -1 || text[2].text.Length != 11)
                alerts[2].SetActive(true);
            else alerts[2].SetActive(false);
        }

        public void SearchTelInRegister()
        {
            int resultTel;

            resultTel = register.FindIndex(x => x.tel == text[3].text);
            if (resultTel != -1)
                alerts[3].SetActive(true);
            else alerts[3].SetActive(false);
        }

    }

    [System.Serializable]
    public class Register
    {
        public string nome;
        public string email;
        public string cpf;
        public string tel;
    }

}