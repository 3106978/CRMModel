using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using CrmBL.Model;

namespace CrmUi
{
    public partial class Catalog<T> : Form
        where T:class
    {
        CrmContext db;
        DbSet<T> set;
        public Catalog(CrmContext db, DbSet<T> set)
        {
            InitializeComponent();
            this.db = db;
            this.set = set;
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
        }
        private void Catalog_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (typeof(T) ==typeof(Product))
            {
                
            }
            else if (typeof(T) == typeof(Seller))
            {

            }
            else if (typeof(T) == typeof(Customer))
            {

            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
          dynamic id=  dataGridView.SelectedRows[0].Cells[0].Value;
            //ShowFormToEditElement(id);
            if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product;
                if (product != null)
                {
                    var form = new ProductForm(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller;
                if (seller != null)
                {
                    var form = new SellerForm(seller);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = set.Find(id) as Customer;
                if (customer != null)
                {
                    var form = new CustomerForm(customer);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer = form.Customer;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
        }
            
            
        
        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }

        //private void ShowFormToEditElement(dynamic id)
        //{
        //    dynamic element;
        //    dynamic form = null;
        //    if (id != null)
        //    {
        //        if (typeof(T) == typeof(Product))
        //        {
        //            element = set.Find(id) as Product;
        //            form = new ProductForm(element);

        //        }

        //        else if (typeof(T) == typeof(Customer))
        //        {
        //            element = set.Find(id) as Customer;
        //            form = new CustomerForm(element as Customer);

        //        }

        //        else if (typeof(T) == typeof(Seller))
        //        {
        //            element = set.Find(id) as Seller;
        //            form = new SellerForm(element as Seller);
        //        }

        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            element = form.element;
        //            db.SaveChanges();
        //            dataGridView.Update();
        //        }
        //    }
        //}
    }
}
