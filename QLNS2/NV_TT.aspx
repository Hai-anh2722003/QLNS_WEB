<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NV_TT.aspx.cs" Inherits="NV_TT" MasterPageFile="NV.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-xxl flex-grow-1 container-p-y">
        <!-- Sticky Actions -->
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header sticky-element bg-label-secondary d-flex justify-content-sm-between align-items-sm-center flex-column flex-sm-row">
                        <h5 class="card-title mb-sm-0 me-2">Thông tin cá nhân</h5>
                        <div class="action-btns">
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-8 mx-auto">
                                <!-- 1. Delivery Address -->
                                <div class="row g-3 pt-4">
                                    <div class="col-md-6">
                                        <label class="form-label" for="fullname">Mã nhân viên</label>
                                        <asp:TextBox ID="txtMaNhanVien" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="email">Họ tên</label>
                                        <div class="input-group input-group-merge">
                                            <asp:TextBox ID="txtHoTen" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="phone">Giới tính</label>
                                        <asp:TextBox ID="txtGioiTinh" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="alt-num">CCCD</label>
                                        <asp:TextBox ID="txtCMND" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="phone">Ngày sinh</label>
                                        <asp:TextBox ID="txtNS" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="alt-num">Email</label>
                                        <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="pincode">Địa chỉ</label>
                                        <asp:TextBox ID="txtDiaChi" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="landmark">Học vấn</label>
                                        <asp:TextBox ID="txtHocVan" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="city">Đảng viên</label>
                                        <asp:TextBox ID="txtDangVien" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="city">Ngày bắt đầu</label>
                                        <asp:TextBox ID="txtBatDau" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="pincode">Chức vụ</label>
                                        <asp:TextBox ID="txtCD" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="landmark">Phòng ban</label>
                                        <asp:TextBox ID="txtCongTac" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="city">Lương cơ bản</label>
                                        <asp:TextBox ID="txtLuong" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label" for="city">Loại hợp đồng</label>
                                        <asp:TextBox ID="txtHĐ" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /Sticky Actions -->
    </div>
    <!-- / Content -->
</asp:Content>


