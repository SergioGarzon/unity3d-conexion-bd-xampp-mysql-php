<?php    
    require_once('conexion.php');

    $usuario_insertar = $_POST['usuario_unity'];
    $password_insertar = $_POST['password_unity'];

    if(!$conexion){
        echo "500"; // Internal Server Error
    } else {

        try {
            $consultar_sql = "SELECT * FROM usuario WHERE nombre_usuario = '$usuario_insertar'";
            $resultado_consulta = mysqli_query($conexion, $consultar_sql);

            if(mysqli_num_rows($resultado_consulta) > 0){
                echo "409"; // Conflict
            } else {
                $insercion_sql = "INSERT INTO usuario (nombre_usuario, password_usuario, ingreso) VALUES ('$usuario_insertar','$password_insertar', 0)";
                $resultado = mysqli_query($conexion, $insercion_sql);

                echo "201"; // Created            
            } 

        } catch (mysqli_sql_exception $e) {
            echo "500"; // Internal Server Error
        }     
    }

    mysqli_close($conexion);
    
?>