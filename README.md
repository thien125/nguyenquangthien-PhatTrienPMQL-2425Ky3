Phát triển Phần mềm quản lý - Nhóm 01

1. Môi trường lập trình
    - C#, .Net, MVC
    - Visual Studio Code/Visual Studio (C# Dev Kit, C#, IntelliCode for C# Dev Kit...)
    - Git + Github (git add, git commit, git push, git pull, git branch...)
2. Nội dung học
   - Phát triển ứng dụng quản lý trên .net MVC
   - Tìm hiểu mô hình MVC, Cách thức hoạt động của Model, View, Controller
   - Nắm được cách gửi nhận dữ liệu giữa Model, View, Controller
   - Kế thừa... => Đủ điều kiện đạt
   - Làm việc với Excel, phân trang dữ liệu
   - Authentication và Authorization
   - HTML, CSS (W3.css/Bootstrap)
   - C# Code First, Entity Framework
3. Đánh giá kết quả học phần
   - Thi điểm A: Vấn đáp
   - Điểm B: Dựa vào điểm thi + Bài thực hành + Bài kiểm tra
   - Điểm C: Điểm danh + Làm bài thực hành
4. Bai thực hành số 1:
   - Cài đặt môi trường lập trình
   - Tạo project DemoMVC: dotnet new mvc -o DemoMVC
   - Tại repository trên github và đẩy code lên github
   - Chèn link repository vào link thông tin môn họ
// Thêm 1 folder upload/excel
// builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
// dotnet ef migrations add Create_table_Person
// dotnet ef database update 
// dotnet aspnet-codegenerator controller -name EmployeeController -m Employee -dc MvcMovie.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
// excel
// dotnet add package EPPlus 

// using DemoMVC.Models.Process;
// private ExcelProcess _excelProcess = new ExcelProcess();

// public async Task<IActionResult> Upload()
// {
//     return View();
// }
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Upload(IFormFile file)
//         {
//             if (file != null)
//             {
//                 string fileExtension = Path.GetExtension(file.FileName);
//                 if (fileExtension != ".xls" && fileExtension != ".xlsx")
//                 {
//                     ModelState.AddModelError("", "Please choose excel file to upload");
//                 }
//                 else
//                 {
//                     var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
//                     var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
//                     var fileLocation = new FileInfo(filePath).ToString();
//                     using (var stream = new FileStream(filePath, FileMode.Create))
//                     {
//                         await file.CopyToAsync(stream);
//                     }
//                     var dt = _excelProcess.ExcelToDataTable(fileLocation);
//                     for (int i = 0; i < dt.Rows.Count; i++)
//                     {
//                         var ps = new Person
//                         {
//                             PersonId = dt.Rows[i][0].ToString(),
//                             FullName = dt.Rows[i][1].ToString(),
//                             Address = dt.Rows[i][2].ToString()
//                         };
//                         _context.Add(ps);
//                     }
//                     await _context.SaveChangesAsync();
//                     return RedirectToAction(nameof(Index));
//                 }
//             }
//             return View();
//         }

// public IActionResult Download()
// {
//     var fileName = "YourFileName" + ".xlsx";
//     using (ExcelPackage excelPackage = new ExcelPackage())
//     {
//         ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
//         worksheet.Cells["A1"].Value = "PersonId";
//         worksheet.Cells["B1"].Value = "FullName";
//         worksheet.Cells["C1"].Value = "Address";
//         var personList = _context.Person.ToList();
//         worksheet.Cells["A2"].LoadFromCollection(personList);
//         var stream = new MemoryStream(excelPackage.GetAsByteArray());
//         return File(stream, "applicaton/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
//     }
// }

// ExcelProcess.cs
// using System.Data;
// using OfficeOpenXml;
// using DemoMVC.Models.Process;
// namespace DemoMVC.Models.Process
// {
//     public class ExcelProcess
//     {
//         public DataTable ExcelToDataTable(string strPath)
//         {
//             ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
//             FileInfo fi = new FileInfo(strPath);
//             ExcelPackage excelPackage = new ExcelPackage(fi);
//             DataTable dt = new DataTable();
//             ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
//             if (worksheet.Dimension == null)
//             {
//                 return dt;
//             }
//             List<string> columnNames = new List<string>();
//             int currentColumn = 1;
//             foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
//             {
//                 string columnName = cell.Text.Trim();
//                 if (cell.Start.Column != currentColumn)
//                 {
//                     columnNames.Add("Header_" + currentColumn);
//                     dt.Columns.Add("Header_" + currentColumn);
//                     currentColumn++;
//                 }
//                 columnNames.Add(columnName);
//                 int occurrences = columnNames.Count(x => x.Equals(columnName));
//                 if (occurrences > 1)
//                 {
//                     columnName = columnName + "_" + occurrences;
//                 }
//                 dt.Columns.Add(columnName);
//                 currentColumn++;
//             }

//             for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
//             {
//                 var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
//                 DataRow newRow = dt.NewRow();
//                 foreach (var cell in row)
//                 {
//                     newRow[cell.Start.Column - 1] = cell.Text;
//                 }
//                 dt.Rows.Add(newRow);
//             }
//             return dt;
//         }
//     }
// }