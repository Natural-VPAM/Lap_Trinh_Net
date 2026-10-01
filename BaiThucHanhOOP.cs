using System;

public abstract class PhuongTien
{
    private string _maPT;
    private string _tenHang;
    private int _namSanXuat;
    private decimal _giaGoc;

    public string MaPT
    {
        get => _maPT;
        set => _maPT = string.IsNullOrWhiteSpace(value) ? "PT000" : value;
    }

    public string TenHang
    {
        get => _tenHang;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tên hãng không được để trống!");
            _tenHang = value;
        }
    }

    public int NamSanXuat
    {
        get => _namSanXuat;
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
                throw new ArgumentException("Năm sản xuất không hợp lệ!");
            _namSanXuat = value;
        }
    }

    public decimal GiaGoc
    {
        get => _giaGoc;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Giá gốc phải > 0!");
            _giaGoc = value;
        }
    }

    protected PhuongTien(string maPT, string tenHang, int namSX, decimal giaGoc)
    {
        MaPT = maPT;
        TenHang = tenHang;
        NamSanXuat = namSX;
        GiaGoc = giaGoc;
    }

    public abstract decimal TinhGiaLanBanh();

    public virtual string GetInfo()
    {
        return $"Mã: {MaPT}, Hãng: {TenHang}, Năm SX: {NamSanXuat}, Giá gốc: {GiaGoc:C}";
    }
}

public class OTo : PhuongTien
{
    public int SoChoNgoi { get; set; }
    public double DungTichDongCo { get; set; }

    public OTo(string maPT, string tenHang, int namSX, decimal giaGoc, int soCho, double dungTich)
        : base(maPT, tenHang, namSX, giaGoc)
    {
        if (soCho <= 0) throw new ArgumentException("Số chỗ ngồi phải > 0!");
        if (dungTich <= 0) throw new ArgumentException("Dung tích động cơ phải > 0!");
        SoChoNgoi = soCho;
        DungTichDongCo = dungTich;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (SoChoNgoi <= 9)
            return GiaGoc + GiaGoc * 0.12m + GiaGoc * 0.30m;
        else
            return GiaGoc + GiaGoc * 0.10m;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Số chỗ: {SoChoNgoi}, Động cơ: {DungTichDongCo}L";
    }
}

public class XeMay : PhuongTien
{
    public int DungTichXylanh { get; set; }

    public XeMay(string maPT, string tenHang, int namSX, decimal giaGoc, int dungTich)
        : base(maPT, tenHang, namSX, giaGoc)
    {
        DungTichXylanh = dungTich;
    }

    public override decimal TinhGiaLanBanh()
    {
        if (DungTichXylanh < 175)
            return GiaGoc + GiaGoc * 0.02m;
        else
            return GiaGoc + GiaGoc * 0.05m;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Dung tích xy-lanh: {DungTichXylanh}cc";
    }
}

public class QuanLyPhuongTien
{
    private List<PhuongTien> danhSach = new List<PhuongTien>();

    public void AddPhuongTien(PhuongTien pt)
    {
        danhSach.Add(pt);
    }

    public void DisplayAll()
    {
        foreach (var pt in danhSach)
        {
            Console.WriteLine($"{pt.GetInfo()}, Giá lăn bánh: {pt.TinhGiaLanBanh():C}");
        }
    }

    public PhuongTien FindMaxGiaLanBanh()
    {
        return danhSach.OrderByDescending(pt => pt.TinhGiaLanBanh()).FirstOrDefault();
    }

    public List<PhuongTien> SearchByName(string keyword)
    {
        return danhSach.Where(pt => pt.TenHang.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
