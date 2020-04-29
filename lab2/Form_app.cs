using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mсr_lib;

namespace app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_find_paradigma_Click(object sender, EventArgs e)
        {
            string dicitonaryName = "zal.mcr";
            Mcr.InitMcr();
            Mcr.LoadMcr(dicitonaryName);

            Mcr.Tids tids = new Mcr.Tids();

            if (txb_input.Text == string.Empty)
            {
                MessageBox.Show("Введите данные для поиска!");
            }
            else
            {
                int wordID = Mcr.FindWID(txb_input.Text, ref tids);

                if (wordID > 0)
                {
                    Mcr.Tinlexdata wordParadigma = new Mcr.Tinlexdata();

                    Mcr.GetWordById(tids.ids[0], false, true, ref wordParadigma);

                    for (int i = 0; i < wordParadigma.inlex.Length; i++)
                    {
                        var paradigma = wordParadigma.inlex[i];

                        if (paradigma.anword != string.Empty)
                        {
                            listBox_output.Items.Add(paradigma.anword);
                        }
                    }
                }
                else
                {
                    listBox_output.Items.Add(" Парадигма для слова " + "[" + txb_input.Text + "]" + " в словаре Зализняка не найдена");

                    var mystemOptions = "-i -n -e 1251";
                    FindWithMystem(mystemOptions);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            riTxtB_output.Clear();
            txb_input.Clear();
            listBox_output.Items.Clear();
        }

        private void FindWithMystem(string mystemOptions)
        {
            riTxtB_output.WordWrap = true;
            Process process = new Process();
            process.StartInfo.FileName = "mystem.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Arguments = mystemOptions;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.StandardInput.WriteLine(txb_input.Text);
            process.StandardInput.Close();
            process.StandardInput.Dispose();
            string result = process.StandardOutput.ReadToEnd();
            process.StandardOutput.Close();
            process.Close();
            riTxtB_output.Text = result.Replace('|', '\n');
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
