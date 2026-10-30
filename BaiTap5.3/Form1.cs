using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;
using BUS;

namespace WindowsFormsApp19
{
    public partial class FrmMain : Form
    {
        BanAnBUS banBUS = new BanAnBUS();

        public FrmMain()
        {
            InitializeComponent();
            LoadBan();
        }

        private void LoadBan()
        {
            flpBan.Controls.Clear();

            DataTable dt =
                banBUS.GetAll();

            foreach (DataRow row in dt.Rows)
            {
                Button btn = new Button();

                btn.Width = 120;
                btn.Height = 80;

                btn.Tag = row["MaBan"];

                btn.Text =
                    row["TenBan"].ToString() +
                    Environment.NewLine +
                    row["TrangThai"].ToString();

                string status =
                    row["TrangThai"].ToString();

                if (status == "Trống")
                    btn.BackColor =
                        Color.LightGreen;
                else
                    btn.BackColor =
                        Color.IndianRed;

                btn.Click += BtnBan_Click;

                flpBan.Controls.Add(btn);
            }
        }

        private void BtnBan_Click(object sender,EventArgs e)
        {
            Button btn =
                sender as Button;

            MessageBox.Show(
                "Đã chọn " +
                btn.Text);
        }

        private void btnThemMon_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Thêm món thành công");
        }

        private void btnThanhToan_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Thanh toán thành công");
        }
    }

    public partial class FrmQuanLyMon : Form
    {
        MonAnBUS monBUS =
            new MonAnBUS();

        public FrmQuanLyMon()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            dgvMon.DataSource =
                monBUS.GetAll();
        }

        private void btnThem_Click(
            object sender,
            EventArgs e)
        {
            MonAnDTO mon =
                new MonAnDTO();

            mon.TenMon =
                txtTenMon.Text;

            mon.MaDanhMuc =
                Convert.ToInt32(
                cboDanhMuc.SelectedValue);

            mon.DonGia =
                decimal.Parse(
                txtDonGia.Text);

            if (monBUS.Insert(mon))
            {
                MessageBox.Show(
                    "Thêm thành công");

                LoadData();
            }
        }

        private void btnSua_Click(
            object sender,
            EventArgs e)
        {
            MonAnDTO mon =
                new MonAnDTO();

            mon.MaMon =
                int.Parse(txtMaMon.Text);

            mon.TenMon =
                txtTenMon.Text;

            mon.MaDanhMuc =
                Convert.ToInt32(
                cboDanhMuc.SelectedValue);

            mon.DonGia =
                decimal.Parse(
                txtDonGia.Text);

            monBUS.Update(mon);

            LoadData();
        }

        private void btnXoa_Click(
            object sender,
            EventArgs e)
        {
            monBUS.Delete(
                int.Parse(
                txtMaMon.Text));

            LoadData();
        }
    }
}

