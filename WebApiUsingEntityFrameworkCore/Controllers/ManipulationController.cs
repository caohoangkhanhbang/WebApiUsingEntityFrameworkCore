using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiUsingEntityFrameworkCore.ADO;
using WebApiUsingEntityFrameworkCore.Models;

namespace WebApiUsingEntityFrameworkCore.Controllers
{
    [ApiController]
    [Route("api-using-ef-core/[controller]")]
    public class ManipulationController: ControllerBase
    {
        private readonly AppDBContext _context;
        public ManipulationController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSanPham()
        {
            var sanPhams = await _context.SanPham.ToListAsync();
            return Ok(sanPhams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSanPhamById(int id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound($"Không tìm thấy sản phẩm có ID {id}");
            } else
            {
                return Ok(sanPham);
            }    
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateSanPham(SanPham sanPham)
        {
            if (sanPham == null)
            {
                return BadRequest("Sản phẩm không được để trống");
            }
            _context.SanPham.Add(sanPham);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSanPhamById), new { id = sanPham.MaSanPham }, sanPham);
        }

        [HttpPut("update-product/{id}")]
        public async Task<IActionResult> UpdateSanPham(int id, SanPham sanPhamNew)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            if(sanPham == null)
            {
                return NotFound($"Không tìm thấy sản phẩm có ID {id}");
            }
            else
            {
                sanPham.TenSanPham = sanPhamNew.TenSanPham;
                sanPham.GiaBan = sanPhamNew.GiaBan;
                _context.SanPham.Update(sanPham);
                await _context.SaveChangesAsync();
                return Ok(sanPham);
            }    
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            if(sanPham ==null)
            {
                return NotFound($"Không có sản phẩm nào có ID {id}");
            }
            else
            {
                //Cách 1: Xóa bằng phương thức where thủ công 
                //return Ok(await _context.SanPham.Where(sp => sp.MaSanPham == id).ExecuteDeleteAsync());
                //Cách 2 : Xóa bằng phương thức Remove
                _context.SanPham.Remove(sanPham);
                await _context.SaveChangesAsync();
                return Ok("Xóa thành công!");
            }
        }
    }
}
