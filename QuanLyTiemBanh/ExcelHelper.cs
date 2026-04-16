using ClosedXML.Excel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BakeryHub
{
    public static class ExcelHelper
    {
        // Hàm XUẤT Excel dùng chung cho mọi DataTable
        public static void Export(DataTable dt, string sheetName)
        {
            if (dt == null || dt.Rows.Count == 0) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                // 1. QUAN TRỌNG: Tên file phải có sẵn đuôi .xlsx bên trong chuỗi
                sfd.FileName = sheetName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                // 2. Thiết lập bộ lọc chuẩn xác
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";

                // 3. Các thuộc tính ép Windows phải nhận diện đúng định dạng
                sfd.DefaultExt = "xlsx";
                sfd.AddExtension = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add(dt, sheetName);
                            ws.Columns().AdjustToContents();
                            wb.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu file: " + ex.Message);
                    }
                }
            }
        }

        // Hàm đọc file Excel trả về DataTable (Để các Form tự xử lý logic Insert sau đó)
        public static DataTable Import(string filePath)
        {
            DataTable dt = new DataTable();
            using (var wb = new XLWorkbook(filePath))
            {
                var sheet = wb.Worksheet(1);
                var firstRow = sheet.FirstRowUsed();

                // Tạo cột cho DataTable từ dòng đầu tiên của Excel
                foreach (var cell in firstRow.Cells())
                {
                    dt.Columns.Add(cell.Value.ToString());
                }

                // Đọc dữ liệu các dòng còn lại
                foreach (var row in sheet.RowsUsed().Skip(1))
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dr[i] = row.Cell(i + 1).Value.ToString();
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        // Hàm tạo file mẫu Excel dựa trên danh sách tiêu đề cột truyền vào
        public static void CreateTemplate(string[] headers, string defaultFileName)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = defaultFileName
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var wb = new ClosedXML.Excel.XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("Template");

                            // 1. Tạo dòng tiêu đề
                            for (int i = 0; i < headers.Length; i++)
                            {
                                var cell = ws.Cell(1, i + 1);
                                cell.Value = headers[i];

                                // Trang trí một chút cho "xịn"
                                cell.Style.Font.Bold = true;
                                cell.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightGray;
                                cell.Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;
                            }

                            // 2. Thêm một dòng ví dụ để người dùng bắt chước (Tùy chọn)
                            // ws.Cell(2, 1).Value = "Ví dụ: NV01";

                            ws.Columns().AdjustToContents(); // Tự rộng cột
                            wb.SaveAs(sfd.FileName);

                            MessageBox.Show("Đã tải file mẫu thành công! Bạn hãy điền dữ liệu từ dòng số 2 nhé.",
                                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tạo file mẫu: " + ex.Message);
                    }
                }
            }
        }
    }
}