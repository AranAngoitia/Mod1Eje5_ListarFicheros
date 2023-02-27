Imports System
Imports System.IO

Module Program

    Sub MostrarDirectorio(rutaDirectorio As DirectoryInfo)
        Console.WriteLine("Directorio que se va a listar: {0}", rutaDirectorio.FullName)

        Dim fichero As FileInfo
        If rutaDirectorio.GetFiles().Count > 0 Then
            For Each fichero In rutaDirectorio.GetFiles()
                Console.WriteLine("Fichero: {0}", fichero.Name)
            Next
        Else
            Console.WriteLine("El directorio {0} no contiene ficheros", rutaDirectorio.FullName)
        End If

        Dim subdirectorios As DirectoryInfo() = rutaDirectorio.GetDirectories()
        Dim subdir As DirectoryInfo
        If subdirectorios.Count > 0 Then
            For Each subdir In subdirectorios
                Console.WriteLine("Subdirectorio: {0}", subdir.Name)
                MostrarDirectorio(subdir)
            Next
        Else
            Console.WriteLine("El directorio {0} no contiene otros directorios", rutaDirectorio.FullName)
        End If

    End Sub

    Sub Main(args As String())
        Console.WriteLine("Introduzca la ruta completa del directorio")
        Dim path As String = Console.ReadLine()

        If String.IsNullOrEmpty(path) Then
            Console.WriteLine("No se ha introducido ningún directorio")
            Exit Sub
        End If

        Dim miDirectorio As DirectoryInfo = New DirectoryInfo(path)
        If (miDirectorio.Exists) Then
            MostrarDirectorio(miDirectorio)
        Else
            Console.WriteLine("El directorio introducido no existe")
        End If
    End Sub
End Module
