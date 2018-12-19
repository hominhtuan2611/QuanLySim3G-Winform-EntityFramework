using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySim3G
{
    public partial class LichSuCuocGoi : Form
    {
        public LichSuCuocGoi()
        {
            InitializeComponent();
            dataLichSu_Load();
        }

        private void dataLichSu_Load(List<CuocGoi> lists )
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Mã Hóa Đơn", typeof(int));
            //  dataTable.Columns.Add("Mã Khách Hàng", typeof(string));
            dataTable.Columns.Add("Mã Sim", typeof(int));
            dataTable.Columns.Add("Thời gian bắt đầu", typeof(DateTime));
            dataTable.Columns.Add("thời gian kết thúc", typeof(DateTime));
            dataTable.Columns.Add("Số phút sử dụng", typeof(Double));
            dataTable.Columns.Add("Thành tiền", typeof(Decimal));
            //   dataTable.Columns.Add("Status", typeof(Boolean));

           
                foreach (var item in lists)
                {
                    this.toString(item);
                    dataTable.Rows.Add(item.MaCuocGoi, item.MaSim, item.TG_BatDau, item.TG_KetThuc, item.SoPhutSD, item.ThanhTien);

                }

                dgLichSu.DataSource = dataTable;            
        }

        private void dataLichSu_Load()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Mã Hóa Đơn", typeof(int));
            //  dataTable.Columns.Add("Mã Khách Hàng", typeof(string));
            dataTable.Columns.Add("Số Sim", typeof(String));
            dataTable.Columns.Add("Thời gian bắt đầu", typeof(DateTime));
            dataTable.Columns.Add("thời gian kết thúc", typeof(DateTime));
            dataTable.Columns.Add("Số phút sử dụng", typeof(Double));
            dataTable.Columns.Add("Thành tiền", typeof(Decimal));
            //   dataTable.Columns.Add("Status", typeof(Boolean));

            using (var dbcontext = new Model1())
            {
                
                var listLichSu = dbcontext.CuocGoi.ToList();

                foreach (var item in listLichSu)
                {
                    this.toString(item);
                    dataTable.Rows.Add(item.MaCuocGoi, item.Sim.SoSim, item.TG_BatDau, item.TG_KetThuc, item.SoPhutSD,item.ThanhTien);
                   
                }

                dgLichSu.DataSource = dataTable;
            }
        }
     
        private void toString (CuocGoi item)
        {
            Console.Write(" Ma cuoc goi: " + item.MaCuocGoi);
            Console.Write(" Ma Sim" + item.MaSim);
            Console.Write(" TG BD" + item.TG_BatDau);
            Console.Write(" TG KT" + item.TG_KetThuc);
            Console.WriteLine(" SO phut su dung" + item.SoPhutSD);
        }

        DateTime gettime(DateTime dt, TimeSpan ts )
        {
            DateTime t = new DateTime(dt.Year, dt.Month, dt.Day, ts.Hours,ts.Minutes, ts.Seconds);
            return t;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    lbOpen.Text = openFileDialog1.FileName;
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    string line = sr.ReadLine();
                    var dbcontext = new Model1();
                while (line != null && line != " ")
                    {
                        string[] item = line.Split('\t');
                        
                        int MaSim= Convert.ToInt32(item[0]);
                        DateTime TG_BatDau = Convert.ToDateTime(item[1]);
                        var listCuocgoi = dbcontext.CuocGoi.Where(i=>i.MaSim==MaSim).ToList();
                        CuocGoi cg = listCuocgoi.Find(i => i.TG_BatDau == TG_BatDau);
                    if (cg == null)
                    {
                        CuocGoi entity = new CuocGoi();
                        entity.MaSim = Convert.ToInt32(item[0]);
                        entity.TG_BatDau = Convert.ToDateTime(item[1]);
                        entity.TG_KetThuc = Convert.ToDateTime(item[2]);
                        //Đang tính số phút sử dụng
                        TimeSpan ts = new TimeSpan(entity.TG_KetThuc.Ticks - entity.TG_BatDau.Ticks);
                        entity.SoPhutSD = ts.TotalMinutes;                       
                        entity.ThanhTien = Convert.ToDecimal(tinhTien(entity));
                        dbcontext.CuocGoi.Add(entity);
                    }
                    else
                    {
                        MessageBox.Show("Đã có rồi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    line = sr.ReadLine();
                    }

                    dbcontext.SaveChanges();
                sr.Close();

                }
                dataLichSu_Load();
            }
               catch
          {
                MessageBox.Show("Không thể Import", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
        private Double tinhTien (CuocGoi entity)
        {
            var dbcontext = new Model1();
            toString(entity);
            Double sum = 0;
            double ex = entity.SoPhutSD;
            DateTime tbd = entity.TG_BatDau;
            double demsang = 0;
            double demtoi = 0;
            LoaiCuoc lc1 = dbcontext.LoaiCuoc.First(i => i.IdCuoc == 1);
            LoaiCuoc lc2 = dbcontext.LoaiCuoc.First(i => i.IdCuoc == 2);
            TimeSpan note = new TimeSpan(0, 0, 0);
            while (DateTime.Compare(tbd, entity.TG_KetThuc) < 0)
            {
                //khung thoi gian cuoc 1
                DateTime TimeStart1 = gettime(tbd, lc1.TG_BatDau);
                DateTime TimeStop1 = gettime(TimeStart1, lc1.TG_KetThuc);

                // DateTime TimeStop2 = TimeStart1.AddDays(+1);

                //TH1
                if (DateTime.Compare(tbd, TimeStart1) < 0 && TimeSpan.Compare(tbd.TimeOfDay, note) > 0
                    && DateTime.Compare(entity.TG_KetThuc, TimeStart1) < 0)
                {
                    Double t = new TimeSpan(entity.TG_KetThuc.Ticks - tbd.Ticks).TotalMinutes;
                    demtoi = demtoi + t;
                    ex = ex - t;
                    tbd = entity.TG_KetThuc;
                }
                //TH2
                if (DateTime.Compare(tbd, TimeStart1) < 0 && DateTime.Compare(tbd, TimeStop1.AddDays(-1)) > 0
                    && DateTime.Compare(entity.TG_KetThuc, TimeStart1) > 0)
                {
                    Double t = new TimeSpan(TimeStart1.Ticks - tbd.Ticks).TotalMinutes;
                    demtoi = demtoi + t;
                    ex = ex - t;
                    tbd = TimeStart1.AddTicks(+1);
                }
                //TH3
                if (DateTime.Compare(tbd, TimeStart1) > 0 && DateTime.Compare(tbd, TimeStop1) < 0
                    && DateTime.Compare(entity.TG_KetThuc, TimeStop1) < 0)
                {
                    Double t = new TimeSpan(entity.TG_KetThuc.Ticks - tbd.Ticks).TotalMinutes;
                    demsang = demsang + t;
                    ex = ex - t;
                    tbd = entity.TG_KetThuc;
                }
                //TH4
                if (DateTime.Compare(tbd, TimeStart1) > 0 && DateTime.Compare(tbd, TimeStop1) < 0
                  && DateTime.Compare(entity.TG_KetThuc, TimeStop1) > 0)
                {
                    Double t = new TimeSpan(TimeStop1.Ticks - tbd.Ticks).TotalMinutes;
                    demsang = demsang + t;
                    ex = ex - t;
                    tbd = TimeStop1.AddTicks(+1);
                }
                //TH5
                if (DateTime.Compare(tbd, TimeStop1) > 0 && DateTime.Compare(tbd, gettime(tbd, note).AddDays(+1)) < 0
                    && DateTime.Compare(entity.TG_KetThuc, gettime(tbd, note).AddDays(+1)) > 0)

                {
                    Double t = new TimeSpan(gettime(tbd.AddDays(+1), note).Ticks - tbd.Ticks).TotalMinutes;
                    demsang = demsang + t;
                    ex = ex - t;
                    tbd = gettime(tbd.AddDays(+1), note).AddTicks(+1);
                }
                //TH6
                if (DateTime.Compare(tbd, TimeStop1) > 0 && DateTime.Compare(tbd, gettime(tbd, note).AddDays(+1)) < 0 && DateTime.Compare(entity.TG_KetThuc, gettime(tbd, note).AddDays(+1)) < 0)

                {
                    Double t = new TimeSpan(entity.TG_KetThuc.Ticks - tbd.Ticks).TotalMinutes;
                    demtoi = demtoi + t;
                    ex = ex - t;
                    tbd = entity.TG_KetThuc;
                }
            }
            sum = demsang * Convert.ToDouble(lc1.GiaCuoc) + demtoi * Convert.ToDouble(lc2.GiaCuoc);
            return sum;
        }
        private void btnTim_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("Mã Hóa Đơn", typeof(int));
                //  dataTable.Columns.Add("Mã Khách Hàng", typeof(string));
                dataTable.Columns.Add("Số Sim", typeof(String));
                dataTable.Columns.Add("Thời gian bắt đầu", typeof(DateTime));
                dataTable.Columns.Add("thời gian kết thúc", typeof(DateTime));
                dataTable.Columns.Add("Số phút sử dụng", typeof(Double));
                 dataTable.Columns.Add("Thành tiền", typeof(Decimal));
                //   dataTable.Columns.Add("Status", typeof(Boolean));

                using (var dbcontext = new Model1())
                {
                    //Sim Sm = dbcontext.Sim.First(i => i.SoSim == txtSoSim.Text);
                   // CuocGoi cg = dbcontext.CuocGoi.First(i => i.Sim.SoSim== txtSoSim.Text);

                    var listLichSu = dbcontext.CuocGoi.ToList();

                    if (txtSoSim.Text!="")
                    {
                        listLichSu = listLichSu.Where(i => i.Sim.SoSim == txtSoSim.Text).ToList();
                    }

                    if (cbMonth.Text != "" && cbMonth.Text != "<Select Month>")
                        
                        listLichSu = listLichSu.Where(i => i.TG_BatDau.Month == int.Parse(cbMonth.Text)).ToList();
                    foreach (var item in listLichSu)
                    {
                        this.toString(item);
                        //dataTable.Rows.Add(item.MaCuocGoi, item.MaSim, item.TG_BatDau, item.TG_KetThuc, item.SoPhutSD);
                        dataTable.Rows.Add(new Object[]
                        {
                        item.MaCuocGoi,
                        item.Sim.SoSim,
                        item.TG_BatDau,
                        item.TG_KetThuc,
                        item.SoPhutSD,
                        item.ThanhTien
                        });


                        //  dataTable.Rows.Add(item.MaCuocGoi, item.MaSim, item.TG_BatDau, item.TG_KetThuc, item.SoPhutSD);

                    }

                    dgLichSu.DataSource = dataTable;
                }
            }
            catch
            {
                MessageBox.Show("Không thể tìm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtSoSim.Text = "";
        }

        private void LichSuCuocGoi_Load(object sender, EventArgs e)
        {

        }

        private void btnTaoLog_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < 50; i++)
                {
                    CuocGoi wcg = random();
                    // string write = wcg.MaSim.ToString() + { '/t'} + wcg.TG_BatDau.ToString() + { '/t'} + wcg.TG_KetThuc.ToString();
                    sw.WriteLine("{0}\t{1}\t{2}", wcg.MaSim.ToString(), wcg.TG_BatDau.ToString(), wcg.TG_KetThuc.ToString());
                    Thread.Sleep(100);
                }
                sw.Close();
                MessageBox.Show("Tạo file Log Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                                
        }

        //random 

        // ma sim lay tu database
        // ngay bat dau nam thang  (chon day)
        // ngay ket thuc phai lon 
        // gio 6
        private CuocGoi random()
        {
            using (var dbcontext = new Model1())
            {
                int count = dbcontext.HoaDonDK.Count();
                CuocGoi cg = new CuocGoi();
                Random r = new Random();

                // danh sach cac hoa don
                // co duoc index random
                // lay ra theo index trong list
                List<HoaDonDK> hoaDonList = dbcontext.HoaDonDK.ToList();

                int indexOfRandomSim = r.Next(1, count);

                int RandomSim=hoaDonList[indexOfRandomSim].MaSim;
                int selectedMonth = Convert.ToInt32(cbMonth.Text);
                int dayStart;
                int dayStop;
                if (selectedMonth==2)
                {
                     dayStart = r.Next(1, 28);
                     dayStop = r.Next(dayStart, 28);
                }
                else
                {
                    dayStart = r.Next(1, 30);
                    dayStop = r.Next(dayStart, 30);
                }
                DateTime start = new DateTime(DateTime.Now.Year, selectedMonth,dayStart,r.Next(0,24),r.Next(0,60),00);
               
                DateTime stop;

                if (dayStop == dayStart)
                {
                    stop = new DateTime(DateTime.Now.Year, selectedMonth, dayStop, r.Next(start.Hour, 24), r.Next(start.Minute, 60),0);
                }
                else
                {
                    stop = new DateTime(DateTime.Now.Year, selectedMonth, dayStop, r.Next(0, 24), r.Next(0, 60), 00);
                }
                cg.MaSim = RandomSim;
                cg.TG_BatDau = start;
                cg.TG_KetThuc = stop ;
                return cg;

            }
        }
    }
}
