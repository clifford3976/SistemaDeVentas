﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="cClientes.aspx.cs" Inherits="SistemaDeVentas.UI.Consultas.cClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container form-group ">
        <div class="row">

            <label for="TipodeFiltro" style="width: 50px">Filtro:</label>
            <div style="width: 220px">
                <asp:DropDownList class="form-control" ID="TipodeFiltro" runat="server" for="TipodeFiltro" Width="200px">
                    <asp:ListItem>ClienteId</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                    <asp:ListItem>Apelido</asp:ListItem>
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



    <div class="container form-group ">
        <div class="row">
            <div class="form-row justify-content-center">
                <asp:GridView ID="ClienteGridView" runat="server" OnSelectedIndexChanging="ClienteGridView_SelectedIndexChanging" OnPageIndexChanging="ClienteGridView_PageIndexChanging" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="LightSkyBlue" />
                    <Columns>
                        <asp:BoundField DataField="ClienteId" HeaderText="ClienteId" />
                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                        <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />



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
