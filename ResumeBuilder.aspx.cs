using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.IO;
using System.Text;
using System.Web.UI;

namespace ATS_friendly_Resume_Maker
{
    public partial class ResumeBuilder : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initial setup (if any)
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtFullName.Value))
                {
                    ShowError("Full Name is required");
                    return;
                }

                // Declare imageFilePath to be used in both blocks
                string imageFilePath = null;

                // Validate and save image file
                if (fileProfileImage.HasFile)
                {
                    string filePath = Server.MapPath("~/UploadedImages/" + fileProfileImage.FileName);
                    fileProfileImage.SaveAs(filePath);

                    imageFilePath = "/UploadedImages/" + fileProfileImage.FileName;
                }
                else
                {
                    ShowError("Profile image is required.");
                    return;
                }

                // Capture form data
                string fullName = SanitizeFileName(txtFullName.Value);
                string email = txtEmail.Value;
                string phone = txtPhone.Value;
                string address = txtAddress.Value;
                string skills = txtSkills.Value;
                string experience = txtExperience.Value;
                string education = txtEducation.Value;

                // Generate PDF with the image and form data
                GenerateResumePdf(fullName, email, phone, address, skills, experience, education, imageFilePath);
            }
            catch (Exception ex)
            {
                ShowError($"Error generating resume: {ex.Message}");
            }
        }

        private void GenerateResumePdf(string fullName, string email, string phone, string address,
                                       string skills, string experience, string education, string imageFilePath)
        {
            try
            {
                // Define file path where the PDF will be saved
                string folderPath = Server.MapPath("~/Resumes/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = fullName.Replace(" ", "_") + "_Resume.pdf";
                string filePath = Path.Combine(folderPath, fileName);

                // Create a new PDF document with professional styling
                iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 40, 40, 50, 50);
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Set Fonts
                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, BaseColor.BLACK);
                iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.DARK_GRAY);
                iTextSharp.text.Font contentFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
                iTextSharp.text.Font bulletFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                // Add Profile Image
                if (!string.IsNullOrEmpty(imageFilePath))
                {
                    Image img = Image.GetInstance(Server.MapPath(imageFilePath));
                    img.ScaleToFit(120f, 120f);  // Resize the image
                    img.Alignment = Element.ALIGN_CENTER;
                    document.Add(img);
                }

                // Add Resume Header
                Paragraph title = new Paragraph(fullName.ToUpper(), titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph(email + " | " + phone + " | " + address, contentFont) { Alignment = Element.ALIGN_CENTER });
                document.Add(new Paragraph("\n\n"));

                // Add Section Header Method
                void AddSectionHeader(string header)
                {
                    document.Add(new Paragraph(header, headerFont));
                    document.Add(new LineSeparator(1f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -2));
                    document.Add(new Paragraph("\n"));
                }

                // Add Section: Skills
                AddSectionHeader("Skills");
                foreach (var skill in skills.Split(','))
                {
                    document.Add(new Paragraph("• " + skill.Trim(), bulletFont));
                }
                document.Add(new Paragraph("\n"));

                // Add Section: Experience
                AddSectionHeader("Experience");
                document.Add(new Paragraph(experience, contentFont));
                document.Add(new Paragraph("\n"));

                // Add Section: Education
                AddSectionHeader("Education");
                document.Add(new Paragraph(education, contentFont));
                document.Add(new Paragraph("\n"));

                document.Close();

                // Generate URL to open the PDF in a new tab
                string pdfUrl = ResolveUrl("~/Resumes/" + fileName);
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + pdfUrl + "', '_blank');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('Error: " + ex.Message + "');", true);
            }
        }

        private string SanitizeFileName(string fileName)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            StringBuilder cleanName = new StringBuilder(fileName);
            foreach (char c in invalidChars)
            {
                cleanName.Replace(c, '_');
            }
            return cleanName.ToString().Trim();
        }

        private void ShowError(string message)
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('{message}');", true);
        }
    }
}


