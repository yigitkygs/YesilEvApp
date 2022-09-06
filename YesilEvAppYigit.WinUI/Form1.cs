using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.DAL;
using YesilEvAppYigit.DTO;
using System.Diagnostics;
using YesilEvAppYigit.DAL.Concerete;
using YesilEvAppYigit.Mapping;
using System.Linq;
using System.Drawing;

namespace YesilEvAppYigit.WinUI
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>

        public Form1()
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

#endif
            txtBarkod.Text = "Barkod no giriniz";
            txtBarkod.ForeColor = Color.Gray;
        }
        dynamic username;
        dynamic password;
        TabPage currentPage;
        UserDTO currentUser;
        bool userApproved = false;

        // todo mevcut kullanıcının karalistesindeki alerjenlerin olduğu ürünleri listelerken renklendir vs

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
                        MessageBox.Show("You're admin");
                        userExists = true;
                        userApproved = true;
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

        private void button13_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ShowLastPage();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

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
        }

        void ShowMenu() => tabControl1.SelectedTab = tabPage3;
        void ShowUser() => tabControl1.SelectedTab = tabPage11;
        void ShowMain() => tabControl1.SelectedTab = tabPage2;
        void ShowProduct() => tabControl1.SelectedTab = tabPage4;

        void ShowLastPage() => tabControl1.SelectedTab = currentPage;

        private void loadBrands()
        {
            cbBrand.Items.Clear();
            foreach (BrandDTO brand in getBrands())
            {
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
                cbCategories.Items.Add(category);
            }
        }

        private List<CategoryDTO> getCategories()
        {
            return new CategoryDAL().GetAllCategories();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage4)
            {
                loadCategories();
                loadBrands();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu özellik henüz kullanılamaz!");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage7;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage8;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ShowUser();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ShowUser();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            ShowUser();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            ShowUser();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            ShowUser();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            userApproved = false;
            currentUser = null;
        }

        private void button42_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (txtUrunAdi.Text != "")
            {
                ProductDAL dal = new ProductDAL() { };
                ProductDTO dto = new ProductDTO();
                BrandDTO brandDTO = (BrandDTO)cbBrand.SelectedItem;
                CategoryDTO categoryDTO = (CategoryDTO)cbCategories.SelectedItem;

                //Ana kategoriyle ürün girilmez

                //dto.BarkodNo = Guid.NewGuid().ToString().ToUpper();
                dto.UrunAdi = txtUrunAdi.Text;
                if (rtbUrunDetay.Text != "") dto.UrunIcerigiText = rtbUrunDetay.Text;
                if (cbBrand.SelectedItem != null) dto.BrandID = MyMapper.BrandToBrandDTO(new BrandDAL().GetBy(a => a.BrandName == brandDTO.BrandName).FirstOrDefault()).BrandID;
                if (cbCategories.SelectedItem != null) dto.KategoriID = MyMapper.CategoryToCategoryDTO(new CategoryDAL().GetBy(a => a.KategoriAdi == categoryDTO.KategoriAdi).FirstOrDefault()).KategoriID;
                dto.AddedBy = currentUser.UserID;
                bool eklendi = dal.AddNewProduct(dto);
                if (eklendi)
                {
                    MessageBox.Show(dto.UrunAdi + " adlı ürün başarıyla eklendi");
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
            ProductDTO productDTO = MyMapper.ProductToProductDTO(new ProductDAL().GetBy(a => a.BarkodNo == txtBarkodSearch.Text).FirstOrDefault());
            SearchDTO search = new SearchDTO();
            search.SearchDate = DateTime.Now;
            search.UserID = currentUser.UserID;
            search.AramaKeyword = txtBarkodSearch.Text;
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
            txtBarkod.Text = p.BarkodNo;
            txtUrunAdi.Text = p.UrunAdi;
            var brandDTO = new BrandDAL().GetBrandFromID(p.BrandID);
            var categoryDTO = new CategoryDAL().GetCategoryFromID(p.KategoriID);

            for (int i = 0; i < cbBrand.Items.Count; i++)
            {
                BrandDTO temp = cbBrand.Items[i] as BrandDTO;
                if (temp.BrandID == brandDTO.BrandID) { cbBrand.SelectedIndex = i; break; }
            }
            for (int i = 0; i < cbCategories.Items.Count; i++)
            {
                CategoryDTO temp = cbCategories.Items[i] as CategoryDTO;
                if (temp.KategoriID == categoryDTO.KategoriID) { cbCategories.SelectedIndex = i; break; }
            }
            rtbUrunDetay.Text = p.UrunIcerigiText;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            ProductDTO productDTO = MyMapper.ProductToProductDTO(new ProductDAL().GetBy(a => a.UrunAdi == txtProductSearch.Text).FirstOrDefault());
            SearchDTO search = new SearchDTO();
            search.SearchDate = DateTime.Now;
            search.UserID = currentUser.UserID;
            search.AramaKeyword = txtProductSearch.Text;
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
                txtProductSearch.Text = String.Empty;
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage9;
            dgvSearch.DataSource = new SearchDAL().GetSearchesFromUserID(currentUser.UserID);
            dgvSearch.Columns[0].HeaderText = "Aranan Kelime/Barkod";
            dgvSearch.Columns[0].Width = 200;
            dgvSearch.Columns[1].HeaderText = "Arama Tarihi";

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
                    new UserDAL().KullaniciGuncelle(newUsername);

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
    }
}
