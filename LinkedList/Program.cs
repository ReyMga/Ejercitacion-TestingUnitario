using Classes;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Classes.LinkedList<int> l = new Classes.LinkedList<int>(1);
            l.add(2);
            l.add(3);
            l.add(4);
            l.printList();

            //Luego de la posicion 2 en este caso (seria el valor 3) agregar el primer valor (en este caso el 5).
            l.addIn(5, 2);
            Console.WriteLine(" ");
            l.printList();

            //l.remove(1); //No borra el primer elemento
            Console.WriteLine(" ");
            l.printList();
            Console.WriteLine(" ");

            //size, imprime un tamaño incorrecto, porque si tengo 5 elementos me escribe 4. Porque arranca de 0 el bucle. 
            //Es como un .length, si tengo 5 me devuelve 5 como size, aca esta devolviendo la posicion de la ultima que seria 4 porque se comienza desde cero. 
            Console.WriteLine("size: " + l.size());

            //search devuelve el valor del ultimo item, porque el counter, no se suma, entonces llega hasta que se termina el array, 
            //si lo que en realidad la funcion busca es devolver el valor del indice ingresado, falta dentro del while un counter++.
            Console.WriteLine("search: " + l.search(2));

            //El parametro se requiere pero no se usa en la funcion
            Console.WriteLine("getLast: " + l.getLast(5));
        }
    }
}