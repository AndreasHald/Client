<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>

        function goBack()
        {
            window.history.go(-1);
        }

    </script>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="week0" Runat="Server">

    <asp:Repeater ID="rweek" runat="server">
            
    </asp:Repeater>
    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="week1" Runat="Server">
    <asp:Repeater ID="rweek1" runat="server">
            
    </asp:Repeater>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="week2" Runat="Server">
<asp:Repeater ID="rweek2" runat="server">
            
    </asp:Repeater>
</asp:Content>