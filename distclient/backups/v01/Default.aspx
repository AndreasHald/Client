<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Bodyholder" Runat="Server">

    <asp:Label ID="selected" runat="server"></asp:Label>
    
    <asp:Calendar ID="Cal" class="calstyle" Runat="Server" OnSelectionChanged="Cal_SelectionChanged" OnDayRender="Cal_DayRender" OnVisibleMonthChanged="Cal_VisibleMonthChanged" DayNameFormat="FirstLetter">


    </asp:Calendar>

   

</asp:Content>

