using System;

namespace ejercicio1
{
    public class Calculadora{
        private double Resultado;

        public double Sumar (double termino){
            Resultado=Resultado+termino;
            return Resultado;
        }
        public double Restar (double termino){
            Resultado=Resultado-termino;
            return Resultado;
        }
        public double Multiplicar (double termino){
            Resultado=Resultado*termino;
            return Resultado;
        }
        public double Dividir (double termino){
            Resultado=Resultado/termino;
            return Resultado;
        }
        public void Limpiar (){
            Resultado=0;
        }
        public double Acceder(){
            return Resultado;
        }
    }
    class Program
    {
        static void Main ()
        {
            int  operacion, flags = 0;
            double numero;
            Calculadora calculadora = new Calculadora();

            while(flags == 0)
            {
                Console.WriteLine("Introduzca la operacion a realizar: ");
                Console.WriteLine("1. Sumar\n2. Restar\n3. Multiplicar\n4. Dividir\n5. Limpiar\n0. Salir");
                operacion = int.Parse(Console.ReadLine());
                
                if(operacion != 0)
                {
                    Console.WriteLine("Ingrese el numero con el que desea operar: ");
                    numero = double.Parse(Console.ReadLine());

                    switch(operacion)
                    {
                        case 1:
                            calculadora.Sumar(numero);
                            break;
                        case 2:
                            calculadora.Restar(numero);
                            break;
                        case 3:
                            calculadora.Multiplicar(numero);
                            break;
                        case 4:
                            calculadora.Dividir(numero);
                            break;
                        case 5:
                            calculadora.Limpiar();
                            break;
                    }
                    Console.WriteLine($"El resultado es: {calculadora.Acceder()}\n");
                } else
                    flags=1;
            }
        }
    }
}
