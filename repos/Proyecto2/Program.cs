namespace Proyecto2
{
    internal class Program
    {
        static void Main(string[] args)

        {
            ArrayList<string> arrayList = new ArrayList();
            arrayList.Add("Hola")
            arrayList.Add("Mundo")


                for (int i = 0; i < arrayList.count(); i++)
            {
                Console.WriteLine(arrayList.get(i));
            }

            Console.ReadKey();
        }
    }
}
