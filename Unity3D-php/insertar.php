<?php    
    require_once('conexion.php');

    $usuario_insertar = $_GET['usuario_unity'];
    $password_insertar = $_GET['password_unity'];

    if(!$conexion){
        echo "500"; // Internal Server Error
    } else {

        $consultar_sql = "SELECT * FROM usuario WHERE nombre_usuario = '$usuario_insertar'";
        $resultado_consulta = mysqli_query($conexion, $consultar_sql);

        if(mysqli_num_rows($resultado_consulta) > 0){
            echo "409"; // Conflict
        } else {
            $insercion_sql = "INSERT INTO usuario (nombre_usuario, password_usuario) VALUES ('$usuario_insertar','$password_insertar')";
            $resultado = mysqli_query($conexion, $insercion_sql);

            echo "201"; // Created            
        } 
        
        mysqli_close($conexion);
    }
    
?>