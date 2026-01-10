using UnityEngine;

public class PanelActive : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

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

}
