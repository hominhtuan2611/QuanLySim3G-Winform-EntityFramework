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
    public partial class ThanhToan : Form
    {
        private HoaDonThanhToan entity = new HoaDonThanhToan();
        public ThanhToan()
        {
            InitializeComponent();
            DataBindingTableThanhtoan();
        }

        void DataBindingTableThanhtoan()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Mã Hóa Đơn", typeof(string));
            dataTable.Columns.Add("Tên Khách Hàng", typeof(string));
            dataTable.Columns.Add("CMND", typeof(string));
            dataTable.Columns.Add("Số Sim", typeof(string));
            dataTable.Columns.Add("Ngày Hóa đơn", typeof(DateTime));
            dataTable.Columns.Add("Thanh toán", typeof(Boolean));
            dataTable.Columns.Add("Thành tiền", typeof(Decimal));
            dataTable.Columns.Add("Status", typeof(Boolean));

            using (var dbcontext = new Model1())
            {
                
                var listHoadDon = dbcontext.HoaDonThanhToan.ToList();

                foreach (var hoadon in listHoadDon)
                {
                    KhachHang kh = dbcontext.KhachHang.First(i => i.MaKH == hoadon.MaKH);
                    dataTable.Rows.Add(hoadon.MaHD,kh.TenKH,kh.CMND,hoadon.Sim.SoSim, hoadon.NgayHD, hoadon.ThanhToan, hoadon.ThanhTien, hoadon.Status);
                }

                dgThanhToan.DataSource = dataTable;
            }

        }

       
        void DataBindingTableThanhtoan_find(int ?month)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Mã Hóa Đơn", typeof(string));
            dataTable.Columns.Add("Tên Khách Hàng", typeof(string));
            dataTable.Columns.Add("CMND", typeof(string));
            dataTable.Columns.Add("Số Sim", typeof(string));
            dataTable.Columns.Add("Ngày Hóa đơn", typeof(DateTime));
            dataTable.Columns.Add("Thanh toán", typeof(Boolean));
            dataTable.Columns.Add("Thành tiền", typeof(Decimal));
            dataTable.Columns.Add("Status", typeof(Boolean));

            using (var dbcontext = new Model1())
            {
                var listHoadDon = dbcontext.HoaDonThanhToan.ToList();
                
                if (txtCmnd.Text!="")//tìm theo cmnd
                {
                   

                     listHoadDon = listHoadDon.Where(i => i.KhachHang.CMND == txtCmnd.Text).ToList();
                }
                if(month!=null)
                {
                    //tìm theo tháng 
                   listHoadDon = listHoadDon.Where(i => i.NgayHD.Month == month).ToList();

                }
                             
                
               foreach (var hoadon in listHoadDon)
                {
                    
                  dataTable.Rows.Add(hoadon.MaHD,hoadon.KhachHang.TenKH,hoadon.KhachHang.CMND,hoadon.Sim.SoSim,hoadon.NgayHD, hoadon.ThanhToan, hoadon.ThanhTien, hoadon.Status);
                }

                dgThanhToan.DataSource = dataTable;
            }

        }

        public HoaDonThanhToan Entity { get => entity; set => entity = value; }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                var dbcontext = new Model1();
                DataGridViewRow row = this.dgThanhToan.Rows[e.RowIndex];
                int MaHD = Convert.ToInt32(row.Cells["Mã Hóa Đơn"].Value.ToString());
                Entity = dbcontext.HoaDonThanhToan.First(i => i.MaHD == MaHD);               
                KhachHang kh = dbcontext.KhachHang.First(i => i.MaKH == Entity.MaKH);
                txtTenkh.Text = kh.TenKH;
                
                txtCmnd.Text = kh.CMND;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dbcontext = new Model1();
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cbMonth.Text == "<select Month>" || cbMonth.Text == "")
                    DataBindingTableThanhtoan_find(null);
                else DataBindingTableThanhtoan_find(int.Parse(cbMonth.Text));
            }
            catch
            {
                MessageBox.Show("Tìm hóa đơn không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtCmnd.Text = "";
                      txtTenkh.Text = "";
        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                HoaDon fhd = new HoaDon(Entity);
                fhd.ShowDialog();
                
                DataBindingTableThanhtoan();
                
            }
            catch
            {
                MessageBox.Show("Thanh toán thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var dbcontext = new Model1();
            var listCuocgoi = dbcontext.CuocGoi.ToList();
            var listTotal = listCuocgoi.GroupBy(i => new {i.MaSim,i.TG_BatDau.Month}).Select(g => new
            {
                id = g.Select(i=>i.MaSim),
                date = g.Select(i=>i.TG_BatDau.Month),
                total = g.Sum(s => s.ThanhTien)
            });
            var listHoaDon = dbcontext.HoaDonThanhToan.ToList();    
            foreach(var item in listTotal)
            {
                int id = Convert.ToInt32(item.id.Max());
                int date = Convert.ToInt32(item.date.Max());
                var listFind = listHoaDon.Where(i =>i.MaSim == id  ).ToList();
                HoaDonThanhToan d = listFind.Find(i => i.NgayHD.Month == date);
                if (d == null)
                {
                    d = new HoaDonThanhToan();
                    HoaDonDK kh = dbcontext.HoaDonDK.First(i => i.MaSim == id);
                    d.MaKH = kh.MaKH;
                    d.MaSim = id;
                    d.NgayHD = new DateTime(DateTime.Now.Year, Convert.ToInt32(item.date.Max()), 20);
                    d.ThanhToan = false;
                    d.ThanhTien = Decimal.Parse(item.total.ToString());
                    d.Status = true;
                    dbcontext.HoaDonThanhToan.Add(d);
                }                
            }
            dbcontext.SaveChanges();
            DataBindingTableThanhtoan();
            MessageBox.Show("Cập nhật hóa đơn đã xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

