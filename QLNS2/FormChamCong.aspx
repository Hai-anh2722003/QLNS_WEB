<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeFile="FormChamCong.aspx.cs" Inherits="FormChamCong" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-xxl flex-grow-1 container-p-y">
    <div class="col-12">
        <div class="card">
            <h5 class ="card-header">Tính lương nhân viên</h5>
            <div class="card-body">
                <form class="form-repeater">
                    <div data-repeater-list="group-a">
                        <div data-repeater-item="">
                            <div class="row">
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Mã nhân viên</label>
  
                                    <asp:TextBox ID="manv" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0 d-flex align-items-center">
                                    <label class="form-label" for="form-repeater-1-1"></label>
                                    <asp:Button ID="dsnv" class="btn btn-primary" runat="server" Text="..." Width="52px" Height="39px" OnClick="dsnv_Click" />
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Khen Thưởng</label>
  
                                    <asp:TextBox ID="kt" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0 d-flex align-items-center">
                                    <asp:Button ID="dskt" class="btn btn-primary" runat="server" Text="..." Width="52px" Height="40px" OnClick="dskt_Click" />
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Số giờ thêm</label>
                                    <asp:TextBox ID="them" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Mã lương</label>
                                    <asp:TextBox ID="ml" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0 d-flex align-items-center">
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Kỉ luật</label>
                                    <asp:TextBox ID="kl" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0 d-flex align-items-center">
                                    <asp:Button ID="dskl" class="btn btn-primary" runat="server" Text="..." Width="52px" Height="40px" OnClick="dskl_Click" />
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Số ngày nghỉ</label>
                                    <asp:TextBox ID="nghi" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Hệ số lương</label>
                                    <asp:TextBox ID="hsl" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0 d-flex align-items-center">
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Tháng</label>
                                    <asp:DropDownList ID="thang"  Class="form-control" runat="server" Width="63px">
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
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0 d-flex align-items-center">
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Số ngày công</label>
                                    <asp:TextBox ID="cong" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Phụ cấp công việc</label>
                                    <asp:TextBox ID="pccv" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0 d-flex align-items-center">
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Năm</label>
                                    <asp:TextBox ID="nam" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0 d-flex align-items-center">
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <label class="form-label" for="form-repeater-1-1">Tổng lương</label>
                                    <asp:TextBox ID="tong" Class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0"> </div>
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0">
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <asp:Button ID="ht" class="btn btn-primary" runat="server" Text="Hiển thị"  Height="40px" OnClick="ht_Click" />
                                </div>
                                <div class ="mb-3 col-lg-12 col-xl-1 col-12 mb-0">
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                    <asp:Button ID="tinhluong" class="btn btn-primary" runat="server" Text="Tính" Height="40px" OnClick="tinhluong_Click" />
                                </div>
                            </div>
                            <br />
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div class="row">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="1139px" style="margin-right: 0px; margin-bottom: 0px">
                                    <Columns>
                                        <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên " SortExpression="MaNhanVien" />
                                        <asp:BoundField DataField="HoTen" HeaderText="Họ Tên" SortExpression="HoTen" />
                                        <asp:BoundField DataField="TongLuong" HeaderText="Tổng lương" SortExpression="TongLuong" />
                                        <asp:BoundField DataField="Thang" HeaderText="Tháng" SortExpression="Thang" />
                                        <asp:BoundField DataField="Nam" HeaderText="Năm" SortExpression="Nam" />
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                                     <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px"  />
                                     <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right"  />
                                     <SelectedRowStyle BackColor="#E0E0ED" Font-Bold="True" ForeColor="black" />
                                     <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                     <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                     <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                     <SortedDescendingHeaderStyle BackColor="#242121" />
                                </asp:GridView>
                            </div> 
                            <br />
                            <br />
                            <div class="row">
                                <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0"> </div>
                                <div class ="mb-3 col-lg-6 col-xl-2 col-12 mb-0">
                                    <asp:Button ID="themluong" class="btn btn-primary" runat="server" Text="Thêm" OnClick="themluong_Click" />
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-2 col-12 mb-0">
                                    <asp:Button ID="moi" class="btn btn-primary" runat="server" Text="Làm mới" OnClick="moi_Click" />
                                </div>
                                <div class ="mb-3 col-lg-6 col-xl-2 col-12 mb-0">
                                    <asp:Button ID="excel" class="btn btn-primary" runat="server" Text="Excel" OnClick="excel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>
<asp:Panel class="container-xxl flex-grow-1 container-p-y" ID="cc_dsnv" runat="server" Direction="LeftToRight" ScrollBars="Auto" >
    <div>
        <div class="col-12">
            <div class="card">
                <h5 class ="card-header">Bảng nhân viên</h5>
                <div class="card-body">
                    <div data-repeater-item=""><br />
                        <div class="row">
                            <div class ="mb-3 col-lg-6 col-xl-2 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Mã nhân viên</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:TextBox ID="manv1" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-1 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">CCCD</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:TextBox ID="cccd1" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:LinkButton ID="chonnv" runat="server" CssClass="btn btn-primary" OnClick="chonnv_Click">
                                    <i class="bx bx-check-circle"></i> Chọn nhân viên
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="mb-3 col-lg-6 col-xl-2 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Họ và tên</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:TextBox ID="hoten1" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-1 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Phòng</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:TextBox ID="phong1" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:LinkButton ID="huy" runat="server" CssClass="btn btn-danger">
                                    <i class="bx bx-x-circle"></i> Huỷ
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row" style="max-height: 300px; overflow-y: auto;">
                            <asp:GridView ID="dsnv1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" ScrollBars="Auto" Height="300px" Width="527px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="dsnv1_SelectedIndexChanged" CssClass="gridview">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên" SortExpression="MaNhanVien" />
                                    <asp:BoundField DataField="IdCongTac" HeaderText="Mã phòng " SortExpression="IdCongTac" />
                                    <asp:BoundField DataField="IdTienLuong" HeaderText="Mã lương" SortExpression="IdTienLuong" />
                                    <asp:BoundField DataField="HoTen" HeaderText="Họ và tên" SortExpression="HoTen" />
                                </Columns>
                               <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                             <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px"  />
                             <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right"  />
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
    </div>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="cc_dsnv" TargetControlID="dsnv"></ajaxToolkit:ModalPopupExtender>