//using System;
//using System.IO;
//using System.Text;
//using System.Web.UI;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.draw;

//namespace ATS_friendly_Resume_Maker
//{
//    public partial class ResumeBuilder : Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {

//            }
//        }

//        protected void SubmitButton_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                // Validate required fields
//                if (string.IsNullOrWhiteSpace(txtFullName.Value))
//                {
//                    ShowError("Full Name is required");
//                    return;
//                }
//                // Capture form data
//                string fullName = SanitizeFileName(txtFullName.Value);
//                string email = txtEmail.Value;
//                string phone = txtPhone.Value;
//                string address = txtAddress.Value;
//                string skills = txtSkills.Value;
//                string experience = txtExperience.Value;
//                string education = txtEducation.Value;

//                GenerateResumePdf(fullName, email, phone, address, skills, experience, education);
//            }
//            catch (Exception ex)
//            {
//                ShowError($"Error generating resume: {ex.Message}");
//            }
//        }

//        private void GenerateResumePdf(string fullName, string email, string phone, string address,
//                                   string skills, string experience, string education)
//        {
//            try
//            {
//                // Define file path where the PDF will be saved
//                string folderPath = Server.MapPath("~/Resumes/");
//                if (!Directory.Exists(folderPath))
//                {
//                    Directory.CreateDirectory(folderPath);
//                }

//                string fileName = fullName.Replace(" ", "_") + "_Resume.pdf";
//                string filePath = Path.Combine(folderPath, fileName);

//                // Create a new PDF document with better styling
//                iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 40, 40, 50, 50);
//                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
//                document.Open();

//                // Set Fonts
//                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, BaseColor.BLACK);
//                iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.DARK_GRAY);
//                iTextSharp.text.Font contentFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
//                iTextSharp.text.Font bulletFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

//                // Add Resume Header
//                Paragraph title = new Paragraph(fullName.ToUpper(), titleFont);
//                title.Alignment = Element.ALIGN_CENTER;
//                document.Add(title);
//                document.Add(new Paragraph(email + " | " + phone + " | " + address, contentFont) { Alignment = Element.ALIGN_CENTER });
//                document.Add(new Paragraph("\n\n"));

//                // Add Section Header Method
//                void AddSectionHeader(string header)
//                {
//                    document.Add(new Paragraph(header, headerFont));
//                    document.Add(new LineSeparator(1f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -2));
//                    document.Add(new Paragraph("\n"));
//                }

//                // Add Section: Skills
//                AddSectionHeader("Skills");
//                foreach (var skill in skills.Split(','))
//                {
//                    document.Add(new Paragraph("• " + skill.Trim(), bulletFont));
//                }
//                document.Add(new Paragraph("\n"));

//                // Add Section: Experience
//                AddSectionHeader("Experience");
//                document.Add(new Paragraph(experience, contentFont));
//                document.Add(new Paragraph("\n"));

//                // Add Section: Education
//                AddSectionHeader("Education");
//                document.Add(new Paragraph(education, contentFont));
//                document.Add(new Paragraph("\n"));

//                document.Close();

//                // Generate URL to open the PDF in a new tab
//                string pdfUrl = ResolveUrl("~/Resumes/" + fileName);
//                ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + pdfUrl + "', '_blank');", true);
//            }
//            catch (Exception ex)
//            {
//                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('Error: " + ex.Message + "');", true);
//            }
//        }
//        private string SanitizeFileName(string fileName)
//        {
//            char[] invalidChars = Path.GetInvalidFileNameChars();
//            StringBuilder cleanName = new StringBuilder(fileName);
//            foreach (char c in invalidChars)
//            {
//                cleanName.Replace(c, '_');
//            }
//            return cleanName.ToString().Trim();
//        }

//        private void ShowError(string message)
//        {
//            ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('{message}');", true);
//        }
//    }
//}