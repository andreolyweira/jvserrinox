<%@ Page Language="C#" MasterPageFile="~/jvserrinox.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="orcamento.aspx.cs" Inherits="jvserrinox.orcamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/site.css" rel="stylesheet">

    <link rel="stylesheet" href="css/feature-carousel.css" charset="utf-8" />
    <script src="js/jquery-1.7.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/jquery.featureCarousel.min.js" type="text/javascript" charset="utf-8"></script>
    <link href='http://fonts.googleapis.com/css?family=Roboto' rel='stylesheet' type='text/css'>
    <script src="js/mascara.js"></script>
    <style>
        .tdLabel {
            width: 100px;
            text-align: left;
        }

        .tdTextBox {
            width: 250px;
            float: left;
        }

        .alinharLeft {
            text-align: left;
        }

        .Produtos {
            min-height: 405px;
        }

        .botao {
            color: #FFF;
            padding: 10px 10px 10px 10px;
            border: 0;
            background-color: #1BBC9B;
            width:240px;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <h1>Orçamento</h1>
                <p>
                    <strong>Preencha o formulário abaixo e entre em contato conosco</strong>
                </p>

                <p style="color: red;">
                    <strong>(*) são campos obrigatórios</strong>
                </p>

                <table>
                    <tr>
                        <td>
                            <asp:Panel runat="server" ID="pnlOrcamento" GroupingText="<strong>Informações para Contato</strong>" Width="520px" CssClass="alinharLeft">
                                <table>
                                    <tr>
                                        <td class="tdLabel">
                                            <asp:Label runat="server" ID="Label3" Text="Nome: (*)"></asp:Label>
                                        </td>
                                        <td class="tdTextBox">
                                            <asp:TextBox runat="server" ID="txtNome" CssClass="tdTextBox"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;
                                <asp:RequiredFieldValidator ID="validatorNome" runat="server" ErrorMessage="*" ControlToValidate="txtNome" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <asp:Label runat="server" ID="Label4" Text="Telefone: (*)"></asp:Label>
                                        </td>
                                        <td class="tdTextBox">
                                            <asp:TextBox runat="server" ID="txtTelefone" CssClass="tdTextBox" onkeyup="formataTelefone(this,event);" MaxLength="15"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;
                                <asp:RequiredFieldValidator ID="validatorTelefone" runat="server" ErrorMessage="*" ControlToValidate="txtTelefone" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <asp:Label runat="server" ID="Label5" Text="Email:"></asp:Label></td>
                                        <td class="tdTextBox">
                                            <asp:TextBox runat="server" ID="txtEmail" CssClass="tdTextBox"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <asp:Label runat="server" ID="Label6" Text="Cidade:"></asp:Label></td>
                                        <td class="tdTextBox">
                                            <asp:TextBox runat="server" ID="txtCidade" CssClass="tdTextBox"></asp:TextBox></td>
                                        <td></td>
                                        <td>
                                            <asp:Label runat="server" ID="Label7" Text="Estado:"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlEstado">
                                                <asp:ListItem Text="AC" Value="AC"></asp:ListItem>
                                                <asp:ListItem Text="AL" Value="AL"></asp:ListItem>
                                                <asp:ListItem Text="AP" Value="AP"></asp:ListItem>
                                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                <asp:ListItem Text="BA" Value="BA"></asp:ListItem>
                                                <asp:ListItem Text="CE" Value="CE"></asp:ListItem>
                                                <asp:ListItem Text="DF" Value="DF"></asp:ListItem>
                                                <asp:ListItem Text="ES" Value="ES"></asp:ListItem>
                                                <asp:ListItem Text="GO" Value="GO"></asp:ListItem>
                                                <asp:ListItem Text="MA" Value="MA"></asp:ListItem>
                                                <asp:ListItem Text="MT" Value="MT"></asp:ListItem>
                                                <asp:ListItem Text="MS" Value="MS"></asp:ListItem>
                                                <asp:ListItem Text="MG" Value="MG"></asp:ListItem>
                                                <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                                                <asp:ListItem Text="PB" Value="PB"></asp:ListItem>
                                                <asp:ListItem Text="PR" Value="PR"></asp:ListItem>
                                                <asp:ListItem Text="PE" Value="PE"></asp:ListItem>
                                                <asp:ListItem Text="PI" Value="PI"></asp:ListItem>
                                                <asp:ListItem Text="RJ" Value="RJ"></asp:ListItem>
                                                <asp:ListItem Text="RN" Value="RN"></asp:ListItem>
                                                <asp:ListItem Text="RS" Value="RS"></asp:ListItem>
                                                <asp:ListItem Text="RO" Value="RO"></asp:ListItem>
                                                <asp:ListItem Text="RR" Value="RR"></asp:ListItem>
                                                <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                                                <asp:ListItem Text="SP" Value="SP" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="SE" Value="SE"></asp:ListItem>
                                                <asp:ListItem Text="TO" Value="TO"></asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <asp:Label runat="server" ID="Label8" Text="Comentário:"></asp:Label></td>
                                        <td class="tdTextBox">
                                            <asp:TextBox runat="server" ID="txtComentario" TextMode="MultiLine" CssClass="tdTextBox"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlOrcamentoItem" GroupingText="<strong>Produtos para o Orçamento</strong>" Width="520px" CssClass="alinharLeft">
                                <table>
                                    <tr>
                                        <td class="tdLabel">
                                            <asp:Label runat="server" ID="lblCategoria" Text="Categoria:"></asp:Label>
                                        </td>
                                        <td class="tdTextBox">
                                            <asp:DropDownList runat="server" ID="ddlCategoria" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" CssClass="tdTextBox" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <asp:Label runat="server" ID="Label1" Text="Produto:"></asp:Label>
                                        </td>
                                        <td class="tdTextBox">
                                            <asp:DropDownList runat="server" ID="ddlProduto" CssClass="tdTextBox"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel">
                                            <asp:Label runat="server" ID="Label2" Text="Quantidade: (*)"></asp:Label>
                                        </td>
                                        <td class="tdTextBox">
                                            <asp:TextBox runat="server" ID="txtQuantidade" onkeyup="formataInteiro(this,event);" CssClass="tdTextBox" MaxLength="10"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <center>
                                <asp:Button runat="server" ID="btnAdicionar" Text="Adicionar no Orçamento" OnClick="btnAdicionar_Click" CssClass="botao" />
                                    </center>
                                <br />

                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel runat="server" ID="pnlProdutos" Height="380px" Visible="false" CssClass="Produto" ScrollBars="Vertical" GroupingText="<strong>Produtos adicionados</strong>">
                                <asp:GridView ID="grdProdutos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="grdProdutos_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="ProdutoInfo.Nome" HeaderText="Produto" />
                                        <asp:BoundField DataField="Quantidade" HeaderText="Quantidade"></asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="image" ImageUrl='<%# Eval("ProdutoInfo.CaminhoImagemTemp") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnRemover" runat="server" Text="Remover" CommandName="remover" CommandArgument='<%# Eval("Guid") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />

                                </asp:GridView>
                            </asp:Panel>

                            <div runat="server" id="divEnviarOrcamento" visible="false">
                                <center>
                                <asp:Button runat="server" ID="btnEnviar" Text="Enviar Orçamento" OnClick="btnEnviar_Click" CssClass="botao" />
                                    </center>
                            </div>
                        </td>
                    </tr>
                </table>


            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
