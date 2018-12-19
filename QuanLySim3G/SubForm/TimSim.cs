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

namespace QuanLySim3G.SubForm
{
    public partial class TimSim : Form
    {
        public TimSim()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void DataBindingTableSim()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Số Sim", typeof(string));
            dataTable.Columns.Add("Tình trạng Sim", typeof(string));
            dataTable.Columns.Add("Trạng thái", typeof(string));

            using (var dbcontext = new Model1())
            {

                var listHoadDonDangKy = dbcontext.Sim.ToList();

                foreach (var sim in listHoadDonDangKy)
                {
                    dataTable.Rows.Add(sim.SoSim,sim.Status,sim.Status);
                }
            }
            dgvSim.DataSource = dataTable;

        }


        List<Sim> FindBySoSim(string soSim)
        {
            using (var dbcontext = new Model1())
            {
                var query = from s in dbcontext.Sim
                            where s.SoSim.Contains(soSim)
                            select s;
                var listSim = query.ToList();

                return listSim;
            }
        }


        void LoadingSearchingSim(string soSim)
        {
            var result = FindBySoSim(soSim);

            if (result.Count != 0)
            {
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("Số Sim", typeof(string));
                dataTable.Columns.Add("Tình trạng Sim", typeof(string));
                dataTable.Columns.Add("Trạng thái", typeof(string));

                using (var dbcontext = new Model1())
                {
                    foreach (var sim in result)
                    {
                        dataTable.Rows.Add(sim.SoSim, sim.Status, sim.Status);
                    }
                }
                dgvSim.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Không tìm thấy số sim", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }

        private void TimSim_Load(object sender, EventArgs e)
        {
            DataBindingTableSim();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTimKiemSim_Click(object sender, EventArgs e)
        {
            string soSim = txtSoSim.Text;
            LoadingSearchingSim(soSim);
        }

        private void btnChonSim_Click(object sender, EventArgs e)
        {
            this.Close();

            Index fIndex = new Index("dangky");
            fIndex.Show();
        }

        private void dgvSim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSim.Rows[e.RowIndex];

                txtSoSim.Text = row.Cells["Số Sim"].Value.ToString();
            }
        }
      
    }
}
