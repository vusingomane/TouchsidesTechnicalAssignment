<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TouchsidesTechAssignment._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style=" padding:2px">
            <tr>
                <td colspan="3" style="text-align:center">
                    <h2>Upload the File</h2>
                </td>
            </tr>
            <tr>
                <td class="lead">
                    Browse File
                </td>
                <td>
                    <asp:FileUpload class="btn btn-primary btn-lg" ID="fpFile" runat="Server" />
                </td>
                <td>
                    <asp:Button class="btn btn-primary btn-lg" ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>          
        </table>
        </div>
   
    <div class="jumbotron">
      <div class="row">
            <h2>Results</h2>
            <asp:Label ID="lblMostFrequentWord" runat="server"></asp:Label> <br />
            <asp:Label ID="lblMostFrequentSevenCharWord" runat="server"></asp:Label><br />
            <asp:Label ID="lblHighestScoringWord" runat="server"></asp:Label>
        </div>        
  </div>
</asp:Content>
