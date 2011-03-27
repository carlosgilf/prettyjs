<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
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
            overflow: hidden;
        }
       
       
        #container
        {
        	height: 100%;
            min-height: 100%;
            width:  100%;
        }
        
        * html #container
        {
            height: 100%;
        }
    </style>

    
</head>
<body scroll="no">
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div id="container">
         <%--  <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%">
    </rsweb:ReportViewer>--%>
 
         <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
             Font-Size="8pt" InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
             WaitMessageFont-Size="14pt"
             Width="100%" Height="100%"
             
             
             >
             <LocalReport ReportPath="Report1.rdlc">
             </LocalReport>
         </rsweb:ReportViewer>
 
    </div>

 
 
    </form>
    
</body>
</html>


