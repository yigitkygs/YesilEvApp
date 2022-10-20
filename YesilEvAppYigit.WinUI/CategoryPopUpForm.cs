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
        public delegate void CategoryDelege(CategoryDTO category);
        public CategoryDelege delegem;

        private void loadUpperCategories()
        {
            listUpperCategories.Items.Clear();
            cbUpperCategories.Items.Clear();
            getUpperCategories().ForEach(a => listUpperCategories.Items.Add(a));
            getUpperCategories().ForEach(a => cbUpperCategories.Items.Add(a));

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
        private List<CategoryDTO> getSubCategoriesByUpperCategoryID(int ID)
        {
            return new CategoryDAL().GetAllCategories().Where(a => a.UpperCategoryID == ID && a.UpperCategoryID != a.CategoryID).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedSubCategory != null)
            {
                delegem(selectedSubCategory);
                this.Close();
            }
            else MessageBox.Show("Kategori seçimi yapınız!");
        }

        private void listUpperCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUpperCategories.SelectedItem != null)
            {
                selectedUpperCategory = (CategoryDTO)listUpperCategories.SelectedItem;
                loadSubCategories();
            }
        }

        private void listSubCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSubCategories.SelectedItem != null)
            {
                selectedSubCategory = (CategoryDTO)listSubCategories.SelectedItem;
            }
            tbSelectedCategory.Text = selectedSubCategory.CategoryName;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (tbNewCategoryName.Text != "" && tbNewCategoryName.Text != " " && cbUpperCategories.SelectedItem != null)
            {
                CategoryDTO categoryDTO = (CategoryDTO)cbUpperCategories.SelectedItem;

                foreach (CategoryDTO item in getSubCategoriesByUpperCategoryID(categoryDTO.CategoryID))
                {
                    if (item.CategoryName == tbNewCategoryName.Text)
                    {
                        MessageBox.Show("Eklemek istediğiniz kategori zaten mevcuttur!!");
                        ResetAddNewCategory();
                        return;
                    }
                }
                bool result = new CategoryDAL().AddNewCategory(new CategoryDTO()
                {
                    CategoryName = tbNewCategoryName.Text,
                    IsActive = true,
                    CreateDate = DateTime.Now,
                    UpperCategoryID = categoryDTO.CategoryID
                });
                if 
                    (!result) MessageBox.Show("Yeni kategori eklenirken bir hata oluştu");
                else 
                { 
                    loadUpperCategories(); 
                    loadSubCategories(); 
                }
            }
            ResetAddNewCategory();
        }

        private void ResetAddNewCategory()
        {
            tbNewCategoryName.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;
        }
    }
}