namespace DAL
{
    public class DBConnection
    {
        protected string strConn =
            @"Data Source=.;Initial Catalog=CafePOSDB;Integrated Security=True";

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(strConn);
        }
    }

    public class BanAnDAL : DBConnection
    {
        public DataTable GetAllTables()
        {
            SqlDataAdapter da =
                new SqlDataAdapter(
                "SELECT * FROM BanAn",
                GetConnection());

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public void UpdateStatus(int maBan,
                                 string trangThai)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlCommand cmd =
                new SqlCommand(
                @"UPDATE BanAn
                  SET TrangThai=@TrangThai
                  WHERE MaBan=@MaBan",
                conn);

            cmd.Parameters.AddWithValue("@TrangThai",
                                        trangThai);

            cmd.Parameters.AddWithValue("@MaBan",
                                        maBan);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }

    public class DanhMucDAL : DBConnection
    {
        public DataTable GetDanhMuc()
        {
            SqlDataAdapter da =
                new SqlDataAdapter(
                "SELECT * FROM DanhMuc",
                GetConnection());

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
    }

    public class MonAnDAL : DBConnection
    {
        public DataTable GetAllMonAn()
        {
            SqlDataAdapter da =
                new SqlDataAdapter(
                @"SELECT *
                  FROM MonAn",
                GetConnection());

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public DataTable GetMonByDanhMuc(int maDM)
        {
            SqlDataAdapter da =
                new SqlDataAdapter(
                @"SELECT *
                  FROM MonAn
                  WHERE MaDanhMuc=@MaDM",
                GetConnection());

            da.SelectCommand.Parameters.AddWithValue(
                "@MaDM",
                maDM);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public bool Insert(MonAnDTO mon)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlCommand cmd = new SqlCommand(
            @"INSERT INTO MonAn
            (
                TenMon,
                MaDanhMuc,
                DonGia
            )
            VALUES
            (
                @TenMon,
                @MaDanhMuc,
                @DonGia
            )",
            conn);

            cmd.Parameters.AddWithValue(
                "@TenMon",
                mon.TenMon);

            cmd.Parameters.AddWithValue(
                "@MaDanhMuc",
                mon.MaDanhMuc);

            cmd.Parameters.AddWithValue(
                "@DonGia",
                mon.DonGia);

            int kq = cmd.ExecuteNonQuery();

            conn.Close();

            return kq > 0;
        }

        public bool Update(MonAnDTO mon)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlCommand cmd = new SqlCommand(
            @"UPDATE MonAn
              SET TenMon=@TenMon,
                  MaDanhMuc=@MaDanhMuc,
                  DonGia=@DonGia
              WHERE MaMon=@MaMon",
            conn);

            cmd.Parameters.AddWithValue("@MaMon",
                                        mon.MaMon);

            cmd.Parameters.AddWithValue("@TenMon",
                                        mon.TenMon);

            cmd.Parameters.AddWithValue("@MaDanhMuc",
                                        mon.MaDanhMuc);

            cmd.Parameters.AddWithValue("@DonGia",
                                        mon.DonGia);

            int kq = cmd.ExecuteNonQuery();

            conn.Close();

            return kq > 0;
        }

        public bool Delete(int maMon)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlCommand cmd =
                new SqlCommand(
                @"DELETE FROM MonAn
                  WHERE MaMon=@MaMon",
                conn);

            cmd.Parameters.AddWithValue(
                "@MaMon",
                maMon);

            int kq = cmd.ExecuteNonQuery();

            conn.Close();

            return kq > 0;
        }
    }

    public class HoaDonDAL : DBConnection
    {
        public int CreateBill(int maBan)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlCommand cmd =
            new SqlCommand(
            @"INSERT INTO HoaDon(MaBan)
VALUES(@MaBan)
 
SELECT SCOPE_IDENTITY()",
            conn);

            cmd.Parameters.AddWithValue(
            "@MaBan",
            maBan);

            int maHD =
            Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            return maHD;
        }

        public void AddFood(
    int maHD,
    int maMon,
    int soLuong,
    decimal donGia)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlCommand cmd =
                new SqlCommand(
                @"INSERT INTO ChiTietHoaDon
        (
            MaHoaDon,
            MaMon,
            SoLuong,
            DonGia
        )
        VALUES
        (
            @MaHD,
            @MaMon,
            @SoLuong,
            @DonGia
        )",
                conn);

            cmd.Parameters.AddWithValue("@MaHD", maHD);
            cmd.Parameters.AddWithValue("@MaMon", maMon);
            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
            cmd.Parameters.AddWithValue("@DonGia", donGia);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public bool ThanhToan(int maHD,
                      int maBan)
        {
            SqlConnection conn = GetConnection();

            conn.Open();

            SqlTransaction trans =
                conn.BeginTransaction();

            try
            {
                decimal tongTien = 0;

                SqlCommand cmdTong =
                    new SqlCommand(
                    @"SELECT
                SUM(SoLuong*DonGia)
              FROM ChiTietHoaDon
              WHERE MaHoaDon=@MaHD",
                    conn,
                    trans);

                cmdTong.Parameters.AddWithValue(
                    "@MaHD",
                    maHD);

                tongTien = Convert.ToDecimal(
                    cmdTong.ExecuteScalar());

                SqlCommand cmdHD =
                    new SqlCommand(
                    @"UPDATE HoaDon
              SET GioRa=GETDATE(),
                  TongTien=@TongTien,
                  TrangThai=1
              WHERE MaHoaDon=@MaHD",
                    conn,
                    trans);

                cmdHD.Parameters.AddWithValue(
                    "@TongTien",
                    tongTien);

                cmdHD.Parameters.AddWithValue(
                    "@MaHD",
                    maHD);

                cmdHD.ExecuteNonQuery();

                SqlCommand cmdBan =
                    new SqlCommand(
                    @"UPDATE BanAn
              SET TrangThai=N'Trống'
              WHERE MaBan=@MaBan",
                    conn,
                    trans);

                cmdBan.Parameters.AddWithValue(
                    "@MaBan",
                    maBan);

                cmdBan.ExecuteNonQuery();

                trans.Commit();

                conn.Close();

                return true;
            }
            catch
            {
                trans.Rollback();
                conn.Close();

                return false;
            }
        }
    }
}

namespace DTO
{
    public class BanAnDTO
    {
        public int MaBan { get; set; }

        public string TenBan { get; set; }

        public string TrangThai { get; set; }
    }

    public class DanhMucDTO
    {
        public int MaDanhMuc { get; set; }

        public string TenDanhMuc { get; set; }
    }

    public class MonAnDTO
    {
        public int MaMon { get; set; }

        public string TenMon { get; set; }

        public int MaDanhMuc { get; set; }

        public decimal DonGia { get; set; }
    }

    public class HoaDonDTO
    {
        public int MaHoaDon { get; set; }

        public int MaBan { get; set; }

        public DateTime GioVao { get; set; }

        public DateTime? GioRa { get; set; }

        public decimal TongTien { get; set; }

        public bool TrangThai { get; set; }
    }
}

namespace BUS
{
    public class BanAnBUS
    {
        BanAnDAL dal = new BanAnDAL();

        public DataTable GetAllTables()
        {
            return dal.GetAllTables();
        }

        public void UpdateStatus(int maBan,
                                 string status)
        {
            dal.UpdateStatus(maBan, status);
        }
    }

    public class DanhMucBUS
    {
        DanhMucDAL dal = new DanhMucDAL();

        public DataTable GetDanhMuc()
        {
            return dal.GetDanhMuc();
        }
    }

    public class MonAnBUS
    {
        MonAnDAL dal = new MonAnDAL();

        public DataTable GetAll()
        {
            return dal.GetAllMonAn();
        }

        public DataTable GetByDanhMuc(int maDM)
        {
            return dal.GetMonByDanhMuc(maDM);
        }

        public bool Insert(MonAnDTO mon)
        {
            if (string.IsNullOrWhiteSpace(mon.TenMon))
                return false;

            if (mon.DonGia < 0)
                return false;

            return dal.Insert(mon);
        }

        public bool Update(MonAnDTO mon)
        {
            if (string.IsNullOrWhiteSpace(mon.TenMon))
                return false;

            if (mon.DonGia < 0)
                return false;

            return dal.Update(mon);
        }

        public bool Delete(int maMon)
        {
            return dal.Delete(maMon);
        }
    }
}
