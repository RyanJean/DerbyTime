<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RaceSetup.aspx.cs" Inherits="DerbyTimeWeb.RaceSetup" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Choose Race Schedule Type:<br />
    <asp:DropDownList ID="sched" runat="server" AutoPostBack="true" OnSelectedIndexChanged="sched_SelectedIndexChanged"></asp:DropDownList><br />
    <br />
    Choose Number of Runs:<br />
    <asp:DropDownList ID="runs" runat="server" AutoPostBack="true" OnSelectedIndexChanged="runs_SelectedIndexChanged"></asp:DropDownList><br />
    <br />
    <asp:Button ID="confirm" runat="server" Text="Confirm Schedule" OnClick="confirm_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="cancel" runat="server" Text="Cancel/Return" OnClick="cancel_Click" />
</asp:Content>
