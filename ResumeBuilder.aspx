<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeBuilder.aspx.cs" Inherits="ATS_friendly_Resume_Maker.ResumeBuilder" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ATS Friendly Resume Maker</title>
    <link rel="stylesheet" type="text/css" href="ResumeBuilder.css?v=2" />
</head>
<body>
    <div class="container">
        <h1>Build Your ATS Friendly Resume</h1>
        <form id="formResume" runat="server">
            <div class="form-group">
                <label for="txtFullName">Full Name:</label>
                <input type="text" id="txtFullName" runat="server" class="form-control" placeholder="Enter your full name" />
            </div>
            <div class="form-group">
                <label for="fileProfileImage">Upload Profile Image:</label>
                <asp:FileUpload ID="fileProfileImage" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtEmail">Email Address:</label>
                <input type="email" id="txtEmail" runat="server" class="form-control" placeholder="Enter your email" />
            </div>

            <div class="form-group">
                <label for="txtPhone">Phone Number:</label>
                <input type="tel" id="txtPhone" runat="server" class="form-control" placeholder="Enter your phone number" />
            </div>

            <div class="form-group">
                <label for="txtAddress">Address:</label>
                <textarea id="txtAddress" runat="server" class="form-control" placeholder="Enter your address"></textarea>
            </div>

            <div class="form-group">
                <label for="txtSkills">Skills:</label>
                <textarea id="txtSkills" runat="server" class="form-control" placeholder="Enter your skills, separated by commas"></textarea>
            </div>

            <div class="form-group">
                <label for="txtExperience">Experience:</label>
                <textarea id="txtExperience" runat="server" class="form-control" placeholder="Describe your work experience"></textarea>
            </div>

            <div class="form-group">
                <label for="txtEducation">Education:</label>
                <textarea id="txtEducation" runat="server" class="form-control" placeholder="Enter your educational qualifications"></textarea>
            </div>
                <asp:Button ID="SubmitButton" runat="server" Text="Create Resume" OnClick="SubmitButton_Click" CssClass="btnSub"/>
        </form>
    </div>
</body>
</html>
