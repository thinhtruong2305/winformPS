using PetShopWinform.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopWinform.Forms
{
    public partial class Products : Form
    {
       
        PetshopWinformEntities db = new PetshopWinformEntities();
        public Products()
        {
            InitializeComponent();
            
        }

        
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label5.ForeColor = ThemeColor.SecondaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            LoadTheme();
            LoadData();
        }

        private void LoadData()
        {
            dgvProductList.DataSource = db.Products.ToList();
            cbCategory.DataSource = db.Categories.ToList();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product pr = new Product()
            {
                Name = txtName.Text,
                Category = Convert.ToInt32(cbCategory.SelectedValue),
                Quantity = Convert.ToInt32(txtQuantity.Text),
                Price = Convert.ToDecimal(txtPrice.Text)
            };
            db.Products.Add(pr);
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Add Successfully!");
           
        }

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvProductList.Rows[e.RowIndex].Cells[0].Value.ToString());

            Product pr = db.Products.Where(x => x.Id == id).First();

            txtId.Text = pr.Id.ToString();
            txtName.Text = pr.Name;
            cbCategory.SelectedValue = pr.Category;
            txtQuantity.Text = pr.Quantity.ToString();
            txtPrice.Text = pr.Price.ToString();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Product pr = db.Products.Where(x => x.Id == id).First();

            pr.Name = txtName.Text;
            pr.Category = Convert.ToInt32(cbCategory.SelectedValue);
            pr.Quantity = Convert.ToInt32(txtQuantity.Text);
            pr.Price = Convert.ToDecimal(txtPrice.Text);

            db.SaveChanges();
            LoadData();
            MessageBox.Show("Edit Successfully!");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Are you sure to Delete?", "EF CRUP Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (PetshopWinformEntities db = new PetshopWinformEntities())
                {
                    int id = Convert.ToInt32(dgvProductList.CurrentRow.Cells[0].Value);
                    Product pr = db.Products.Where(x => x.Id == id).First();
                    db.Products.Remove(pr);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Delete Successfully!");
                }
            }
        }

        

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Product pr = new Product();
            var results = db.Products.Where(p => p.Name.Contains(txtSearch.Text));
            dgvProductList.DataSource = results.ToList();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
