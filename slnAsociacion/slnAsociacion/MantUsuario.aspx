<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MantUsuario.aspx.cs" Inherits="slnAsociacion.MantUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        if (Session["Usuario"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    %>
    <div class="row">
        <div class="col-md-12">
            <h4 class="text-center">Mantenimiento de Usuarios</h4>
        </div>
    </div>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                        <asp:Label ID="lblEstado" CssClass="col-lg-5 control-label" runat="server" Text="Estado:"></asp:Label>
                        <div class="col-lg-5">
                            <label class="radio-inline">
                                <asp:RadioButton GroupName="estado" ID="A" Text="Activo" runat="server" />
                            </label>
                            <label class="radio-inline">
                                <asp:RadioButton GroupName="estado" ID="I" Text="Inactivo" runat="server" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblPerfil" CssClass="col-lg-5 control-label" runat="server" Text="Perfil:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblContrasenna" CssClass="col-lg-5 control-label" runat="server" Text="Contraseña:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtContrasenna" CssClass="form-control" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnNuevo" CssClass="btn btn-default" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />

                    <asp:Button ID="btnGuardar" CssClass="btn btn-default" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />

                    <asp:Button ID="btnModificar" CssClass="btn btn-default" runat="server" Text="Modificar" Enabled="false" OnClick="btnModificar_Click" />
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
                    <asp:GridView ID="gvUsuarios" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EnableModelValidation="True" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="PK_Usuario" HeaderText="Código" SortExpression="PK_Codigo" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                            <asp:BoundField DataField="NombrePerfil" HeaderText="Perfil" SortExpression="NombrePerfil" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="FK_Perfil" HeaderText="Perfil" SortExpression="FK_Perfil" Visible="false" />
                            <asp:CommandField ShowSelectButton="true" SelectText="<span class='glyphicon glyphicon-pencil'></span>" ControlStyle-CssClass="btn btn-primary btn-sm input-sm">
                                <ControlStyle CssClass="btn btn-primary btn-sm input-sm" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
