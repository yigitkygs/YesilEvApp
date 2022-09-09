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
            foreach (CategoryDTO category in getUpperCategories())
            {
                if ((bool)category.IsActive)
                    listUpperCategories.Items.Add(category);
            }
        }

        private List<CategoryDTO> getUpperCategories()
        {
            return new CategoryDAL().GetAllCategories().Where(a=>a.UpperCategoryID==a.CategoryID).ToList();
        }

        private void loadSubCategories()
        {
            listSubCategories.Items.Clear();
            foreach (CategoryDTO category in getSubCategories())
            {
                if ((bool)category.IsActive)
                    listSubCategories.Items.Add(category);
            }
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
            //todo delegate ile gönder
        }
    }
}
