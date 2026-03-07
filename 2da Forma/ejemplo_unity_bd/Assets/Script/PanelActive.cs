using UnityEngine;
using UnityEngine.UI;

public class PanelActive : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    public Text txtMensaje;
    public Image imgColorInformacion;

    public void unactivePanel()
    {
        if(panel1 != null)
            panel1.SetActive(false);
    }

    public void activePanel()
    {
        if (panel1 != null)
            panel1.SetActive(true);
    }

    public void activatePanelRegister()
    {
        if (panel1 != null)
            panel1.SetActive(false);

        if (panel2 != null)
            panel2.SetActive(true);
    }

    public void deactivatePanelRegister()
    {
        if (panel1 != null)
            panel1.SetActive(true);

        if (panel2 != null)
            panel2.SetActive(false);
    }

    public void setMensaje(string mensaje)
    {
        txtMensaje.text = mensaje;
    }

    public void setChangeColor(int valor)
    {
        switch(valor)
        {
            case 1: // Usuario creado
                imgColorInformacion.color = Color.blue;
                break;
            case 2: // Conflicto, no se puede crear usuario
                imgColorInformacion.color = Color.yellow;
                break;
            case 3: // Error, falta agregar informacion
                imgColorInformacion.color = Color.red;
                break;
        }
    }

}
