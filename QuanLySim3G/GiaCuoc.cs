using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySim3G
{
    public partial class GiaCuoc : Form
    {
        public GiaCuoc()
        {
            InitializeComponent();
            DataBidingGiaCuoc();
        }
        private void DataBidingGiaCuoc()
        {
            using (var dbcontext = new Model1())
            {
                var listGiaCuoc = dbcontext.LoaiCuoc.ToList();
                DataTable table = new DataTable();
                table.Columns.Add("Mã Loại Cước", typeof(int));
                table.Columns.Add("Giá Cước", typeof(Decimal));
                table.Columns.Add("Giờ Bắt Đầu", typeof(TimeSpan));
                table.Columns.Add("Giờ Kết Thúc", typeof(TimeSpan));
                table.Columns.Add("Trạng thái", typeof(Boolean));
                foreach (LoaiCuoc item in listGiaCuoc)
                {
                    table.Rows.Add(item.IdCuoc, item.GiaCuoc, item.TG_BatDau, item.TG_KetThuc, item.Status);
                }
                dgLoaiCuoc.DataSource = table;
            }
          
        }

        private void dgLoaiCuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgLoaiCuoc.Rows[e.RowIndex];
                txtMaLoai.Text = row.Cells["Mã Loại Cước"].Value.ToString();
                txtGiaTien.Text= row.Cells["Giá Cước"].Value.ToString();
                txtGioBD.Text= row.Cells["Giờ Bắt Đầu"].Value.ToString();
                txtGioKT.Text = row.Cells["Giờ Kết Thúc"].Value.ToString();
                btnCapNhat.Enabled = true;
               
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //try
            //{
                using (var dbcontext = new Model1())
                {
                int id = int.Parse(txtMaLoai.Text);
                    LoaiCuoc loaiCuoc = dbcontext.LoaiCuoc.First(i => i.IdCuoc == id );
                    loaiCuoc.GiaCuoc = Convert.ToInt32(txtGiaTien.Text);
                    loaiCuoc.TG_BatDau = TimeSpan.Parse(txtGioBD.Text);
                    loaiCuoc.TG_KetThuc = TimeSpan.Parse(txtGioKT.Text);
                    dbcontext.SaveChanges();
                }
                DataBidingGiaCuoc();
            //}
            //catch
            //{
            //    MessageBox.Show("Cập nhật cước thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
