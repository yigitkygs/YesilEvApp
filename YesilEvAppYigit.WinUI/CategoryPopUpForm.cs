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
    public partial class CategoryPopUpForm : Form
    {
        public CategoryPopUpForm()
        {
            InitializeComponent();
        }

        private void CategoryPopUpForm_Load(object sender, EventArgs e)
        {
            loadUpperCategories();
        }

        CategoryDTO selectedUpperCategory=null;
        CategoryDTO selectedSubCategory = null;


        private void loadUpperCategories()
        {
            listUpperCategories.Items.Clear();
            getUpperCategories().ForEach(a => listUpperCategories.Items.Add(a));
        }

        private List<CategoryDTO> getUpperCategories()
        {
            return new CategoryDAL().GetAllCategories().Where(a=>a.UpperCategoryID==a.CategoryID).ToList();
        }

        private void loadSubCategories()
        {
            listSubCategories.Items.Clear();
            getSubCategories().ForEach(a => listSubCategories.Items.Add(a));
        }

        private List<CategoryDTO> getSubCategories()
        {
            return new CategoryDAL().GetAllCategories().Where(a => a.UpperCategoryID == selectedUpperCategory.CategoryID && a.UpperCategoryID!=a.CategoryID).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listUpperCategories.SelectedItem != null)
            {
                selectedUpperCategory = (CategoryDTO)listUpperCategories.SelectedItem;
                loadSubCategories();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listSubCategories.SelectedItem != null)
            {
                selectedSubCategory = (CategoryDTO)listSubCategories.SelectedItem;
            }
            tbSelectedCategory.Text = selectedSubCategory.CategoryName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedSubCategory != null)
            {
                //todo delegate ile gönder
            }
            else MessageBox.Show("Kategori seçimi yapınız!");
        }
    }
}
