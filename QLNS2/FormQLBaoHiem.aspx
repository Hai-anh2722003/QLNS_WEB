<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormQLBaoHiem.aspx.cs" Inherits="FormQLBaoHiem" MasterPageFile="Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-xxl flex-grow-1 container-p-y">
        <div class="col-12">
            <div class="card mb-4">
                <h5 class="card-header">Bảo hiểm</h5>
                <div class="card-body">
                    <br />
                    <div class="row">
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Tiền bảo hiểm</label>
                            <asp:TextBox ID="txtTienBaoHiem" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Mã nhân viên</label>
                            <asp:DropDownList ID="cboMaNhanVien" runat="server" AutoPostBack="True" Class="form-control typeahead tt-hint" OnSelectedIndexChanged="cboMaNhanVien_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Tên nhân viên</label>
                            <asp:TextBox ID="txtTennhanvien" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Mã bảo hiểm</label>
                            <asp:TextBox ID="cboMaBH" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Nơi cấp</label>
                            <asp:TextBox ID="txtNoiCap" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Ngày cấp</label>
                            <asp:TextBox ID="DateNgayCap" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Ghi chú</label>
                            <asp:TextBox ID="txtGhiChu" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="row justify-content-end">
                            <div class="col-sm-8">
                                <asp:LinkButton  ID="btnThem" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Thêm" OnClick="btnThem_Click"><i class="fa fa-plus me-sm-2"></i> Thêm </asp:LinkButton>
                                <asp:LinkButton  ID="btnSua" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Sửa" OnClick="btnSua_Click"><i class="fa fa-edit me-sm-2"></i> Sửa </asp:LinkButton>
                                <asp:LinkButton  ID="btnXoa" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Xóa" OnClick="btnXoa_Click"><i class="fa fa-trash"></i> Xóa</asp:LinkButton>
                                <asp:LinkButton  ID="btnLM" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Làm mới" OnClick="btnLM_Click"><i class="fa fa-arrows-rotate"></i>Làm mới</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <asp:GridView ID="GV_BaoHiem" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GV_BaoHiem_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Mã bảo hiểm" />
                                <asp:BoundField DataField="TienBaoHiem" HeaderText="Tiền bảo hiểm" />
                                <asp:BoundField DataField="NgayCap" HeaderText="Hệ số" />
                                <asp:BoundField DataField="NoiCap" HeaderText="Phụ cấp" />
                                <asp:BoundField DataField="IdNhanVien" HeaderText="Lương công" />
                                <asp:BoundField DataField="GhiChu" HeaderText="Ghi chú" />
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
