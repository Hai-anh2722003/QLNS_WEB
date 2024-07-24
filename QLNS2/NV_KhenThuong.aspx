<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NV_KhenThuong.aspx.cs" Inherits="NV_KhenThuong" MasterPageFile="NV.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-xxl flex-grow-1 container-p-y">
        <div class="row my-4">
            <div class="col">
                <h3>Thông tin khen thưởng</h3>
                <div class="accordion" id="collapsibleSection">
                    <div class="card accordion-item pt-4">
                        <div id="collapseDeliveryAddress" class="accordion-collapse collapse show" aria-labelledby="headingDeliveryAddress" data-bs-parent="#collapsibleSection">
                            <div class="accordion-body">
                                <div class="row g-3">
                                    <asp:GridView ID="GV_KhenThuong" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên" />
                                            <asp:BoundField DataField="Id" HeaderText="Mã khen thưởng" />
                                            <asp:BoundField DataField="KhenThuong" HeaderText="Loại khen thưởng" />
                                            <asp:BoundField DataField="Tien" HeaderText="Số tiền thưởng" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                                        <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px" />
                                        <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                    </asp:GridView><br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
