using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spo5 {
    class CombinedSortListMethod {

        public List<String>[] table_identif = new List<String>[300];

        public String time = "";
       
        public Int32[] array_table = new Int32[100];
        public int count = 0;

        public CombinedSortListMethod() {
            for (int i = 0; i < array_table.Length; i++) {
                array_table[i] = -1;
            }

            for (int i = 0; i < table_identif.Length; i++) {
                table_identif[i] = new List<string>();
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

        public void sortArray() {

            Array.Sort(table_identif, (a, b) => a.Count - b.Count);
            Array.Reverse(table_identif);
        }

        public String findElement(String element) {
           
            int index = hash_func(element);

            if (array_table[index] == -1) {
                return "not found 2 alg";
            }
            else {
                int i = array_table[index];

                bool flag = false;
                for (int h = 0; h < table_identif[i].Count; h++) {
                    if (!table_identif[i][h].Equals(element)) {
                        flag = true;
                    }
                    else {
                        flag = false;
                    }
                }

                if (flag) {
                   return "found element";
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
                List<String> elementList = new List<String>();
                elementList.Add(element);
                table_identif[count] = elementList;
                count++;
            }
            else {
                int i = array_table[index];

                bool flag = false;
                for (int h = 0; h < table_identif[i].Count; h++) {
                    if (!table_identif[i][h].Equals(element)) {
                        flag = true;
                    }
                    else {
                        flag = false;
                    }
                }

                if (flag) {
                    table_identif[i].Add(element);
                }
            }

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            time = String.Format(ts.TotalMilliseconds.ToString());

                  
        }

    }
}
