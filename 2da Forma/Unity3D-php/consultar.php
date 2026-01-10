<?php
    require_once('conexion.php');

    $usuario_consultar = $_GET['usuario_unity'];
    $password_consultar = $_GET['password_unity'];

    if(!$conexion){
        echo "500"; // Internal Server Error
    } else {
        $consulta_sql = "SELECT * FROM usuario WHERE nombre_usuario LIKE '$usuario_consultar' AND password_usuario LIKE '$password_consultar'";
        $resultado = mysqli_query($conexion, $consulta_sql);

        if(mysqli_num_rows($resultado) > 0){
            echo "200"; // OK
        } else {
            echo "404"; // Not found
        }

        mysqli_close($conexion);
    }
    
?>