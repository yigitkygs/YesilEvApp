using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEvAppYigit.DAL.Concrete;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.WinUI
{
    public partial class BrandPopUpForm : Form
    {
        public BrandPopUpForm()
        {
            InitializeComponent();
        }

        BrandDTO selectedBrand = null;
        public delegate void BrandDelege(BrandDTO brand);
        public BrandDelege delegem;
        private void BrandPopUpForm_Load(object sender, EventArgs e)
        {
            loadBrands();
            loadManufacturers();
        }

        private void loadBrands()
        {
            listBrands.Items.Clear();
            getBrands().ForEach(a => listBrands.Items.Add(a));
        }

        private List<BrandDTO> getBrands()
        {
            return new BrandDAL().GetAllBrands().OrderBy(a=>a.BrandName).ToList();
        }

        private void loadManufacturers()
        {
            cbManufacturer.Items.Clear();
            getManufacturers().ForEach(a => cbManufacturer.Items.Add(a));
        }

        private List<ManufacturerDTO> getManufacturers()
        {
            return new ManufacturerDAL().GetAllManufacturers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(selectedBrand != null)
            {
                delegem(selectedBrand);
                this.Close();
            }
            else MessageBox.Show("Marka seçimi yapınız!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbNewBrandName.Text != "" && tbNewBrandName.Text != " " && cbManufacturer.SelectedItem != null)
            {
                ManufacturerDTO manufacturerDTO = (ManufacturerDTO)cbManufacturer.SelectedItem;

                foreach (BrandDTO item in listBrands.Items)
                {
                    if(item.BrandName == tbNewBrandName.Text)
                    {
                        MessageBox.Show("Eklemek istediğiniz marka adı zaten mevcuttur!!");
                        ResetAddNewBrand();
                        return;
                    }
                }

               bool result = new BrandDAL().AddNewBrand(new BrandDTO() { BrandName= tbNewBrandName.Text,
                IsActive=true,
                CreateDate=DateTime.Now,
                ManufacturerID = manufacturerDTO.ManufacturerID,
                Manufacturer = manufacturerDTO
                });

                if (!result) MessageBox.Show("Yeni marka eklenirken bir hata oluştu");
                else loadBrands();

            }
            ResetAddNewBrand();
        }

        private void ResetAddNewBrand()
        {
            tbNewBrandName.Text = String.Empty;
        }

        private void listBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBrands.SelectedItem != null)
            {
                selectedBrand = (BrandDTO)listBrands.SelectedItem;
            }
            tbSelectedCategory.Text = selectedBrand.BrandName;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;
        }
    }
}
