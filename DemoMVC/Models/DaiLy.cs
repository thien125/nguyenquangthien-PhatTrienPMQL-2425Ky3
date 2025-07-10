using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models;

public class DaiLy
{
    [Key]
    public required string MaDaiLy { get; set; }
    public string? TenDaiLy { get; set; }
    public string? DiaChi { get; set; }
    public string? NguoiDaiDien { get; set; }
    public string? DienThoai { get; set; }
    public string? MaHTPP { get; set; }
}