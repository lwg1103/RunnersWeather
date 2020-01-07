using RunnersWeather.Clothes;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace RunnersWeather
{
    public partial class ClothesWindow : Form
    {
        private ClothesContext db = new ClothesContext();
        public ClothesWindow()
        {
            InitializeComponent();
        }

        private void ClothesWindow_Load(object sender, EventArgs e)
        {
            ClothesPiecesLoad();
            ClothesUsageConditionsLoad();
        }

        private void ClothesPiecesLoad()
        {
            db.ClothesPiecesDbSet.Load();
            //ClothesDataGridView.AutoGenerateColumns = false;
            ClothesDataGridView.DataSource = db.ClothesPiecesDbSet.Local.ToBindingList<ClothesPiece>();
            ClothesNameColumn.DataPropertyName = "Name";
            ClothesNameColumn.Width = 200;
        }

        private void ClothesUsageConditionsLoad()
        {
            db.ClothesUsageConditionsDbSet.Load();
            //ClothesUsageDataGridView.AutoGenerateColumns = false;
            ClothesUsageDataGridView.DataSource = db.ClothesUsageConditionsDbSet.Local.ToBindingList<ClothesUsageConditions>();
            MinValueColumn.DataPropertyName = "MinValue";
            MaxValueColumn.DataPropertyName = "MaxValue";
            ClothesNameUsageColumn.DataSource = db.ClothesPiecesDbSet.Local.ToBindingList<ClothesPiece>(); ;
            ClothesNameUsageColumn.DisplayMember = "Name";
            ClothesNameUsageColumn.ValueMember = "ClothesPieceId";
            ClothesNameUsageColumn.DataPropertyName = "ClothesPieceId";
        }

        private void SaveClothesButton_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
