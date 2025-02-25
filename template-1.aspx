<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="template-1.aspx.cs" Inherits="ATS_friendly_Resume_Maker.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Favicons -->
    <link href="assets/img/favicon.png" rel="icon">
    <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">
    <title>ResumePro</title>
    <style>
        body {
/*            margin: 2rem;
            margin-left: 3rem;
            margin-right: 3rem;*/
        }
    </style>
</head>
<body lang="en-IN" dir="ltr">
    <form id="form1" runat="server">
        <p align="left" style="margin-bottom: 0cm">
            &shy;
       
        </p>
        <table width="100%" cellpadding="7" cellspacing="0" style="page-break-before: auto;">
            <col width="256*" />
            <tr>
                <td width="100%" valign="top" style="border-top: none; border-bottom: 1.50pt solid #39a5b7; border-left: none; border-right: none; padding-top: 0cm; padding-bottom: 0.05cm; padding-left: 0cm; padding-right: 0cm">
                    <p align="left" style="orphans: 0; widows: 0">
                        <font color="#2a7b88"><font face="Cambria, serif"><font size="6" style="font-size: 28pt">
                            <asp:Literal ID="litName" runat="server" />
                        </font></font></font>
                    </p>
                </td>
            </tr>
        </table>

        <p align="left" style="margin-top: 0.21cm; margin-bottom: 0.42cm">
            <font color="#000000"><font face="Cambria, serif"><font size="3" style="font-size: 12pt">
                <asp:Literal ID="litContactInfo" runat="server" />
            </font></font></font>
        </p>

        <h1 align="left"><font color="#2a7b88"><font face="Cambria, serif"><font size="4" style="font-size: 14pt">About Me</font></font></font></h1>
        <p align="left" style="margin-bottom: 0cm">
            <font color="#000000"><font face="Cambria, serif"><font size="3" style="font-size: 12pt">
                <asp:Literal ID="litProfile" runat="server" />
            </font></font></font>
        </p>

        <h1 align="left"><font color="#2a7b88"><font face="Cambria, serif"><font size="4" style="font-size: 14pt"><b>Experience</b></font></font></font></h1>

        <div class="Experience">
            <asp:Repeater ID="rptExperience" runat="server">
                <ItemTemplate>
                    <h2 class="western" align="left" style="font-size: medium">
                        <%# Eval("JobTitle") %> | <%# Eval("CompanyName") %> | <%# GetFormattedDuration(Eval("StartMonth"), Eval("StartYear"), Eval("EndMonth"), Eval("EndYear")) %></h2>
                    <ul>
                        <li>
                            <p align="left" style="line-height: 120%; margin-bottom: 0.42cm">
                                <font color="#000000"><font face="Cambria, serif"><font size="3" style="font-size: 12pt">
                                    <%# Eval("Description") %>
                                </font></font></font>
                            </p>
                        </li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <h1 align="left"><font color="#2a7b88"><font face="Cambria, serif"><font size="4" style="font-size: 14pt"><b>Education</b></font></font></font></h1>

        <div class="Education">
            <asp:Repeater ID="rptEducation" runat="server">
                <ItemTemplate>
                    <h2 class="western" align="left"><font color="#000000"><font face="Cambria, serif"><font size="3" style="font-size: 12pt">
                        <%# Eval("Degree") %> | <%# GetFormattedEducationDuration(Eval("StartYear"), Eval("EndYear")) %> | <%# Eval("SchoolName") %>, <%# Eval("City") %>
                    </font></font></font></h2>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <h1 align="left"><font color="#2a7b88"><font face="Cambria, serif"><font size="4" style="font-size: 14pt"><b>Skills & Abilities</b></font></font></font></h1>

        <div class="Skill">
            <table width="100%" cellpadding="6" cellspacing="5">
                <!--<col width="137*" />
                <col width="119*" />-->
                <tr valign="top">
                    <td width="100%" style="border: none; padding: 0cm">
                        <div style="display: flex; flex-wrap: wrap; gap: 10px;">
                            <asp:Repeater ID="rptSkills" runat="server">
                                <ItemTemplate>
                                    <b>
                                        <span style="font-family: Cambria, serif; font-size: 12pt; color: #000000; list-style: disc">
                                            <%# Eval("Skill") %>
                                        </span>
                                    </b>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.10.1/html2pdf.bundle.min.js"></script>

    <script>
        const download = function () {
            setTimeout(() => {
                html2pdf()
                    .set({
                        filename: 'Resume.pdf',
                        margin: [5, 10, 10, 10],
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

    </form>

</body>
</html>
