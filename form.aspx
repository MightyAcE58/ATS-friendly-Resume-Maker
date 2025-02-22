<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" EnableEventValidation="false" CodeBehind="form.aspx.cs" Inherits="ATS_friendly_Resume_Maker.Resume_Maker" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ResumePro - Create Your Own Resume</title>
    <!-- Favicons -->
    <link href="assets/img/favicon.png" rel="icon">
    <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">

    <!-- Fonts -->
    <link href="https://fonts.googleapis.com/css2?family=Raleway:ital,wght@0,500;1,500&display=swap" rel="stylesheet">
    <style>
        /* Global Box Sizing */
        *, *::before, *::after {
            box-sizing: border-box;
        }

        /* Global Styles */
        body {
/*            background-color: #9A60E6;
background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='100%25' height='100%25' viewBox='0 0 1600 800'%3E%3Cg %3E%3Cpath fill='%237628dd' d='M486 705.8c-109.3-21.8-223.4-32.2-335.3-19.4C99.5 692.1 49 703 0 719.8V800h843.8c-115.9-33.2-230.8-68.1-347.6-92.2C492.8 707.1 489.4 706.5 486 705.8z'/%3E%3Cpath fill='%23581ba9' d='M1600 0H0v719.8c49-16.8 99.5-27.8 150.7-33.5c111.9-12.7 226-2.4 335.3 19.4c3.4 0.7 6.8 1.4 10.2 2c116.8 24 231.7 59 347.6 92.2H1600V0z'/%3E%3Cpath fill='%233b1271' d='M478.4 581c3.2 0.8 6.4 1.7 9.5 2.5c196.2 52.5 388.7 133.5 593.5 176.6c174.2 36.6 349.5 29.2 518.6-10.2V0H0v574.9c52.3-17.6 106.5-27.7 161.1-30.9C268.4 537.4 375.7 554.2 478.4 581z'/%3E%3Cpath fill='%231d0938' d='M0 0v429.4c55.6-18.4 113.5-27.3 171.4-27.7c102.8-0.8 203.2 22.7 299.3 54.5c3 1 5.9 2 8.9 3c183.6 62 365.7 146.1 562.4 192.1c186.7 43.7 376.3 34.4 557.9-12.6V0H0z'/%3E%3Cpath fill='%23000000' d='M181.8 259.4c98.2 6 191.9 35.2 281.3 72.1c2.8 1.1 5.5 2.3 8.3 3.4c171 71.6 342.7 158.5 531.3 207.7c198.8 51.8 403.4 40.8 597.3-14.8V0H0v283.2C59 263.6 120.6 255.7 181.8 259.4z'/%3E%3Cpath fill='%231d0938' d='M1600 0H0v136.3c62.3-20.9 127.7-27.5 192.2-19.2c93.6 12.1 180.5 47.7 263.3 89.6c2.6 1.3 5.1 2.6 7.7 3.9c158.4 81.1 319.7 170.9 500.3 223.2c210.5 61 430.8 49 636.6-16.6V0z'/%3E%3Cpath fill='%233b1271' d='M454.9 86.3C600.7 177 751.6 269.3 924.1 325c208.6 67.4 431.3 60.8 637.9-5.3c12.8-4.1 25.4-8.4 38.1-12.9V0H288.1c56 21.3 108.7 50.6 159.7 82C450.2 83.4 452.5 84.9 454.9 86.3z'/%3E%3Cpath fill='%23581ba9' d='M1600 0H498c118.1 85.8 243.5 164.5 386.8 216.2c191.8 69.2 400 74.7 595 21.1c40.8-11.2 81.1-25.2 120.3-41.7V0z'/%3E%3Cpath fill='%237628dd' d='M1397.5 154.8c47.2-10.6 93.6-25.3 138.6-43.8c21.7-8.9 43-18.8 63.9-29.5V0H643.4c62.9 41.7 129.7 78.2 202.1 107.4C1020.4 178.1 1214.2 196.1 1397.5 154.8z'/%3E%3Cpath fill='%239A60E6' d='M1315.3 72.4c75.3-12.6 148.9-37.1 216.8-72.4h-723C966.8 71 1144.7 101 1315.3 72.4z'/%3E%3C/g%3E%3C/svg%3E");
background-attachment: fixed;
background-size: cover;*/
          background-color: #000000;
            background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='100%25' height='100%25' viewBox='0 0 800 400'%3E%3Cdefs%3E%3CradialGradient id='a' cx='396' cy='281' r='514' gradientUnits='userSpaceOnUse'%3E%3Cstop offset='0' stop-color='%239A60E6'/%3E%3Cstop offset='1' stop-color='%23000000'/%3E%3C/radialGradient%3E%3ClinearGradient id='b' gradientUnits='userSpaceOnUse' x1='400' y1='148' x2='400' y2='333'%3E%3Cstop offset='0' stop-color='%23D1D0FF' stop-opacity='0'/%3E%3Cstop offset='1' stop-color='%23D1D0FF' stop-opacity='0.5'/%3E%3C/linearGradient%3E%3C/defs%3E%3Crect fill='url(%23a)' width='800' height='400'/%3E%3Cg fill-opacity='0.4'%3E%3Ccircle fill='url(%23b)' cx='267.5' cy='61' r='300'/%3E%3Ccircle fill='url(%23b)' cx='532.5' cy='61' r='300'/%3E%3Ccircle fill='url(%23b)' cx='400' cy='30' r='300'/%3E%3C/g%3E%3C/svg%3E");
            background-attachment: fixed;
            background-size: cover;
            background-position:center;
            color: #e0e0e0;
            font-family: "Raleway", sans-serif;
            margin: 0;
            padding: 20px;
        }

        /* Form Container */
        .form-container {
            margin: 20px auto;
            padding: 30px 40px;
            max-width: 850px;
            border-radius: 25px;
            background: #1f1f1f;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.5);
            border: 1px solid #444;
            transition: box-shadow 0.3s ease;
        }

            .form-container:hover {
                box-shadow: 0 6px 30px rgba(0, 0, 0, 0.7);
            }

        /* Labels */
        label {
            font-weight: 600;
            font-size: 14px;
            color: #fff;
            margin-bottom: 8px;
            display: block;
            transition: color 0.3s ease;
        }

        /* Inputs, Selects, Textareas */
        .form-container input,
        .form-container select,
        .form-container textarea {
            width: 100%; /* Changed from 93% to 100% */
            padding: 12px 15px;
            margin: 10px 0 20px;
            border: 1px solid #555;
            border-radius: 6px;
            font-size: 16px;
            background: #2b2b2b;
            color: #e0e0e0;
            transition: border-color 0.3s ease, box-shadow 0.3s ease;
        }

            .form-container input:focus,
            .form-container select:focus,
            .form-container textarea:focus {
                border-color: #9a60e6;
                box-shadow: 0 0 8px rgba(154, 96, 230, 0.5);
                outline: none;
            }

        .no-resize {
            resize: none;
        }

        /* Buttons in Form Container */
        .form-container button,
        .form-container .btn {
            padding: 14px 20px;
            background-color: #9a60e6;
            color: #fff;
            border: none;
            border-radius: 40px;
            font-size: 16px;
            cursor: pointer;
            width: 100%;
            transition: background-color 0.3s ease, transform 0.2s ease;
            margin-top: 10px;
        }

            .form-container button:hover,
            .form-container .btn:hover {
                background-color: #814dc2;
            }

        /* Entry Containers (employment, education, link, skill) */
        .employment-entry,
        .education-entry,
        .link-entry,
        .skill-entry {
            position: relative; /* For absolute positioning of remove button */
            margin-bottom: 20px;
            padding: 20px;
            border-radius: 6px;
            background: #252525;
            color: #fff;
            border: 1px solid #333;
            transition: border-color 0.3s ease, box-shadow 0.3s ease;
        }

            .employment-entry:hover,
            .education-entry:hover,
            .link-entry:hover,
            .skill-entry:hover {
                border-color: #9a60e6;
                box-shadow: 0 4px 12px rgba(154, 96, 230, 0.3);
            }

        /* Icon-Only Remove Button (Using Provided SVG Icon) */
        .btn-remove {
            position: absolute !important;
            top: 12px !important;
            right: 12px !important;
            width: 24px !important;
            height: 24px !important;
            margin: 0 !important;
            padding: 0 !important;
            border: none !important;
            outline: none !important;
            background-color: transparent !important;
            -webkit-appearance: none !important;
            -moz-appearance: none !important;
            appearance: none !important;
            /* Inline SVG as background */
            background: url("data:image/svg+xml,%3Csvg%20xmlns=%22http://www.w3.org/2000/svg%22%20height=%2224px%22%20viewBox=%220%20-960%20960%20960%22%20width=%2224px%22%20fill=%22%239a60e6%22%3E%3Cpath%20d=%22M280-120q-33%200-56.5-23.5T200-200v-520h-40v-80h200v-40h240v40h200v80h-40v520q0%2033-23.5%2056.5T680-120H280Zm400-600H280v520h400v-520ZM360-280h80v-360h-80v360Zm160%200h80v-360h-80v360ZM280-720v520-520Z%22/%3E%3C/svg%3E") no-repeat center center !important;
            background-size: contain !important;
            /* Hide button text */
            color: transparent !important;
            text-indent: -9999px !important;
            white-space: nowrap !important;
            overflow: hidden !important;
            cursor: pointer !important;
            transition: transform 0.3s ease !important;
        }

            .btn-remove:hover {
                transform: scale(1.1);
            }

        /* Date & Years Containers */
        .date-container,
        .years-container {
            display: flex;
            gap: 10px;
            color: #b3b3b3;
        }

        /* Action Buttons */
        .action-buttons {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            margin-bottom: 20px;
        }

            .action-buttons .btn {
                flex: 1;
                min-width: 200px;
            }

        /* Decorative Element */
        .decor {
            display: flex;
            justify-content: space-between;
            width: 100%;
            white-space: nowrap;
            color: #ae74fa;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>Resume Pro Maker</h1>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <div class="mb-4">
                        <h3>Personal Details</h3>
                        <label for="txtFullName" class="form-label">Full Name:</label>
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter your full name"></asp:TextBox>

                        <label for="txtEmail" class="form-label mt-2">Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your email"></asp:TextBox>

                        <label for="txtPhone" class="form-label mt-2">Phone:</label>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Enter your phone number"></asp:TextBox>

                        <label for="txtCountry" class="form-label mt-2">Country:</label>
                        <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" placeholder="Country"></asp:TextBox>

                        <label for="txtSummary" class="form-label mt-2">Summary:</label>
                        <asp:TextBox ID="txtSummary" runat="server" CssClass="form-control no-resize" TextMode="MultiLine" Rows="5"
                            placeholder="Briefly describe yourself"></asp:TextBox>
                    </div>

                    <div class="mb-4">
                        <h3>Skills</h3>
                        <label for="txtskill" class="form-label">Enter Skills:</label>
                        <asp:TextBox ID="txtskill" runat="server" CssClass="form-control" placeholder="Enter Skills (e.g Html, css, javascript)"></asp:TextBox>

                    </div>

                    <div class="action-buttons">
                        <asp:Button ID="btnAddEmployment" runat="server" Text="Add Experiences" OnClick="btnAddEmployment_Click" CssClass="btn" />
                        <asp:Button ID="btnAddEducation" runat="server" Text="Add Education" OnClick="btnAddEducation_Click" CssClass="btn" />
                        <asp:Button ID="btnAddWebsite" runat="server" Text="Add Website" OnClick="btnAddWebsite_Click" CssClass="btn" />

                    </div>


                    <asp:Panel ID="pnlForms" runat="server">
                        <!-- Employment Section -->
                        <asp:Repeater ID="rptEmployment" runat="server" OnItemCommand="rptEmployment_ItemCommand" OnItemDataBound="rptEmployment_ItemDataBound">
                            <ItemTemplate>
                                <div class="employment-entry">
                                    <div class="decor">
                                        <h3>Employment Information</h3>

                                        <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn-remove"
                                            CommandName="Remove" CommandArgument="<%# Container.ItemIndex %>" />
                                    </div>

                                    <label for="txtCompany">Company Name:</label>
                                    <asp:TextBox ID="txtCompany" runat="server" placeholder="Enter company name"></asp:TextBox>

                                    <label for="txtTitle">Job Title:</label>
                                    <asp:TextBox ID="txtTitle" runat="server" placeholder="Enter job title"></asp:TextBox>

                                    <label for="ddlEmployment">Employment Type:</label>
                                    <asp:DropDownList ID="ddlEmployment" runat="server">
                                        <asp:ListItem Text="Full-time" Value="Full-time" />
                                        <asp:ListItem Text="Part-time" Value="Part-time" />
                                        <asp:ListItem Text="Contract" Value="Contract" />
                                        <asp:ListItem Text="Freelance" Value="Freelance" />
                                        <asp:ListItem Text="Internship" Value="Internship" />
                                    </asp:DropDownList>

                                    <label>Start Date:</label>
                                    <div class="date-container">
                                        <asp:DropDownList ID="ddlStartMonth" runat="server">
                                            <asp:ListItem Text="January" Value="1" />
                                            <asp:ListItem Text="February" Value="2" />
                                            <asp:ListItem Text="March" Value="3" />
                                            <asp:ListItem Text="April" Value="4" />
                                            <asp:ListItem Text="May" Value="5" />
                                            <asp:ListItem Text="June" Value="6" />
                                            <asp:ListItem Text="July" Value="7" />
                                            <asp:ListItem Text="August" Value="8" />
                                            <asp:ListItem Text="September" Value="9" />
                                            <asp:ListItem Text="October" Value="10" />
                                            <asp:ListItem Text="November" Value="11" />
                                            <asp:ListItem Text="December" Value="12" />
                                        </asp:DropDownList>

                                        <asp:DropDownList ID="ddlStartYear" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                    <label>End Date:</label>
                                    <div class="date-container">
                                        <asp:DropDownList ID="ddlEndMonth" runat="server">
                                            <asp:ListItem Text="January" Value="1" />
                                            <asp:ListItem Text="February" Value="2" />
                                            <asp:ListItem Text="March" Value="3" />
                                            <asp:ListItem Text="April" Value="4" />
                                            <asp:ListItem Text="May" Value="5" />
                                            <asp:ListItem Text="June" Value="6" />
                                            <asp:ListItem Text="July" Value="7" />
                                            <asp:ListItem Text="August" Value="8" />
                                            <asp:ListItem Text="September" Value="9" />
                                            <asp:ListItem Text="October" Value="10" />
                                            <asp:ListItem Text="November" Value="11" />
                                            <asp:ListItem Text="December" Value="12" />
                                        </asp:DropDownList>

                                        <asp:DropDownList ID="ddlEndYear" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                    <label for="txtLocation">Location:</label>
                                    <asp:TextBox ID="txtLocation" runat="server" placeholder="City, State, Country"></asp:TextBox>

                                    <label for="txtDescription">Description:</label>
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control no-resize" TextMode="MultiLine" Rows="4"
                                        placeholder="Describe your responsibilities and achievements"></asp:TextBox>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <!-- Education Section -->
                        <asp:Repeater ID="rptEducation" runat="server" OnItemCommand="rptEducation_ItemCommand" OnItemDataBound="rptEducation_ItemDataBound">
                            <ItemTemplate>
                                <div class="education-entry">
                                    <div class="decor">

                                        <h3>Education Information</h3>

                                        <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn-remove"
                                            CommandName="Remove" CommandArgument="<%# Container.ItemIndex %>" />

                                    </div>

                                    <label for="txtSchool">School/College Name:</label>
                                    <asp:TextBox ID="txtSchool" runat="server" placeholder="Enter school name"></asp:TextBox>

                                    <label for="txtDegree">Degree:</label>
                                    <asp:TextBox ID="txtDegree" runat="server" placeholder="Enter degree"></asp:TextBox>

                                    <label>Years Attended:</label>
                                    <div class="years-container">
                                        <asp:DropDownList ID="ddlStartYear" runat="server">
                                        </asp:DropDownList>
                                        <span>to</span>
                                        <asp:DropDownList ID="ddlEndYear" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                    <label for="txtCity">City:</label>
                                    <asp:TextBox ID="txtCity" runat="server" placeholder="City, State, Country"></asp:TextBox>

                                    <label for="txtEduDescription">Description:</label>
                                    <asp:TextBox ID="txtEduDescription" runat="server" CssClass="form-control no-resize" TextMode="MultiLine" Rows="4"
                                        placeholder="Describe your studies, achievements, activities"></asp:TextBox>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <!-- Website/Links Section -->
                        <asp:Repeater ID="rptLinks" runat="server" OnItemCommand="rptLinks_ItemCommand" OnItemDataBound="rptLinks_ItemDataBound">
                            <ItemTemplate>
                                <div class="link-entry">
                                    <div class="decor">

                                        <h3>Website/Link Information</h3>

                                        <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn-remove"
                                            CommandName="Remove" CommandArgument="<%# Container.ItemIndex %>" />
                                    </div>

                                    <label for="txtLabel">Label:</label>
                                    <asp:TextBox ID="txtLabel" runat="server" placeholder="Enter label (e.g., Portfolio, LinkedIn)"></asp:TextBox>

                                    <label for="txtUrl">URL:</label>
                                    <asp:TextBox ID="txtUrl" runat="server" placeholder="Enter URL"></asp:TextBox>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>

                    <asp:Button ID="btnSubmit" runat="server" Text="Generate Resume" OnClick="btnSubmit_Click" CssClass="btn" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
