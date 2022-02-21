using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int entero = -2; //Entero de 4 bytes
            uint enteroPositvo = 2; //Entero positivo de 4 bytes
            long enteroLong = 12; //Entero de 8 bytes
            decimal cosaRara = -2; //Esto parece solo recibir enteros pero cosas rara.

            string stringTipico = "Un String tipico de toda la vida"; // Supuestamente 2bytes por caracter. Esto es mucho
            char caracter = 'a'; //Un caracter, 2 bytes.

            bool boleano = false; //Un booleano de toda la vida, 1 bit.
            
            float floatT = 45.2f; //Un float , 4 bytes. 6-7 digitos.
            double doubleTipico = 5.2; // Double 8 bytes. Hasta 15 digitos.

            //Leyendo datos por consola. 
            Console.WriteLine("Leyendo String, nombre: ");
            string leyendoString = Console.ReadLine();

            Console.WriteLine("Leyendo un int");
            int convertir = Convert.ToInt32(Console.ReadLine()); //Convertir a int, no funciona para uint.
            Console.WriteLine("Leyendo un unit");
            uint convUint = Convert.ToUInt32(Console.ReadLine());

            //Declaracion multiple
            var(bool1, bool2, bool3) = (false,"true",false);


            Console.WriteLine("Hello "+leyendoString);
            Console.WriteLine($"Hola {leyendoString}!, de {convUint} años.");
            //pr.arreglos();
            */


            Program pr = new Program();

            int m = 18;
            int n = 18;
            //Dictionary<string,uint> memo = new Dictionary<string, uint>();
            // Console.WriteLine(pr.travelerProblem(n,m,memo));

            n = 100;

            int[] nums = {1, 2, 5, 25 };
            Dictionary<int, bool> memo = new Dictionary<int, bool>();
            Dictionary<int, LinkedList<int>> memo2 = new Dictionary<int, LinkedList<int>>();
            //Console.WriteLine(pr.canSum(n, nums, memo));
            //Console.WriteLine(new LinkedList<int>());
            LinkedList<int> resp = pr.bestSum(n, nums, memo2);
            foreach(int numero in resp){
                Console.WriteLine(numero);
            }
        }
        void arreglos() {

            string[] coffeTypes;///
            float[] coffeValues;
            coffeTypes = new string[] { "Expresso", "Largo", "Filtrado"};
            coffeValues = new float[3];

            coffeValues[0] = 4.5f;

            Console.WriteLine($"coffe {coffeTypes[0]} value: {coffeValues[0]}");

        }

        uint travelerProblem(int n , int m, Dictionary<string,uint> memo) {

            
            string key = n + "," + m;
            if (n == 0 || m == 0) return 0;
            if (n == 1 && m == 1) return 1;
            if (memo.ContainsKey(key)) return memo[key]; 

            memo[key] = travelerProblem(n - 1, m, memo) + travelerProblem(n, m - 1, memo);
         
            return memo[key];
        }

        bool canSum(int n, int[] nums, Dictionary<int, bool> memo ) {

            if (n < 0) return false;
            if (n == 0) return true;
            if (memo.ContainsKey(n)) return memo[n];

            for (int i = 0; i < nums.Length; i++)
            {
               
                memo[n] = canSum(n - nums[i], nums, memo) ;
                if (memo[n] == true) {
                    Console.WriteLine(nums[i]);
                    return true; 
                }
            }

            return false;



        }

        LinkedList<int> bestSum(int n, int[] nums, Dictionary<int,LinkedList<int>> memo) {

            if (memo.ContainsKey(n)) return memo[n];
            if (n < 0) return null;
            if (n == 0) return  new LinkedList<int>();
            

            int resp = 0;
            for (int i = 0; i < nums.Length; i++) {
                
                memo[n] = bestSum(n-nums[i], nums, memo);
                
                if (memo[n] != null ) {
                    memo[n].AddFirst(nums[i]);
                    
                    if (resp ==0 || memo[n].Count < resp) {
                        resp = memo[n].Count;
                        
                        
                    }
                        
                   

                }
            }
            return memo[n];
        
        }
    }
    
}
