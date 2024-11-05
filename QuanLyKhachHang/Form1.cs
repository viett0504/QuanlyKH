using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Add_Production
{
    public partial class Form1 : Form
    {
        //============================Khách hàng==========================
        private List<KhachHang> danhsachKhachHang = new List<KhachHang>();
        private List<DichVu> danhsachDichVu = new List<DichVu>();

        public Form1()
        {
            InitializeComponent();

            InsertDataCustomers();
            InputCustomers();
            OutputCustomers();


            InsertDataService();
            InputService();
            OutputService();

            DataCustomers_view.CellClick += DataCustomers_view_CellClick;
            DataService.CellClick += DataService_CellClick;
            button6.Click += button6_Click;

        }

        private void InsertDataCustomers()
        {
            DataCustomers_view.ColumnCount = 4;
            DataCustomers_view.Columns[0].Name = "Mã KH";
            DataCustomers_view.Columns[1].Name = "Tên KH";
            DataCustomers_view.Columns[2].Name = "SĐT";
            DataCustomers_view.Columns[3].Name = "Địa chỉ";
            DataCustomers_view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void InputCustomers()
        {
            danhsachKhachHang.Add(new KhachHang("1", "Nguyễn Văn A", "091234567" , "HaNoi"));
            danhsachKhachHang.Add(new KhachHang("2", "Trần Thị B", "091234567" , "HaNoi"));
            danhsachKhachHang.Add(new KhachHang("3", "Lê Văn C", "091234567" , "HaNoi"));
            danhsachKhachHang.Add(new KhachHang("4", "Phạm Thị D", "091234567" , "HaNoi"));
            danhsachKhachHang.Add(new KhachHang("5", "Vũ Thị E", "091234567" , "HaNoi"));
        }

        private void OutputCustomers()
        {
            DataCustomers_view.Rows.Clear();
            foreach (KhachHang kh in danhsachKhachHang)
            {
                DataCustomers_view.Rows.Add(kh.Makh, kh.Tenkh, kh.Sdt, kh.DiaChi);
            }
        }

        //============================Dịch Vụ==========================
        

        private void InsertDataService()
        {
            DataService.ColumnCount = 3;
            DataService.Columns[0].Name = "Mã dịch vụ";
            DataService.Columns[1].Name = "Tên dịch vụ";
            DataService.Columns[2].Name = "Giá dịch vụ";
            DataService.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void InputService()
        {
            danhsachDichVu.Add(new DichVu("1", "Rửa xe", 50000));
            danhsachDichVu.Add(new DichVu("2", "Thay dầu", 120000));
            danhsachDichVu.Add(new DichVu("3", "Thay nhớt", 150000));
            danhsachDichVu.Add(new DichVu("4", "Thay lốp", 150000));
            danhsachDichVu.Add(new DichVu("5", "Bơm hơi", 10000));
        }

        private void OutputService()
        {
            DataCustomers_view.Rows.Clear();
            foreach (DichVu dv in danhsachDichVu)
            {
                DataService.Rows.Add(dv.Madv, dv.Tendv, dv.Gia);
            }
        }

        private void label4_Click(object sender, EventArgs e) { }

        private void label8_Click(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void label9_Click(object sender, EventArgs e) { }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            string makh = textBox1.Text;
            string tenkh = textBox2.Text;
            string sdt = textBox3.Text;
            string diachi = textBox4.Text;


            KhachHang kh = new KhachHang(makh, tenkh, sdt, diachi);
            danhsachKhachHang.Add(kh);

            OutputCustomers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DataCustomers_view.SelectedRows.Count > 0)
            {
       
                int index = DataCustomers_view.SelectedRows[0].Index;
                danhsachKhachHang[index].Makh = textBox1.Text;
                danhsachKhachHang[index].Tenkh = textBox2.Text;
                danhsachKhachHang[index].Sdt = textBox3.Text;
                danhsachKhachHang[index].DiaChi = textBox4.Text;

                OutputCustomers();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DataCustomers_view.SelectedRows.Count > 0)
            {
         
                int index = DataCustomers_view.SelectedRows[0].Index;
                danhsachKhachHang.RemoveAt(index);


                OutputCustomers();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_btn_Click(object sender, EventArgs e)
        {       
            string maKhachHang = searchID_txt.Text;

            KhachHang kh = danhsachKhachHang.Find(s => s.Makh == maKhachHang);

            if (kh != null)
            {
                DataCustomers_view.Rows.Clear();
                DataCustomers_view.Rows.Add(kh.Makh, kh.Tenkh, kh.Sdt, kh.DiaChi);
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutputCustomers();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string madv = searchIDService.Text;

            DichVu dv = danhsachDichVu.Find(s => s.Madv == madv);

            if (dv != null)
            {
                DataService.Rows.Clear();
                DataService.Rows.Add(dv.Madv, dv.Tendv, dv.Gia);
            }
            else
            {
                MessageBox.Show("Không tìm thấy dịch vụ!");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OutputService();
        }

        private List<DichVu> danhSachDichVuChon = new List<DichVu>();
        private KhachHang khachHangChon = null;

        private void DataCustomers_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                khachHangChon = danhsachKhachHang[e.RowIndex];
                MessageBox.Show("Đã chọn khách hàng: " + khachHangChon.Tenkh);
            }
        }

        private void DataService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DichVu dv = danhsachDichVu[e.RowIndex];
                danhSachDichVuChon.Add(dv);
                MessageBox.Show("Đã thêm dịch vụ: " + dv.Tendv + " - Giá: " + dv.Gia);
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (khachHangChon == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }
            if (danhSachDichVuChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dịch vụ.");
                return;
            }

            float tongChiPhi = danhSachDichVuChon.Sum(dv => dv.Gia);

            StringBuilder hoaDonTamThoi = new StringBuilder();
            hoaDonTamThoi.AppendLine("Hóa đơn tạm thời");
            hoaDonTamThoi.AppendLine("Khách hàng: " + khachHangChon.Tenkh);
            hoaDonTamThoi.AppendLine("SĐT: " + khachHangChon.Sdt);
            hoaDonTamThoi.AppendLine("Dịch vụ đã chọn:");

            foreach (var dv in danhSachDichVuChon)
            {
                hoaDonTamThoi.AppendLine("- " + dv.Tendv + ": " + dv.Gia + " VND");
            }

            hoaDonTamThoi.AppendLine("Tổng chi phí: " + tongChiPhi + " VND");

            MessageBox.Show(hoaDonTamThoi.ToString());
        }
    }





    public class KhachHang
    {
        public string Makh { get; set; }
        public string Tenkh { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }

        public KhachHang(string makh, string tenkh, string sdt, string diachi)
        {
            Makh = makh;
            Tenkh = tenkh;
            Sdt = sdt;
            DiaChi = diachi;
        }
    }

    public class DichVu
    {
        public string Madv { get; set; }
        public string Tendv { get; set; }
        public float Gia { get; set; }

        public DichVu(string madv, string tendv, float gia)
        {
            Madv = madv;
            Tendv = tendv;
            Gia = gia;
        }
    }
}
