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
    
    public partial class HoaDon : Form
    {
        private HoaDonThanhToan item;

        public HoaDonThanhToan Item { get => item; set => item = value; }

        public HoaDon()
        {
            InitializeComponent();
        }
        public HoaDon(HoaDonThanhToan item)
        {
            InitializeComponent();
            Item = item;
            lbThang.Text = item.NgayHD.Month.ToString();
            lbTien.Text = item.ThanhTien.ToString();
            txtSoSim.Text = item.Sim.SoSim.ToString();
            txtTenKhach.Text =item.KhachHang.TenKH.ToString();
            txtCMND.Text = item.KhachHang.CMND.ToString();
            txtDiaChi.Text = item.KhachHang.DiaChi.ToString();
            txtNghe.Text = item.KhachHang.NgheNghiep.ToString();
            txtSoHD.Text = item.MaHD.ToString();
            btnThanhToan.Enabled = true;
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            var dbcontext = new Model1();
            HoaDonThanhToan hd = dbcontext.HoaDonThanhToan.First(i => i.MaHD == Item.MaHD);
            hd.ThanhToan = true;
            hd.Status = false;
            int k = dbcontext.SaveChanges();
            if (k > 0)
            { 
            MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }
         else MessageBox.Show("Thanh toán thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); 
         this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
