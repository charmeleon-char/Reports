<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MvcApplication2.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ReportSupConnectionString %>" SelectCommand="SELECT Userid, Name, HoraEntrada, horasalida, CAST(DATEDIFF(minute, HoraEntrada, horasalida) / 60.0 AS decimal(18 , 2)) AS HoraTrabajada FROM (SELECT ui.Userid, ui.Name, MIN(checkins.CheckTime) AS HoraEntrada, MAX(checkins.CheckTime) AS horasalida FROM Checkinout AS checkins INNER JOIN Userinfo AS ui ON checkins.Userid = ui.Userid WHERE (CAST(checkins.CheckTime AS date) = '2015-08-13') AND (ui.Deptid = 2) GROUP BY ui.Userid, ui.Name) AS resultado"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="133px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1465px">
            <Columns>
                <asp:BoundField DataField="Userid" HeaderText="Codigo" SortExpression="Userid" />
                <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                <asp:BoundField DataField="HoraEntrada" HeaderText="HoraEntrada" ReadOnly="True" SortExpression="HoraEntrada" />
                <asp:BoundField DataField="horasalida" HeaderText="Hora de salida" ReadOnly="True" SortExpression="horasalida" />
                <asp:BoundField DataField="HoraTrabajada" HeaderText="Horas Trabajada" ReadOnly="True" SortExpression="HoraTrabajada" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
