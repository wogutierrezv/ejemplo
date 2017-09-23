<%@ Page Title="Ingresar" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="slnAsociacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-default">
                    <div class="panel-heading">Ingrese su usuario</div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-lg-3 control-label">Usuario</label>
                            <div class="col-lg-6">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <span class="glyphicon glyphicon-user"></span>
                                    </div>
                                    <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-3 control-label">Contraseña</label>
                            <div class="col-lg-6">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <span class="glyphicon glyphicon-lock"></span>
                                    </div>
                                    <asp:TextBox ID="txtContrasenna" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-5">
                                <asp:Label ID="lbl_mensaje" runat="server" Font-Bold="True" ForeColor="Red" Text="Verifique el Usuario y la contraseña"
                                    Visible="False" Font-Strikeout="False"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-5">
                                <asp:Button ID="btnIngresar" CssClass="btn btn-primary" runat="server" OnClick="btnIngresar_Click"
                                    Text="Ingresar" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


</asp:Content>
