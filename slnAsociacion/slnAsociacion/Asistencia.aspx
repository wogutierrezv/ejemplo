<%@ Page Title="Registrar Asistencia" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Asistencia.aspx.cs" Inherits="slnAsociacion.Asistencia" %>

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
            <h4 class="text-center">Registrar Asistencia</h4>
        </div>
    </div>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblCodigo" CssClass="col-lg-5 control-label" runat="server" Text="Evento:"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlEvento" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblBuscar" CssClass="col-lg-5 control-label" runat="server" Text="Buscar Asociado:"></asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:LinkButton ID="CogLinkButton" CssClass="btn btn-default btn-lg" OnClick="CogLinkButton_Click" runat="server"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblAsociado" CssClass="col-lg-5 control-label" runat="server" Text="Asociado:"></asp:Label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlAsociado" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btnNuevo" CssClass="btn btn-default" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                    <asp:Button ID="btnGuardar" CssClass="btn btn-default" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />

                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="alert alert-success" id="MensajeSuccess" runat="server">Asistencia registrada correctamente.</div>
                    <div class="alert alert-danger" id="MensajeDanger" runat="server">¡Disculpe! Corrija algunos campos y vuelva a intentarlo.</div>
                    <div class="alert alert-success" id="MensajeUpdate" runat="server">Datos actualizados correctamente.</div>
                    <div class="alert alert-danger" id="MensajeEstado" runat="server">>¡Disculpe! El usuario no se encuentra activo o no confirmo asistencia</div>
                </div>
            </div>
            <hr />
            <h5>Confirmaron Asistencia</h5>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvAsistencia" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EnableModelValidation="True" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="PK_Evento" HeaderText="Evento" SortExpression="PK_Evento" />
                            <asp:BoundField DataField="PK_Asociado" HeaderText="Asociado" SortExpression="PK_Asociado" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                            <asp:BoundField DataField="Usuario_Registra" HeaderText="Usuario" SortExpression="Usuario_Registra" />
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
