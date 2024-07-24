<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NV_TongLuong.aspx.cs" Inherits="NV_TongLuong" MasterPageFile="NV.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-xxl flex-grow-1 container-p-y">
        <div class="row ">
            <div class="col">
                <h3>Bảng lương</h3>
                <div class="accordion" id="collapsibleSection">
                    <div class="card accordion-item pt-4">
                        <div id="collapseDeliveryAddress" class="accordion-collapse collapse show" aria-labelledby="headingDeliveryAddress" data-bs-parent="#collapsibleSection">
                            <div class="accordion-body">
                                <div class="row">
                                    <div class="col-xl-5 col-md-6 col-sm-12 mb-4">
                                    </div>
                                    <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                                        <label class="form-label" >Tháng</label>
                                    </div>
                                    <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                                        <asp:DropDownList ID="cbThang" Class="form-control typeahead tt-hint" runat="server" OnSelectedIndexChanged="cbThang_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row g-3">
                                    <div class="col-xl-6 col-md-6 col-sm-12 mb-4">
                                        <asp:GridView ID="GV_NgayCong" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên" />
                                                <asp:BoundField DataField="CongNgay" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày chấm công" />
                                                <asp:BoundField DataField="GioLamThem" HeaderText="Số giờ làm thêm" />
                                                <asp:BoundField DataField="NgayNghi" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày nghỉ" />
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                                            <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px" />
                                            <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                        </asp:GridView>
                                        <br />
                                    </div>
                                    <div class="col-xl-6 col-md-6 col-sm-12 mb-4">
                                        <asp:GridView ID="GV_Luong" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên" />
                                                <asp:BoundField DataField="TongLuong" HeaderText="Tổng lương" />
                                                <asp:BoundField DataField="Thang" HeaderText="Tháng" />
                                                <asp:BoundField DataField="Nam" HeaderText="Năm" />
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                                            <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px" />
                                            <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                        </asp:GridView>
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
