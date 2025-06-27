using System.ComponentModel.DataAnnotations;

namespace web_nha_sach_lt.Models
{
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }

        public string TheLoai { get; set; }
        public string TieuDe { get; set; }
        public string TacGia { get; set; }
        public decimal Gia { get; set; }
        public string NhaXuatBan { get; set; }
        public int SoTrang { get; set; }
        public string NgonNgu { get; set; }
        public int NamXuatBan { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }
    }
}
