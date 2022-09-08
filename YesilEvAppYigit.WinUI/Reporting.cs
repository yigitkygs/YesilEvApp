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
    public partial class Reporting : Form
    {
        public Reporting()
        {
            InitializeComponent();
        }

        private void Raporlama_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().UrunUrunIcerikAdetRapor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().UrunveAlerjenleriGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().HowManyProductDidEachUserAdd();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().HowManyProductsAreInFavoriteListsWithLeastRiskedAllergen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().HowManyProductsAreAddedThisMonthAndNotApprovedByAdmin();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().HowManyUsersAndAdminsAreInDatabase();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().KullaniciEkledikleriUrunRapor();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().KaralisteEnCokUrunKullaniciRapor();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().WhichAllergensHaveTheHighestRiskLevel();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().EnCokFavoriUrunRapor();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().EnCokFavori3UrunRapor();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().KullaniciListeSayisiRapor();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new ReportingDAL().BuAyFavoriKaralisteyeAlinanlarRapor();
        }
    }
}
