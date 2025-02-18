<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test-form.aspx.cs" Inherits="ATS_friendly_Resume_Maker.test_form" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dynamic Fields</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Add Info" OnClick="Button1_Click" />
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <div style="margin-bottom:10px;">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Label") %>'></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Value") %>'></asp:TextBox>
                        <asp:Button ID="RemoveButton" runat="server" CommandName="Remove" CommandArgument='<%# Container.ItemIndex %>' Text="Remove" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
