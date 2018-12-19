using Model;
using QuanLySim3G.SubForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySim3G
{
    public partial class DangKySim : Form
    {
              public DangKySim()
        {
            InitializeComponent();
        }

        void DataBindingTableHopDongDangKy()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Tên khách hàng", typeof(string));
            dataTable.Columns.Add("Địa chỉ khách hàng", typeof(string));
            dataTable.Columns.Add("CMND", typeof(string));
            dataTable.Columns.Add("Nghề nghiệp", typeof(string));
           // dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Ngày đăng ký", typeof(DateTime));

            dataTable.Columns.Add("Chi phí", typeof(Decimal));
            dataTable.Columns.Add("Sim", typeof(string));

            using (var dbcontext = new Model1())
            {

                var listHoadDonDangKy = dbcontext.HoaDonDK.ToList();

                foreach (var hoadon in listHoadDonDangKy)
                {
                    dataTable.Rows.Add(hoadon.KhachHang.TenKH, hoadon.KhachHang.DiaChi,hoadon.KhachHang.CMND,hoadon.KhachHang.NgheNghiep, hoadon.NgayDK, hoadon.ChiPhi, hoadon.Sim.SoSim);
                }
            }

            dgvHopDongDangKy.DataSource = dataTable;
           
        }

        Sim FindBySoSim(string soSim)
        {
            using (var dbcontext = new Model1())
            {
                var query = from s in dbcontext.Sim
                            where s.SoSim.Contains(soSim)
                            select s;
                var listSim = query.FirstOrDefault();

                return listSim;
            }
        }
        int ChangeStatusSim(int maSim)
        {
            using (var dbcontext = new Model1())
            {
                //staus của thng2 sim này thành mới

             
                Sim curretnSim = dbcontext.Sim.First(s => s.MaSim == maSim);

                curretnSim.Status = true;


                dbcontext.Entry(curretnSim).State = EntityState.Modified;


                return dbcontext.SaveChanges() ;
            }
        }


        //đã có trong db rồi. find theo email 
        KhachHang FindCustomerByCMND(string cmnd)
        {
            using (var dbcontext = new Model1())
            {
                var query = from s in dbcontext.KhachHang
                            where s.CMND.Contains(cmnd)
                            select s;
                var listSim = query.FirstOrDefault();

                return listSim;
            }
        }


        int InsertKhachHang(KhachHang kh)
        {
            using (var dbcontext = new Model1())
            {
                dbcontext.KhachHang.Add(kh);
                return dbcontext.SaveChanges();
            }
        }

        int UpdateKhachHang(KhachHang updatedKhachh)
        {
            using (var dbcontext = new Model1())
            {
                dbcontext.Entry(updatedKhachh).State = EntityState.Modified;

                var currentKhachHang = dbcontext.KhachHang.FirstOrDefault(kh => kh.MaKH == updatedKhachh.MaKH);

                currentKhachHang.NgheNghiep = updatedKhachh.NgheNghiep;

                currentKhachHang.DiaChi = updatedKhachh.DiaChi;
                currentKhachHang.CMND = updatedKhachh.CMND;
                currentKhachHang.TenKH = updatedKhachh.TenKH;
                currentKhachHang.NgheNghiep = updatedKhachh.NgheNghiep;
               // currentKhachHang.Email = updatedKhachh.Email;

               return dbcontext.SaveChanges();
            }
        }

        int InserHoaDonDK(HoaDonDK hoaDonDangKy)
        {
            using (var dbcontext = new Model1())
            {
                dbcontext.HoaDonDK.Add(hoaDonDangKy);
                return dbcontext.SaveChanges();
            }
        }

        //int GetPhiHoaMang()
        //{
        //    using (var dbcontext = new Model1())
        //    {
        //        dbcontext.HoaDonDK.Add(hoaDonDangKy);
        //        return dbcontext.SaveChanges();
        //    }
        //}

        private void DangKySim_Load(object sender, EventArgs e)
        {
            DataBindingTableHopDongDangKy();
        }

        //1. Kiểm tra sim có tồn tại && đã sử dụng chưa nữa ko thì thông báo cho người ta
        //2.  insert khách hàng trước 
        //3. thành công thì insert hợp đồng
        //4. ! thành công thì thông báo insert khách lỗi
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            Sim customerSim = FindBySoSim(txtSoSim.Text);
            //84913919143
            if (customerSim != null && customerSim.Status != true){

                KhachHang kh = new KhachHang();

                kh.DiaChi=txtDiaChi.Text;
                kh.CMND=txtCMND.Text ;
                kh.TenKH=txtTenKhach.Text;
                kh.NgheNghiep=txtNghe.Text;
            //    kh.Email = txtEmail.Text;

                int result = InsertKhachHang(kh);

                if (result == 1){
                    HoaDonDK hoaDonDangKy  = new HoaDonDK();

                    hoaDonDangKy.MaKH = kh.MaKH;
                    hoaDonDangKy.ChiPhi=50000;
                    hoaDonDangKy.NgayDK = DateTime.Now;
                    hoaDonDangKy.MaSim = customerSim.MaSim;

                    int flag = InserHoaDonDK(hoaDonDangKy);
                  
                   
                     if (flag == 1){

                        if (ChangeStatusSim(customerSim.MaSim) >0)
                        {
                            MessageBox.Show("Thêm hợp đồng thành công", "Thông báo thêm hợp đồng đăng ký Sim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataBindingTableHopDongDangKy();
                        }
                        else
                        {
                            MessageBox.Show("Thay đổi trạng thái Sim fail", "Thông báo lỗi số Sim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                     }
                     else{
                         MessageBox.Show("Thêm hợp đồng fail", "Thông báo lỗi nhập sai số Sim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                }
                else{
                    MessageBox.Show("Thêm khách fail", "Thông báo lỗi nhập sai số Sim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else{
                MessageBox.Show("Sim không tồn tại hoặc có người sử dụng", "Thông báo lỗi nhập sai số Sim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimSim_Click(object sender, EventArgs e)
        {
            TimSim fTimSim = new TimSim();
            fTimSim.ShowDialog();
        }

        private void dgvHopDongDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvHopDongDangKy.Rows[e.RowIndex];

                txtDiaChi.Text = row.Cells["Địa chỉ khách hàng"].Value.ToString();
                txtSoSim.Text = row.Cells["Sim"].Value.ToString();
                txtCMND.Text = row.Cells["CMND"].Value.ToString();
                txtTenKhach.Text = row.Cells["Tên khách hàng"].Value.ToString();
               // txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtDiaChi.Text = row.Cells["Địa chỉ khách hàng"].Value.ToString();
                txtNghe.Text = row.Cells["Nghề nghiệp"].Value.ToString();


                btnCapNhat.Enabled = true;
                btnDangKy.Enabled = false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtSoSim.Text = "";
            txtCMND.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtNghe.Text = "";
        


            btnCapNhat.Enabled = false;
            btnDangKy.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //chắc chắn kiếm được ln
             KhachHang kh = FindCustomerByCMND(txtCMND.Text);

             kh.DiaChi = txtDiaChi.Text;
             kh.CMND = txtCMND.Text;
             kh.TenKH = txtTenKhach.Text;
             kh.NgheNghiep = txtNghe.Text;
          //   kh.Email = txtEmail.Text;


            if (UpdateKhachHang(kh) > 0)
            {
                MessageBox.Show("Cập nhật khách hàng thành công", "Thông báo cập nhật khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBindingTableHopDongDangKy();
            }
            else
            {
                MessageBox.Show("Cập nhật khách hàng thất bại", "Thông báo cập nhật khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
