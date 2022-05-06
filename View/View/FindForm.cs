using Model;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace View
{
    public partial class FindForm : Form
    {
        BindingList<Base> lst; //список
        double eps; //точность для поиска

        public FindForm(BindingList<Base> lst)
        {
            InitializeComponent();
            this.lst = lst;
            eps = 0.0001;
        }

        //закрыть
        private void button4_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        //поиск по цене
        private void button1_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                double price = double.Parse(textBox1.Text.Replace(".", ","));
                for (int i = 0; i < lst.Count; i++)
                {
                    if (Math.Abs(lst[i].Price - price) < eps)
                    {
                        listBox1.Items.Add(lst[i] +
                            "; Цена со скидкой = " + lst[i].LastPrice());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Цена имеет неверный формат!");
            }
        }

        //поиск по скидке
        private void button2_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                double discount = double.Parse(textBox2.Text.Replace(".", ","));
                for (int i = 0; i < lst.Count; i++)
                {
                    if (Math.Abs(lst[i].Discount - discount) < eps)
                    {
                        listBox1.Items.Add(lst[i] +
                            "; Цена со скидкой = " + lst[i].LastPrice());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Скидка имеет неверный формат!");
            }
        }

        //поиск по двум полям сразу
        private void button3_Click(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                double price, discount;
                bool result = double.TryParse(textBox1.Text.Replace(".", ","), out price);
                if (!result)
                {
                    throw new Exception("Цена имеет неверный формат!");
                }
                result = double.TryParse(textBox2.Text.Replace(".", ","), out discount);
                if (!result)
                {
                    throw new Exception("Скидка имеет неверный формат!");
                }
                for (int i = 0; i < lst.Count; i++)
                {
                    if (Math.Abs(lst[i].Price - price) < eps &&
                        Math.Abs(lst[i].Discount - discount) < eps)
                    {
                        listBox1.Items.Add(lst[i] +
                            "; Цена со скидкой = " + lst[i].LastPrice());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}