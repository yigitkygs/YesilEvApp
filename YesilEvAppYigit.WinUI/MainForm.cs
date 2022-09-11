﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.DAL;
using YesilEvAppYigit.DTO;
using System.Diagnostics;
using YesilEvAppYigit.DAL.Concrete;
using YesilEvAppYigit.Mapping;
using System.Linq;
using System.Drawing;
using YesilEvAppYigit.WinUI.Properties;

namespace YesilEvAppYigit.WinUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            //var sajdıjk = new ProductDAL().UrunleriGetir();
            //var hede = new ProductDAL().UrunGetir(1);
            //var asdsad = new BlacklistAllergenDAL().KullaniciBlacklistGetir(1);
            var hede = new BlacklistDAL().GetAllBlacklistsFKWithUserID(3);
            //txtUsername.Text = "admin";
            //txtSifre.Text = "password";
#endif
            txtBarkod.Text = "Barkod no giriniz";
            txtBarkod.ForeColor = Color.Gray;
        }
        #region Global Variables
        dynamic username;
        dynamic password;
        TabPage currentPage;
        UserDTO currentUser;
        ProductDTO currentProduct;
        bool userApproved = false;
        bool isSearchHistory = false;
        bool orderByAsc = false;
        List<FavoriteDTO> favoriteDTOs = null;
        List<BlacklistUserPageDTO> blacklistAllergensDTOs = null;
        List<List<FavoriteProductDTO>> favoriteProductDTOs = null;
        List<ProductAllergenDTO> currentProductAllergens = null;
        int usersAddedProductCount = 0;
        #endregion



        //todo validation eklenecek


        //todo ürün sayfasından yıldız veya kalp simgesine basılarak favorilere eklenmiş ürünler görülebilecek.

        //todo  Eğer alanlardan biri boş bırakılırsa bir uyarı mesajı ile doldurulması istenecek. Doğru şekilde doldurulduysa
        //onaya gönderildiğine dair bir teşekkür mesajı belirecek ve ardından otomatik olarak ana sayfaya dönecek.


        //todo Alerjenin detay sayfasında mevcut olduğu ürün sayısı belirtilecek ve dokunulduğunda bu ürünler listelenecek.


        //todo test eklenecek

        //önemsizler



        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != null && txtSifre.Text != null)
            {
                username = txtUsername.Text;
                password = txtSifre.Text;
                Login(username, password);
                if (userApproved) tabControl1.SelectedTab = tabPage2;
                lblUsername.Text = username;
            }
        }

        private void Login(string u, string p)
        {
            bool userExists = false;
            //şifreler db'de md5 hash'i olarak tutulacağından ayrıca db'de şifrelemeye şimdilik gerek yok

            //primary key single or default
            foreach (UserDTO user in getUsers())
            {
                if (user.Username == u && user.Password == getMD5Hash(p))
                {
                    if (user.RoleID == 2)
                    {
                        userExists = true;
                        userApproved = true;
                    }
                    else if (user.RoleID == 1)
                    {
                        userExists = true;
                        userApproved = true;
                        btnRapor.Visible = true;
                        btnAdminPanel.Visible = true;
                    }
                    currentUser = user;
                    countUsersAddedProducts();
                    LoadCurrentUsersAllergens();
                }
            }
            if (!userExists)
            {
                MessageBox.Show("Kullanıcı adı veya Şifre Yanlış");
            }
        }

        private void countUsersAddedProducts()
        {
            usersAddedProductCount = new ProductDAL().GetProductsBy(a => a.AddedBy == currentUser.UserID).Count();
        }

        private List<UserDTO> getUsers()
        {
            return new UserDAL().GetAllUsers();
        }

        private string getMD5Hash(string v)
        {
            byte[] encoded = new UTF8Encoding().GetBytes(v + "özel salt değerimiz");
            byte[] hashed = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encoded);
            string converted = BitConverter.ToString(hashed)
               .Replace("-", string.Empty)
               .ToLower();
            return converted;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void button13_Click(object sender, EventArgs e) => ShowMenu();

        private void button19_Click(object sender, EventArgs e) => ShowLastPage();

        private void button23_Click(object sender, EventArgs e) => ShowMenu();

        private void button21_Click(object sender, EventArgs e) => ShowMain();

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != null && txtSifre.Text != null)
            {
                username = txtUsername.Text;
                password = txtSifre.Text;
                RegisterUser(username, password);
            }
        }

        private void RegisterUser(string u, string p)
        {
            foreach (UserDTO user in getUsers())
            {
                if (user.Username == username && user.Password == getMD5Hash(password))
                {
                    MessageBox.Show("Bu bilgilere ait kullanıcı mevcuttur!!");
                    return;
                }
            }
            bool checking = new UserDAL().AddNewUser(new UserDTO()
            {
                Username = u,
                Password = getMD5Hash(p),
                RoleID = 2
            });
            if (checking)
                MessageBox.Show("Başarıyla yeni kullanıcı kaydedildi", "Bilgi");
            else
                MessageBox.Show("Yeni kullanıcı kaydederken hata oluştu", "Hata");
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab != tabPage3) currentPage = tabControl1.SelectedTab;
            if (tabControl1.SelectedTab == tabPage5)
            {
                tabControl2.SelectedTab = tabPage6;
            }
        }

        void ShowMenu() => tabControl1.SelectedTab = tabPage3;

        void ShowMain() => tabControl1.SelectedTab = tabPage2;

        void ShowProduct() => tabControl1.SelectedTab = tabPage4;

        void ShowViewProduct() => tabControl1.SelectedTab = tabPage17;

        void ShowLastPage() => tabControl1.SelectedTab = currentPage;

        void ShowUser()
        {
            tabControl1.SelectedTab = tabPage11;
            countUsersAddedProducts();
            lbAddedProducts.Text = "Eklediği Ürün Sayısı: " + usersAddedProductCount;
        }

        private List<BrandDTO> getBrands()
        {
            return new BrandDAL().GetAllBrands();
        }

        private void loadUpperCategories()
        {
            lbUpperCategory.Items.Clear();
            getUpperCategories().ForEach(a => lbUpperCategory.Items.Add(a));
        }

        private List<CategoryDTO> getUpperCategories()
        {
            return new CategoryDAL().GetAllCategories().Where(a => a.UpperCategoryID == a.CategoryID).ToList();
        }
        private void loadSubCategories()
        {
            lbSubCategory.Items.Clear();
            getAllSubCategories().ForEach(a => lbSubCategory.Items.Add(a));
        }
        private void loadSubCategories(int ID)
        {
            lbSubCategory.Items.Clear();
            getSubCategories(ID).ForEach(a => lbSubCategory.Items.Add(a));
        }
        private List<CategoryDTO> getAllSubCategories()
        {
            return new CategoryDAL().GetAllCategories().Where(a => a.UpperCategoryID != a.CategoryID).ToList();
        }
        private List<CategoryDTO> getSubCategories(int ID)
        {
            return new CategoryDAL().GetAllCategories().Where(a => a.UpperCategoryID == ID && a.UpperCategoryID != a.CategoryID).ToList();
        }
        private List<UserDTO> getAllUsers()
        {
            return new UserDAL().GetAllUsers();
        }
        private string getUsername(int ID)
        {
            return new UserDAL().GetUserFromID(ID).Username;
        }

        private void LoadCurrentUsersAllergens()
        {
            blacklistAllergensDTOs = new BlacklistAllergenDAL().GetAllBlacklistAllergensFromUserID(currentUser.UserID).Select(a => new BlacklistUserPageDTO()
            {
                UserID = a.UserID,
                AllergenName = a.Allergen.AllergenName,
                BlacklistAllergenID = a.BlacklistAllergenID,
                BlacklistID = a.BlacklistID,
                CreateDate = a.CreateDate,
                AllergenID = a.AllergenID
            }).ToList();
        }

        void LoadCurrentProductsIngredients()
        {
            currentProductAllergens = new ProductAllergenDAL().GetProductAllergenFromProductID(currentProduct.ProductID);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void button30_Click(object sender, EventArgs e) => ShowMenu();

        private void button29_Click(object sender, EventArgs e) => ShowMain();

        private void button32_Click(object sender, EventArgs e) => tabControl2.SelectedTab = tabPage7;

        private void button31_Click(object sender, EventArgs e)
        {
            loadUpperCategories();
            tabControl2.SelectedTab = tabPage8;
        }

        private void button18_Click(object sender, EventArgs e) => ShowUser();

        private void button20_Click(object sender, EventArgs e) => ShowUser();

        private void button28_Click(object sender, EventArgs e) => ShowUser();

        private void button34_Click(object sender, EventArgs e) => ShowUser();

        private void button37_Click(object sender, EventArgs e) => ShowUser();

        private void button46_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            userApproved = false;
            currentUser = null;
        }

        private void button42_Click(object sender, EventArgs e) => ShowMenu();

        private void button22_Click(object sender, EventArgs e)
        {
            if (txtUrunAdi.Text != "")
            {
                ProductDAL dal = new ProductDAL() { };
                ProductDTO dto = new ProductDTO();
                dto.ProductName = txtUrunAdi.Text;
                dto.BarcodeNo = txtBarkod.Text;
                dto.BrandID = new BrandDAL().GetBrandFromID(1).BrandID;
                dto.CategoryID = new CategoryDAL().GetCategoryFromID(1).CategoryID;
                dto.AddedBy = currentUser.UserID;
                dto.DoesUserConsent = cbUserConsent.Checked;
                bool eklendi = dal.AddNewProduct(dto);
                if (eklendi)
                {
                    MessageBox.Show(dto.ProductName + " adlı ürün başarıyla eklendi");
                    ShowMain();
                }
                else
                {
                    MessageBox.Show("Ürün eklenirken bir hata oluştu.");
                }
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            currentProduct = MyMapper.ProductToProductDTO(new ProductDAL().GetBy(a => a.BarcodeNo == txtBarkodSearch.Text).FirstOrDefault());
            SearchDTO search = new SearchDTO();
            search.SearchDate = DateTime.Now;
            search.UserID = currentUser.UserID;
            search.SearchKeyword = txtBarkodSearch.Text;
            search.IsDeleted = false;
            new SearchDAL().AddNewSearch(search);
            if (currentProduct != null)
            {
                LoadNewProductPage(currentProduct);
                ShowProduct();
            }
            else
            {
                currentProduct = new ProductDTO() { BarcodeNo = txtBarkodSearch.Text };
                LoadNewProductPage(currentProduct);
                ShowProduct();
                txtBarkodSearch.Text = String.Empty;
            }
        }

        public void LoadNewProductPage(ProductDTO p)
        {
            txtBarkod.Text = p.BarcodeNo;
            txtUrunAdi.Text = p.ProductName;
            var brandDTO = new BrandDAL().GetBrandFromID(p.BrandID);
            var categoryDTO = new CategoryDAL().GetCategoryFromID(p.CategoryID);
            if (brandDTO != null)
                tbBrand.Text = brandDTO.BrandName;
            if (categoryDTO != null)
                tbCategory.Text = categoryDTO.CategoryName;
            if (currentProductAllergens != null)
                currentProductAllergens.ForEach(a => listCurrentIngredients.Items.Add(a));
        }

        public void LoadViewProductPage(ProductDTO p)
        {
            lbIngredients.Items.Clear();
            txtBarkod.Text = p.BarcodeNo;
            lbProductName.Text = p.ProductName;
            var brandDTO = new BrandDAL().GetBrandFromID(p.BrandID);
            var categoryDTO = new CategoryDAL().GetCategoryFromID(p.CategoryID);
            if (brandDTO != null)
                lbBrandName.Text = brandDTO.BrandName;
            if (categoryDTO != null)
                lbCategoryName.Text = categoryDTO.CategoryName;
            if (currentProductAllergens.Count > 0)
                currentProductAllergens.ForEach(a => lbIngredients.Items.Add(a));
            if ((bool)p.DoesUserConsent)
            {
                lbUserWhoPosted.Text = "Görüntülediğiniz ürün bilgileri " + getUsername(p.AddedBy) + "\nkullanıcı adlı üyemiz tarafından sağlanmıştır.";
            }
            else lbUserWhoPosted.Text = "Görüntülediğiniz ürün bilgileri anonim \nüyemiz tarafından sağlanmıştır.";

            int howManyItemsAreInBlacklistInThisProduct = currentProductAllergens.Join(blacklistAllergensDTOs, a => a.AllergenID, b => b.AllergenID, (a, b) => (a, b)).Count();
            lbBlacklistIngredients.Text = "Kara listedeki içerikler " + howManyItemsAreInBlacklistInThisProduct;
            lbHighRiskIngredients.Text = "Riskli içerikler " + currentProductAllergens.Where(a => a.Allergen.RiskID == 4).Count();
            lbMidLevelRiskIngredients.Text = "Orta riskli içerikler " + currentProductAllergens.Where(a => a.Allergen.RiskID == 3).Count();
            lbLowRiskIngredients.Text = "Az Riskli içerikler " + currentProductAllergens.Where(a => a.Allergen.RiskID == 2).Count();
            lbNoRiskIngredients.Text = "Temiz içerikler " + currentProductAllergens.Where(a => a.Allergen.RiskID == 1).Count();

            if (howManyItemsAreInBlacklistInThisProduct > 0) lbProductIsInBlacklist.Visible = true;
            else lbProductIsInBlacklist.Visible = false;

        }

        private void button47_Click(object sender, EventArgs e)
        {
            List<ProductUserPageDTO> productUserPageDTOs = new List<ProductUserPageDTO>();
            if (lbUpperCategory.SelectedItem != null)
            {
                CategoryDTO upperCategory = (CategoryDTO)lbUpperCategory.SelectedItem;
                if (lbSubCategory.SelectedItem != null)
                {
                    CategoryDTO subCategory = (CategoryDTO)lbSubCategory.SelectedItem;

                    if (txtProductSearch.Text != "")
                    {
                        productUserPageDTOs = MyMapper.ListProductDTOToListProductUserPageDTO(new ProductDAL()
                            .GetProductsBy(a => a.ProductName.Contains(txtProductSearch.Text) && subCategory.CategoryID == a.CategoryID).ToList());
                        SearchDTO search = new SearchDTO();
                        search.SearchDate = DateTime.Now;
                        search.UserID = currentUser.UserID;
                        search.SearchKeyword = txtProductSearch.Text;
                        search.IsDeleted = false;
                        new SearchDAL().AddNewSearch(search);
                        if (productUserPageDTOs.Count > 1)
                        {
                            dgvSearchedProducts.DataSource = productUserPageDTOs;
                        }
                        else
                        {
                            MessageBox.Show("Aradığınız ürün bulunamadı.");
                            dgvSearchedProducts.DataSource = null;
                            txtProductSearch.Text = String.Empty;
                        }
                    }
                    else
                    {
                        productUserPageDTOs = MyMapper.ListProductDTOToListProductUserPageDTO(new ProductDAL()
                            .GetProductsBy(a => subCategory.CategoryID == a.CategoryID).ToList());
                        if (productUserPageDTOs.Count > 1)
                        {
                            dgvSearchedProducts.DataSource = productUserPageDTOs;
                        }
                        else
                        {
                            MessageBox.Show("Aradığınız ürün bulunamadı.");
                            dgvSearchedProducts.DataSource = null;
                            txtProductSearch.Text = String.Empty;
                        }
                    }
                }
                else
                {
                    if (txtProductSearch.Text != "")
                    {
                        productUserPageDTOs = MyMapper.ListProductDTOToListProductUserPageDTO(new ProductDAL()
                            .GetProductsBy(a => a.ProductName.Contains(txtProductSearch.Text) && getAllSubCategories().Exists(x => upperCategory.CategoryID == x.UpperCategoryID && a.CategoryID == x.CategoryID)).ToList());
                        SearchDTO search = new SearchDTO();
                        search.SearchDate = DateTime.Now;
                        search.UserID = currentUser.UserID;
                        search.SearchKeyword = txtProductSearch.Text;
                        search.IsDeleted = false;
                        new SearchDAL().AddNewSearch(search);
                        if (productUserPageDTOs.Count > 1)
                        {
                            dgvSearchedProducts.DataSource = productUserPageDTOs;
                        }
                        else
                        {
                            MessageBox.Show("Aradığınız ürün bulunamadı.");
                            dgvSearchedProducts.DataSource = null;
                            txtProductSearch.Text = String.Empty;
                        }
                    }
                    else
                    {
                        productUserPageDTOs = MyMapper.ListProductDTOToListProductUserPageDTO(new ProductDAL().
                            GetProductsBy(a => getAllSubCategories().Exists(x => upperCategory.CategoryID == x.UpperCategoryID && a.CategoryID == x.CategoryID)).ToList());
                        if (productUserPageDTOs.Count > 1)
                        {
                            dgvSearchedProducts.DataSource = productUserPageDTOs;
                        }
                        else
                        {
                            MessageBox.Show("Aradığınız ürün bulunamadı.");
                            dgvSearchedProducts.DataSource = null;
                            txtProductSearch.Text = String.Empty;
                        }
                    }
                }
            }
            else
            {
                productUserPageDTOs = MyMapper.ListProductDTOToListProductUserPageDTO(new ProductDAL().GetProductsBy(a => a.ProductName.Contains(txtProductSearch.Text)).ToList());
                SearchDTO search = new SearchDTO();
                search.SearchDate = DateTime.Now;
                search.UserID = currentUser.UserID;
                search.SearchKeyword = txtProductSearch.Text;
                search.IsDeleted = false;
                new SearchDAL().AddNewSearch(search);
                if (productUserPageDTOs.Count > 1)
                {
                    dgvSearchedProducts.DataSource = productUserPageDTOs;
                }
                else if (productUserPageDTOs.Count == 1)
                {
                    currentProduct = MyMapper.ProductUserPageDTOToProductDTO(productUserPageDTOs[0]);
                    LoadNewProductPage(currentProduct);
                    ShowProduct();
                }
                else
                {
                    MessageBox.Show("Aradığınız ürün bulunamadı.");
                    dgvSearchedProducts.DataSource = null;
                    txtProductSearch.Text = String.Empty;
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            GetUsersSearches();
        }

        private void GetUsersSearches()
        {
            List<SearchDTO> temp = new SearchDAL().GetSearchesFromUserID(currentUser.UserID);
            if (temp.Count > 0)
            {
                tabControl1.SelectedTab = tabPage9;
                dgvSearch.DataSource = temp;
                dgvSearch.Columns[0].HeaderText = "Aranan Kelime/Barkod";
                dgvSearch.Columns[0].Width = 200;
                dgvSearch.Columns[1].HeaderText = "Arama Tarihi";
                button52.Text = "Seçili Aramayı Sil";
                lblArama.Text = "Arama Geçmişi";
                isSearchHistory = true;
            }
            else MessageBox.Show("Arama geçmişiniz boştur");
        }

        private void button45_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage10;
            txtCurrentUsername.Text = currentUser.Username;
        }

        private void txtBarkod_Enter(object sender, EventArgs e)
        {
            if (txtBarkod.ForeColor == Color.Gray)
            {
                txtBarkod.Text = "";
                txtBarkod.ForeColor = Color.Black;
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (txtNewUsername.Text.Length > 3)
            {
                if (txtNewUsername.Text != currentUser.Username &&
                    new UserDAL().GetBy(a => a.Username == txtNewUsername.Text).First() == null)
                {
                    UserDTO newUsername = currentUser;
                    newUsername.Username = txtNewUsername.Text;
                    new UserDAL().UpdateUser(newUsername);

                    if (new UserDAL().GetBy(a => a.Username == txtNewUsername.Text).First() != null)
                    {
                        MessageBox.Show("Kullanıcı adı başarıyla değiştirildi");
                        currentUser = newUsername;
                        lblUsername.Text = newUsername.Username;
                        ShowUser();
                    }
                    else MessageBox.Show("Bilinmeyen bir sorun oluştu");
                }
                else MessageBox.Show("Farklı bir kullanıcı adı giriniz");
            }
            else MessageBox.Show("En az 4 karakterli bir kullanıcı adı giriniz");
        }

        private void button44_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage10;
            tabControl3.SelectedTab = tabPage13;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (tbYeniSifre.Text.Length > 4)
            {
                if (tbYeniSifre.Text == tbYeniSifreTekrar.Text)
                {
                    if (currentUser.Password == getMD5Hash(tbYeniSifre.Text))
                    {
                        MessageBox.Show("Farklı bir şifre giriniz");
                        return;
                    }
                    else
                    {
                        UserDTO newPassword = currentUser;
                        newPassword.Password = getMD5Hash(tbYeniSifre.Text);
                        new UserDAL().UpdateUser(newPassword);
                    }
                    if (new UserDAL().GetBy(a => a.Password == getMD5Hash(tbYeniSifre.Text)).First() != null)
                    {
                        MessageBox.Show("Şifre başarıyla değiştirildi");
                        ShowUser();
                    }
                    else MessageBox.Show("Bilinmeyen bir sorun oluştu");
                }
                else MessageBox.Show("Girdiğiniz şifreler birbiriyle uyuşmamaktadır.");
            }
            else MessageBox.Show("En az 5 karakterli bir şifre giriniz");
        }

        private void button40_Click(object sender, EventArgs e)
        {
            LoadUserBlacklistAllergens();
        }

        private void LoadUserBlacklistAllergens()
        {
            tabControl1.SelectedTab = tabPage9;
            lblArama.Text = "Kara Liste";
            tabControl4.SelectedTab = tabPage16;
            dgvBlacklist.DataSource = blacklistAllergensDTOs;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            ShowUsersFavoriteLists();
        }

        private void ShowUsersFavoriteLists()
        {
            favoriteDTOs = new FavoriteDAL().GetFavoriteFromUserID(currentUser.UserID);
            if (favoriteDTOs == null || favoriteDTOs.Count == 0)
            {
                MessageBox.Show("Favori listeniz bulunmamaktadır!");
                return;
            }
            favoriteProductDTOs = new List<List<FavoriteProductDTO>>();
            favoriteDTOs.ForEach(a =>
            {
                favoriteProductDTOs.Add(new FavoriteProductDAL().GetFavoriteProductListsFromFavoriID(a.FavoriteID).Select(x => new FavoriteProductDTO()
                {
                    FavoriteID = x.FavoriteID,
                    IsActive = x.IsActive,
                    CreateDate = x.CreateDate,
                    FavoriteProductID = x.FavoriteProductID,
                    ProductID = x.ProductID,
                    ProductName = new ProductDAL().GetProductByID(x.ProductID).ProductName
                }).ToList());
                cbFavori.Items.Add(a.FavoriteName);
            });

            cbFavori.SelectedIndex = 0;
            tabControl1.SelectedTab = tabPage9;
            tabControl4.SelectedTab = tabPage15;
            lblArama.Text = "Favoriler";
            dgvFavorite.DataSource = favoriteProductDTOs[cbFavori.SelectedIndex];
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (dgvSearch.CurrentRow != null)
            {
                new SearchDAL().SoftDeleteSearch((SearchDTO)dgvSearch.CurrentRow.DataBoundItem);
                GetUsersSearches();
            }
        }

        private void button4_Click(object sender, EventArgs e) => MessageBox.Show("Coded by S. Yiğit KAYGISIZ\n 2022");
        private void button41_Click(object sender, EventArgs e) => ShowMain();

        private void buttonRapor_Click(object sender, EventArgs e)
        {
            Reporting r = new Reporting();
            r.Show();
        }

        private void cbFavori_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFavorite.DataSource = favoriteProductDTOs[cbFavori.SelectedIndex];
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (dgvSearch.CurrentRow != null)
            {
                // new FavoriteDAL().((SearchDTO)dgvSearch.CurrentRow.DataBoundItem);
                GetUsersSearches();
            }

        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            AdminPanel adminPaneli = new AdminPanel();
            adminPaneli.Show();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            List<SearchDTO> temp = new SearchDAL().GetSearchesFromUserID(currentUser.UserID);
            if (temp.Count > 0)
            {
                temp.ForEach(a => new SearchDAL().SoftDeleteSearch((SearchDTO)a));
                MessageBox.Show("Arama geçmişiniz başarıyla temizlenmiştir.");
            }
            else MessageBox.Show("Arama geçmişiniz yoktur.");

        }

        private void dgvSearchedProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearchedProducts.CurrentRow != null)
            {
                ProductUserPageDTO temp = (ProductUserPageDTO)dgvSearchedProducts.CurrentRow.DataBoundItem;
                currentProduct = new ProductDAL().GetProductByID(temp.ProductID);
                LoadCurrentProductsIngredients();
                LoadViewProductPage(currentProduct);
                ShowProduct();
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            ShowUsersFavoriteLists();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button63_Click(object sender, EventArgs e)
        {
            if (orderByAsc)
                currentProductAllergens = currentProductAllergens.OrderBy(a => a.Allergen.AllergenName).ToList();
            else
                currentProductAllergens = currentProductAllergens.OrderByDescending(a => a.Allergen.AllergenName).ToList();

            orderByAsc = !orderByAsc;
            lbIngredients.Items.Clear();
            currentProductAllergens.ForEach(x => lbIngredients.Items.Add(x));
        }

        private void button61_Click(object sender, EventArgs e)
        {
            CategoryPopUpForm categoryPopUpForm = new CategoryPopUpForm();
            categoryPopUpForm.ShowDialog();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            BrandPopUpForm brandPopUpForm = new BrandPopUpForm();
            brandPopUpForm.ShowDialog();
        }

        private void pbFavorite_Click(object sender, EventArgs e)
        {
            //todo if current product is in one of the users user's favorite lists favori listesi user listesi ve favorite product listelerini join ile birleştirip kontrol edilecek 

            pbFavorite.Image = Resources.icons8_star_50__1_;
        }

        private void button62_Click(object sender, EventArgs e)
        {
            ProductIngedientsPopUpForm productIngedientsPopUpForm = new ProductIngedientsPopUpForm();
            productIngedientsPopUpForm.ShowDialog();
        }

        private void lbAddedProducts_Click(object sender, EventArgs e)
        {
            List<ProductDTO> productDTOs = new ProductDAL().GetProductsBy(a => a.AddedBy == currentUser.UserID);
            List<ProductUserPageDTO> productUserPageDTOs = new List<ProductUserPageDTO>();
            productDTOs.ForEach(dto => productUserPageDTOs.Add(MyMapper.ProductDTOToProductUserPageDTO(dto)));
            dgvAddedProducts.DataSource = productUserPageDTOs;
            tabControl1.SelectedTab = tabPage18;
        }

        private void lbUpperCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUpperCategory.SelectedItem != null)
            {
                CategoryDTO upperCategory = (CategoryDTO)lbUpperCategory.SelectedItem;
                loadSubCategories(upperCategory.CategoryID);
            }
        }

        private void dgvAddedProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAddedProducts.CurrentRow != null)
            {
                ProductUserPageDTO temp = (ProductUserPageDTO)dgvAddedProducts.CurrentRow.DataBoundItem;
                currentProduct = new ProductDAL().GetProductByID(temp.ProductID);
                LoadCurrentProductsIngredients();
                LoadViewProductPage(currentProduct);
                ShowViewProduct();
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            if (dgvBlacklist.CurrentRow != null)
            {
                BlacklistUserPageDTO temp = (BlacklistUserPageDTO)dgvBlacklist.CurrentRow.DataBoundItem;
                new BlacklistAllergenDAL().SoftDeleteBlacklistAllergen(temp.BlacklistAllergenID);
                LoadUserBlacklistAllergens();
            }
        }

        private void dgvFavorite_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFavorite.CurrentRow != null)
            {
                FavoriteProductDTO temp = (FavoriteProductDTO)dgvFavorite.CurrentRow.DataBoundItem;
                currentProduct = new ProductDAL().GetProductByID(temp.ProductID);
                LoadCurrentProductsIngredients();
                LoadViewProductPage(currentProduct);
                ShowViewProduct();
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            ShowUser();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            ShowUser();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            ShowMain();
        }
    }
}
