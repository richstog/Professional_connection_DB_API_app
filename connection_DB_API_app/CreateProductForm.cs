using connection_DB_API_app.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connection_DB_API_app
{
    public partial class CreateProductForm : Form
    {
        public CreateProductForm()
        {
            InitializeComponent();
        }

        private void CreateProductForm_Load(object sender, EventArgs e)
        {
            List<Creator> creators = APIConnect.getAll<Creator>();
            List<Material> materials = APIConnect.getAll<Material>();

            foreach (Creator creator in creators)
            {
                listBox1.Items.Add(String.Format("{0}. {1}",creator.kod_creatora, creator.name));
            }

            foreach (Material material in materials)
            {
                listBox2.Items.Add(String.Format("{0}. {1}, {2}", material.kod_materiala, material.nazv_materiala, material.homeland));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var id = APIConnect.getAll<Product>().Max(p => p.kod_producta) + 1;
            Product product = new Product();

            string str_creator = listBox1.SelectedItem.ToString().Substring(0);
            var id_creator = int.Parse(str_creator.Substring(0, str_creator.IndexOf('.')));

            string str_material = listBox2.SelectedItem.ToString().Substring(0);
            var id_material = int.Parse(str_material.Substring(0, str_material.IndexOf('.')));

            int cost = int.Parse(textBox2.Text.Trim());

            product.kod_producta = id;
            product.nazv_producta = textBox1.Text;
            product.kod_materiala = id_material;
            product.kod_creatora = id_creator;
            product.cost = cost;
            try
            {
                APIConnect.createOne<Product>(product);
                MessageBox.Show("Продукт создан, обновите главную форму", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неудачное создание", "Ошибка");
            }
        }
    }
}
