﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="cInventarios.aspx.cs" Inherits="SistemaDeVentas.UI.Consultas.cInventarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container form-group ">
        <div class="row">

            <label for="TipodeFiltro" style="width: 50px">Filtro:</label>
            <div style="width: 220px">
                <asp:DropDownList class="form-control" ID="TipodeFiltro" runat="server" for="TipodeFiltro" Width="200px">
                    <asp:ListItem>InventarioId</asp:ListItem>
                    <asp:ListItem>RopaId</asp:ListItem>
                    <asp:ListItem>Todos</asp:ListItem>


                </asp:DropDownList>
            </div>
            <asp:Label ID="LabelCriterio" runat="server" Text="Criterio:" Style="width: 60px"></asp:Label>
            <div style="width: 370px">
                <asp:TextBox class="form-control" ID="TextCriterio" runat="server" Style="width: 350px"></asp:TextBox>

            </div>
            <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" class="btn btn-info btn-md" OnClick="ButtonBuscar_Click1" />

        </div>
    </div>

    <div>
        <table>
            <tr>
                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                </td>
                <td>
                    <asp:TextBox ID="DesdeTextBox" TextMode="Date" runat="server" class="form-control" Height="25" Width="175"></asp:TextBox>
                </td>
                <td>&nbsp<strong><asp:Label ID="Label1" runat="server" Text="-"> Desde </asp:Label></strong>&nbsp
                </td>
                <td>
                    <asp:TextBox ID="HastaTextBox" TextMode="Date" runat="server" class="form-control" Height="25" Width="175">Hasta</asp:TextBox>
                </td>
            </tr>
        </table>
    </div>


    <div>
        <table>
            <tr>
                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                </td>
                <td>
                    <asp:CheckBox ID="FechaCheckBox" runat="server" Text="Fecha" />
                </td>

            </tr>
        </table>
    </div>

    <div class="container form-group ">
        <div class="row">
            <div class="form-row justify-content-center">
                <asp:GridView ID="InventarioGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="LightSkyBlue" />
                    <Columns>
                        <asp:BoundField DataField="InventarioId" HeaderText="InventarioId" />
                        <asp:BoundField DataField="RopaId" HeaderText="RopaId" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />


                    </Columns>
                    <HeaderStyle BackColor="LightCyan" Font-Bold="True" />
                </asp:GridView>


            </div>
        </div>
    </div>

    <div class="panel-footer">
        <div class="modal-content">
            <div class="text-center">
            </div>
        </div>
    </div>

    <asp:Button ID="ReporteButton" runat="server" class="btn btn-success" Text="Imprimir" OnClick="ReporteButton_Click" />


</asp:Content>
