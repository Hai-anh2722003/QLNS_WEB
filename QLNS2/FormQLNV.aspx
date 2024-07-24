<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormQLNV.aspx.cs" Inherits="FormQLNV" MasterPageFile="Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function navigateToThem() {
            // Example of client-side navigation using JavaScript
            window.location.href = 'FormThemNhanVien.aspx';
            return false; // Prevent postback
        }
</script>
    <div class="container-xxl flex-grow-1 container-p-y">
        <div class="col-12">
            <div class="card">
                <div class="card-header sticky-element bg-label-secondary d-flex justify-content-sm-between align-items-sm-center flex-column flex-sm-row">
                    <h5 class="card-title mb-sm-0 me-2">Quản lý nhân viên</h5>
                    <div class="action-btns">
                        <asp:LinkButton ID="btnMoi" class="btn btn-primary" runat="server"><i class="fa fa-magnifying-glass me-sm-2"></i> Tìm kiếm</asp:LinkButton>
                        <asp:LinkButton ID="btnExcel" class="btn btn-primary" runat="server" OnClick="btnExcel_Click"><i class="fa fa-file-export me-sm-2"></i> Excel</asp:LinkButton>
                        <asp:LinkButton ID="btnThem" class="btn btn-primary" runat="server" OnClientClick="return navigateToThem();"><i class="fa fa-plus me-sm-2"></i> Thêm</asp:LinkButton>
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
                            <asp:TextBox ID="txtMaNhanVien" Class="form-control typeahead tt-hint" runat="server" OnTextChanged="txtMaNhanVien_TextChanged"></asp:TextBox>
                        </div>
                        <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Tên nhân viên</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtTenNhanVien" Class="form-control typeahead tt-hint" runat="server" OnTextChanged="txtTenNhanVien_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row" style="overflow-x: auto; white-space: nowrap;">
                        <asp:GridView ID="DGVNhanVien" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" PageSize="10" OnPageIndexChanging="DGVNhanVien_PageIndexChanging" AutoGenerateSelectButton="True" OnSelectedIndexChanged="DGVNhanVien_SelectedIndexChanged" OnRowCommand="DGVNhanVien_RowCommand">
                            <Columns>
                                <asp:ButtonField Text="Xóa" ButtonType="Button" CommandName="DeleteUser" />
                                <asp:BoundField DataField="IdUser" HeaderText="IdUser" />
                                <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên" />
                                <asp:BoundField DataField="HoTen" HeaderText="Họ và tên" />
                                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" DataFormatString="{0:yyyy/MM/dd}" />
                                <asp:BoundField DataField="GioiTinh" HeaderText="Giới tính" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                                <asp:BoundField DataField="DangVien" HeaderText="Đảng viên" />
                                <asp:BoundField DataField="HocVan" HeaderText="Học vấn" />
                                <asp:BoundField DataField="CMND" HeaderText="CMND" />
                                <asp:BoundField DataField="TenChucDanh" HeaderText="Chức danh" />
                                <asp:BoundField DataField="LoaiHopDong" HeaderText="Loại hợp đồng" />
                                <asp:BoundField DataField="IdTienLuong" HeaderText="Mã tiền lương" />
                                <asp:BoundField DataField="TenCongTac" HeaderText="Công tác" />
                                <asp:BoundField DataField="NgayBatDau" HeaderText="Ngày bắt đầu" DataFormatString="{0:yyyy/MM/dd}" />
                                <asp:BoundField DataField="NgayKetThuc" HeaderText="Ngày kết thúc" DataFormatString="{0:yyyy/MM/dd}" />
                                <asp:BoundField DataField="DuongDan" HeaderText="Đường dẫn" />
                                <asp:BoundField DataField="IdHopDong" HeaderText="Mã hợp đồng" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                            <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px" />
                            <PagerTemplate>
                                <div class="btn-toolbar" role="toolbar">
                                    <div class="btn-group me-2" role="group">
                                        <asp:LinkButton ID="lnkPrev" runat="server" CommandName="Page" CommandArgument="Prev" CssClass="btn btn-primary">Previous</asp:LinkButton>
                                        <asp:LinkButton ID="lnkNext" runat="server" CommandName="Page" CommandArgument="Next" CssClass="btn btn-primary">Next</asp:LinkButton>
                                    </div>
                                    <div class="btn-group" role="group">
                                        <asp:Repeater ID="rptPager" runat="server">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPage" runat="server" CommandName="Page" CommandArgument='<%# Container.DataItem %>' CssClass='<%# Container.DataItem.ToString() == ((GridView)Container.Parent.Parent.Parent.Parent).PageIndex + 1.ToString() ? "btn btn-primary active" : "btn btn-primary" %>'><%# Container.DataItem %></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </PagerTemplate>
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
