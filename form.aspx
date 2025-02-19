<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" EnableEventValidation="false" CodeBehind="form.aspx.cs" Inherits="ATS_friendly_Resume_Maker.Resume_Maker" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ATS Resume Maker</title>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="">
    <link href="https://fonts.googleapis.com/css2?family=Raleway:ital,wght@0,500;1,500&display=swap" rel="stylesheet">
    <style>
        body {
            background-color: #343541 !important;
        }
        /* Container Styles */
        .form-container {
            margin: 20px auto;
            padding: 25px;
            max-width: 850px;
            border-radius: 12px;
            background-color: #f9f9f9;
            box-shadow: 0 10px 30px rgba(177, 130, 242, 1);
            border: 1px solid #ddd;
            transition: all 0.3s ease;
            font-family: "Raleway", serif;
        }

            .form-container:hover {
                box-shadow: 0 8px 20px rgba(131, 73, 196, 1);
            }

        label {
            font-weight: 600;
            font-size: 14px;
            color: #333;
            margin-bottom: 8px;
            display: block;
            transition: color 0.3s ease;
            font-family: "Raleway", serif;
        }

        .form-container input,
        .form-container select,
        .form-container textarea {
            width: 93%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ddd;
            border-radius: 8px;
            font-size: 16px;
            background-color: #fff;
            transition: border-color 0.3s ease, box-shadow 0.3s ease;
        }

        .form-container button,
        .form-container .btn {
            padding: 14px;
            background-color: #9a60e6;
            color: #fff;
            border: none;
            border-radius: 8px;
            font-size: 16px;
            cursor: pointer;
            width: 100%;
            transition: background-color 0.3s ease, transform 0.2s ease;
            margin-top: 10px;
        }

            .form-container button:hover,
            .form-container .btn:hover {
                background-color: #8349c4;
            }

        .employment-entry, .education-entry, .link-entry, .skill-entry {
            margin-bottom: 20px;
            padding: 15px;
            border: 1px solid #ddd;
            border-radius: 8px;
            background-color: #fff;
        }

        .btn-remove {
            background-color: #dc3545 !important;
            margin-left: 1rem !important;
        }

            .btn-remove:hover {
                background-color: #c82333 !important;
            }

        .date-container, .years-container {
            display: flex;
            gap: 10px;
        }

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


        .no-resize {
            resize: none !important;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>ATS-Friendly Resume Maker</h1>

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
                                    <h3>Employment Information</h3>

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

                                    <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn-remove"
                                        CommandName="Remove" CommandArgument="<%# Container.ItemIndex %>" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <!-- Education Section -->
                        <asp:Repeater ID="rptEducation" runat="server" OnItemCommand="rptEducation_ItemCommand" OnItemDataBound="rptEducation_ItemDataBound">
                            <ItemTemplate>
                                <div class="education-entry">
                                    <h3>Education Information</h3>

                                    <label for="txtSchool">School Name:</label>
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

                                    <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn-remove"
                                        CommandName="Remove" CommandArgument="<%# Container.ItemIndex %>" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <!-- Website/Links Section -->
                        <asp:Repeater ID="rptLinks" runat="server" OnItemCommand="rptLinks_ItemCommand" OnItemDataBound="rptLinks_ItemDataBound">
                            <ItemTemplate>
                                <div class="link-entry">
                                    <h3>Website/Link Information</h3>

                                    <label for="txtLabel">Label:</label>
                                    <asp:TextBox ID="txtLabel" runat="server" placeholder="Enter label (e.g., Portfolio, LinkedIn)"></asp:TextBox>

                                    <label for="txtUrl">URL:</label>
                                    <asp:TextBox ID="txtUrl" runat="server" placeholder="Enter URL"></asp:TextBox>

                                    <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn-remove"
                                        CommandName="Remove" CommandArgument="<%# Container.ItemIndex %>" />
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
