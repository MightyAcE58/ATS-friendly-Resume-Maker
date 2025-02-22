﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ATS_friendly_Resume_Maker.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ResumePro - Resgister</title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css">
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        html, body {
            height: 100%;
        }

        .bg-body-tertiary {
            background-color: #343541 !important;
        }

        .form-register {
            max-width: 330px;
            padding: 1rem;
        }

            .form-register .form-floating:focus-within {
                z-index: 2;
            }
    </style>
</head>
<body class="d-flex align-items-center py-4 bg-body-tertiary">
    <form id="formRegister" runat="server" class="form-register w-100 m-auto">
        <div class="text-center">
            <img class="mb-4" src="/assets/img/logo-nobg.png" alt="" width="300" height="67">
            <h1 class="h3 mb-3 fw-normal text-white">Please Register</h1>
        </div>

        <!-- First Name -->
        <div class="form-floating">
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
            <label for="txtFirstName">First Name</label>
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name is required" ForeColor="Red" Display="Dynamic" />
        </div>

        <!-- Last Name -->
        <div class="form-floating mt-2">
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
            <label for="txtLastName">Last Name</label>
            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name is required" ForeColor="Red" Display="Dynamic" />
        </div>

        <!-- Email -->
        <div class="form-floating mt-2">
            <asp:TextBox ID="txtRegEmail" runat="server" CssClass="form-control" placeholder="name@example.com"></asp:TextBox>
            <label for="txtRegEmail">Email address</label>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtRegEmail" ErrorMessage="Email is required" ForeColor="Red" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtRegEmail"
                ErrorMessage="Invalid email format"
                ValidationExpression="^[\w\.-]+@[\w\.-]+\.\w+$"
                ForeColor="Red" Display="Dynamic" />
        </div>

        <!-- Password -->
        <div class="form-floating mt-2">
            <asp:TextBox ID="txtRegPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
            <label for="txtRegPassword">Password</label>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtRegPassword"
                ErrorMessage="Password is required" ForeColor="Red" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtRegPassword"
                ErrorMessage="Password must be at least 6 characters" ForeColor="Red" Display="Dynamic"
                ValidationExpression=".{6,}" />
        </div>


        <!-- Retype Password -->
        <div class="form-floating mt-2">
            <asp:TextBox ID="txtRetypePassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Retype Password"></asp:TextBox>
            <label for="txtRetypePassword">Retype Password</label>
            <asp:RequiredFieldValidator ID="rfvRetypePassword" runat="server" ControlToValidate="txtRetypePassword" ErrorMessage="Please retype your password" ForeColor="Red" Display="Dynamic" />
            <asp:CompareValidator ID="cvPasswords" runat="server" ControlToValidate="txtRetypePassword" ControlToCompare="txtRegPassword" ErrorMessage="Passwords do not match" ForeColor="Red" Display="Dynamic" />
        </div>

        <div class="form-floating">
            <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <!-- Register Button -->
        <div class="form-floating mt-2">
            <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-success w-100 py-2" Text="Register" OnClick="btnRegister_Click" />
        </div>

        <div class="text-center mt-4">
            <p class="fw-medium text-secondary">
                Already have an account?
            <a href="Login.aspx" class="fw-bold text-primary text-decoration-none">Sign in</a>
            </p>
        </div>

    </form>

</body>
</html>