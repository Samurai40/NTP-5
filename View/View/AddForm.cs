using System;
using System.ComponentModel;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class AddForm : Form
    {

        BindingList<Base> lst; //список

        public AddForm(BindingList<Base> lst)
        {
            InitializeComponent();
            this.lst = lst;
        }

        //добавление объекта
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double price = double.Parse(textBox1.Text.Replace(".", ","));
                double discount = double.Parse(textBox2.Text.Replace(".", ","));
                if (radioButton1.Checked)
                {
                    lst.Add(new Percent(price, discount));
                }
                else
                {
                    lst.Add(new Certificate(price, discount));
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //закрыть
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}