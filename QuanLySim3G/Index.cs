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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        public Index(string contentNeedShow)
        {
            InitializeComponent();


            showContentDangKySim();

        }
        void showContentTongQuan()
        {
            TongQuan tongquan = new TongQuan();
            tongquan.TopLevel = false;

            pnContent.Controls.Clear();
            pnContent.Controls.Add(tongquan);

            tongquan.Show();
            
        }

        void showContentDangKySim()
        {
            DangKySim dangkysim = new DangKySim();
            dangkysim.TopLevel = false;

            pnContent.Controls.Clear();
            pnContent.Controls.Add(dangkysim);

            dangkysim.Show();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDangKySim_Click(object sender, EventArgs e)
        {
            DangKySim dks = new DangKySim();
            dks.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(dks);

            dks.Show();
        }

        private void pnTongQuan_Click(object sender, EventArgs e)
        {
            showContentTongQuan();
        }

        private void lblTongQuan_Click(object sender, EventArgs e)
        {
            showContentTongQuan();
        }

        private void lblThanhToan_Click(object sender, EventArgs e)
        {
            ThanhToan thanhtoan = new ThanhToan();
            thanhtoan.TopLevel = false;

            pnContent.Controls.Clear();
            pnContent.Controls.Add(thanhtoan);

            thanhtoan.Show();
        }

        private void lblLichSuSuDung_Click(object sender, EventArgs e)
        {
            LichSuCuocGoi lichSu = new LichSuCuocGoi();
            lichSu.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(lichSu);
            lichSu.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            GiaCuoc gc = new GiaCuoc();
            gc.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(gc);
            gc.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            QLSim sim = new QLSim();
            sim.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(sim);
            sim.Show();
        }
    }
}
