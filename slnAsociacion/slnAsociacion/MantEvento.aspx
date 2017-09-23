<%@ Page Title="Evento" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MantEvento.aspx.cs" Inherits="slnAsociacion.MantEvento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
            <h4 class="text-center">Mantenimiento de Eventos</h4>
        </div>
    </div>
    <hr />

            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="lblCodigo" CssClass="col-lg-5 control-label" runat="server" Text="Código:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" MaxLength="50" OnTextChanged="txtCodigo_TextChanged"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblNombre" CssClass="col-lg-5 control-label" runat="server" Text="Nombre:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblFecha" CssClass="col-lg-5 control-label" runat="server" Text="Fecha Inicio:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtFechaInicio" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:CalendarExtender ID="txtFechaInicioCalendar" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFechaInicio">
                            </asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-5 col-sm-9">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlHoraInicio" CssClass="form-control" runat="server" Width="80px">
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlMinutosInicio" CssClass="form-control" runat="server" Width="80px">
                                        <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlFormatoInicio" CssClass="form-control" runat="server" Width="80px">
                                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">

                    <div class="form-group">
                        <asp:Label ID="Label3" CssClass="col-lg-5 control-label" runat="server" Text="Fecha Fin:"></asp:Label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtFechaFin" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:CalendarExtender ID="txtFechaFinCalendar" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFechaFin">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-5 col-sm-9">
                            <div class="form-group">
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlHoraFin" CssClass="form-control" runat="server" Width="80px">
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlMinutosFin" CssClass="form-control" runat="server" Width="80px">
                                        <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="ddlFormatoFin" CssClass="form-control" runat="server" Width="80px">
                                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
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
            <br />
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="alert alert-success" id="MensajeSuccess" runat="server">Datos guardados correctamente.</div>
                    <div class="alert alert-danger" id="MensajeDanger" runat="server">¡Disculpe! Corrija algunos campos y vuelva a intentarlo.</div>
                    <div class="alert alert-success" id="MensajeUpdate" runat="server">Datos actualizados correctamente.</div>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvEventos" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EnableModelValidation="True" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="Codigo" HeaderText="Código" SortExpression="Codigo" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                            <asp:BoundField DataField="Fecha_Inicio" HeaderText="Fecha Inicio" SortExpression="Fecha_Inicio" />
                            <asp:BoundField DataField="Fecha_Fin" HeaderText="Fecha Fin" SortExpression="Fecha_Fin" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>

</asp:Content>
