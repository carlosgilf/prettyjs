<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="WebApplication1._Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
       
        *
        {
            padding: 0;
            margin: 0;
        }
        html, body,form
        {
            height: 100%;
            width:100%;
        }
       
       
        #container
        {
        	height: 300px;
            width:  100%;
        }
        
        * html #container
        {
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="container">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
            Width="100%" Height="300">
        </rsweb:ReportViewer>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="FSchoolID" HeaderText="FSchoolID" 
                SortExpression="FSchoolID" />
            <asp:BoundField DataField="FTitle" HeaderText="FTitle" 
                SortExpression="FTitle" />
            <asp:BoundField DataField="FKeywords" HeaderText="FKeywords" 
                SortExpression="FKeywords" />
            <asp:BoundField DataField="FPromulgatorID" HeaderText="FPromulgatorID" 
                SortExpression="FPromulgatorID" />
            <asp:BoundField DataField="FCategory" HeaderText="FCategory" 
                SortExpression="FCategory" />
            <asp:BoundField DataField="FTypeID" HeaderText="FTypeID" 
                SortExpression="FTypeID" />
            <asp:BoundField DataField="FAttachmentInfos" HeaderText="FAttachmentInfos" 
                SortExpression="FAttachmentInfos" />
            <asp:BoundField DataField="FViewLevel" HeaderText="FViewLevel" 
                SortExpression="FViewLevel" />
            <asp:CheckBoxField DataField="FTrackReadLog" HeaderText="FTrackReadLog" 
                SortExpression="FTrackReadLog" />
            <asp:BoundField DataField="FOvertime" HeaderText="FOvertime" 
                SortExpression="FOvertime" />
            <asp:BoundField DataField="FViewCount" HeaderText="FViewCount" 
                SortExpression="FViewCount" />
            <asp:CheckBoxField DataField="FNeedHint" HeaderText="FNeedHint" 
                SortExpression="FNeedHint" />
            <asp:BoundField DataField="FPubTime" HeaderText="FPubTime" 
                SortExpression="FPubTime" />
            <asp:BoundField DataField="FSkin" HeaderText="FSkin" SortExpression="FSkin" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eCampusConnectionString %>"
        
        SelectCommand="SELECT [FSchoolID], [FTitle], [FKeywords], [FPromulgatorID], [FCategory], [FTypeID], [FAttachmentInfos], [FViewLevel], [FTrackReadLog], [FOvertime], [FViewCount], [FNeedHint], [FPubTime], [FSkin] FROM [News]"></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
