# Ejercicios

1.	Dada la siguiente función, perteneciente a la clase Lista, escriba al menos 5 casos de prueba unitarios, utilizando NUnit:
'''    
    public int[] getTail(){
        int[] lista_r = new int[lista.Length-1];
        for(int i=1; i<lista.Length; i++){
            lista_r[i] = lista[i];
        }
        return lista_r;
    }

'''

2. Cree casos de prueba unitarios para cada una de las funciones de la clase LinkedList. Utilice NUnit para su creación y ejecución. Puede adjuntar un repositorio o el código fuente de las pruebas para su revisión.

- Nota: Se dejo configurado el proyecto de Test junto con un archivo con un ejemplo, para que puedan continuar el desarrollo desde ahi. 