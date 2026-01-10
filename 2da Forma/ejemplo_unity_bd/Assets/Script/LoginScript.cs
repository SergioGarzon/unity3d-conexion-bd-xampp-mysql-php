using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LoginScript : MonoBehaviour
{
    public InputField txtUsuario;
    public InputField txtPassword;
    public GameObject panelMensajeError;

    public void ValidarUsuarioPassword()
    {
        StartCoroutine(Logueo());
    }

    IEnumerator Logueo()
    {
        string url = "http://localhost:8080/Unity3D-php/consultar.php?usuario_unity=" + txtUsuario.text + "&password_unity=" + txtPassword.text;


        using (UnityWebRequest conexion = UnityWebRequest.Get(url))
        {
            yield return conexion.SendWebRequest();

            if(conexion.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error en la conexion: " + conexion.error);
            } else {

                string respuesta = conexion.downloadHandler.text;

                if (respuesta == "200")
                {
                    SceneManager.LoadScene("GamePlay");
                }

                if (respuesta == "404")
                {
                    panelMensajeError.SetActive(true);
                }

                if (respuesta == "500")
                {
                    Debug.Log("Error del lado del servidor");
                }
            }

            
        }

            

        
    }

}
