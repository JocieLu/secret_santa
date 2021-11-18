using System;
using System.Collections.Generic;
using System.Linq;

namespace testapp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> all = new List<string>();
            Dictionary<string, string> iskl = new Dictionary<string, string>();

            Console.WriteLine("Перечислите всех участников через пробел. (Например: Лена Леша Паша Анна)");
            all = Console.ReadLine().Split(" ").ToList();

            Console.WriteLine("Перечислите пары которые не должны попадть друг другу. Что бы закончить ввод пар, введите «Конец»");
            while (true)
            {

                Console.WriteLine("Введите пару (через пробел)");
                string answer = Console.ReadLine();

                if (String.Equals(answer, "Конец", StringComparison.OrdinalIgnoreCase)) break;

                List<string> para = answer.Split(" ").ToList();
                iskl.Add(para[0], para[1]);
                iskl.Add(para[1], para[0]);

            }

            List<string> dariteli = new List<string>(all);
            List<string> prinemateli = new List<string>(all);

            Dictionary<string, string> finaly = new Dictionary<string, string>();

            Random random = new Random();
            Random rnd = new Random();
            while (true)
            {

                int daritel = 0;
                int prinimatel = 0;
                if (dariteli.Count != 1 || prinemateli.Count != 1)
                {
                    daritel = random.Next(0, dariteli.Count - 1);
                    prinimatel = rnd.Next((prinemateli.Count - 1) / 2 + 1, prinemateli.Count - 1);
                }

                string firstmemb = dariteli[daritel];
                string secondmemb = prinemateli[prinimatel];

                if (String.Equals(firstmemb, secondmemb, StringComparison.OrdinalIgnoreCase)
                    || String.Equals(iskl[firstmemb], secondmemb, StringComparison.OrdinalIgnoreCase)
                    || String.Equals(iskl[secondmemb], firstmemb, StringComparison.OrdinalIgnoreCase)) continue;

                finaly.Add(firstmemb, secondmemb);

                dariteli.RemoveAt(daritel);
                prinemateli.RemoveAt(prinimatel);

                if (dariteli.Count == 0 && prinemateli.Count == 0) break;

            }

            Console.WriteLine("Итоговый список:");
            foreach (KeyValuePair<string, string> kvp in finaly)
            {
                Console.WriteLine("{0} {1}", kvp.Key.Substring(0, 1).ToUpper() + kvp.Key.Substring(1, kvp.Key.Length - 1), kvp.Value.Substring(0, 1).ToUpper() + kvp.Value.Substring(1, kvp.Value.Length - 1));
            }

            Console.ReadLine();
        }
    }
}
