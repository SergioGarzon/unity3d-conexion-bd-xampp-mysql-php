using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System;

public class RegisterScript : MonoBehaviour
{
    public InputField txtUsuarioRegistro;
    public InputField txtPasswordRegistro;   

    private PanelActive pnlActivar;
    

    private void Start()
    {
        pnlActivar = GetComponent<PanelActive>();
    }

    public void RegistrarUsuario()
    {
        bool valorDevuelto = validarUsuarioClaveIngresados();

        if (valorDevuelto)
            StartCoroutine(Register());
        else
        {
            pnlActivar.setMensaje("FALTA INGRESAR USUARIO Y CONTRASEÑA");
            pnlActivar.activePanel();
            pnlActivar.setChangeColor(3);
        }
            
    }

    private bool validarUsuarioClaveIngresados()
    {
        return (txtPasswordRegistro.text != "" && txtUsuarioRegistro.text != "");
    }

    IEnumerator Register()
    {
        string url = "http://localhost:8080/Unity3D-php/insertar.php";

        WWWForm form = new WWWForm();
        form.AddField("usuario_unity", txtUsuarioRegistro.text);
        form.AddField("password_unity", txtPasswordRegistro.text);

        using (UnityWebRequest conexion = UnityWebRequest.Post(url, form))
        {
            yield return conexion.SendWebRequest();

            if (conexion.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error en la conexion: " + conexion.error);
            }
            else
            {
                string respuesta = conexion.downloadHandler.text;

                if (respuesta == "201")
                {
                    pnlActivar.setMensaje("FELICITACIONES, USUARIO CREADO CORRECTAMENTE");
                    pnlActivar.activePanel();
                    pnlActivar.setChangeColor(1);
                }

                if (respuesta == "409")
                {
                    pnlActivar.setMensaje("NO ES POSIBLE CREAR EL USUARIO, PORQUE YA EXISTE");
                    pnlActivar.activePanel();
                    pnlActivar.setChangeColor(2);
                }             
                   
                
            }


        }




    }
}
