<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CodeAssesment._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <p>This is the data from your file</p>
        <p>
            <asp:DataGrid ID="myDataGrid" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered"></asp:DataGrid>
        </p>
        <p>
            These are the creatures broken out by type
            
            <asp:GridView ID="fireDataGrid" runat="server" AutoGenerateColumns="true" HeaderText="Fire Data" CssClass="table table-bordered"></asp:GridView>

            <br />
            
            <asp:GridView ID="waterDataGrid" runat="server" AutoGenerateColumns="true" HeaderText="Water Data" CssClass="table table-bordered"></asp:GridView>
        </p>
    </div>



</asp:Content>
