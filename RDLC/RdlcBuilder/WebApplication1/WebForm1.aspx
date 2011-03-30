<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
<table id ="PrintTable" cellpadding ="0" cellspacing ="0" border ="1">
    <tr>
        <td colspan ="2" bgcolor="red" rowspan ="2"   align="center" >one</td>
        <td width ="100px" height="80px" >two</td>
        <td width ="100px">three</td>
    </tr>
    <tr>
        <td rowspan ="3">four</td>
        <td style="height:60px">five</td>
    </tr>
    <tr>
        <td width ="100px" style="height:60px">six</td>
        <td width ="100px" rowspan ="2">seven</td>
        <td>eight</td>
    </tr>
    <tr>
        <td style="height:80px">nine</td>
        <td>ten</td>
    </tr>
			
</table>
<img src="http://www.zhang51.com/imgs/before.jpg"><br />
<img src="http://www.zhang51.com/imgs/print.jpg">
    </div>
    </form>
    </body>
</html>
