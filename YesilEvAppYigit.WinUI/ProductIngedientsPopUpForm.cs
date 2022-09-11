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
    public partial class ProductIngedientsPopUpForm : Form
    {
        public ProductIngedientsPopUpForm()
        {
            InitializeComponent();
        }

        public ProductIngedientsPopUpForm(ProductDTO p)
        {
            currProduct = p;
            productIngredientsDTOs.Clear();
            p.ProductAllergens.ForEach(a => productIngredientsDTOs.Add(a.Allergen));
        }

        List<AllergenDTO> allergenDTOs = new List<AllergenDTO>();
        List<AllergenDTO> allIngredientsDTOs = new List<AllergenDTO>();
        List<AllergenDTO> productIngredientsDTOs = new List<AllergenDTO>();
        ProductDTO currProduct;

        private void ProductIngedientsPopUpForm_Load(object sender, EventArgs e)
        {
            loadAllIngredients();
            LoadLists();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listProductIngedients.Items.Count < 1)
            {
                MessageBox.Show("Ürün içeriği eklemediniz");
                return;
            }
        }

        private void LoadLists()
        {
            listAllIngredients.Items.Clear();
            listProductIngedients.Items.Clear();
            allIngredientsDTOs = allIngredientsDTOs.OrderBy(a => a.AllergenName).ToList();
            productIngredientsDTOs = productIngredientsDTOs.OrderBy(a => a.AllergenName).ToList();
            allIngredientsDTOs.ForEach(a => listAllIngredients.Items.Add(a));
            productIngredientsDTOs.ForEach(a => listProductIngedients.Items.Add(a));
        }

        private void loadAllIngredients()
        {
            allergenDTOs = new AllergenDAL().GetAllAllergens();
            allIngredientsDTOs = allergenDTOs;
            productIngredientsDTOs.ForEach(dto => allIngredientsDTOs.Remove(dto));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listAllIngredients.SelectedItem != null)
            {
                AllergenDTO temp = (AllergenDTO)listAllIngredients.SelectedItem;
                allIngredientsDTOs.Remove(temp);
                productIngredientsDTOs.Add(temp);
                LoadLists();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listProductIngedients.SelectedItem != null)
            {
                AllergenDTO temp = (AllergenDTO)listProductIngedients.SelectedItem;
                productIngredientsDTOs.Remove(temp);
                allIngredientsDTOs.Add(temp);
                LoadLists();
            }
        }
    }
}
