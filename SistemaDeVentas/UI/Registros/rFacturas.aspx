<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="rFacturas.aspx.cs" Inherits="SistemaDeVentas.UI.Registros.rFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" panel panel-primary">
        <div class="panel-heading text-center">
            <h1><ins>Facturas</ins></h1>
            <br />
        </div>
    </div>

    <div class="col-sm-12">

        <div class="Container-fluid">
           


                <%--   FacturaId--%>
             <div class="align-content-center">

                <table>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="ID" runat="server" Text="FacturaId: "></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="FacturaIdTextbox" runat="server" class="form-control" Height="30" Width="200" ValidationGroup="Buscar"></asp:TextBox>
                        </td>
                        <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="BuscarButton" ValidationGroup="Buscar" runat="server" class="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
                            <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='solo acepta numeros' ControlToValidate="FacturaIdTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>

                <br />
                <%--  Fecha--%>

                <div>
                    <table>
                        <tr>
                            <td>
                                <strong>
                                    <asp:Label ID="Label1" runat="server" Text="Fecha: "></asp:Label></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="FechaTextBox" ValidationGroup="Guardar" runat="server" class="form-control" type="date" Height="30" Width="300" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator2" CssClass="ErrorMessage" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="Seleccione una Fecha"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                    </table>

                </div>
                <%--  Cliente--%>
                <div>
                    <table>
                        <tr>
                            <td>
                                <strong>
                                    <label for="ClienteDropDownList">Clliente</label></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ClienteDropDownList" class="form-control input-sm" runat="server" OnSelectedIndexChanged="ClienteDropDownList_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CustomValidator ID="CVCliente" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="ClienteDropDownList" ValidationGroup="Guardar" ErrorMessage="Seleccione Un cliente"></asp:CustomValidator>
                            </td>

                        </tr>
                    </table>
                </div>


                <%--  Ropa--%>
                <div>
                    <table>
                        <tr>
                            <td>
                                <strong>
                                    <label for="RopaDropDownList">Ropa</label></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="RopaDropDownList" OnTextChanged="RopaDropDownList_TextChanged" class="form-control input-sm" runat="server">
                                    <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CustomValidator ID="CVRopa" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="RopaDropDownList" ValidationGroup="Guardar" ErrorMessage="Seleccione Una ropa"></asp:CustomValidator>
                            </td>

                        </tr>
                    </table>
                </div>
            </div>

            <%--CantidadTexbox--%>

            <div>
                <table>
                    <tr>
                        <td>
                            <strong>
                                <asp:Label ID="Label3" runat="server" Text="Cantidad:"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="CantidadTexbox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" type="Number" AutoPostBack="true" OnTextChanged="CantidadTexbox_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="ValidaBalanceNUM" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="CantidadTexbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="ValidaBalance" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="CantidadTexbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>


                <%--PrecioTextbox--%>
                <div>
                    <table>
                        <tr>
                            <td>
                                <strong>
                                    <asp:Label ID="Label2" runat="server" Text="Precio:"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="PrecioTextbox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" ReadOnly="true" AutoPostBack="true" type="Number" OnTextChanged="PrecioTextbox_TextChanged"></asp:TextBox>
                            </td>
                            <%--  <td>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="PrecioTextbox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="PrecioTextbox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td> --%>
                        </tr>
                    </table>
                </div>


                <%--ImporteTextbox--%>
                <div>
                    <table>
                        <tr>
                            <td>
                                <strong>
                                    <asp:Label ID="Label6" runat="server" Text="Importe:"></asp:Label>
                                </strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="ImporteTextbox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" ReadOnly="true" AutoPostBack="true" type="Number" OnTextChanged="ImporteTextbox_TextChanged"></asp:TextBox>
                            </td>
                            <%--  <td>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator4" runat="server" ErrorMessage='Campo "Balance" solo acepta numeros' ControlToValidate="ImporteTextbox" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator5" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="ImporteTextbox" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td> --%>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="col-lg-1 p-0">
                <asp:LinkButton ID="agregarLinkButton" CssClass="btn btn-dark mt-4" runat="server" OnClick="agregarLinkButton_Click">
                                <span class="fas fa-search"></span>Agregar
                </asp:LinkButton>
            </div>
            &nbsp;&nbsp;
                               
        </div>
        
        <div class="col-md-12 col-md-offset-3">
            <div class="container">
                <div class="form-group">
                    <div class="form-row justify-content-center">
                        <asp:GridView ID="detalleGridView" runat="server" OnRowDataBound="detalleGridView_RowDataBound" OnSelectedIndexChanged="detalleGridView_SelectedIndexChanged" class="table table-condensed table-bordered table-responsive"
                            CellPadding="4" AllowPaging="true" PageSize="7" ForeColor="Black" GridLines="None" BackColor="White" OnPageIndexChanging="detalleGridView_PageIndexChanging1" OnRowCommand="detalleGridView_RowCommand">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False" HeaderText="Opcion">
                                    <ItemTemplate>
                                        <asp:Button ID="Remover" runat="server" CausesValidation="false" CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).DataItemIndex %>"
                                            Text="Remover" class="btn btn-danger btn-sm" data-toggle="modal" data-target=".bd-ejemplo-modal-lg" OnClick="Remover_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#009900" Font-Bold="True" />
                        </asp:GridView>
                    </div>
                </div>

            </div>
        </div>

        <%--MontoTextBox--%>

        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label7" runat="server" Text="Monto:"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="MontoTextBox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" type="Number" AutoPostBack="true" OnTextChanged="MontoTextBox_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" ErrorMessage='Campo "Monto" solo acepta numeros' ControlToValidate="MontoTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="MontoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>

        <%--SubtotalTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label9" runat="server" Text="Subtotal:"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="SubtotalTextBox" runat="server" class="form-control col-md-12" Height="30" Width="300" ReadOnly="true" AutoPostBack="true" MaxLength="80" type="Number"></asp:TextBox>
                    </td>
                    <%-- <td>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator5" runat="server" ErrorMessage='Campo "Devuelta" solo acepta numeros' ControlToValidate="SubtotalTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="SubtotalTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td> --%>
                </tr>
            </table>
        </div>

        <%--TotalTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label10" runat="server" Text="Total:"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TotalTextBox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" ReadOnly="true" AutoPostBack="true" type="Number"></asp:TextBox>
                    </td>
                    <%--  <td>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator6" runat="server" ErrorMessage='Campo "Total" solo acepta numeros' ControlToValidate="TotalTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator6" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="TotalTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td> --%>
                </tr>
            </table>
        </div>



        <%--DevueltaTextBox--%>
        <div>
            <table>
                <tr>
                    <td>
                        <strong>
                            <asp:Label ID="Label8" runat="server" Text="Devuelta:"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="DevueltaTextBox" runat="server" class="form-control col-md-12" Height="30" Width="300" MaxLength="80" type="Number" ReadOnly="true" AutoPostBack="true" OnTextChanged="DevueltaTextBox_TextChanged"></asp:TextBox>
                    </td>
                    <%-- <td>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator3" runat="server" ErrorMessage='Campo "Devuelta" solo acepta numeros' ControlToValidate="DevueltaTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ErrorMessage="El campo &quot;Balance&quot; esta vacio" ControlToValidate="DevueltaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Balance obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                    </td> --%>
                </tr>
            </table>
        </div>

    </div>
    <%--  <%-- Botones--%>
    <div class="panel-footer">
        <div class="text-center">

            <asp:Label class="text-center " ID="ErrorLabel" runat="server" Text=""></asp:Label>

            <asp:Button ID="NuevoButton" runat="server" class="btn btn-info" Text="Nuevo" OnClick="NuevoButton_Click" />
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                               

                        <asp:Button ID="GuardarButton" runat="server" class="btn btn-success" Text="Guardar" OnClick="GuardarButton_Click" ValidationGroup="Guardar" />
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                   
                               

                        <asp:Button ID="EliminarButton" runat="server" class="btn btn-danger" Text="Eliminar" OnClick="EliminarButton_Click" />
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                          <asp:Button ID="ReporteButton" runat="server" class="btn btn-success" Text="Imprimir" OnClick="ReporteButton_Click" />


        </div>
    </div>






    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <link href="/Content/toastr.min.css" rel="stylesheet" />
    <script src="/Scripts/toastr.min.js"></script>
    <script src="/Scripts/jquery-3.2.1.slim.min.js"></script>
</asp:Content>
