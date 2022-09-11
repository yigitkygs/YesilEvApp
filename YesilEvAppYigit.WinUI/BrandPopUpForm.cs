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

        private void BrandPopUpForm_Load(object sender, EventArgs e)
        {
            loadBrands();
        }

        private void loadBrands()
        {
            listBrands.Items.Clear();
            getBrands().ForEach(a => listBrands.Items.Add(a));
        }

        private List<BrandDTO> getBrands()
        {
            return new BrandDAL().GetAllBrands();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBrands.SelectedItem != null)
            {
                selectedBrand = (BrandDTO)listBrands.SelectedItem;
            }
            tbSelectedCategory.Text = selectedBrand.BrandName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(selectedBrand != null)
            {
                //todo delegate ile selectedBrand'i gönder
            }
            else MessageBox.Show("Marka seçimi yapınız!");
        }
    }
}
