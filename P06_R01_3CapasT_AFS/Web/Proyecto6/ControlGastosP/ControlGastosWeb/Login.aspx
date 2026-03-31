<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ControlGastosWeb.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>

    <style>
        body {
            background: linear-gradient(135deg, #1e1e1e, #3a0000);
            font-family: 'Segoe UI';
        }

        .login-container {
            width: 350px;
            margin: 100px auto;
            padding: 30px;
            background-color: #2d2d2d;
            border-radius: 10px;
            box-shadow: 0px 0px 15px rgba(255,0,0,0.5);
            text-align: center;

            animation: fadeIn 1s ease-in-out;
        }

        @keyframes fadeIn {
            from { opacity: 0; transform: translateY(-20px); }
            to { opacity: 1; transform: translateY(0); }
        }

        h2 {
            color: white;
            margin-bottom: 20px;
        }

        .input {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: none;
            border-radius: 5px;
            background-color: #444;
            color: white;
        }

        .btn {
            width: 100%;
            padding: 10px;
            background-color: #c00000;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #ff5050;
        }

        .error {
            color: #ff8080;
            margin-top: 10px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>LOGIN</h2>

            <asp:TextBox ID="txtEmail" runat="server" CssClass="input" Placeholder="Email"></asp:TextBox>

            <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password" Placeholder="Password"></asp:TextBox>

            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn" OnClick="btnLogin_Click" />

            <asp:Label ID="lblMensaje" runat="server" CssClass="error"></asp:Label>
        </div>
    </form>
</body>
</html>
