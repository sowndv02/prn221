using OfficeOpenXml;
using SEP_Management.Models;

namespace SEP_Management.Utils
{
    public class ExcelHandler
    {
        public void ImportProjectFromExcel(string filePath, int classId)
        {
            Project pro = new Project();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
                {
                    pro.GroupName = worksheet.Cells[i, 1].GetValue<string>();
                    pro.ProjectCode = worksheet.Cells[i, 2].GetValue<string>();
                    pro.ProjectEnName = worksheet.Cells[i, 3].GetValue<string>();
                    pro.ProjectVieName = worksheet.Cells[i, 4].GetValue<string>();
                    pro.ProjectDescription = worksheet.Cells[i, 5].GetValue<string>();
                    pro.Status = 1;
                    pro.ClassId = classId;
                    using (var context = new SEP_ManagementContext())
                    {
                        context.Projects.Add(pro);
                        context.SaveChanges();
                    }
                }
            }
        }

        public void ExportTemplateProject(string filePath)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Projects");

                    worksheet.Cells[1, 1].Value = "group_name";
                    worksheet.Cells[1, 2].Value = "project_code";
                    worksheet.Cells[1, 3].Value = "project_en_name";
                    worksheet.Cells[1, 4].Value = "project_vi_name";
                    worksheet.Cells[1, 5].Value = "project_descript";

                    worksheet.Cells[2, 1].Value = "";
                    worksheet.Cells[2, 2].Value = "";
                    worksheet.Cells[2, 3].Value = "";
                    worksheet.Cells[2, 4].Value = "";
                    worksheet.Cells[2, 5].Value = "";

                    FileInfo excelFile = new FileInfo(filePath);
                    package.SaveAs(excelFile);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ExportProjectToExcel(List<Project> projects, string filePath)
        {
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a worksheet to the package
                var worksheet = package.Workbook.Worksheets.Add("Projects");

                // Add headers to the worksheet
                worksheet.Cells["A1"].Value = "project_id";
                worksheet.Cells["B1"].Value = "project_code";
                worksheet.Cells["C1"].Value = "project_en_name";
                worksheet.Cells["D1"].Value = "project_vi_name";
                worksheet.Cells["E1"].Value = "project_descript";
                worksheet.Cells["F1"].Value = "status";
                worksheet.Cells["G1"].Value = "class_id";
                worksheet.Cells["H1"].Value = "group_name";
                worksheet.Cells["I1"].Value = "mentor_id";
                worksheet.Cells["J1"].Value = "co_mentor_id";

                // Populate the worksheet with data
                int row = 2;
                foreach (var p in projects)
                {
                    worksheet.Cells["A" + row].Value = p.ProjectId;
                    worksheet.Cells["B" + row].Value = p.ProjectCode;
                    worksheet.Cells["C" + row].Value = p.ProjectEnName;
                    worksheet.Cells["D" + row].Value = p.ProjectVieName;
                    worksheet.Cells["E" + row].Value = p.ProjectDescription;
                    worksheet.Cells["F" + row].Value = p.Status;
                    worksheet.Cells["G" + row].Value = p.Class.ClassCode;
                    worksheet.Cells["H" + row].Value = p.GroupName;
                    worksheet.Cells["I" + row].Value = p.MentorId;
                    worksheet.Cells["J" + row].Value = p.CoMentorId;
                    row++;
                }

                FileInfo excelFile = new FileInfo(filePath);
                package.SaveAs(excelFile);
            }

            Console.WriteLine($"Excel file exported to: {filePath}");
        }
    }
}
