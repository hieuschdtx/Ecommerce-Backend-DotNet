using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Exceptions;
using FileMode = System.IO.FileMode;

namespace shopecommerce.Domain.Extensions
{
    public static class SaveFileImageExtensions
    {
        public static async Task<string> SaveFileImageAsync(IFormFile file, IWebHostEnvironment environment, string folder)
        {
            // Tạo đường dẫn đến thư mục "wwwroot/images"
            var imagePath = Path.Combine(environment.WebRootPath, $"images/{folder}");

            // Tạo tên file kết hợp timeStamp và tên gốc của file
            var fileName = $"{HandleCharacter.ConvertAlias(file.FileName[..file.FileName.LastIndexOf(".")]) + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName)}";
            // Đường dẫn tới tệp hình ảnh sau khi lưu
            var filePath = Path.Combine(imagePath, fileName);
            try
            {
                Directory.CreateDirectory(imagePath);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return $"/{fileName}";
            }
            catch(Exception ex)
            {
                throw new BusinessRuleException("Error", ex.Message);
            }
        }
    }
}