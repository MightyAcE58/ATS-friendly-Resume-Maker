<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ATS_friendly_Resume_Maker.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ResumePro - Sign in</title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css">
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

    <style>
        html,
        body {
            height: 100%;
        }

        .bg-body-tertiary {
            background-color: #343541 !important;
        }

        .form-signin {
            max-width: 330px;
            padding: 1rem;
        }

            .form-signin .form-floating:focus-within {
                z-index: 2;
            }

            .form-signin input[type="email"] {
                margin-bottom: -1px;
                border-bottom-right-radius: 0;
                border-bottom-left-radius: 0;
            }

            .form-signin input[type="password"] {
                margin-bottom: 10px;
                border-top-left-radius: 0;
                border-top-right-radius: 0;
            }

        .btn-purple {
            background-color: #9a60e6 !important;
            color: white !important;
            border: none;
        }

            .btn-purple:hover {
                background-color: #844ec4 !important;
            }
    </style>
</head>
<body class="d-flex align-items-center py-4 bg-body-tertiary">
    <form id="form1" runat="server" class="form-signin w-100 m-auto">
        <div class="text-center">
            <img class="mb-4" src="/assets/img/logo-nobg.png" alt="" width="300" height="67">
            <h1 class="h3 mb-3 fw-normal text-white">Sign In</h1>
        </div>

        <div class="form-floating">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="name@example.com"></asp:TextBox>
            <label for="txtEmail">Email address</label>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="Email is required." ForeColor="Red" Display="Dynamic" CssClass="small"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Enter a valid email address."
                ForeColor="Red" Display="Dynamic" CssClass="small"></asp:RegularExpressionValidator>
        </div>

        <div class="form-floating mt-2">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
            <label for="txtPassword">Password</label>
        </div>

        <div class="form-floating">
            <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
        </div>

        <asp:Button ID="btnSignIn" runat="server" CssClass="btn btn-purple w-100 py-2" Text="Sign in" OnClick="btnSignIn_Click" />

        <div class="text-center mt-4">
            <p class="fw-medium text-secondary">
                New here? 
            <a href="Register.aspx" class="fw-bold text-primary text-decoration-none">Create an account</a>
            </p>
        </div>


    </form>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
