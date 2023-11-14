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

namespace connection_DB_API_app.UserControllers
{
    public partial class ProductControl : UserControl
    {
        Product product;
        public ProductControl(Product product)
        {
            this.product = product;
            InitializeComponent();
        }

        private void ProductControl_Load(object sender, EventArgs e)
        {
            nazvLabel.Text = product.nazv_producta;
            costLabel.Text = String.Format("Стоимость: {0}",product.cost.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoForm form = new InfoForm(product);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить объект?", "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                try
                {
                    APIConnect.delete<Product>(product.kod_producta);
                    this.BackColor = Color.OrangeRed;
                    MessageBox.Show("Объект упешно удален, обновите главную форму","Успех");
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }

        private void nazvLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
