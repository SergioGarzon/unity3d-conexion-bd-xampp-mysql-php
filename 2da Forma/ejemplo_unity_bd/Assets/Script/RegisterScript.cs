using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class RegisterScript : MonoBehaviour
{
    public InputField txtUsuarioRegistro;
    public InputField txtPasswordRegistro;

    public void RegistrarUsuario()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        string url = "http://localhost:8080/Unity3D-php/insertar.php?usuario_unity=" + txtUsuarioRegistro.text + "&password_unity=" + txtPasswordRegistro.text;


        using (UnityWebRequest conexion = UnityWebRequest.Get(url))
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
                    Debug.Log("Usuario creado");
                }

                if (respuesta == "409")
                {
                    Debug.Log("Usuario ya existe, no se puede crear");
                }
            }


        }




    }
}
