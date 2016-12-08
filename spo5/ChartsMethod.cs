using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spo5 {
    class ChartsMethod {

        public Int32[] array_table = new Int32[100];
        public int count = 0;
        public String time = "";

        public List<String> table_identif = new List<String>();

        public ChartsMethod() {
            for (int i = 0; i < array_table.Length; i++) {
                array_table[i] = -1;
            }
        }

        public static int hash_func(String element) {
            byte[] bytes = Encoding.Unicode.GetBytes(element);
            int sum = 0;

            foreach (byte b in bytes)
                for (int i = 0; i < 8; i++)
                    sum += (b >> i) & 1;
            return sum;
        }

        public String findElement(String element) {
            
            int index = hash_func(element);

            if (array_table[index] == -1) {
                return "такого элемента нет";
            }
            else {
                int i = array_table[index];
                bool flag = false;
                while (!flag) {
                    if (!element.Equals(table_identif[i].Split(' ')[0])) {
                        if (table_identif[i].Split(' ')[1].Equals("-")) {
                            flag = true;
                        }
                        else {
                            i = Int32.Parse(table_identif[i].Split(' ')[1]);
                        }
                    }
                    else {
                        return "Такой элемент существует.";
                    }
                }
            }
            return "";

        }

        public void addElementToTable(String element) {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int index = hash_func(element);

            if (array_table[index] == -1) {
                array_table[index] = count;
                table_identif.Add(element + " " + "-");
                count++;
            }
            else {
                int i = array_table[index];
                bool flag = false;
                while (!flag) {
                    if (!element.Equals(table_identif[i].Split(' ')[0])) {
                        if (table_identif[i].Split(' ')[1].Equals("-")) {
                            table_identif[i] = table_identif[i].Split(' ')[0] + " " + Convert.ToString(count);
                            table_identif.Add(element + " " + "-");
                            count++;
                            flag = true;
                        }
                        else {
                            i = Int32.Parse(table_identif[i].Split(' ')[1]);
                        }
                    }
                    else {
                        flag = true;
                    }
                }
            }

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            time = String.Format(ts.TotalMilliseconds.ToString());

            
        }


    }
}