</asp:Panel>
<asp:Panel class="container-xxl flex-grow-1 container-p-y" ID="cc_dskt" runat="server" Direction="LeftToRight" ScrollBars="Auto">
    <div>
        <div class="col-12">
            <div class="card">
                <h5 class ="card-header">Khen thưởng</h5>
                <div class="card-body">
                    <div data-repeater-item=""><br />
                        <div class="row">
                            <asp:GridView ID="dskt1" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="dskt1_SelectedIndexChanged" CssClass="gridview">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Mã khen thưởng" SortExpression="Id" />
                                    <asp:BoundField DataField="Tien" HeaderText="Số tiền thưởng" SortExpression="Tien" />
                                    <asp:BoundField DataField="KhenThuong" HeaderText="Lí do khen thưởng" SortExpression="KhenThuong" />
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                                 <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px"  />
                                 <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right"  />
                                 <SelectedRowStyle BackColor="#E0E0ED" Font-Bold="True" ForeColor="black" />
                                 <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                 <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                 <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                 <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </div><br />
                        <div class="row">
                            <div class ="mb-3 col-lg-6 col-xl-2 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Số tiền</label>
                            </div>
                             <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:TextBox ID="stkt" Class="form-control" runat="server" OnTextChanged="stkt_TextChanged" ></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-1 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Tiền sẵn có</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:TextBox ID="tsckt" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:LinkButton ID="ctkt" runat="server" CssClass="btn btn-primary" OnClick="ctkt_Click">
                                    <i class="bx bx-plus-circle"></i> Cộng thêm
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="mb-3 col-lg-6 col-xl-2 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Số lần</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0" >
                                <asp:TextBox ID="slkt" Class="form-control" runat="server" OnTextChanged="slkt_TextChanged"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-1 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Tổng</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                               <asp:TextBox ID="tkt" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:LinkButton ID="tbkt" runat="server" CssClass="btn btn-primary" OnClick="tbkt_Click">
                                    <i class="bx bx-minus-circle"></i> Trừ bớt
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server"  PopupControlID="cc_dskt" TargetControlID="dskt"></ajaxToolkit:ModalPopupExtender>
</asp:Panel>
<asp:Panel class="container-xxl flex-grow-1 container-p-y" ID="cc_dskl" runat="server" ScrollBars="Auto">
    <div>
        <div class="col-12">
            <div class="card">
                <h5 class ="card-header">Kỉ luật</h5>
                <div class="card-body">
                    <div data-repeater-item=""><br />
                        <div class="row">
                            <asp:GridView ID="dskl1" runat="server" AutoGenerateColumns="False" Width="444px" AutoGenerateSelectButton="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="dskl1_SelectedIndexChanged" CssClass="gridview">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Mã kỉ luật " SortExpression="Id" />
                                    <asp:BoundField DataField="Tien" HeaderText="Số tiền phạt" SortExpression="Tien" />
                                    <asp:BoundField DataField="KiLuat" HeaderText="Lí do kỉ luật" SortExpression="KiLuat" />
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                                 <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px"  />
                                 <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right"  />
                                 <SelectedRowStyle BackColor="#E0E0ED" Font-Bold="True" ForeColor="black" />
                                 <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                 <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                 <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                 <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </div><br />
                        <div class="row">
                            <div class ="mb-3 col-lg-6 col-xl-2 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Số tiền</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:TextBox ID="stkl" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-1 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Tiền sẵn có</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:TextBox ID="tsckl" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:LinkButton ID="ctkl" runat="server" CssClass="btn btn-primary" OnClick="ctkl_Click">
                                    <i class="bx bx-plus-circle"></i> Cộng thêm
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="mb-3 col-lg-6 col-xl-2 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Số lần</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:TextBox ID="slkl" Class="form-control" runat="server" OnTextChanged="slkl_TextChanged"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-1 col-12 mb-0">
                                <label class="form-label" for="form-repeater-1-1">Tổng</label>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                               <asp:TextBox ID="tkl" Class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class ="mb-3 col-lg-6 col-xl-3 col-12 mb-0">
                                <asp:LinkButton ID="tbkl" runat="server" CssClass="btn btn-primary" OnClick="tbkl_Click">
                                    <i class="bx bx-minus-circle"></i> Trừ bớt
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="cc_dskl" TargetControlID="dskl"></ajaxToolkit:ModalPopupExtender>
</asp:Panel>
 <script type="text/javascript">
     window.onload = function () {
         document.getElementById('<%= dskt.ClientID %>').addEventListener('click', function () {
             var kt = document.getElementById('<%= kt.ClientID %>').value;
             document.getElementById('<%= tsckt.ClientID %>').value = kt;
     });
         document.getElementById('<%= dskl.ClientID %>').addEventListener('click', function () {
             var kl = document.getElementById('<%= kl.ClientID %>').value;
             document.getElementById('<%= tsckl.ClientID %>').value = kl;
         });

     }
 </script>

</asp:Content>

