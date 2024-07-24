<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormThemNhanVien.aspx.cs" Inherits="FormThemNhanVien" MasterPageFile="Site.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-xxl flex-grow-1 container-p-y">
        <div class="col-12">
            <div class="card">
                <div class="card-header sticky-element bg-label-secondary d-flex justify-content-sm-between align-items-sm-center flex-column flex-sm-row">
                    <h5 class="card-title mb-sm-0 me-2">Thêm thông tin nhân viên</h5>
                </div>
                <div class="card-body">
                    <br />

                    <div class="row">
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Mã nhân viên</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtMaNhanVien" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Họ và tên</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtHoTen" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">CCCD</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtCMND" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Email</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtEmail" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Địa chỉ</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtDiaChi" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Chức vụ</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:DropDownList ID="CbChucDanh" Class="form-control typeahead tt-hint" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CbChucDanh_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Mã lương</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:DropDownList ID="CbMaLuong" Class="form-control typeahead tt-hint" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Hợp đồng</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:DropDownList ID="CbLoaiHopDong" Class="form-control typeahead tt-hint" runat="server">
                                <asp:ListItem>Hợp đồng thử việc</asp:ListItem>
                                <asp:ListItem>Hợp đồng có thời hạn</asp:ListItem>
                                <asp:ListItem>Hợp đồng không thời hạn</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Phòng ban</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:DropDownList ID="CbCongTac" runat="server" Class="form-control typeahead tt-hint"></asp:DropDownList>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Đảng viên</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:DropDownList ID="CbDangVien" Class="form-control typeahead tt-hint" runat="server">
                                <asp:ListItem >Đã là đảng viên</asp:ListItem>
                                <asp:ListItem >Chưa là đảng viên</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Giới tính</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:DropDownList ID="CbGioiTinh" Class="form-control typeahead tt-hint" runat="server">
                                <asp:ListItem>Nam</asp:ListItem>
                                <asp:ListItem>Nữ</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Học vấn</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:DropDownList ID="CbHocVan" Class="form-control typeahead tt-hint" runat="server">
                                <asp:ListItem>Cao đẳng</asp:ListItem>
                                <asp:ListItem>Cử nhân</asp:ListItem>
                                <asp:ListItem>Thạc sĩ</asp:ListItem>
                                <asp:ListItem>Tiến sĩ</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Ngày sinh</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="calExtNgaySinh" runat="server" TargetControlID="txtNgaySinh" Format="yyyy-MM-dd"></asp:CalendarExtender>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Ngày bắt đầu</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtNgayBatDau" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="calExtNgayHetHan" runat="server" TargetControlID="txtNgayBatDau" Format="yyyy-MM-dd"></asp:CalendarExtender>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <label class="form-label" for="TypeaheadBasic">Ngày Kết Thúc</label>
                        </div>
                        <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                            <asp:TextBox ID="txtNgayKetThuc" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CalendarExtender ID="calExtNgayKetThuc" runat="server" TargetControlID="txtNgayKetThuc" Format="yyyy-MM-dd"></asp:CalendarExtender>
                        </div>
                        <div class="col-xl-6 col-md-6 col-sm-12 mb-4">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-6 col-md-6 col-sm-12 mb-4">
                            <asp:Button ID="btnUpload" runat="server" Text="Thêm" class="btn btn-primary" OnClick="btnUpload_Click" />
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                        </div>
                        <div class="col-xl-6 col-md-6 col-sm-12 mb-4">
                            <asp:Image ID="imgPreview" runat="server" class="col-xl-12" Visible="False" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
