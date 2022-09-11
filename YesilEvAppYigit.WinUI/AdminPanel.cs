using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEvAppYigit.DAL;
using YesilEvAppYigit.DAL.Concrete;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.WinUI
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        List<UserDTO> users = null;
        List<ProductDTO> products = null;
        List<BrandDTO> brands = null;
        List<ManufacturerDTO> manufacturers = null;
        List<FavoriteDTO> favorites = null;
        List<BlacklistDTO> blacklists = null;
        List<CategoryDTO> categories = null;
        List<AllergenDTO> allergens = null;
        List<SearchDTO> searches = null;
        List<ProductAllergenDTO> productAllergens = null;
        List<BlacklistAllergenDTO> blacklistAllergens = null;
        List<FavoriteProductDTO> favoriteProducts = null;

        private void EnableEditing()
        {
            dgvAdminPanel.ReadOnly = false;
        }
        private void DisableEditing()
        {
            dgvAdminPanel.ReadOnly = true;
        }
        private void GetUsersToTable()
        {
            users = new UserDAL().GetAllUsers();
            dgvAdminPanel.DataSource = users;
        }

        private void GetProductsToTable()
        {
            products = new ProductDAL().GetAllProducts();
            dgvAdminPanel.DataSource = products;
        }

        private void GetBrandsToTable()
        {
            brands = new BrandDAL().GetAllBrands();
            dgvAdminPanel.DataSource = brands;
        }

        private void GetManufacturersToTable()
        {
            manufacturers = new ManufacturerDAL().GetAllManufacturers();
            dgvAdminPanel.DataSource = manufacturers;
        }

        private void GetFavoritesToTable()
        {
            favorites = new FavoriteDAL().GetAllFavorites();
            dgvAdminPanel.DataSource = favorites;
        }

        private void GetBlacklistsToTable()
        {
            blacklists = new BlacklistDAL().GetAllBlacklists();
            dgvAdminPanel.DataSource = blacklists;
        }

        private void GetCategoriesToTable()
        {
            categories = new CategoryDAL().GetAllCategories();
            dgvAdminPanel.DataSource = categories;
        }

        private void GetAllergensToTable()
        {
            allergens = new AllergenDAL().GetAllAllergens();
            dgvAdminPanel.DataSource = allergens;
        }

        private void GetSearchesToTable()
        {
            searches = new SearchDAL().GetAllSearches();
            dgvAdminPanel.DataSource = searches;
        }

        private void GetProductAllergensToTable()
        {
            productAllergens = new ProductAllergenDAL().GetAllProductAllergens();
            dgvAdminPanel.DataSource = productAllergens;
        }

        private void GetBlacklistAllergensToTable()
        {
            blacklistAllergens = new BlacklistAllergenDAL().GetAllBlacklistAllergens();
            dgvAdminPanel.DataSource = blacklistAllergens;
        }

        private void GetFavoriteProductsToTable()
        {
            favoriteProducts = new FavoriteProductDAL().GetAllFavoriteProducts();
            dgvAdminPanel.DataSource = favoriteProducts;
        }

        private void kullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetUsersToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage1;
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetProductsToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage2;
        }

        private void markalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBrandsToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage3;
        }

        private void üreticilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetManufacturersToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage4;
        }

        private void favorilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFavoritesToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage5;
        }

        private void karalistelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBlacklistsToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage6;
        }

        private void kategorilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCategoriesToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage7;
        }

        private void alerjenlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAllergensToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage8;
        }

        private void aramalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetSearchesToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage9;
        }

        private void ürünAlerjenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetProductAllergensToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage10;
        }

        private void karaListeAlerjenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetBlacklistAllergensToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage11;
        }

        private void favoriÜrünToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFavoriteProductsToTable();
            dgvAdminPanel.ReadOnly = true;
            tabControl1.SelectedTab = tabPage12;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new UserDAL().SoftDeleteUser((UserDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetUsersToTable();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new UserDAL().RevertSoftDeleteUser((UserDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetUsersToTable();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveUser.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new ProductDAL().SoftDeleteProduct((ProductDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetProductsToTable();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new ProductDAL().RevertSoftDeleteProduct((ProductDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetProductsToTable();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveProduct.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new ProductDAL().UpdateProduct((ProductDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetProductsToTable();
            btnSaveProduct.Enabled = false;
            DisableEditing();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            users.Add(new UserDTO()
            {
                UserID = users.Last().UserID + 1,
                Username = " ",
                Password = " ",
                RoleID = 2,
                IsActive = true
            });
            dgvAdminPanel.DataSource = users;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new BrandDAL().SoftDeleteBrand((BrandDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetBrandsToTable();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new BrandDAL().RevertSoftDeleteBrand((BrandDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetBrandsToTable();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveBrand.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new BrandDAL().UpdateBrand((BrandDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetBrandsToTable();
            btnSaveBrand.Enabled = false;
            DisableEditing();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new ManufacturerDAL().SoftDeleteManufacturer((ManufacturerDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetManufacturersToTable();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new ManufacturerDAL().RevertSoftDeleteManufacturer((ManufacturerDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetManufacturersToTable();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveManufacturer.Enabled = true;
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new UserDAL().UpdateUser((UserDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetUsersToTable();
            btnSaveUser.Enabled = false;
            DisableEditing();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveFavorite.Enabled = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveBlacklist.Enabled = true;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveCategory.Enabled = true;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveAllergen.Enabled = true;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveSearch.Enabled = true;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveProductAllergen.Enabled = true;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveBlacklistAllergen.Enabled = true;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            EnableEditing();
            btnSaveFavoriteProduct.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            products = new ProductDAL().GetProductsBy(a=>a.IsApproved==false);
            dgvAdminPanel.DataSource = products;
        }

        private void btnSaveManufacturer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new ManufacturerDAL().UpdateManufacturer((ManufacturerDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetManufacturersToTable();
            btnSaveManufacturer.Enabled = false;
            DisableEditing();
        }

        private void btnSaveFavorite_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new FavoriteDAL().UpdateFavorite((FavoriteDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetFavoritesToTable();
            btnSaveFavorite.Enabled = false;
            DisableEditing();
        }

        private void btnSaveBlacklist_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new BlacklistDAL().UpdateBlacklist((BlacklistDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetBlacklistsToTable();
            btnSaveBlacklist.Enabled = false;
            DisableEditing();
        }

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new CategoryDAL().UpdateCategory((CategoryDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetCategoriesToTable();
            btnSaveCategory.Enabled = false;
            DisableEditing();
        }

        private void btnSaveAllergen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new AllergenDAL().UpdateAllergen((AllergenDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetAllergensToTable();
            btnSaveAllergen.Enabled = false;
            DisableEditing();
        }

        private void btnSaveSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new SearchDAL().UpdateSearch((SearchDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetSearchesToTable();
            btnSaveSearch.Enabled = false;
            DisableEditing();
        }

        private void btnSaveProductAllergen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new ProductAllergenDAL().UpdateProductAllergen((ProductAllergenDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetProductAllergensToTable();
            btnSaveProductAllergen.Enabled = false;
            DisableEditing();
        }

        private void btnSaveBlacklistAllergen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new BlacklistAllergenDAL().UpdateBlacklistAllergen((BlacklistAllergenDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetBlacklistAllergensToTable();
            btnSaveBlacklistAllergen.Enabled = false;
            DisableEditing();
        }

        private void btnSaveFavoriteProduct_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new FavoriteProductDAL().UpdateFavoriteProduct((FavoriteProductDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetFavoriteProductsToTable();
            btnSaveFavoriteProduct.Enabled = false;
            DisableEditing();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new FavoriteDAL().SoftDeleteFavorite((FavoriteDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetFavoritesToTable();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new BlacklistDAL().SoftDeleteBlacklist((BlacklistDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetBlacklistsToTable();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new CategoryDAL().SoftDeleteCategory((CategoryDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetCategoriesToTable();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new AllergenDAL().SoftDeleteAllergen((AllergenDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetAllergensToTable();
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new SearchDAL().SoftDeleteSearch((SearchDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetSearchesToTable();
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new ProductAllergenDAL().SoftDeleteProductAllergen((ProductAllergenDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetProductAllergensToTable();
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                BlacklistAllergenDTO temp = (BlacklistAllergenDTO)dgvAdminPanel.CurrentRow.DataBoundItem;
                new BlacklistAllergenDAL().SoftDeleteBlacklistAllergen(temp.BlacklistAllergenID);
                GetBlacklistAllergensToTable();
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new FavoriteProductDAL().RevertSoftDeleteFavoriteProduct((FavoriteProductDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetFavoriteProductsToTable();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new FavoriteDAL().RevertSoftDeleteFavorite((FavoriteDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetFavoritesToTable();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new BlacklistDAL().RevertSoftDeleteBlacklist((BlacklistDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetBlacklistsToTable();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new CategoryDAL().RevertSoftDeleteCategory((CategoryDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetCategoriesToTable();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new AllergenDAL().RevertSoftDeleteAllergen((AllergenDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetAllergensToTable();
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new SearchDAL().RevertSoftDeleteSearch((SearchDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetSearchesToTable();
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new ProductAllergenDAL().RevertSoftDeleteProductAllergen((ProductAllergenDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetProductAllergensToTable();
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                BlacklistAllergenDTO temp = (BlacklistAllergenDTO)dgvAdminPanel.CurrentRow.DataBoundItem;
                new BlacklistAllergenDAL().RevertSoftDeleteBlacklistAllergen(temp.BlacklistAllergenID);
                GetBlacklistAllergensToTable();
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                new FavoriteProductDAL().RevertSoftDeleteFavoriteProduct((FavoriteProductDTO)dgvAdminPanel.CurrentRow.DataBoundItem);
                GetFavoriteProductsToTable();
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (dgvAdminPanel.CurrentRow != null)
            {
                ProductDTO productDTO = (ProductDTO)dgvAdminPanel.CurrentRow.DataBoundItem;
                new ProductDAL().ApproveProduct(productDTO.ProductID);
                GetProductsToTable();
            }
        }
    }
}
