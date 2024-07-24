<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormBangLuong.aspx.cs" Inherits="FormBangLuong" MasterPageFile="Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-xxl flex-grow-1 container-p-y">
        <div class="col-12">
            <div class="card mb-4">
                <h5 class="card-header">Bảng lương</h5>
                <div class="card-body">
                    <br />
                    <div class="row">
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Mã nhân viên</label>
                            <asp:TextBox ID="txtMaLuong" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Phụ cấp</label>
                            <asp:TextBox ID="txtPhuCap" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Hệ số</label>
                            <asp:TextBox ID="txtHeSo" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Lương công</label>
                            <asp:TextBox ID="txtLuongCong" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Bậc lương</label>
                            <asp:TextBox ID="txtBacLuong" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Ghi chú</label>
                            <asp:TextBox ID="txtGhiChu" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="row justify-content-end">
                            <div class="col-sm-8">
                                <asp:LinkButton ID="btnThem" class="btn btn-primary me-sm-3 me-1" runat="server" OnClick="btnThem_Click"><i class="fa fa-plus"></i> Thêm</asp:LinkButton>
                                <asp:LinkButton ID="btnSua" class="btn btn-primary me-sm-3 me-1" runat="server" OnClick="btnSua_Click"><i class="fa fa-pen-to-square"></i> Sửa</asp:LinkButton>
                                <asp:LinkButton ID="btnXoa" class="btn btn-primary me-sm-3 me-1" runat="server" OnClick="btnXoa_Click"><i class="fa fa-trash"></i> Xóa</asp:LinkButton>
                                <asp:LinkButton ID="btnEx" class="btn btn-primary me-sm-3 me-1" runat="server" OnClick="btnEx_Click"><i class="fa fa-file-export"></i> Excel</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <asp:GridView ID="GV_Bangluong" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GV_Bangluong_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Mã lương" />
                                <asp:BoundField DataField="BacLuong" HeaderText="Bậc lương" />
                                <asp:BoundField DataField="HeSo" HeaderText="Hệ số" />
                                <asp:BoundField DataField="PhuCap" HeaderText="Phụ cấp" />
                                <asp:BoundField DataField="LuongCong" HeaderText="Lương công" />
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
