using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spo5 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        ChartsMethod chartsMethod;
        CombinedSortListMethod combined;

        private void button1_Click(object sender, EventArgs e) {
            textBox4.Text = "Anyone who reads Old and Middle English literary texts will be familiar with the mid-brown volumes of the EETS, with the symbol of Alfred's jewel embossed on the front cover. Most of the works attributed to King Alfred or to Aelfric, along with some of those by bishop Wulfstan and much anonymous prose and verse from the pre-Conquest period, are to be found within the Society's three series; all of the surviving medieval drama, most of the Middle English romances, much religious and secular prose and verse including the English works of John Gower, Thomas Hoccleve and most of Caxton's prints all find their place in the publications. Without EETS editions, study of medieval English texts would hardly be possible. anya is the witch yes yes or no she is very kind and sweet because she does not have an axe but if he anya is the witch yes yes or no she is very kind and sweet because she does not have an axe but if he tyuie btyu4 8btyr uie btyuir3b цршду ыру шы is she lookong information for me i am writing the text for the laba";
            chartsMethod = new ChartsMethod();
            String[] array = textBox4.Text.Split(' ');
            for (int i = 0; i < array.Length; i++) {
                textBox1.Text += ChartsMethod.hash_func(array[i]).ToString() + " ";
                chartsMethod.addElementToTable(array[i]);
            }

            for (int i = 0; i < chartsMethod.table_identif.Count; i++) {
                textBox1.Text += Environment.NewLine + i.ToString() + ". " + chartsMethod.table_identif[i];
            }

            combined = new CombinedSortListMethod();
            for (int i = 0; i < array.Length; i++) {
                textBox2.Text += CombinedSortListMethod.hash_func(array[i]).ToString() + " ";
                combined.addElementToTable(array[i]);
            }

            combined.sortArray();

            for (int i = 0; i < combined.table_identif.Length; i++) {
                textBox2.Text += Environment.NewLine;
                if (combined.table_identif[i] != null) {
                    for (int j = 0; j < combined.table_identif[i].Count; j++) {
                        textBox2.Text += combined.table_identif[i][j] + " ";
                    }
                }
            }

            label3.Text = chartsMethod.time;
            label4.Text = combined.time;


           // ChartsMethod.hash_func("anya");
           // textBox1.Text += "\n" + new ChartsMethod().
        }

        private void button2_Click(object sender, EventArgs e) {
            label1.Text = chartsMethod.findElement(textBox3.Text);
            label2.Text = combined.findElement(textBox3.Text);
        }
    }
}
