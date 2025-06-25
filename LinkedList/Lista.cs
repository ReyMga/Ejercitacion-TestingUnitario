namespace Classes
{
    public class Lista
    {
        private int[] lista;

        public Lista(int[] _lista)
        {
            lista = _lista;
        }

        public int[] getTail()
        {
            int[] lista_r = new int[lista.Length - 1];
            for (int i = 1; i < lista.Length; i++)
            {
                lista_r[i] = lista[i];
            }
            return lista_r;
        }
    }
}
