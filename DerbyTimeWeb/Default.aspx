<%@ Page Title="Derby Time!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DerbyTimeWeb._Default" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <button style="width: 225px; height: 75px; vertical-align: middle; line-height: 30px;" runat="server" id="btn_conf">
        <img src="Images/Menu/Menu_Gear.png" style="float: left; height: 65px;" />
        <span style="float: right; font-weight: bold; font-size: 1.4em;">Race<br />Configuration</span>
    </button>
    <br /><br />
    <button style="width: 225px; height: 75px; vertical-align: middle; line-height: 30px;" runat="server" id="btn_drvr">
        <img src="Images/Menu/Menu_Wheel.png" style="float: right; height: 65px;" />
        <span style="float: left; font-weight: bold; font-size: 1.4em;">Driver<br />Management</span>
    </button>
    <br /><br />
    <button style="width: 225px; height: 75px; vertical-align: middle; line-height: 30px;" runat="server" id="btn_race">
        <img src="Images/Menu/Menu_Flag.png" style="float: left; height: 65px;" />
        <span style="float: right; font-weight: bold; font-size: 1.4em;">Start<br />Race!</span>
    </button>
</asp:Content>
