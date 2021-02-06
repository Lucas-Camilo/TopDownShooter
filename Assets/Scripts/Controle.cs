using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controle : MonoBehaviour
{
    public void CarregarNovaTela(string nomeDaTela)
    {
        SceneManager.LoadScene(nomeDaTela);
    }
    public void Fechar()
    {
        Application.Quit();
    }
}
