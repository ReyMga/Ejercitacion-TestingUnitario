namespace LinkedListTest;
using NUnit.Framework;
using Classes;

public class UniteTestLinkedList
{
    private LinkedList<int> list;

    [SetUp]
    public void Setup()
    {
        list = new LinkedList<int>(1);
    }

    // Tests para add()
    [Test]
    public void Add_AgregaElemento()
    {
        list.add(2);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = "1\n2".Replace("\n", Environment.NewLine);
        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void Add_AgregaVariosElementosCorrectamente()
    {
        list.add(10);
        list.add(20);
        list.add(30);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = "1\n10\n20\n30".Replace("\n", Environment.NewLine);
        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void Add_AgregaElementoNegativo()
    {
        list.add(-5);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = "1\n-5".Replace("\n", Environment.NewLine);
        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void Add_ElementoDuplicadoSeAgrega()
    {
        list.add(1); // mismo valor que el head

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = "1\n1".Replace("\n", Environment.NewLine);
        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void Add_ListaString()
    {
        var listStr = new LinkedList<string>("Good");
        listStr.add("Vibes");

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        listStr.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = "Good\nVibes".Replace("\n", Environment.NewLine);
        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void PrintList_ImprimeTodosLosElementos()
    {
        // Arrange
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(3);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        list.printList();

        // Assert
        var output = stringWriter.ToString().Trim();
        var esperado = "1\n2\n3".Replace("\n", Environment.NewLine);
        Assert.That(output, Is.EqualTo(esperado));
    }

    // Tests para remove()
    [Test]
    public void Remove_RemoverPrimerElemento()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(3);

        list.remove(1); // eliminar primer elemento

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = "2" + Environment.NewLine + "3";

        //Falla porque la funcion debe mejorarse y actualmente no permite eliminar el primer elemento. 
        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void Remove_EliminaElementoYVerificaSalida()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(3);

        list.remove(2);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();

        var esperado = "1" + Environment.NewLine + "3";

        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void Remove_ElementoNoExiste_NoCambiaLista()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(3);

        list.remove(5); // 5 no está en la lista

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = "1" + Environment.NewLine + "2" + Environment.NewLine + "3";

        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void Remove_EliminarVariosElementosSecuencialmente()
    {
        var list = new LinkedList<int>(10);
        list.add(20);
        list.add(30);
        list.add(40);
        list.add(50);

        list.remove(20);
        list.remove(30);
        list.remove(40);

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = "10" + Environment.NewLine + "50";

        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void Remove_RemoverElementoRepetido()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(2);
        list.add(3);

        list.remove(2); // debería eliminar solo la primera aparición de 2

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = "1" + Environment.NewLine + "2" + Environment.NewLine + "3";

        Assert.That(output, Is.EqualTo(esperado));
    }


    // Tests para addIn()
    [Test]
    public void AddIn_InsertarEnElMedio()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(4);

        list.addIn(3, 1); // Inserto un 3 en la posición después del índice 1 (entre 2 y 4)

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = string.Join(Environment.NewLine, new[] { "1", "2", "3", "4" });

        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void AddIn_InsertarAntesDelUltimo()
    {
        var list = new LinkedList<int>(10);
        list.add(20);
        list.add(40);

        list.addIn(30, 1); // Se inserta 30 entre 20 y 40

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = string.Join(Environment.NewLine, new[] { "10", "20", "30", "40" });

        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void AddIn_InsertarDespuesDelHead()
    {
        var list = new LinkedList<int>(5);
        list.add(10);
        list.add(15);

        list.addIn(7, 0); // después del head

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = string.Join(Environment.NewLine, new[] { "5", "7", "10", "15" });

        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void AddIn_InsertarMismoValorDosVeces()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(4);

        list.addIn(3, 1); // lista: 1, 2, 3, 4
        list.addIn(3, 3); // lista: 1, 2, 3, 4, 3

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = string.Join(Environment.NewLine, new[] { "1", "2", "3", "4", "3" });

        Assert.That(output, Is.EqualTo(esperado));
    }

    [Test]
    public void AddIn_InsertarEnListaLarga()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.add(5);
        list.add(6);
        list.add(8);
        list.add(9);

        list.addIn(7, 5); // Se inserta 7 entre 6 y 8

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        list.printList();

        var output = stringWriter.ToString().Trim();
        var esperado = string.Join(Environment.NewLine, new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });

        Assert.That(output, Is.EqualTo(esperado));
    }


    // Tests para size()
    //Todos fallan porque size falla. El size debe ser el tamaño(size) de la lista, si tengo 1 elemento el tamaño es de 1. 
    [Test]
    public void Size_ListaConUnElementoDevuelveCero()
    {
        var list = new LinkedList<int>(1);

        var resultado = list.size();

        //Falla porque el size de la lista es de 1, porque tiene 1 elemento, seria como el length, pero esta devolviendo como length -1.
        Assert.That(resultado, Is.EqualTo(1));
    }

    [Test]
    public void Size_ListaConDosElementosDevuelveUno()
    {
        var list = new LinkedList<int>(1);
        list.add(2);

        var resultado = list.size();

        //Falla porque el size de la lista debe ser de 2, porque tiene 2 elementos, seria como el length, pero esta devolviendo como length -1.
        Assert.That(resultado, Is.EqualTo(2));
    }

    [Test]
    public void Size_ListaConCincoElementosDevuelveCuatro()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(3);
        list.add(4);
        list.add(5);

        var resultado = list.size();

        Assert.That(resultado, Is.EqualTo(5));
    }

    [Test]
    public void Size_ListaConDuplicadosDevuelveCantidadMenosUno()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(2);
        list.add(3);

        var resultado = list.size();

        Assert.That(resultado, Is.EqualTo(4));
    }

    [Test]
    public void Size_ListaLargaDevuelveCantidadMenosUno()
    {
        var list = new LinkedList<int>(0);

        for (int i = 1; i <= 99; i++)
        {
            list.add(i);
        }

        var resultado = list.size();

        Assert.That(resultado, Is.EqualTo(100));
    }


    // Tests para search()
    [Test]
    public void Search_IndiceUno_DevuelveUltimo()
    {
        var list = new LinkedList<int>(10);
        list.add(20);
        list.add(30);

        var resultado = list.search(1); // debería ser 20, pero devuelve 30

        Assert.That(resultado, Is.EqualTo(20));
    }

    [Test]
    public void Search_IndiceFueraDeRango_DevuelveUltimo()
    {
        var list = new LinkedList<int>(100);
        list.add(200);

        // debería tirar error, pero devuelve último

        Assert.Throws<Exception>(() => list.search(5));
    }

    [Test]
    public void Search_UnElemento_RetornaEseElemento()
    {
        var list = new LinkedList<string>("Hola");

        var resultado = list.search(0);

        Assert.That(resultado, Is.EqualTo("Hola"));
    }

    [Test]
    public void Search_ListaLarga_DevuelveUltimo()
    {
        var list = new LinkedList<int>(1);
        for (int i = 2; i <= 10; i++)
        {
            list.add(i);
        }

        var resultado = list.search(3); // debería devolver 4, pero devuelve 10

        Assert.That(resultado, Is.EqualTo(4));
    }

    [Test]
    public void Search_IndiceDos_DevuelveUltimo()
    {
        var list = new LinkedList<string>("X");
        list.add("Y");
        list.add("Z");

        var resultado = list.search(2); // debería devolver "Z"

        Assert.That(resultado, Is.EqualTo("Z"));
    }


    // Tests para getLast()
    [Test]
    public void GetLast_ListaUnElemento_SiempreDevuelveEse()
    {
        var list = new LinkedList<int>(5);

        var resultado = list.getLast(0); // parametro no tiene efecto

        Assert.That(resultado, Is.EqualTo(5));
    }

    [Test]
    public void GetLast_ListaVariosElementos_IndiceCeroDevuelveUltimo()
    {
        var list = new LinkedList<string>("a");
        list.add("b");
        list.add("c");

        var resultado = list.getLast(0); // parametro no tiene efecto

        Assert.That(resultado, Is.EqualTo("c"));
    }

    [Test]
    public void GetLast_ListaVariosElementos_IndiceNoUsadoDevuelveUltimo()
    {
        var list = new LinkedList<string>("x");
        list.add("y");
        list.add("z");

        var resultado = list.getLast(100); // parametro no tiene efecto

        Assert.That(resultado, Is.EqualTo("z"));
    }

    [Test]
    public void GetLast_ListaConDuplicados_SiempreDevuelveUltimo()
    {
        var list = new LinkedList<int>(1);
        list.add(2);
        list.add(2);
        list.add(3);

        var resultado = list.getLast(2); // parametro no tiene efecto

        Assert.That(resultado, Is.EqualTo(3));
    }

    [Test]
    public void GetLast_ListaLarga_IndiceNegativoIgnorado()
    {
        var list = new LinkedList<int>(1);
        for (int i = 2; i <= 10; i++)
        {
            list.add(i);
        }

        var resultado = list.getLast(-5); // parametro no tiene efecto

        Assert.That(resultado, Is.EqualTo(10));
    }
}