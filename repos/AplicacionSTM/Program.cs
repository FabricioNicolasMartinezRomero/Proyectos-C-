using System.Text.RegularExpressions;
namespace AplicacionSTM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boolean menu = true;
            String aux;
            int boleto = 0, recaudado = 0, menores = 0, mayores = 0, comun = 0;
            int[] CI = new int[100];
            int[] CIEstudiante = new int[100];
            int[] edad = new int[100];
            int[] saldo = new int[100];

            CI[0] = 1; CI[1] = 2;CI[2]=3 ;//Asignamos la cedula a los trabajadores
            CIEstudiante[0] = 1;//Asignamos la cedula a los estudiantes
            edad[0] = 17; edad[1] = 22; edad[2] = 24;//Asignamos las edades
            saldo[0] = 18; saldo[1] = 19; saldo[2] = 1700;//Asignamos el saldo a la s tarjetas 
              
            while (menu)//Mostramos varias veces el menu 
            {
                Console.Clear();
                Console.WriteLine("Ingrese una opcion \n1)Recargar boletera \n2)Viajar\n3)Finalizar y mostrar informacion de viaje");//Le mostramos un mensaje para que ingrese una opcion
                aux = Console.ReadLine();//Guardamos la Opcion
                    switch (validarNum(aux))//Analiuzamos la opcion
                    {
                        case 1://Inicio opcion de recargar
                            //Pedimos su CI para ver si existe 
                            Console.Clear();//Limpiamos la consola
                            Console.WriteLine("Ingrese la CI a buscar\n");
                            aux = Console.ReadLine();//Pedimos la cedula a buscar
                            int x = Array.IndexOf(CI, validarNum(aux));//Me retorna la pocicion encontrada
                           
                        if (x != -1)//Si encuentra al usuario
                        {
                            Console.WriteLine("\nCedula:" + CI[x] + "Edad:" + edad[x] + "Saldo:" + saldo[x]);
                            if (Array.IndexOf(CIEstudiante, int.Parse(aux)) != -1 && edad[x] <= 21)//Validamos si es un estudiante y es menor de edad
                            {
                                saldo[x] = 50;//Le damos 50 boleto si es estudiante y menor de edad
                                Console.WriteLine("Se han recargado los boletos");
                            }
                            else//Si es mayor de edad le combramos
                            {
                                Console.WriteLine("Dinero a recargar:$");
                                aux = Console.ReadLine();
                                saldo[x] += int.Parse(aux);
                                Console.WriteLine("Se le han recargado $" + aux + "\n");
                                recaudado += int.Parse(aux);//Le sumamos la plata a recaudado
                            }
                        }else
                        {
                            Console.WriteLine("\nEl usuario no esta registrado\nVolviendo al inicio");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Cedula:" + CI[x] + "Edad:" + edad[x] + "Saldo:" + saldo[x]);
                        Console.WriteLine("\nPrecione una tecla para continuar");
                        Console.ReadKey();
                            break;//Final opcion de recargar
                      //------------------------------------------------------------------------------//
                    case 2://Inicio opcion de viajar
                        Console.Clear();//limpiamos la consola   
                        do
                        {
                            Console.WriteLine("Seleccione el voleto\n\n1)1 Horas $45           2)2 Horas $67\n3)Comun $56             4)Metropolitano $70");
                            aux = Console.ReadLine();//Guardar la opcion
                            switch (validarNum(aux))//Valido la opcion y guardo el valor del boleto
                            {
                                case 1://Boleto de 1 hora
                                    boleto = 45;
                                    break;
                                case 2://Boleto de 2 horas
                                    boleto = 56;
                                    comun++;
                                    break;
                                case 3://Boleto comun
                                    boleto = 56;
                                    break;
                                case 4://Boleto Metropolitano
                                    boleto = 70;
                                    break;

                                default:
                                    Console.WriteLine("\nBoleto invalido");
                                    break;
                            }
                        } while (validarNum(aux)>4 || validarNum(aux)==-1);

                        Console.WriteLine("Ingrese la cedula");//Le pedimos que ingrese la cedula
                        aux = Console.ReadLine();//Guardamos la cedula
                        int x2 = Array.IndexOf(CI, validarNum(aux));//Verificamos si esta ingresado el usuario

                        if (Array.IndexOf(CIEstudiante, validarNum(aux)) != -1 && edad[x2] <= 21)//Analiza si es estudiante y es menor a 21
                        {
                            saldo[x2] -= 1;//Le restamos un boleto
                            menores++;//Aumenta el viaje de menores en 1

                        }
                        else
                        {
                            if(Array.IndexOf(CIEstudiante,validarNum(aux)) != -1 && edad[x2] >21)//Si es estudiante y es mayor a 21 se le cobra la mitad
                            {
                                saldo[x2] -= (boleto / 2);//Le cobramos la mitad
                                recaudado += (boleto / 2);
                                mayores++;//Aumenta el viaje de mayores
                            }
                            else//No es estudiante
                            {
                                if (Array.IndexOf(CI, validarNum(aux)) != -1)
                                {
                                    saldo[x2] -= boleto;//Si no es estudiante le descontamos el boleto normal
                                    recaudado += boleto;
                                }
                                else
                                {
                                    Console.WriteLine("\nEl usuario  ingresado no esta registrado");
                                    Console.ReadKey();
                                }
                                
                            }
                        }
                        break;//Final opcion de viajar
                    case 3:
                        Console.WriteLine("Dinero recaudado:$"+recaudado+"\n"+"Pasajeros menores:"+menores+"\nMayores:"+mayores+"\nComunes:"+comun);
                        Console.ReadKey();
                        Console.WriteLine("\nDesea realizar otro viaje\nPrecione 1 para si, cualquier tecla apra no\n");
                        aux=Console.ReadLine();
                        if (validarNum(aux)==1) {
                            recaudado = 0; mayores=0; menores = 0; comun = 0;
                        break;
                        }
                        else
                        {
                            menu = false;
                        }
                        
                        break;
                        default://Selecciono una opcion que no existe
                            Console.WriteLine("\nOpcion no valida\n");
                            Console.ReadKey();
                        break;
                    }
            }
        }
        //Inicio creacion de metodo
        public static int validarNum(String x)//Creamos un metodo para validar numero
        {
            if (Regex.IsMatch(x, "[0-9]+"))//Validamos si es un numero y no esta vacio "+"
            {
                return int.Parse(x);//Me duevuelve el numero valido
            }
            return -1;//Si no cumple la condicion por defecto devuelve -1
        }
        //Finalizamos la creacion de metodos
    }
}