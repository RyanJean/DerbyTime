<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RaceStats.aspx.cs" Inherits="DerbyTimeWeb.RaceStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
        function getData() { $.ajax({ url: 'RaceQuery.aspx', type: 'GET', success: handleData, cache: false }) }
        function handleData(data) { if (JSON.parse(data).updates == 'True') window.location = 'RaceStats.aspx'; }
        setInterval(getData, 1000);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style>
        table.leaderboard { width: 300px; border: 1px solid black; }
        .leaderboard td {border-bottom: 1px solid black; border-top: 1px solid black; padding: 2px 10px;}
        .leaderboard td:nth-child(1) {width:50px;text-align:center;}
        .leaderboard td:nth-child(2) {width:150px;text-align:left;}
        .leaderboard td:nth-child(3) {width: 100px;text-align:center;}

        table.winnerboard { width: 350px; border: 1px solid black; }
        .winnerboard td {border-bottom: 1px solid black; border-top: 1px solid black; padding: 2px 10px;}
        .winnerboard td:nth-child(1) {width:50px;text-align:center;}
        .winnerboard td:nth-child(2) {width:150px;text-align:left;}
        .winnerboard td:nth-child(3) {width:100px;text-align:center;}
        .winnerboard td:nth-child(4) {width:50px;text-align:center;}

        table.heats { width: <%=DerbyTimeWeb.MySession.Current.num_Lanes*150 %>px; border: 1px solid black; }
        .heats td {border: 1px solid black; padding: 2px 10px; width:150px; text-align:left;}
    </style>
    <asp:PlaceHolder ID="completeZone" runat="server" Visible="false">
        <div style="width: 700px; margin: 10px auto; text-align: center;">
            <h2>Race Complete!</h2>
            <div style="float: left"><asp:Image ID="trophy" runat="server" ImageUrl="~/Images/Awards/Trophy.png" Width="300" /></div>
            <div style="float: right"><asp:PlaceHolder ID="finalScoreZone" runat="server"></asp:PlaceHolder></div>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="notCompleteZone" runat="server">
    <div style="width: <%=(DerbyTimeWeb.MySession.Current.num_Lanes*150)+400 %>px; margin: 10px auto; text-align: center;">
        <div style="float: left"><asp:PlaceHolder ID="leftZone" runat="server"></asp:PlaceHolder></div>
        <div style="float: right"><asp:PlaceHolder ID="rightZone" runat="server"></asp:PlaceHolder></div>
    </div>
    </asp:PlaceHolder>
</asp:Content>
