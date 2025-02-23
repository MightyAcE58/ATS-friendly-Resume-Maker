<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PickUrTemplate.aspx.cs" Inherits="ATS_friendly_Resume_Maker.PickUrTemplate" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ResumePro - Choose Your Resume Template</title>
    <meta charset="utf-8" />
    <!-- Favicons -->
    <link href="assets/img/favicon.png" rel="icon">
    <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        /* Global Styles */
        body {
            background: linear-gradient(135deg, #121212, #1e1e2f);
            color: #f0f0f0;
            font-family: 'Poppins', sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        /* Card Styling - Glassmorphism Effect */
        .card {
            background: rgba(255, 255, 255, 0.1);
            backdrop-filter: blur(10px);
            border-radius: 15px;
            padding: 20px;
            width: 600px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }

            .card:hover {
                transform: translateY(-5px);
                box-shadow: 0 6px 20px rgba(0, 0, 0, 0.5);
            }

        /* Iframe Container */
        .iframe-container {
            height: 600px;
            border-radius: 15px;
            overflow: hidden;
            border: 2px solid rgba(255, 255, 255, 0.2);
        }

            .iframe-container iframe {
                width: 100%;
                height: 100%;
                border: none;
                background: white !important;
            }

        /* Modern Button Style */
        .btn-custom {
            background: linear-gradient(90deg, #9a60e6, #854dd8);
            border: none;
            color: white;
            padding: 12px 20px;
            font-size: 16px;
            font-weight: bold;
            border-radius: 8px;
            cursor: pointer;
            transition: all 0.3s ease;
            box-shadow: 0 4px 10px rgba(154, 96, 230, 0.3);
        }

            .btn-custom:hover {
                background: linear-gradient(90deg, #854dd8, #9a60e6);
                transform: scale(1.05);
                box-shadow: 0 6px 15px rgba(154, 96, 230, 0.5);
            }

        /* Floating Animation for Cards */
        @keyframes floating {
            0% {
                transform: translateY(0px);
            }

            50% {
                transform: translateY(-5px);
            }

            100% {
                transform: translateY(0px);
            }
        }

        .floating {
            animation: floating 3s infinite ease-in-out;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container my-4">
            <h1 class="text-center text-white mb-4">Choose Your Resume Template</h1>
            <div class="row g-4 justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="iframe-container">
                            <iframe src="template-1.aspx" sandbox="allow-same-origin"></iframe>
                        </div>
                        <div class="card-body">
                            <asp:Button ID="btnTemplate1" runat="server" CssClass="btn btn-custom w-100" Text="Select Template" CommandArgument="1" OnClick="btnTemplate1_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card">
                        <div class="iframe-container">
                            <iframe src="template-2.aspx" sandbox="allow-same-origin"></iframe>
                        </div>
                        <div class="card-body">
                            <asp:Button ID="btnTemplate2" runat="server" CssClass="btn btn-custom w-100" Text="Select Template" CommandArgument="2" OnClick="btnTemplate2_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
