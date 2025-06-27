namespace web_nha_sach_lt.Models
{
    public class CartItem
    {
        public int MaSach { get; set; }
        public string TieuDe { get; set; }
        public string TacGia { get; set; }     
        public string HinhAnh { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
    }
}
