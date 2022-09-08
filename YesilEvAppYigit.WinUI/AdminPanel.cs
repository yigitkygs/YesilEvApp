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

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new UserDAL().UpdateUser((UserDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetUsersToTable();
            btnKaydet.Enabled = false;
            dgvAdminPanel.ReadOnly = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            dgvAdminPanel.ReadOnly = false;
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
            btnKaydet.Enabled = true;
            dgvAdminPanel.ReadOnly = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new ProductDAL().UpdateProduct((ProductDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetProductsToTable();
            btnKaydet.Enabled = false;
            dgvAdminPanel.ReadOnly = true;
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
            btnKaydet.Enabled = true;
            dgvAdminPanel.ReadOnly = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAdminPanel.Rows.Count; i++)
            {
                new BrandDAL().UpdateBrand((BrandDTO)dgvAdminPanel.Rows[i].DataBoundItem);
            }
            GetBrandsToTable();
            btnKaydet.Enabled = false;
            dgvAdminPanel.ReadOnly = true;
        }


    }
}
