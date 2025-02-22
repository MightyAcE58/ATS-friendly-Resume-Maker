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
            background-color: #121212;
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
            border-radius: 10px;
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
            border-radius: 6px;
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
            <h1>Resume Pro</h1>

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
                        <asp:Button ID="btnAddEmployment" runat="server" Text="Add Employment/Experiences" OnClick="btnAddEmployment_Click" CssClass="btn" />
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
