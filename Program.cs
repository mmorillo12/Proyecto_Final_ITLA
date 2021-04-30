using System;

namespace Calculado_Prestamos
{
    public class Prestamo{
        protected float monto, tasa, balance;
        protected float interes_mensual;
        protected float cuota_capital, Totalcuota;
        protected int plazo;
        public float Monto{ get{return monto;} set{monto = value;}}
        public float Tasa{ get{return tasa;} set{tasa = value;}}
        public float Interes_mensual{ get{return interes_mensual;} set{interes_mensual = value;}}
        public int Plazo{ get{return plazo;} set{plazo = value;}}


        public float ConseguirInteresmensual(){
            return (monto * (tasa/100)/360)*30;
        }
        public float ConseguirCuota_Capital_Mensual(){
            return (monto / plazo);
        }
        public float ConseguirCuota_Final(){
            cuota_capital = (monto / plazo);
            interes_mensual = (monto * (tasa/100)/360)*30;
            return cuota_capital + interes_mensual;
        }
        public void Ver_datos(){
            Console.WriteLine("Monto del prestamo en RD$:           {0}", Monto);
            Console.WriteLine("Tasa de Porcentaje Anual:            {0}%", Tasa);
            Console.WriteLine("Plazo:                               {0} meses\n", Plazo);
        }

        public void Tabla_Amorticazion(){
            balance = monto;
            Console.WriteLine(" Mes     ---      Capital     ---          Interes     ---        Balance");
            Console.WriteLine(" {0}                 {1}                      {2}                    {3}", 1, ConseguirCuota_Capital_Mensual(), ConseguirInteresmensual(), balance);

            for(int i = 1; i < plazo+1; i++){
            Console.WriteLine(" {0}                 {1}                      {2}                    {3}", i+1, ConseguirCuota_Capital_Mensual(),((balance - ConseguirCuota_Capital_Mensual()) * (tasa/100)/360)*30, balance - ConseguirCuota_Capital_Mensual());
            balance = balance - ConseguirCuota_Capital_Mensual();
            } 
        }

        public void MostrarCuotaMensual(){
            Console.WriteLine("\nLa cuota mensual es {0}\n",ConseguirCuota_Final());
        }
            
        public void Salir(){
            Console.Clear();
            Console.Write("Fin del Programa");
        }
    }

    public class Ejecutable : Prestamo{
        public void Mostar_Datos(){
        int va = 0;
        Prestamo datos = new Prestamo();
        do{
                Console.WriteLine("-- SISTEMA CALCULADORA DE PRÉSTAMOS --");
                Console.WriteLine("1 -- Escoger los datos --");
                Console.WriteLine("2 -- Calcular la cuota mensual --");
                Console.WriteLine("3 -- Ver la tabla amortizada --");
                Console.WriteLine("4 -- Terminar --\n");
                Console.WriteLine("Escoja una accion");
                va = int.Parse(Console.ReadLine());
                switch(va){
                    case 1:
                    Console.WriteLine("Monto del prestamo en RD$:");
                    datos.Monto = float.Parse(Console.ReadLine());
                    Console.WriteLine("Tasa de Porcentaje Anual:");
                    datos.Tasa = float.Parse(Console.ReadLine());
                    Console.WriteLine("Plazo:");
                    datos.Plazo = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    datos.Ver_datos();
                    break;

                    case 2:
                    datos.MostrarCuotaMensual();
                    break;

                    case 3:
                    datos.Tabla_Amorticazion();
                    break;
                    
                    case 4:
                    datos.Salir();
                    break;
                }
            }while(va != 4);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Ejecutable ej = new Ejecutable();
            ej.Mostar_Datos();
        }
    }
}
