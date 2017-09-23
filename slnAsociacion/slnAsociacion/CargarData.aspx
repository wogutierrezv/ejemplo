<%@ Page Title="Asociados" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CargarData.aspx.cs" Inherits="slnAsociacion.CargarData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
        if (Session["Usuario"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    %>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <h4 class="text-center">Cargar Información</h4>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblCodigo" CssClass="col-lg-5 control-label" runat="server" Text="Código:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblNombre" CssClass="col-lg-5 control-label" runat="server" Text="Nombre:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblIdentificacion" CssClass="col-lg-5 control-label" runat="server" Text="Identificación:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtIndentificacion" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblEstatus1" CssClass="col-lg-5 control-label" runat="server" Text="Estatus1:"></asp:Label>
                        <div class="col-lg-5">
                            <label class="radio-inline">
                                <asp:RadioButton GroupName="estado1" ID="EstatusA" Text="Activo" runat="server" />
                            </label>
                            <label class="radio-inline">
                                <asp:RadioButton GroupName="estado1" ID="EstatusI" Text="Inactivo" runat="server" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblEstado2" CssClass="col-lg-5 control-label" runat="server" Text="Estado2:"></asp:Label>
                        <div class="col-lg-5">
                            <label class="radio-inline">
                                <asp:RadioButton GroupName="estado2" ID="Estado2A" Text="Confirmado" runat="server" />
                            </label>
                            <label class="radio-inline">
                                <asp:RadioButton GroupName="estado2" ID="Estado2I" Text="No" runat="server" />
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblCorreo" CssClass="col-lg-5 control-label" runat="server" Text="Correo:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblTelefono" CssClass="col-lg-5 control-label" runat="server" Text="Teléfono:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnNuevo" CssClass="btn btn-default" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />

                    <asp:Button ID="btnGuardar" CssClass="btn btn-default" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />

                    <asp:Button ID="btnModificar" CssClass="btn btn-default" runat="server" Text="Modificar" Enabled="false" OnClick="btnModificar_Click" />

                    <asp:Button runat="server" ID="UploadButton" CssClass="btn btn-default" Text="Excel" OnClick="UploadButton_Click" Visible="false" />
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="alert alert-success" id="MensajeSuccess" runat="server">Datos guardados correctamente.</div>
                    <div class="alert alert-danger" id="MensajeDanger" runat="server">¡Disculpe! Corrija algunos campos y vuelva a intentarlo.</div>
                    <div class="alert alert-success" id="MensajeUpdate" runat="server">Datos actualizados correctamente.</div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvAsociados" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False"
                        OnSelectedIndexChanged="gvAsociados_SelectedIndexChanged" BackColor="White" BorderColor="#336666"
                        BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal"
                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvAsociados_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Código" SortExpression="Id" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                            <asp:BoundField DataField="Identificacion" HeaderText="Identificación" SortExpression="Identificacion" />
                            <asp:BoundField DataField="Estatus1" HeaderText="Estatus 1" SortExpression="Estatus1" />
                            <asp:BoundField DataField="Estado2" HeaderText="Estado 2" SortExpression="Estado2" />
                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                            <asp:CommandField ShowSelectButton="true" SelectText="<span class='glyphicon glyphicon-pencil'></span>" ControlStyle-CssClass="btn btn-primary btn-sm input-sm">
                                <ControlStyle CssClass="btn btn-primary btn-sm input-sm" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="Black" HorizontalAlign="Center" CssClass="pagination-ys" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
