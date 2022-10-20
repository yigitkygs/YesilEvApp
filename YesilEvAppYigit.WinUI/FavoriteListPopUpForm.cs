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
    public partial class FavoriteListPopUpForm : Form
    {
        public FavoriteListPopUpForm()
        {
            InitializeComponent();
        }

        ProductDTO productDTO;
        int userID;
        List<FavoriteDTO> favoriteList;

        public FavoriteListPopUpForm(ProductDTO p,int ID) : this()
        {
            productDTO = p;
            userID = ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listFavorites.SelectedItem != null)
            {
                FavoriteDTO selected = (FavoriteDTO)listFavorites.SelectedItem;

                if (favoriteList.Contains(selected))
                {
                   bool result1 = new FavoriteProductDAL().AddNewFavoriteProduct(new FavoriteProductDTO()
                    {
                        CreateDate = DateTime.Now,
                        IsActive = true,
                        Product = productDTO,
                        ProductID = productDTO.ProductID,
                        ProductName = productDTO.ProductName,
                        Favorite = selected,
                        FavoriteID = selected.FavoriteID
                    });
                    if (result1)
                        Successfull();
                }
                else
                {
                    new FavoriteDAL().AddNewFavorite(selected);
                    FavoriteDTO favoriteDTO = new FavoriteDAL().GetAllFavorites().Where(a=>a.UserID==userID&&a.FavoriteName==selected.FavoriteName).FirstOrDefault();
                    bool result2 = new FavoriteProductDAL().AddNewFavoriteProduct(new FavoriteProductDTO()
                    {
                        CreateDate = DateTime.Now,
                        IsActive = true,
                        Product = productDTO,
                        ProductID = productDTO.ProductID,
                        ProductName = productDTO.ProductName,
                        Favorite = favoriteDTO,
                        FavoriteID = favoriteDTO.FavoriteID
                    });
                    if (result2)
                        Successfull();
                }
            }
        }

        private void Successfull()
        {
            MessageBox.Show("Ürün favorinize eklenmiştir.");
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FavoriteListPopUpForm_Load(object sender, EventArgs e)
        {
            favoriteList = new FavoriteDAL().GetFavoriteFromUserID(userID);
            favoriteList.ForEach(x => listFavorites.Items.Add(x));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbFavoriteListName.Text.Length > 0)
            {
                for (int i = 0; i < favoriteList.Count; i++)
                {
                    if(favoriteList[i].FavoriteName == tbFavoriteListName.Text)
                    {
                        MessageBox.Show("Girdiğiniz favori liste adı mevcuttur.\nYeni bir liste adı giriniz.");
                        return;
                    }
                }
                listFavorites.Items.Add(new FavoriteDTO()
                {
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    FavoriteName = tbFavoriteListName.Text,
                    UserID = userID,
                });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;
        }
    }
}
