<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="DerbyTimeWeb.Config" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        td:first-child {text-align: right;}
        td:last-child {text-align:left;}
        td:first-child:last-child {text-align:center;}
    </style>
    <table style="width: 300px; margin: 0px auto;">
        <tr>
            <td colspan="2"><span style="font-size: 1.5em;">Configuration...</span></td>
        </tr>
        <tr>
            <td colspan="2" style="color: red;">
                <asp:RequiredFieldValidator ID="val1" runat="server" ControlToValidate="pack_Num" Display="Dynamic" ErrorMessage="Pack Number cannot be blank!<br />" />
                <asp:RegularExpressionValidator ID="val2" runat="server" ControlToValidate="pack_Num" Display="Dynamic" ErrorMessage="Pack Number must be a number!<br />" ValidationExpression="^\d+$" />
                <asp:RequiredFieldValidator ID="val3" runat="server" ControlToValidate="pack_Loc" Display="Dynamic" ErrorMessage="Pack Location cannot be blank!<br />" />
                <asp:RangeValidator ID="val4" runat="server" ControlToValidate="lanes" Display="Dynamic" ErrorMessage="Number of Lanes must be chosen!" MaximumValue="6" MinimumValue="2" />
            </td>
        </tr>
        <tr>
            <td>Pack Number:</td>
            <td><asp:TextBox ID="pack_Num" runat="server" Width="50" MaxLength="6"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Pack Location:</td>
            <td><asp:TextBox ID="pack_Loc" runat="server" Width="150" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td># of Lanes:</td>
            <td><asp:DropDownList ID="lanes" runat="server" Width="100">
                <asp:ListItem Selected="True" Text="--SELECT--" Value="0" />
                <asp:ListItem Text="2" Value="2" />
                <asp:ListItem Text="3" Value="3" />
                <asp:ListItem Text="4" Value="4" />
                <asp:ListItem Text="5" Value="5" />
                <asp:ListItem Text="6" Value="6" />
                </asp:DropDownList></td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td colspan="2"><button runat="server" id="btn">Submit Configuration</button></td>
        </tr>
    </table>
</asp:Content>
