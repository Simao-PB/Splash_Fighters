using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecaoMapa : MonoBehaviour
{
    public void IrParaBattleground()
    {
        SceneManager.LoadScene("Movimentacao_mapa1");
    }

    public void IrParaPowerStation()
    {
        SceneManager.LoadScene("Movimentacao_mapa2");
    }

    public void IrParaSubway()
    {
        SceneManager.LoadScene("Movimentacao_mapa3");
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}