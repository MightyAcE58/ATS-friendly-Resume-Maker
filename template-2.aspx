<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="template-2.aspx.cs" Inherits="ATS_friendly_Resume_Maker.template_2" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <!-- Favicons -->
    <link href="assets/img/favicon.png" rel="icon">
    <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">
    <title>ResumePro</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            color: #333;
        }

        .container {

        }

        .name {
            letter-spacing: 4.0pt;
            line-height: 1.27cm;
            margin-bottom: 0.64cm;
            font-family: Georgia, serif;
            font-size: 40pt;
            font-weight: bold;
            color: #2c3e50;
        }

        .contact-info {
            text-align: center;
            margin: 1em 0;
            padding: 15px 0;
            border-top: 1px solid #eee;
            border-bottom: 1px solid #eee;
        }

            .contact-info a {
                text-decoration: none;
                color: inherit;
                margin: 0 10px;
            }

        .section-header {
            text-transform: uppercase;
            letter-spacing: 1.0pt;
            font-family: Georgia, serif;
            font-size: 12pt;
            font-weight: bold;
            margin: 30px 0 20px 0;
            color: #2c3e50;
            border-bottom: 2px solid #3498db;
            padding-bottom: 5px;
        }

        .profile-summary {
            line-height: 1.6;
            margin: 20px 0;
            color: #555;
        }

        .experience-item {
            margin-bottom: 25px;
        }

        .job-title {
            font-size: 16px;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .company-name {
            font-style: italic;
            color: #3498db;
        }

        .duration-location {
            color: #666;
            margin: 5px 0;
            font-size: 14px;
        }

        .description {
            margin-top: 10px;
            line-height: 1.5;
        }

        .education-item {
            margin-bottom: 20px;
        }

        .school-name {
            font-weight: bold;
            margin-bottom: 5px;
        }

        .degree {
            font-style: italic;
        }

        .skills-list {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
        }

        .skill-item {
            background-color: #f8f9fa;
            padding: 5px 15px;
            border-radius: 15px;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="name">
                <asp:Literal ID="litName" runat="server" />
            </div>

            <div class="contact-info">
                <asp:Literal ID="litContactInfo" runat="server" />
            </div>

            <div class="profile-summary">
                <asp:Literal ID="litProfile" runat="server" />
            </div>

            <div class="section-header">EXPERIENCE</div>
            <asp:Repeater ID="rptExperience" runat="server">
                <ItemTemplate>
                    <div class="experience-item">
                        <div class="job-title">
                            <%# Eval("JobTitle") %>
                            <span class="company-name">@ <%# Eval("CompanyName") %></span>
                        </div>
                        <div class="duration-location">
                            <%# GetFormattedDuration(
                                Eval("StartMonth"), 
                                Eval("StartYear"),
                                Eval("EndMonth"),
                                Eval("EndYear")) %>
                            <%# !string.IsNullOrEmpty(Eval("Location").ToString()) ? " | " + Eval("Location") : "" %>
                            <%# !string.IsNullOrEmpty(Eval("EmploymentType").ToString()) ? " | " + Eval("EmploymentType") : "" %>
                        </div>
                        <div class="description">
                            <%# Eval("Description") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="section-header">EDUCATION</div>
            <asp:Repeater ID="rptEducation" runat="server">
                <ItemTemplate>
                    <div class="education-item">
                        <div class="school-name">
                            <%# Eval("SchoolName") %>
                            <%# !string.IsNullOrEmpty(Eval("City").ToString()) ? " - " + Eval("City") : "" %>
                        </div>
                        <div class="degree"><%# Eval("Degree") %></div>
                        <div class="duration-location">
                            <%# GetFormattedEducationDuration(Eval("StartYear"), Eval("EndYear")) %>
                        </div>
                        <%# !string.IsNullOrEmpty(Eval("Description").ToString()) ? 
                            "<div class='description'>" + Eval("Description") + "</div>" : "" %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="section-header">SKILLS</div>
            <div class="skills-list">
                <asp:Repeater ID="rptSkills" runat="server">
                    <ItemTemplate>
                        <span class="skill-item"><%# Eval("Skill") %></span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
<script src="https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.10.1/html2pdf.bundle.min.js"></script>

   <script>
       const download = function () {
           setTimeout(() => {
               html2pdf()
                   .set({
                       filename: 'Resume.pdf',
                       margin: [10, 10, 10, 10],
                       image: { type: 'jpeg', quality: 0.98 },
                       html2canvas: { scale: 3, logging: true, letterRendering: true },
                       jsPDF: { unit: 'mm', format: 'a4', orientation: 'portrait' }
                   })
                   .from(document.body)
                   .save();
           }, 1000);
       };

       if (confirm("Do you want to Download this Resume?") == true) {
           download();
       } else {
           alert("Reload this page if you want to download it.");
       }
   </script>
</html>
