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
            //var sad = new ProductDAL().UrunEkle(new DTO.ProductDTO()
            //{
            //    KategoriID = 2,
            //    UrunAdi = "Pro2",
            //    BarkodNo = Guid.NewGuid().ToString().ToUpper()
            //});
            //var sajdıjk = new ProductDAL().UrunleriGetir();
            //var hede = new ProductDAL().UrunGetir(1);
            //var asdsad = new BlacklistAllergenDAL().KullaniciBlacklistGetir(1);
            var hede = new BlacklistDAL().GetAllBlacklistsWithFK();
            txtUsername.Text = "admin";
            txtSifre.Text = "password";

#endif
            txtBarkod.Text = "Barkod no giriniz";
            txtBarkod.ForeColor = Color.Gray;
        }
        #region Global Variables
        dynamic username;
        dynamic password;
        TabPage currentPage;
        UserDTO currentUser;
        bool userApproved = false;
        bool isSearchHistory = false;
        List<FavoriteDTO> favoriteDTOs = null;
        List<BlacklistAllergenDTO> blacklistAllergensDTOs = null;

        List<List<FavoriteProductDTO>> favoriteProductDTOs = null;
        #endregion

        // todo mevcut kullanıcının karalistesindeki alerjenlerin olduğu ürünleri listelerken renklendir vs

        // todo ürün ekleme menüsüne ürün içerik ekleme için ayrı pop up form ekle

        //todo Sadece ilk açılışta «Kullanım Koşulları» görüntülenebilir. Altına bir daha gösterme seçeneği default olarak seçili olacak.

        //todo Taratılan barkod, veri tabanında eşleşirse direk olarak ilgili ürün sayfası ekrana gelecek. Eşleşmezse, yeni ürün
        //ekleme sayfası gelecek ve doldurulması gereken formda barkod no hazır olarak gözükecek.

        //todo ürün sayfasından yıldız veya kalp simgesine basılarak favorilere eklenmiş ürünler görülebilecek.

        //todo Kullanıcının kara listeye eklediği içerikler kırmızı olmasa bile en üstte yer alacaklar.

        //todo İçeriğin bilgileri kopyalanamaz şekilde görüntülenecek.

        //todo Eğer kara listede yer alan bir içerik ise bir uyarı olacak. Yoksa hiçbir şey yazmayacak. 

        //todo  Bu içeriğin mevcut olduğu ürün sayısı belirtilecek ve dokunulduğunda bu ürünler listelenecek.

        //todo  Eğer alanlardan biri boş bırakılırsa bir uyarı mesajı ile doldurulması istenecek. Doğru şekilde doldurulduysa
        //onaya gönderildiğine dair bir teşekkür mesajı belirecek ve ardından otomatik olarak ana sayfaya dönecek.

        //todo Uygulamaya eklediği ürün sayısı yazısnın üzerine dokunulduğu zaman, kullanıcının eklediği ürünlerin listesi açılacak.

        //todo Kullanıcını gönderdiği tüm ürünleri liste halinde görebilecek ve tıkladığpında düzenleme menüsü açılacak

        //todo Gönder butonun önce bir seçenek sunulacak. Kullanıcı buradaki onayı kaldırmazsa ürünün sayfasında bilgileri bu kullanıcının sağladığı gözükecek. 
        // bunun için product'a user consent diye bir bool değeri atanacak.

        //todo aynısı marka için yapılacak

        //todo ürün arama sayfasında istenilirse önce üst kategori seçilip sonra alt kategori seçilerek, sadece üste kategori seçilerek veya ürün adı ile arama yapılabilecek

        //todo ayrıca istenirse bir kategorideki tüm ürünler listenecek ( eğer textbox boş olursa)

        //todo admin paneli yeni row ekleme düzelt

        //todo validation eklenecek

        //todo test eklenecek

        //todo bütün dal'lar foreign key ile birleşecek


        private void button1_Click(object sender, EventArgs e)
        {
            //check for nulls
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

            //primary key single or defauklt

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
                }
            }
            if (!userExists)
            {
                MessageBox.Show("Kullanıcı adı veya Şifre Yanlış");
            }
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
            if (tabControl1.SelectedTab == tabPage4)
            {
                loadCategories();
                loadBrands();
            }
            if (tabControl1.SelectedTab == tabPage5)
            {
                tabControl2.SelectedTab = tabPage6;
            }

        }

        void ShowMenu() => tabControl1.SelectedTab = tabPage3;

        void ShowMain() => tabControl1.SelectedTab = tabPage2;
        void ShowProduct() => tabControl1.SelectedTab = tabPage4;
        void ShowLastPage() => tabControl1.SelectedTab = currentPage;
        void ShowUser()
        {
            tabControl1.SelectedTab = tabPage11;
            lbAddedProducts.Text = "Eklediği Ürün Sayısı: ";
        }

        private void loadBrands()
        {
            cbBrand.Items.Clear();
            foreach (BrandDTO brand in getBrands())
            {
                if ((bool)brand.IsActive)
                    cbBrand.Items.Add(brand);
            }
        }

        private List<BrandDTO> getBrands()
        {
            return new BrandDAL().GetAllBrands();
        }

        private void loadCategories()
        {
            cbCategories.Items.Clear();
            foreach (CategoryDTO category in getCategories())
            {
                if ((bool)category.IsActive)
                    cbCategories.Items.Add(category);
            }
        }

        private List<CategoryDTO> getCategories()
        {
            return new CategoryDAL().GetAllCategories();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void button30_Click(object sender, EventArgs e) => ShowMenu();

        private void button29_Click(object sender, EventArgs e) => ShowMain();

        private void button32_Click(object sender, EventArgs e) => tabControl2.SelectedTab = tabPage7;

        private void button31_Click(object sender, EventArgs e) => tabControl2.SelectedTab = tabPage8;

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
                BrandDTO brandDTO = (BrandDTO)cbBrand.SelectedItem;
                CategoryDTO categoryDTO = (CategoryDTO)cbCategories.SelectedItem;
                //Ana kategoriyle ürün girilmez
                dto.ProductName = txtUrunAdi.Text;
                dto.BarcodeNo = txtBarkod.Text;
                if (rtbUrunDetay.Text != "") dto.ProductIngredientsText = rtbUrunDetay.Text;
                if (cbBrand.SelectedItem != null) dto.BrandID = MyMapper.BrandToBrandDTO(new BrandDAL().GetBy(a => a.BrandName == brandDTO.BrandName).FirstOrDefault()).BrandID;
                if (cbCategories.SelectedItem != null) dto.CategoryID = MyMapper.CategoryToCategoryDTO(new CategoryDAL().GetBy(a => a.CategoryName == categoryDTO.CategoryName).FirstOrDefault()).CategoryID;
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
            ProductDTO productDTO = MyMapper.ProductToProductDTO(new ProductDAL().GetBy(a => a.BarcodeNo == txtBarkodSearch.Text).FirstOrDefault());
            SearchDTO search = new SearchDTO();
            search.SearchDate = DateTime.Now;
            search.UserID = currentUser.UserID;
            search.SearchKeyword = txtBarkodSearch.Text;
            search.IsDeleted = false;
            new SearchDAL().AddNewSearch(search);
            if (productDTO != null)
            {
                LoadProductPage(productDTO);
                ShowProduct();
            }
            else
            {
                MessageBox.Show("Aradığınız ürün bulunamadı.");
                txtBarkodSearch.Text = String.Empty;
            }
        }

        public void LoadProductPage(ProductDTO p)
        {
            loadCategories();
            loadBrands();
            txtBarkod.Text = p.BarcodeNo;
            txtUrunAdi.Text = p.ProductName;
            var brandDTO = new BrandDAL().GetBrandFromID(p.BrandID);
            var categoryDTO = new CategoryDAL().GetCategoryFromID(p.CategoryID);
            tbBrand.Text = brandDTO.ToString();
            tbCategory.Text = categoryDTO.ToString();
            rtbUrunDetay.Text = p.ProductIngredientsText;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            List<ProductUserPageDTO> productUserPageDTOs = MyMapper.ListProductDTOToListProductUserPageDTO(new ProductDAL().GetProductsBy(a => a.ProductName.Contains(txtProductSearch.Text)).ToList());
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
                LoadProductPage(MyMapper.ProductUserPageDTOToProductDTO(productUserPageDTOs[0]));
                ShowProduct();
            }
            else
            {
                MessageBox.Show("Aradığınız ürün bulunamadı.");
                txtProductSearch.Text = String.Empty;
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
                    new UserDAL().GetBy(a => a.Username == txtNewUsername.Text).First() == null) // Ayrıca diğer kullanıcı adlarıyla kıyasla
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
            tabControl1.SelectedTab = tabPage9;
            lblArama.Text = "Kara Liste";
            tabControl4.SelectedTab = tabPage16;
            blacklistAllergensDTOs = new BlacklistDAL().GetAllBlacklistsWithFK().Where(a => a.UserID == currentUser.UserID).Select(a => new BlacklistAllergenDTO()
            {
                UserID = a.UserID
            }).ToList();
        }

        private void button43_Click(object sender, EventArgs e)
        {

            //dgvFavorite.Columns[0].HeaderText = "Aranan Kelime/Barkod";
            //dgvFavorite.Columns[0].Width = 200;
            // dgvFavorite.Columns[1].HeaderText = "Arama Tarihi";

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
                favoriteProductDTOs.Add(new FavoriteProductDAL().GetFavoriteProductListsFromFavoriID(a.FavoriteID));
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
                LoadProductPage(new ProductDAL().GetProductByID(temp.ProductID));
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
    }
}
