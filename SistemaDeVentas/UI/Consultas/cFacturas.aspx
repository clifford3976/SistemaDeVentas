<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="cFacturas.aspx.cs" Inherits="SistemaDeVentas.UI.Consultas.cFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form-group ">
        <div class="row">

            <label for="TipodeFiltro" style="width: 50px">Filtro:</label>
            <div style="width: 220px">
                <asp:DropDownList class="form-control" ID="TipodeFiltro" runat="server" for="TipodeFiltro" Width="200px">
                    <asp:ListItem>FacturaId</asp:ListItem>
                    <asp:ListItem>ClienteId</asp:ListItem>
                    <asp:ListItem>Total</asp:ListItem>
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
                <asp:GridView ID="facturaGridView" runat="server" class="table table-condensed table-bordered table-responsive" OnPageIndexChanging="facturaGridView_PageIndexChanging" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="LightSkyBlue" />
                    <Columns>
                        <asp:BoundField DataField="FacturaId" HeaderText="FacturaId" />
                        <asp:BoundField DataField="ClienteId" HeaderText="ClienteId" />
                        <asp:BoundField DataField="Monto" HeaderText="Monto" />
                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                        <asp:BoundField DataField="Total" HeaderText="Total" />
                        <asp:BoundField DataField="Devuelta" HeaderText="Devuelta" />



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
