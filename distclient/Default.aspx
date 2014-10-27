<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Table ID="tableweek2"  CssClass="calstyle" runat="server">
    
    <asp:TableHeaderRow CssClass="rowheader">
      
        <asp:TableCell ColumnSpan="8"><asp:Label ID="labelweek2" runat="server"></asp:Label></asp:TableCell>
      
    </asp:TableHeaderRow>
    <asp:TableRow ID="tablerowweek2" CssClass="row">
        <asp:TableCell></asp:TableCell>
        <asp:TableCell>Monday</asp:TableCell>
        <asp:TableCell>Tuesday</asp:TableCell>
        <asp:TableCell>Wednesday</asp:TableCell>
        <asp:TableCell>Thursday</asp:TableCell>
        <asp:TableCell>Friday</asp:TableCell>
        <asp:TableCell>Saturday</asp:TableCell>
        <asp:TableCell>Sunday</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">8:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">9:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">10:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">11:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">12:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">13:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">14:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">15:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">16:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">17:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="row">
        <asp:TableCell CssClass="ctime">18:00</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
        <asp:TableCell CssClass="cell">...</asp:TableCell>
    </asp:TableRow>

</asp:Table>
</asp:Content>