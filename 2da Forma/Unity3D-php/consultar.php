<?php
    require_once('conexion.php');

    $usuario_consultar = $_POST['usuario_unity'];
    $password_consultar = $_POST['password_unity'];

    if(!$conexion){
        echo "500"; // Internal Server Error
    } else {

        try {
            $consulta_sql = "SELECT * FROM usuario WHERE nombre_usuario LIKE '$usuario_consultar' AND password_usuario LIKE '$password_consultar'";
            $resultado = mysqli_query($conexion, $consulta_sql);

            if(mysqli_num_rows($resultado) > 0) {
                echo "200"; // OK

                $actualizar_usuario = "UPDATE usuario SET ingreso = 1 WHERE nombre_usuario = '$usuario_consultar'";
                mysqli_query($conexion, $actualizar_usuario);
            }       
            else
                echo "404"; // Not found              
        }
        catch (mysqli_sql_exception $e) {
            echo "500"; // Internal Server Error
        }   
    }

    mysqli_close($conexion);
    
?>