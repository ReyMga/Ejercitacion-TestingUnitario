using NUnit.Framework;
using Classes;

namespace LinkedListTest
{
    public class ListaTests
    {
        private static readonly int[] expected_1 = new int[] { };

        [Test]
        public void GetTail_LanzaExcepcionConTresElementos()
        {
            var lista = new Lista(new int[] { 1, 2, 3 });
            //Porque lista_r tiene 1 posicion menos que lista, y en el for contempla hasta la ultima posicion de lista. 
            Assert.Throws<System.IndexOutOfRangeException>(() => lista.getTail());
        }

        [Test]
        public void GetTail_LanzaExcepcionConDosElementos()
        {
            var lista = new Lista(new int[] { 10, 20 });
            //Porque lista_r tiene 1 posicion menos que lista, y en el for contempla hasta la ultima posicion de lista. 
            Assert.Throws<System.IndexOutOfRangeException>(() => lista.getTail());
        }

        [Test]
        public void GetTail_LanzaExcepcionConUnElemento()
        {
            var lista = new Lista(new int[] { 5 });
            var resultado = lista.getTail();
            //Al iniciar en 1 el for, no entra y por eso el resultado es array vacio. 
            Assert.That(resultado, Is.EqualTo(expected_1));
        }

        [Test]
        public void GetTail_LanzaExcepcionConListaVacia()
        {
            var lista = new Lista(new int[] { });
            //Porque intenta hacer new int de - 1 --> new int[- 1]
            Assert.Throws<System.OverflowException>(() => lista.getTail());
        }

        [Test]
        public void GetTail_LanzaExcepcionConNumerosNegativos()
        {
            var lista = new Lista(new int[] { -1, -2, -3 });
            // Porque lista_r tiene 1 posicion menos que lista, y en el for contempla hasta la ultima posicion de lista.
            Assert.Throws<System.IndexOutOfRangeException>(() => lista.getTail());
        }
    }
}