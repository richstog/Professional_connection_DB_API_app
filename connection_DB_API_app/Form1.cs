using connection_DB_API_app.Classes;
using connection_DB_API_app.Compares;
using connection_DB_API_app.UserControllers;
using Npgsql;
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
    public partial class Form1 : Form
    {
        List<Product> products;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            products = APIConnect.getAll<Product>();
            loadFlow(APIConnect.getAll<Product>());
        }

        void loadFlow(List<Product> products)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (Product product in products)
            {
                ProductControl productControl = new ProductControl(product);
                flowLayoutPanel1.Controls.Add(productControl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Product> find_products = products.FindAll(p => p.cost >= Convert.ToInt32(minTextBox.Text) && p.cost <= Convert.ToInt32(maxTextBox.Text));
            loadFlow(find_products);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            products.Sort(new ProductsKodCompare());
            loadFlow(products);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            products.Sort(new ProductsNazvCompare());
            loadFlow(products);
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            List<Product> find_products = products.FindAll(p => p.nazv_producta.Contains(findTextBox.Text));
            loadFlow(find_products);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateProductForm form = new CreateProductForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            products = APIConnect.getAll<Product>();
            loadFlow(APIConnect.getAll<Product>());
        }
    }

    
}
