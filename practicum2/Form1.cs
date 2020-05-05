using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace practicum2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            // De random nummers setten in de 3 verschillende invoervelden. Ik set ze als String, aangezien ze in de button1_Click methode worden geparst naar een int.
            Random random = new Random();

            // De random nummers zullen telkens onder de 10 zijn.
            num1Text.Text = random.Next(10).ToString();
            num2Text.Text = random.Next(10).ToString();
            num3Text.Text = random.Next(10).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = Int32.Parse(num1Text.Text);
            int num2 = Int32.Parse(num2Text.Text);
            int num3 = Int32.Parse(num3Text.Text);
            
            String output = MethodRunner.RunAllMethods(num1,num2,num3);
            methodOutput.Text = output;

            output = LambdaRunner.RunAllMethods(num1,num2,num3);
            lambdaOutput.Text = output;

            // Check of de outputs gelijk zijn
            bool result = compareOutput();
            
            // Toont juiste bericht in een MessageBox
            String outputMessage = result ? "Results OK!" : "Results not OK!";
            System.Windows.Forms.MessageBox.Show(outputMessage);
        }

        // Methode die checkt of de outputs na het '='-teken gelijk zijn
        private bool compareOutput()
        {
            // De boolean die uiteindelijk weergeeft of alle uitkomsten gelijk zijn aan elkaar
            bool result = true;

            // Alle lines van de methodOutput textfield zonder de lege lines
            IEnumerable<String> methodOutputLines = methodOutput.Lines.Where(line => !String.IsNullOrWhiteSpace(line));

            // Alle lines van de lambdaOutput textfield zonder de lege lines
            IEnumerable<String> lambdaOutputLines = lambdaOutput.Lines.Where(line => !String.IsNullOrWhiteSpace(line));


            for (int i=0; i<methodOutputLines.Count(); i++)
            {
                // Ieder methodOutput uitkomst per line
                String methodAnswer = methodOutput.Lines[i].Split('=').Last();
                // Ieder lambdaOutput uitkomst per line
                String lambdaAnswer = lambdaOutput.Lines[i].Split('=').Last();

                // Als de methodOutput en lambdaOutput verschillen, wordt de result boolean op false gezet
                if (!methodAnswer.Equals(lambdaAnswer))
                {
                    result = false;
                }
            }

            return result;
        }

    }
}
