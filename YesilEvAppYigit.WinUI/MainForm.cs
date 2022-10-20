using System;
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
using System.IO;

namespace YesilEvAppYigit.WinUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// Return icon on Allergen Page source:
        /// back by The Icon Z from <ahref="https://thenounproject.com/browse/icons/term/back/"target="_blank" title="back Icons">Noun Project</a>
        /// </summary>

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            //var d1 = new ProductDAL().UrunleriGetir();
            //var d2 = new ProductDAL().UrunGetir(1);
            //var d3 = new BlacklistAllergenDAL().KullaniciBlacklistGetir(1);
            //var d4 = new BlacklistDAL().GetAllBlacklistsFKWithUserID(3);
            txtUsername.Text = "admin";
            txtSifre.Text = "password";
#endif
        }
        #region Global Variables
        dynamic username;
        dynamic password;
        TabPage currentPage;
        UserDTO currentUser;
        ProductDTO currentProduct;
        AllergenDTO currentAllergen;
        bool userApproved = false;
        bool orderByAsc = false;
        List<FavoriteDTO> favoriteDTOs = null;
        List<FavoriteDTO> favoriteDTOsWithNotActive = null;
        List<BlacklistUserPageDTO> blacklistAllergensDTOs = null;
        List<List<FavoriteProductDTO>> favoriteProductDTOs = null;
        List<ProductAllergenDTO> currentProductAllergens = null;
        CategoryDTO selectedCategoryfromPopUp;
        BrandDTO selectedBrandfromPopUp;
        List<AllergenDTO> selectedIngredientsfromPopUp = null;
        int usersAddedProductCount = 0;
        byte[] tempProductIngredientImg;
        byte[] tempProductFrontImg;
        byte[] tempProductBackImg;

        #endregion


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
            ResetNewProductPage();
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
            ResetSearches();
        }

        private void ResetSearches()
        {
            txtBarkodSearch.Text = txtProductSearch.Text = String.Empty;
            dgvSearchedProducts.DataSource = null;
            lbUpperCategory.Items.Clear();
            lbSubCategory.Items.Clear();
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
            if (txtUrunAdi.Text.Length < 1)
            {
                MessageBox.Show("Ürün Adı boş bırakılamaz");
                return;
            }
            if (txtBarkod.Text.Length < 1)
            {
                MessageBox.Show("Barkod no boş bırakılamaz!");
                return;
            }
            if (tbBrand.Text.Length < 1)
            {
                MessageBox.Show("Marka boş bırakılamaz!");
                return;
            }
            if (tbCategory.Text.Length < 1)
            {
                MessageBox.Show("Kategori boş bırakılamaz!");
                return;
            }
            if (listCurrentIngredients.Items.Count < 1)
            {
                MessageBox.Show("Ürün içeriği boş bırakılamaz!");
                return;
            }
            ProductDAL dal = new ProductDAL() { };
            ProductDTO dto = new ProductDTO();
            dto.ProductName = txtUrunAdi.Text;
            dto.BarcodeNo = txtBarkod.Text;
            dto.BrandID = new BrandDAL().GetAllBrands().Where(a => a.BrandName == tbBrand.Text).SingleOrDefault().BrandID;
            dto.CategoryID = new CategoryDAL().GetAllCategories().Where(a => a.CategoryName == tbCategory.Text).SingleOrDefault().CategoryID;
            dto.AddedBy = currentUser.UserID;
            dto.DoesUserConsent = cbUserConsent.Checked;
            dto.CreateDate = DateTime.Now;
            dto.IsActive = true;
            dto.IsApproved = false;
            if (tempProductIngredientImg != null)
                dto.ProductIngredientsImg = tempProductIngredientImg;
            if (tempProductFrontImg != null)
                dto.FrontImg = tempProductFrontImg;
            if (tempProductBackImg != null)
                dto.BackImg = tempProductBackImg;

            List<ProductAllergenDTO> productAllergenDTOs = new List<ProductAllergenDTO>();
            bool added;
            bool update = false;
            if (dal.GetProductsBy(a => a.BarcodeNo == dto.BarcodeNo).Any())
            {
                dto.ProductID = currentProduct.ProductID;
                added = dal.UpdateProduct(dto);
                update = true;
            }
            else
            {
                added = dal.AddNewProduct(dto);
            }

            if (added)
            {
                if (!update)
                {
                    dto.ProductID = dal.GetProductsBy(a => a.BarcodeNo == dto.BarcodeNo).FirstOrDefault().ProductID;
                    currentProductAllergens = new List<ProductAllergenDTO>();
                    for (int i = 0; i < listCurrentIngredients.Items.Count; i++)
                    {
                        AllergenDTO a = (AllergenDTO)listCurrentIngredients.Items[i];
                        currentProductAllergens.Add(new ProductAllergenDTO()
                        {
                            AllergenID = a.AllergenID,
                            IsActive = true,
                            CreateDate = DateTime.Now,
                            Product = dto,
                            ProductID = dto.ProductID,
                        }
                        );
                    }
                    currentProductAllergens.ForEach(a => new ProductAllergenDAL().AddNewProductAllergen(a));
                    dto.ProductAllergens = currentProductAllergens;
                    dal.UpdateProduct(dto);
                }
                else if (update)
                {
                    List<ProductAllergenDTO> formerProductAllergen = new ProductAllergenDAL().GetProductAllergenFromProductID(dto.ProductID);

                    currentProductAllergens = new List<ProductAllergenDTO>();
                    for (int i = 0; i < listCurrentIngredients.Items.Count; i++)
                    {
                        AllergenDTO a = (AllergenDTO)listCurrentIngredients.Items[i];
                        formerProductAllergen.Where(fp => fp.AllergenID == a.AllergenID).ToList().ForEach(x => currentProductAllergens.Add(x));
                    }
                    for (int i = 0; i < listCurrentIngredients.Items.Count; i++)
                    {
                        AllergenDTO a = (AllergenDTO)listCurrentIngredients.Items[i];

                        if (!currentProductAllergens.Exists(cpa => cpa.AllergenID == a.AllergenID))
                            currentProductAllergens.Add(new ProductAllergenDTO()
                            {
                                AllergenID = a.AllergenID,
                                CreateDate = DateTime.Now,
                                IsActive = true,
                                ProductID = dto.ProductID
                            });
                    }

                    for (int i = 0; i < formerProductAllergen.Count; i++)
                    {
                        if (!currentProductAllergens.Contains(formerProductAllergen[i]))
                        {
                            formerProductAllergen[i].IsActive = false;
                        }
                    }
                    for (int i = 0; i < currentProductAllergens.Count; i++)
                    {
                        if (!formerProductAllergen.Contains(currentProductAllergens[i]))
                        {
                            new ProductAllergenDAL().AddNewProductAllergen(currentProductAllergens[i]);
                        }
                    }
                    formerProductAllergen.ForEach(a => new ProductAllergenDAL().UpdateProductAllergen(a));
                }
                if (update)
                    MessageBox.Show(dto.ProductName + " adlı ürün başarıyla güncellendi");
                else
                    MessageBox.Show(dto.ProductName + " adlı ürün başarıyla eklendi");
                ShowMain();
            }
            else
            {
                MessageBox.Show("Ürün eklenirken bir hata oluştu.");
            }
            ResetNewProductPage();
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

        public void ResetNewProductPage()
        {
            txtBarkod.Text = txtUrunAdi.Text = tbBrand.Text = tbCategory.Text = String.Empty;
            listCurrentIngredients.Items.Clear();
            btnAddProductIngredientImage.Text = "Ürün İçeriği Fotoğraf Ekle";
            btnAddProductFrontImg.Text = "Ön Yüz Fotoğrafı Ekle";
            btnAddProductBackImg.Text = "Arka Yüz Fotoğrafı Ekle";
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

            if (p.FrontImg != null)
            {
                if (p.FrontImg.Length > 1)
                    pbProductImage.Image = Image.FromStream(new MemoryStream(p.FrontImg));
                else pbProductImage.Image = Resources.images;
            }
            else pbProductImage.Image = Resources.images;

            getFavoriteProducts();
            bool isProductInFavorite = false;
            for (int i = 0; i < favoriteProductDTOs.Count; i++)
            {
                for (int j = 0; j < favoriteProductDTOs[i].Count; j++)
                {
                    FavoriteProductDTO t = favoriteProductDTOs[i][j];
                    if (t.ProductID == currentProduct.ProductID && t.IsActive == true)
                    {
                        isProductInFavorite = true; break;
                    }
                }
            }
            if (isProductInFavorite)
            {
                pbFavorite.Image = Resources.icons8_star_50__1_;
                lbFavori.Text = "Favorilerden Çıkar";
            }
            else
            {
                pbFavorite.Image = Resources.icons8_star_50;
                lbFavori.Text = "Favorilere Ekle";
            }
        }

        public void LoadAllergenPage(AllergenDTO a)
        {

            lbAllergenPageProductName.Text = new BrandDAL().GetBrandFromID(currentProduct.BrandID).BrandName + " " + currentProduct.ProductName;
            lbAllergenPageAllergenName.Text = a.AllergenName;
            int count = new ProductAllergenDAL().GetProductAllergensBy(x => x.AllergenID == a.AllergenID).Count();
            lbAllergenPageHowManyProductHasThisAllergen.Text = "Bu içerik " + count + " ürünün bileşenleri arasında yer almaktadır.";
            int howManyItemsAreInBlacklistInThisProduct = currentProductAllergens.Join(blacklistAllergensDTOs, x => x.AllergenID, y => y.AllergenID, (x, y) => (x, y)).Count();
            if (howManyItemsAreInBlacklistInThisProduct > 0)
            {
                lbAllergenPageAllergenIsInUsersBlacklist.Visible = true;
                btnAllergenPageAddRemoveFromBlacklist.Text = "- Kara liste'den çıkar";
            }

            else
            {
                lbAllergenPageAllergenIsInUsersBlacklist.Visible = false;
                btnAllergenPageAddRemoveFromBlacklist.Text = "+ Kara liste'ye ekle";

            }
            richTextBox1.Text = a.Description;
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
            getFavoriteProducts();

            if (cbFavori.SelectedIndex < 0)
                cbFavori.SelectedIndex = 0;
            tabControl1.SelectedTab = tabPage9;
            tabControl4.SelectedTab = tabPage15;
            lblArama.Text = "Favoriler";
            dgvFavorite.DataSource = favoriteProductDTOs[cbFavori.SelectedIndex];
        }

        private void getFavoriteProducts()
        {
            favoriteDTOs = new FavoriteDAL().GetFavoriteFromUserIDWithNotActive(currentUser.UserID);
            favoriteProductDTOs = new List<List<FavoriteProductDTO>>();
            cbFavori.Items.Clear();
            if (favoriteDTOs != null || favoriteDTOs.Count > 0)
            {
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
                    if (a.IsActive == true)
                        cbFavori.Items.Add(a.FavoriteName);
                });
            }
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
            if (dgvFavorite.CurrentRow != null)
            {
                FavoriteProductDTO temp = (FavoriteProductDTO)dgvFavorite.CurrentRow.DataBoundItem;
                temp.FavoriteID = new FavoriteDAL().GetFavoriteFromUserID(currentUser.UserID).Where(a => a.FavoriteName == cbFavori.SelectedItem.ToString()).FirstOrDefault().FavoriteID;
                new FavoriteProductDAL().SoftDeleteFavoriteProduct(temp.FavoriteProductID);
                dgvFavorite.DataSource = favoriteProductDTOs[cbFavori.SelectedIndex];
                ShowUsersFavoriteLists();
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
                ShowViewProduct();
                tabControl2.SelectedTab = tabPage6;
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            ShowUsersFavoriteLists();
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
            categoryPopUpForm.delegem = new CategoryPopUpForm.CategoryDelege(getSelectedCategory);
            categoryPopUpForm.ShowDialog();
        }

        public void getSelectedCategory(CategoryDTO target)
        {
            selectedCategoryfromPopUp = target;
            tbCategory.Text = selectedCategoryfromPopUp.CategoryName;
        }

        public void getSelectedBrand(BrandDTO target)
        {
            selectedBrandfromPopUp = target;
            tbBrand.Text = selectedBrandfromPopUp.BrandName;
        }

        public void getSelectedIngredients(List<AllergenDTO> target)
        {
            selectedIngredientsfromPopUp = target;
            listCurrentIngredients.Items.Clear();
            selectedIngredientsfromPopUp.ForEach(x => listCurrentIngredients.Items.Add(x));
        }

        private void button60_Click(object sender, EventArgs e)
        {
            BrandPopUpForm brandPopUpForm = new BrandPopUpForm();
            brandPopUpForm.delegem = new BrandPopUpForm.BrandDelege(getSelectedBrand);
            brandPopUpForm.ShowDialog();
        }

        private void pbFavorite_Click(object sender, EventArgs e)
        {
            getFavoriteProducts();

            bool isProductInFavorite = false;
            for (int i = 0; i < favoriteProductDTOs.Count; i++)
            {
                for (int j = 0; j < favoriteProductDTOs[i].Count; j++)
                {
                    FavoriteProductDTO t = favoriteProductDTOs[i][j];

                    if (t.ProductID == currentProduct.ProductID)
                    {
                        if (t.IsActive == true)
                        {
                            isProductInFavorite = true; break;
                        }
                    }
                }
            }

            if (!isProductInFavorite)
            {
                FavoriteListPopUpForm favoriteListPopUpForm = new FavoriteListPopUpForm(currentProduct, currentUser.UserID);
                if (favoriteListPopUpForm.ShowDialog() == DialogResult.OK)
                {
                    pbFavorite.Image = Resources.icons8_star_50__1_;
                    lbFavori.Text = "Favorilerden Çıkar";
                }
            }
            else if (isProductInFavorite)
            {
                List<FavoriteProductDTO> temp = new FavoriteProductDAL().GetFavoriteProductByProductIdAndUserID(currentProduct.ProductID, currentUser.UserID);

                temp.ForEach(a => new FavoriteProductDAL().SoftDeleteFavoriteProduct(a.FavoriteProductID));

                pbFavorite.Image = Resources.icons8_star_50;
                lbFavori.Text = "Favorilere Ekle";

            }
            LoadViewProductPage(currentProduct);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            ProductIngedientsPopUpForm productIngedientsPopUpForm = new ProductIngedientsPopUpForm(currentProduct);
            productIngedientsPopUpForm.delegem = new ProductIngedientsPopUpForm.IngredientDelegate(getSelectedIngredients);
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
                LoadNewProductPage(currentProduct);
                ShowProduct();
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

        private void dgvFavorite_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void button69_Click(object sender, EventArgs e)
        {
            ShowViewProduct();
        }

        private void lbIngredients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbIngredients.SelectedItem != null)
            {
                ProductAllergenDTO temp = (ProductAllergenDTO)lbIngredients.SelectedItem;
                currentAllergen = new AllergenDAL().GetAllergen(temp.AllergenID);
                LoadAllergenPage(currentAllergen);
                ShowAllergenPage();
            }
        }

        private void ShowAllergenPage()
        {
            tabControl1.SelectedTab = tabPage19;
        }

        private void btnAllergenPageAddRemoveFromBlacklist_Click(object sender, EventArgs e)
        {
            LoadCurrentUsersAllergens();

            if (blacklistAllergensDTOs.Where(a => a.AllergenID == currentAllergen.AllergenID).ToList().Count < 1)
            {
                new BlacklistAllergenDAL().AddNewBlacklistAllergen(new BlacklistAllergenDTO()
                {
                    AllergenID = currentAllergen.AllergenID,
                    IsActive = true,
                    BlacklistID = blacklistAllergensDTOs[0].BlacklistID,
                    CreateDate = DateTime.Now,
                    UserID = currentUser.UserID
                });
            }
            else
            {
                new BlacklistAllergenDAL().SoftDeleteBlacklistAllergen(blacklistAllergensDTOs.Where(a => a.AllergenID == currentAllergen.AllergenID && a.UserID == currentUser.UserID).FirstOrDefault().BlacklistAllergenID);
            }
            LoadAllergenPage(currentAllergen);
        }

        private void selectProductImage(ref Byte[] temp, ref Button b)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg;)|*.jpg; *.jpeg;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                temp = convertToByteArray(new Bitmap(openFileDialog.FileName));
                b.Text = openFileDialog.SafeFileName;
            }
        }

        private Byte[] convertToByteArray(Image image)
        {
            return (Byte[])new ImageConverter().ConvertTo(image, typeof(Byte[]));
        }

        private void button25_Click(object sender, EventArgs e)
        {
            selectProductImage(ref tempProductIngredientImg, ref btnAddProductIngredientImage);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            selectProductImage(ref tempProductFrontImg, ref btnAddProductFrontImg);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            selectProductImage(ref tempProductBackImg, ref btnAddProductBackImg);
        }

        private void pbProductImage_Click(object sender, EventArgs e)
        {
            //Image tempFrontImg = null, tempBackImg = null, tempIngredientImg = null;

            //if (currentProduct.FrontImg != null) tempFrontImg = Image.FromStream(new MemoryStream(currentProduct.FrontImg));
            //if (currentProduct.BackImg != null) tempBackImg = Image.FromStream(new MemoryStream(currentProduct.BackImg));
            //if (currentProduct.ProductIngredientsImg != null) tempIngredientImg = Image.FromStream(new MemoryStream(currentProduct.ProductIngredientsImg));

            //List<Image> images = new List<Image>()
            //{
            //    tempFrontImg, tempBackImg, tempIngredientImg
            //};

            //for(int i = 0; i < images.Count; i++)
            //{
            //    if (images[i] != null)
            //    pbProductImage.Image = images[i];
            //}


            //if (tempFrontImg != null)
            //{
            //    if (pbProductImage.Image == tempFrontImg && tempBackImg != null)
            //        pbProductImage.Image = tempBackImg;
            //    else if(pbProductImage.Image == tempFrontImg && tempIngredientImg != null)
            //        pbProductImage.Image = tempIngredientImg;
            //    else if (pbProductImage.Image == tempBackImg && tempIngredientImg != null)
            //        pbProductImage.Image = tempIngredientImg;
            //    else if (pbProductImage.Image == tempIngredientImg)
            //        pbProductImage.Image = tempFrontImg;
            //}
        }
    }
}
