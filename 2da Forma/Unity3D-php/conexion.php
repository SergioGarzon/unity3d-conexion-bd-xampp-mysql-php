<?php
    $servidor = 'localhost';
    $usuario = 'root';
    $password = 'root';
    $baseDatos = 'ejemplo_unity';

    $conexion = mysqli_connect($servidor, $usuario, $password, $baseDatos) or die(mysqli_error());
?>