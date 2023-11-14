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
    public partial class InfoForm : Form
    {
        Product product;
        public InfoForm(Product product)
        {
            this.product = product;
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            this.Text = product.nazv_producta;

            label1.Text = String.Format("О {0}", product.nazv_producta);

            Creator creator = APIConnect.getOne<Creator>(product.kod_creatora);
            Material material = APIConnect.getOne<Material>(product.kod_materiala);

            nameLabel.Text = String.Format("Имя: {0}", creator.name);
            ageLabel.Text = String.Format("Возраст: {0}", creator.age.ToString());
            nazvMatLabel.Text = String.Format("Название: {0}", material.nazv_materiala);
            homelandLabel.Text = String.Format("От куда: {0}", material.homeland);
        }
    }
}
