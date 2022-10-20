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

        public ProductIngedientsPopUpForm(ProductDTO p) : this()
        {
            if(p != null)
            {
                currProduct = p;
                productIngredientsDTOs.Clear();
                new ProductAllergenDAL().GetProductAllergenFromProductID(p.ProductID).ForEach(a => productIngredientsDTOs.Add(a.Allergen));
            } 
        }

        List<AllergenDTO> allIngredientsDTOs = new List<AllergenDTO>();
        List<AllergenDTO> notUsedIngredientsDTOs = new List<AllergenDTO>();
        List<AllergenDTO> productIngredientsDTOs = new List<AllergenDTO>();
        List<RiskDTO> risks = new RiskDAL().GetAllRisks();

        ProductDTO currProduct;

        public delegate void IngredientDelegate(List<AllergenDTO> allergens);
        public IngredientDelegate delegem;

        private void ProductIngedientsPopUpForm_Load(object sender, EventArgs e)
        {
            loadAllIngredients();
            LoadLists();
            risks.ForEach(x => cbRiskLevel.Items.Add(x)); 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (productIngredientsDTOs.Count < 1)
            {
                MessageBox.Show("Ürün içeriği eklemediniz");
                return;
            }
            else
            {
                delegem(productIngredientsDTOs);
                this.Close();
            }
        }

        private void LoadLists()
        {
            listAllIngredients.Items.Clear();
            listProductIngedients.Items.Clear();
            notUsedIngredientsDTOs = notUsedIngredientsDTOs.OrderBy(a => a.AllergenName).ToList();
            productIngredientsDTOs = productIngredientsDTOs.OrderBy(a => a.AllergenName).ToList();
            notUsedIngredientsDTOs.ForEach(a => listAllIngredients.Items.Add(a));
            productIngredientsDTOs.ForEach(a => listProductIngedients.Items.Add(a));
        }

        private void loadAllIngredients()
        {
            allIngredientsDTOs = new AllergenDAL().GetAllAllergens();
            notUsedIngredientsDTOs = allIngredientsDTOs;
            productIngredientsDTOs.ForEach(dto => { notUsedIngredientsDTOs = notUsedIngredientsDTOs.SkipWhile(a => a.AllergenID == dto.AllergenID).ToList(); });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listAllIngredients.SelectedItem != null)
            {
                AllergenDTO temp = (AllergenDTO)listAllIngredients.SelectedItem;
                notUsedIngredientsDTOs.Remove(temp);
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
                notUsedIngredientsDTOs.Add(temp);
                LoadLists();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tbNewIngredientName.Text != "" && tbNewIngredientName.Text != " " && cbRiskLevel.SelectedItem != null)
            {
                RiskDTO riskDTO = (RiskDTO)cbRiskLevel.SelectedItem;
                foreach (AllergenDTO item in allIngredientsDTOs)
                {
                    if (item.AllergenName == tbNewIngredientName.Text)
                    {
                        MessageBox.Show("Eklemek istediğiniz içerik zaten mevcuttur!!");
                        ResetAddNewIngredient();
                        return;
                    }
                }
                bool result = new AllergenDAL().AddNewAllergen(new AllergenDTO()
                {
                    AllergenName = tbNewIngredientName.Text,
                    IsActive = true,
                    CreateDate = DateTime.Now,
                    Description = rtbDescription.Text,
                    RiskID = riskDTO.RiskID
                });
                if
                    (!result) MessageBox.Show("Yeni içerik eklenirken bir hata oluştu");
                else
                {
                    loadAllIngredients();
                    LoadLists();
                }
            }
            ResetAddNewIngredient();
        }

        private void ResetAddNewIngredient()
        {
            tbNewIngredientName.Text = String.Empty;
            rtbDescription.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;
        }
    }
}
