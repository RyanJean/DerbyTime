<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Drivers.aspx.cs" Inherits="DerbyTimeWeb.Drivers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        td {border-top: 1px solid black; border-bottom: 1px solid black; padding: 2px 5px; text-align: center;}
        td:nth-child(2) {text-align: left;}
    </style>
    <script type="text/javascript">
        var x = document.getElementsByTagName("input");
        function toggle(obj, mode) {
            for (var i = 0; i < x.length; i++)
                if (x[i].type == 'image')
                    x[i].style.display = (mode) ? 'none' : '';
            document.getElementsByTagName("button")[0].disabled = mode;
            document.getElementById('rowAdd').style.display = (mode) ? 'none' : '';
            document.getElementById('rowa' + obj).style.display = (mode) ? 'none' : '';
            document.getElementById('rowb' + obj).style.display = (mode) ? '' : 'none';
            document.getElementById('G' + obj).style.display = '';
            document.getElementById('H' + obj).style.display = '';
            return false;
        }
    </script>
    <div style="width: 1000px; margin: 10px auto; text-align: center;">
        <span style="font-size: 1.5em;">Drivers...</span>
        <br />
        <asp:PlaceHolder ID="ErrZone" runat="server"></asp:PlaceHolder>
        <br />
        <asp:PlaceHolder ID="tZone" runat="server"></asp:PlaceHolder>
        <br />
        <button runat="server" id="btn_submit">Submit Drivers</button>
    </div>
</asp:Content>
