<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormHeThong.aspx.cs" Inherits="FormHeThong" MasterPageFile="Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-xxl flex-grow-1 container-p-y">
        <div class="col-12">
            <div class="card mb-4">
                <div class="card-header sticky-element bg-label-secondary d-flex justify-content-sm-between align-items-sm-center flex-column flex-sm-row">
                    <h5 class="card-title mb-sm-0 me-2">Quản lý quyền</h5>
                    <div class="action-btns">
                        <asp:LinkButton ID="btnSua" class="btn btn-primary" runat="server" OnClick="btnSua_Click"><i class="fa fa-edit me-sm-2"></i> Sửa </asp:LinkButton>
                        <asp:LinkButton ID="btnThem" class="btn btn-primary" runat="server" OnClick="btnThem_Click"><i class="fa fa-plus me-sm-2"></i> Thêm </asp:LinkButton>
                    </div>
                </div>
                <div class="card-body">
                    <br />
                    <div class="row">
                        <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                        </div>
                        <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Mã nhân viên</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtMaNhanVien" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Họ và tên</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtHoTen" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                        </div>
                        <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Mật khẩu</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtMk" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Xác minh mật khẩu</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtXacNhanMK" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                        </div>
                        <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Quyền</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:DropDownList ID="CbQuyen" Class="form-control typeahead tt-hint" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">IdUserRole</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtIdUserRole" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                        </div>
                        <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">IdUser</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                             <asp:TextBox ID="txtIdUser" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <br />
                        <asp:GridView ID="DGVHeThong" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" OnSelectedIndexChanged="GV_TraCuu_SelectedIndexChanged" OnRowCommand="DGVHeThong_RowCommand" OnRowDeleted="DGVHeThong_RowDeleted">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteTK" CommandArgument='<%# Container.DataItemIndex %>' CssClass="fas fa-trash-alt" ToolTip="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnUpdate" runat="server" CommandName="UpdateTK" CommandArgument='<%# Container.DataItemIndex %>' CssClass="fas fa-edit" ToolTip="Update"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdUserRole" HeaderText="IdUserRole" />
                                <asp:BoundField DataField="IdUser" HeaderText="Id User" />
                                <asp:BoundField DataField="Role" HeaderText="Quyền tài khoản" />
                                <asp:BoundField DataField="HoTen" HeaderText="Tên chủ tài khoản" />
                                <asp:BoundField DataField="MaNhanVien" HeaderText="Tài khoản" />
                                <asp:BoundField DataField="MatKhau" HeaderText="MatKhau" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                            <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px" />
                            <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#E0E0ED" Font-Bold="True" ForeColor="black" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>

                    </div>
    </div>
    </div>
        </div>
    </div>
</asp:Content>
